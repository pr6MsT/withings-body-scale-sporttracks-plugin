using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Xml;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.Measurement;
using ZoneFiveSoftware.Common.Visuals;

namespace WithingsBodyScale
{
    class Synchronizer
    {
        public static void FetchDataFromServer(ILogbook logbook)
        {
            // Running in the UI thread - launch the background thread.
            Synchronizer synchronizer = new Synchronizer(logbook);
            ThreadPool.QueueUserWorkItem(SynchronizerBackgroundCallback, synchronizer);
        }

        private static void SynchronizerBackgroundCallback(object stateObj)
        {
            // Running in a background thread, wrapper to call Synchronizer.Run()
            Synchronizer synchronizer = (Synchronizer)stateObj;
            synchronizer.Run();
        }

        public void Run()
        {
            // Running in a background thread, perform the web query which may take awhile.
            LogbookSettings settings = new LogbookSettings();
            settings.Load(logbook);

            if (settings.UserId.Length > 0 && settings.PublicKey.Length > 0)
            {
                IList<WithingsWebServiceProxy.MeasurementInfo> measurements = null;
                try
                {
                    measurements = WithingsWebServiceProxy.GetMeasurementsSinceLastUpdate(culture, settings.UserId, settings.PublicKey, settings.LastUpdate);
                }
                catch (Exception ex)
                {
                    measurements = null;
                    AddLogEntry(settings, "Could not read user measurements. " + ex.Message);
                }

                // Jump back to the UI thread to process the web response since it may cause data change events and UI updates.
                // TODO: Ugly way to get back on the UI thread via the ActiveView. Possibly a better solution in 3.0?
                IView activeView = Plugin.Instance.Application.ActiveView;
                while (activeView == null)
                {
                    Thread.Sleep(2000);
                    activeView = Plugin.Instance.Application.ActiveView;
                }
                activeView.CreatePageControl().BeginInvoke(new ProcessResponseCallback(ProcessResponse), new object[] { logbook, settings, measurements });
            }
        }

        delegate void ProcessResponseCallback(ILogbook logbook, LogbookSettings settings, IList<WithingsWebServiceProxy.MeasurementInfo> measurements);
        private void ProcessResponse(ILogbook logbook, LogbookSettings settings, IList<WithingsWebServiceProxy.MeasurementInfo> measurements)
        {
            // Running in the UI thread.
            if (measurements != null)
            {
                MeasurementImporter.ImportMeasurements(logbook, settings, measurements);
                settings.LastUpdate = WithingsWebServiceProxy.GetNowEpoch();
                AddLogEntry(settings, "");
            }
            settings.Save(logbook);
            ExtendSettingsPages.RefreshSettings();
        }


        private void AddLogEntry(LogbookSettings settings, string errortext)
        {
            settings.LastLogEntryDate = DateTime.Today;
            if (errortext.Length == 0)
            {
                settings.LastLogEntry = CommonResources.Text.ActionOk;
            }
            else
            {
                settings.LastLogEntry = errortext;
            }
        }

        private Synchronizer(ILogbook logbook)
        {
            this.logbook = logbook;
            culture = Thread.CurrentThread.CurrentUICulture.ToString();
        }

        private ILogbook logbook;
        private string culture;

        private static string URL_GetMeasurements = "http://localhost/api/withings/getmeasurements.php?locale={0}&userid={1}&publickey={2}&lastupdate={3}";
    }
}
