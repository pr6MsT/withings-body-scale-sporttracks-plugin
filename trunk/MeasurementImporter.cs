// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Collections.Generic;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.Measurement;

namespace WithingsBodyScale
{
    class MeasurementImporter
    {
        public static void ImportMeasurements(ILogbook logbook, LogbookSettings settings, IList<WithingsWebServiceProxy.MeasurementInfo> measurements)
        {
            List<WithingsWebServiceProxy.MeasurementInfo> orderedMeasurements = new List<WithingsWebServiceProxy.MeasurementInfo>(measurements);
            if (settings.ImportMultipleEntries == LogbookSettings.MultipleEntriesUpdateStyles.Latest)
            {
                orderedMeasurements.Sort(new OldestToNewestComparer());
            }
            else
            {
                orderedMeasurements.Sort(new NewestToOldestComparer());
            }

            foreach (WithingsWebServiceProxy.MeasurementInfo measurement in orderedMeasurements)
            {
                // Skip ambiguous readings unless setting is selected.
                if (!settings.ImportAmbiguousEntries)
                {
                    if (measurement.Source == WithingsWebServiceProxy.MeasurementInfo.SourceType.AmbiguousScaleReading) continue;
                }

                // Always import height if settings is selected (even if manual).
                if (settings.ImportHeightEntries && !float.IsNaN(measurement.HeightMeters))
                {
                    logbook.Athlete.HeightCentimeters = measurement.HeightMeters * 100;
                }

                // Skip manual entries unless settings is selected.
                if (!settings.ImportManualEntries)
                {
                    if (measurement.Source == WithingsWebServiceProxy.MeasurementInfo.SourceType.ManualEntry ||
                    measurement.Source == WithingsWebServiceProxy.MeasurementInfo.SourceType.ProfileCreation) continue;
                }

                IAthleteInfoEntry athleteInfoEntry = logbook.Athlete.InfoEntries.EntryForDate(measurement.Time.Date);
                try
                {
                    // Import weight
                    if (!float.IsNaN(measurement.WeightKilograms) && measurement.WeightKilograms > 0)
                    {
                        //System.Diagnostics.Trace.WriteLine("Weight entry on " + measurement.Time.ToLocalTime().ToShortDateString() + " " + measurement.Time.ToLocalTime().ToShortTimeString() + "=" + measurement.WeightKilograms);
                        float actualKilograms = measurement.WeightKilograms;
                        float roundedKilograms = actualKilograms;
                        switch (Plugin.Instance.Application.SystemPreferences.WeightUnits)
                        {
                            case Weight.Units.Kilogram:
                                roundedKilograms = (float)Math.Round(actualKilograms + 0.005, 1);
                                break;
                            case Weight.Units.Pound:
                            case Weight.Units.Stone:
                                double pounds = Weight.Convert(actualKilograms + 0.005, Weight.Units.Kilogram, Weight.Units.Pound);
                                pounds = Math.Round(pounds, 1);
                                roundedKilograms = (float)Weight.Convert(pounds, Weight.Units.Pound, Weight.Units.Kilogram);
                                break;
                        }

                        bool update = false;
                        if (float.IsNaN(athleteInfoEntry.WeightKilograms))
                        {
                            update = true;
                        }
                        else
                        {
                            switch (settings.ImportMultipleEntries)
                            {
                                case LogbookSettings.MultipleEntriesUpdateStyles.Earliest:
                                case LogbookSettings.MultipleEntriesUpdateStyles.Latest:
                                    update = true;
                                    break;
                                case LogbookSettings.MultipleEntriesUpdateStyles.Lowest:
                                    if (roundedKilograms < athleteInfoEntry.WeightKilograms) update = true;
                                    break;
                                case LogbookSettings.MultipleEntriesUpdateStyles.Highest:
                                    if (roundedKilograms > athleteInfoEntry.WeightKilograms) update = true;
                                    break;
                            }
                        }
                         
                        if (update)
                        {
                            //System.Diagnostics.Trace.WriteLine("Weight updated to " + roundedKilograms + " kilograms. actual=" + actualKilograms);
                            athleteInfoEntry.WeightKilograms = roundedKilograms;

                            if (settings.UpdateBMI)
                            {
                                if (!float.IsNaN(logbook.Athlete.HeightCentimeters) && logbook.Athlete.HeightCentimeters > 0)
                                {
                                    float meters = logbook.Athlete.HeightCentimeters / 100;
                                    athleteInfoEntry.BMI = (float)Math.Round(actualKilograms / (meters * meters), 1);
                                    //System.Diagnostics.Trace.WriteLine("BMI updated to " + athleteInfoEntry.BMI);
                                }
                            }
                        }
                    }

                    // Import percent fat
                    if (!float.IsNaN(measurement.PercentFat) && measurement.PercentFat > 0 && measurement.PercentFat < 100)
                    {
                        //System.Diagnostics.Trace.WriteLine("Percent Fat entry on " + measurement.Time.ToLocalTime().ToShortDateString() + " " + measurement.Time.ToLocalTime().ToShortTimeString() + "=" + measurement.PercentFat);
                        float percent = measurement.PercentFat;
                        bool update = false;
                        if (float.IsNaN(athleteInfoEntry.BodyFatPercentage))
                        {
                            update = true;
                        }
                        else
                        {
                            switch (settings.ImportMultipleEntries)
                            {
                                case LogbookSettings.MultipleEntriesUpdateStyles.Earliest:
                                case LogbookSettings.MultipleEntriesUpdateStyles.Latest:
                                    update = true;
                                    break;
                                case LogbookSettings.MultipleEntriesUpdateStyles.Lowest:
                                    if (percent < athleteInfoEntry.BodyFatPercentage) update = true;
                                    break;
                                case LogbookSettings.MultipleEntriesUpdateStyles.Highest:
                                    if (percent > athleteInfoEntry.BodyFatPercentage) update = true;
                                    break;
                            }
                        }
                        if (update)
                        {
                            percent = (float)Math.Round(percent + 0.005, 1);
                            //System.Diagnostics.Trace.WriteLine("Body fat % updated to " + percent + "%");
                            athleteInfoEntry.BodyFatPercentage = percent;
                        }
                    }
                }
                catch { }
            }
        }

        private class OldestToNewestComparer : IComparer<WithingsWebServiceProxy.MeasurementInfo>
        {
            public int Compare(WithingsWebServiceProxy.MeasurementInfo x, WithingsWebServiceProxy.MeasurementInfo y)
            {
                return x.Time.CompareTo(y.Time);
            }
        }

        private class NewestToOldestComparer : IComparer<WithingsWebServiceProxy.MeasurementInfo>
        {
            public int Compare(WithingsWebServiceProxy.MeasurementInfo x, WithingsWebServiceProxy.MeasurementInfo y)
            {
                return y.Time.CompareTo(x.Time);
            }
        }
    }
}
