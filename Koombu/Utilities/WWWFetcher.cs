using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Koombu.Utilities
{
    public class WWWFetcher
    {
        public static void Get(string url, string method)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            request.Method = method;

            request.Headers.Add("userMail", "215339@supinfo.com");
            request.Headers.Add("userPass", "password");

            //var result = request.GetResponse();

            using (var web = new WebClient())
            {
                web.Headers.Add("userMail", "215339@supinfo.com");
                web.Headers.Add("userPass", "password");
                var result = web.DownloadString(url);
            }

                return;
        }

        public static string HttpGet(string URI)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);

            req.Headers.Add("userMail", "215339@supinfo.com");
            req.Headers.Add("userPass", "password");

            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public static string HttpPost(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}