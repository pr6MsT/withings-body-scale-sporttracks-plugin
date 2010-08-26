// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.IO;
using System.Text;
using System.Xml;

using ZoneFiveSoftware.Common.Data.Fitness;

namespace WithingsBodyScale
{
    public class LogbookSettings
    {
        public LogbookSettings()
        {
        }

        public enum MultipleEntriesUpdateStyles
        {
            Lowest,
            Highest,
            Latest,
            Earliest
        }

        private class xmlTags
        {
            public const string rootElement = "settings";
            public const string email = "email";
            public const string username = "username";
            public const string userid = "userid";
            public const string publicKey = "publicKey";
            public const string multiple = "multiple";
            public const string bmi = "bmi";
            public const string manual = "manual";
            public const string ambiguous = "ambiguous";
            public const string height = "height";
            public const string lastupdate = "lastupdate";
            public const string logDate = "logDate";
            public const string log = "log";
        }

        public void Load(ILogbook logbook)
        {
            try
            {
                byte[] data = logbook.GetExtensionData(Plugin.Instance.Id);
                if (data != null && data.Length > 0)
                {
                    string attr;
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(Encoding.UTF8.GetString(data));

                    XmlElement nodeRoot = xmlDoc.DocumentElement;

                    email = nodeRoot.GetAttribute(xmlTags.email);
                    username = nodeRoot.GetAttribute(xmlTags.username);
                    userid = nodeRoot.GetAttribute(xmlTags.userid);
                    publicKey = nodeRoot.GetAttribute(xmlTags.publicKey);

                    attr = nodeRoot.GetAttribute(xmlTags.multiple);
                    if (attr.Length > 0)
                    {
                        try
                        {
                            importMultipleEntries = (MultipleEntriesUpdateStyles)Enum.Parse(typeof(MultipleEntriesUpdateStyles), attr);
                        }
                        catch { }
                    }
                    updateBMI = XmlConvert.ToBoolean(nodeRoot.GetAttribute(xmlTags.bmi));
                    importManualEntries = XmlConvert.ToBoolean(nodeRoot.GetAttribute(xmlTags.manual));
                    importAmbiguousEntries = XmlConvert.ToBoolean(nodeRoot.GetAttribute(xmlTags.ambiguous));
                    importHeightEntries = XmlConvert.ToBoolean(nodeRoot.GetAttribute(xmlTags.height));

                    lastUpdate = XmlConvert.ToInt64(nodeRoot.GetAttribute(xmlTags.lastupdate));

                    attr = nodeRoot.GetAttribute(xmlTags.logDate);
                    if (attr.Length > 0) lastLogEntryDate = XmlConvert.ToDateTime(attr, XmlDateTimeSerializationMode.Utc);
                    lastLogEntry = nodeRoot.GetAttribute(xmlTags.log);
                }
            }
            catch { }
        }

        public void Save(ILogbook logbook)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);

                XmlElement nodeRoot = xmlDoc.CreateElement(xmlTags.rootElement);

                if (email.Length > 0) nodeRoot.SetAttribute(xmlTags.email, email);
                if (username.Length > 0) nodeRoot.SetAttribute(xmlTags.username, username);
                if (userid.Length > 0) nodeRoot.SetAttribute(xmlTags.userid, userid);
                if (publicKey.Length > 0) nodeRoot.SetAttribute(xmlTags.publicKey, publicKey);

                nodeRoot.SetAttribute(xmlTags.multiple, importMultipleEntries.ToString());
                nodeRoot.SetAttribute(xmlTags.bmi, XmlConvert.ToString(updateBMI));
                nodeRoot.SetAttribute(xmlTags.manual, XmlConvert.ToString(importManualEntries));
                nodeRoot.SetAttribute(xmlTags.ambiguous, XmlConvert.ToString(importAmbiguousEntries));
                nodeRoot.SetAttribute(xmlTags.height, XmlConvert.ToString(importHeightEntries));

                nodeRoot.SetAttribute(xmlTags.lastupdate, XmlConvert.ToString(lastUpdate));

                if (lastLogEntryDate != DateTime.MinValue) nodeRoot.SetAttribute(xmlTags.logDate, XmlConvert.ToString(lastLogEntryDate, XmlDateTimeSerializationMode.Utc));
                if (lastLogEntry.Length != 0) nodeRoot.SetAttribute(xmlTags.log, lastLogEntry);

                xmlDoc.AppendChild(nodeRoot);

                byte[] data = Encoding.UTF8.GetBytes(xmlDoc.OuterXml);
                logbook.SetExtensionData(Plugin.Instance.Id, data);
                // TODO: Hack to trigger a modified flag on logbook, fix this in core code - if extension data/text changes, flag modified
                logbook.Athlete.Name = logbook.Athlete.Name;
            }
            catch { }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public string UserId
        {
            get { return userid; }
            set { userid = value; }
        }

        public string PublicKey
        {
            get { return publicKey; }
            set { publicKey = value; }
        }

        public MultipleEntriesUpdateStyles ImportMultipleEntries
        {
            get { return importMultipleEntries; }
            set { importMultipleEntries = value; }
        }

        public bool UpdateBMI
        {
            get { return updateBMI; }
            set { updateBMI = value; }
        }

        public bool ImportManualEntries
        {
            get { return importManualEntries; }
            set { importManualEntries = value; }
        }

        public bool ImportAmbiguousEntries
        {
            get { return importAmbiguousEntries; }
            set { importAmbiguousEntries = value; }
        }

        public bool ImportHeightEntries
        {
            get { return importHeightEntries; }
            set { importHeightEntries = value; }
        }

        public long LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }

        public DateTime LastLogEntryDate
        {
            get { return lastLogEntryDate; }
            set { lastLogEntryDate = value; }
        }

        public string LastLogEntry
        {
            get { return lastLogEntry; }
            set { lastLogEntry = value; }
        }

        private string email = "";
        private string username = "";
        private string userid = "";
        private string publicKey = "";
        private MultipleEntriesUpdateStyles importMultipleEntries = MultipleEntriesUpdateStyles.Earliest;
        private bool updateBMI = true;
        private bool importManualEntries = false;
        private bool importAmbiguousEntries = false;
        private bool importHeightEntries = false;
        private long lastUpdate = 0;
        private DateTime lastLogEntryDate = DateTime.MinValue;
        private string lastLogEntry = "";
    }
}
