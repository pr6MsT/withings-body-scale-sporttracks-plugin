// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml;

namespace WithingsBodyScale
{
    public class WithingsWebServiceProxy
    {
        private static string URL_Host = "http://zonefivesoftware.com/";
        private static string URL_GetUsers = URL_Host + "api/withings/getusers.php?locale={0}&myversion={1}&user={2}&pass={3}";
        private static string URL_GetAllMeasurements = URL_Host + "api/withings/getmeasurements.php?locale={0}&userid={1}&publickey={2}";
        private static string URL_GetMeasurementsSinceLastUpdate = URL_Host + "api/withings/getmeasurements.php?locale={0}&userid={1}&publickey={2}&lastupdate={3}";

        public static long GetNowEpoch()
        {
            DateTime date = DateTime.Now.AddHours(-12);
            return (long)((date.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        }

        public class UserInfo
        {
            public string FirstName = "";
            public string LastName = "";
            public string Nickname = "";
            public string Id = "";
            public string PublicKey = "";
            public bool Male = true;
            public DateTime Birthday = DateTime.MinValue;

            public override string ToString()
            {
                return FirstName + " " + LastName + " [ " + Nickname + " ]";
            }
        }

        public static IList<UserInfo> GetUserList(string culture, string username, string password)
        {
            string version = Assembly.GetEntryAssembly().GetName().Version.ToString(3);
            username = System.Web.HttpUtility.UrlEncode(username, System.Text.Encoding.UTF8);
            password = System.Web.HttpUtility.UrlEncode(password, System.Text.Encoding.UTF8);
            string url = string.Format(URL_GetUsers, culture, version, username, password);
            XmlDocument xmlDoc = XmlWebRequest(url);

            XmlElement root = xmlDoc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("ns", Plugin.ApplicationNamespace);

            XmlElement errorNode = (XmlElement)root.SelectSingleNode("ns:error", nsmgr);
            if (errorNode != null)
            {
                throw new Exception(errorNode.InnerText);
            }
            IList<UserInfo> users = new List<UserInfo>();
            XmlNodeList nodes = root.SelectNodes("ns:user", nsmgr);
            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    UserInfo info = new UserInfo();
                    info.Id = XmlNodeInnerText(node.SelectSingleNode("ns:id", nsmgr));
                    info.FirstName = XmlNodeInnerText(node.SelectSingleNode("ns:firstname", nsmgr));
                    info.LastName = XmlNodeInnerText(node.SelectSingleNode("ns:lastname", nsmgr));
                    info.Nickname = XmlNodeInnerText(node.SelectSingleNode("ns:shortname", nsmgr));
                    info.Male = XmlNodeInnerText(node.SelectSingleNode("ns:gender", nsmgr)) != "female";
                    XmlNode bdayNode = node.SelectSingleNode("ns:birthdate", nsmgr);
                    if (bdayNode != null) info.Birthday = XmlConvert.ToDateTime(bdayNode.InnerText, XmlDateTimeSerializationMode.Utc);
                    info.PublicKey = XmlNodeInnerText(node.SelectSingleNode("ns:publickey", nsmgr));
                    users.Add(info);
                }
            }
            return users;
        }

        public class MeasurementInfo
        {
            public MeasurementInfo(DateTime time)
            {
                this.Time = time;
            }

            public enum CategoryType
            {
                Measure,
                Target
            }

            public enum SourceType
            {
                ScaleReading,
                AmbiguousScaleReading,
                ManualEntry,
                ProfileCreation
            }

            public static SourceType Parse(string sourceValue)
            {
                if (sourceValue == "scale-reading") return SourceType.ScaleReading;
                if (sourceValue == "ambiguous-scale-reading") return SourceType.AmbiguousScaleReading;
                if (sourceValue == "profile-creation") return SourceType.ProfileCreation;
                return SourceType.ManualEntry;
            }

            public DateTime Time;
            public SourceType Source = SourceType.ManualEntry;
            public float WeightKilograms = float.NaN;
            public float HeightMeters = float.NaN;
            public float PercentFat = float.NaN;
        }

        public static IList<MeasurementInfo> GetAllMeasurements(string culture, string userId, string publicKey)
        {
            string url = string.Format(URL_GetAllMeasurements, culture, userId, publicKey);
            return GetMeasurements(url);
        }

        public static IList<MeasurementInfo> GetMeasurementsSinceLastUpdate(string culture, string userId, string publicKey, long lastUpdate)
        {
            string url = string.Format(URL_GetMeasurementsSinceLastUpdate, culture, userId, publicKey, lastUpdate.ToString());
            return GetMeasurements(url);
        }

        private static IList<MeasurementInfo> GetMeasurements(string url)
        {
            XmlDocument xmlDoc = XmlWebRequest(url);

            XmlElement root = xmlDoc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("ns", Plugin.ApplicationNamespace);

            XmlElement errorNode = (XmlElement)root.SelectSingleNode("ns:error", nsmgr);
            if (errorNode != null)
            {
                throw new Exception(errorNode.InnerText);
            }
            IList<MeasurementInfo> measurements = new List<MeasurementInfo>();
            XmlNodeList nodes = root.SelectNodes("ns:measure", nsmgr);
            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    DateTime entryTime = DateTime.MinValue;
                    XmlNode dateNode = node.SelectSingleNode("ns:date", nsmgr);
                    if (dateNode != null)
                    {
                        try
                        {
                            entryTime = XmlConvert.ToDateTime(dateNode.InnerText, XmlDateTimeSerializationMode.Utc);
                        }
                        catch
                        {
                        }
                    }
                    if (entryTime == DateTime.MinValue) continue;
                    MeasurementInfo info = new MeasurementInfo(entryTime);
                    info.Source = MeasurementInfo.Parse(XmlNodeInnerText(node.SelectSingleNode("ns:source", nsmgr)));

                    info.WeightKilograms = XmlNodeInnerTextFloatVal(node.SelectSingleNode("ns:weight", nsmgr));
                    info.HeightMeters = XmlNodeInnerTextFloatVal(node.SelectSingleNode("ns:height", nsmgr));
                    info.PercentFat = XmlNodeInnerTextFloatVal(node.SelectSingleNode("ns:percent-fat", nsmgr));
                    measurements.Add(info);
                }
            }
            return measurements;
        }

        private static XmlDocument XmlWebRequest(string url)
        {
            Stream source = null;
            try
            {
                WebRequest request = ConnectionUtils.CreateHttpWebRequest(url, 30);
                source = request.GetResponse().GetResponseStream();
                MemoryStream ms = new MemoryStream();
                byte[] data = new byte[256];
                int c = source.Read(data, 0, data.Length);
                while (c > 0)
                {
                    ms.Write(data, 0, c);
                    c = source.Read(data, 0, data.Length);
                }
                source.Close();
                ms.Position = 0;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ms);
                return xmlDoc;
            }
            finally
            {
                if (source != null) source.Close();
            }
        }

        private static string XmlNodeInnerText(XmlNode node)
        {
            return node != null ? node.InnerText : "";
        }

        private static float XmlNodeInnerTextFloatVal(XmlNode node)
        {
            if (node == null) return float.NaN;
            try
            {
                return (float)XmlConvert.ToDouble(node.InnerText);
            }
            catch {}
            return float.NaN;
        }
    }
}
