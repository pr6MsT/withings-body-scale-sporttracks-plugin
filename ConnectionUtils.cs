// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Net;

using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace WithingsBodyScale
{
    class ConnectionUtils
    {
        public static HttpWebRequest CreateHttpWebRequest(string url, int timeoutRequestSeconds)
        {
            IInternetSettings settings = Plugin.Instance.Application.SystemPreferences.InternetSettings;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = timeoutRequestSeconds * 1000;
            if (System.Environment.OSVersion.Platform != System.PlatformID.Unix)
            {
                request.Credentials = CredentialCache.DefaultCredentials;
            }
            if (settings.UseProxy)
            {
                WebProxy proxy = new WebProxy(settings.ProxyHost, settings.ProxyPort);
                if (settings.ProxyUsername.Length > 0 && settings.ProxyPassword.Length > 0)
                {
                    proxy.Credentials = new NetworkCredential(settings.ProxyUsername, settings.ProxyPassword);
                }
                request.Proxy = proxy;
            }
            else
            {
                request.Proxy = HttpWebRequest.DefaultWebProxy;
            }
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322) ";
            return request;
        }
    }
}
