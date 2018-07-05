using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Koombu.Utilities
{
    public class WWWFetcher
    {
        public static string Get(string uri, Dictionary<string, string> headers)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(uri);

            foreach(KeyValuePair<string, string> header in headers)
            {
                req.Headers.Add(header.Key, header.Value);
            }

            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public static string Post(string uri, string Parameters, Dictionary<string, string> headers)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(uri);

            foreach (KeyValuePair<string, string> header in headers)
            {
                req.Headers.Add(header.Key, header.Value);
            }

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