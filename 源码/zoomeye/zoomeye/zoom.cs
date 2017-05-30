using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace zoomeye
{
    class zoom
    {
        public string access_token = "";

        public zoom()
        {
            
        }


        public bool Login(string Url, string postDataStr)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postDataStr.Length;
                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                writer.Write(postDataStr);
                writer.Flush();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string encoding = response.ContentEncoding;
                if (encoding == null || encoding.Length < 1)
                {
                    encoding = "UTF-8"; //默认编码  
                }
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                string retString = reader.ReadToEnd();
                access_token = retString;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public string Get(string getDataStr,string myheaderget,string myheaderset)
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(getDataStr);
                httpRequest.Timeout = 2000;
                httpRequest.Method = "GET";
                httpRequest.Headers.Add(myheaderget, myheaderset);
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8"));
                string result = sr.ReadToEnd();
                result = result.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                int status = (int)httpResponse.StatusCode;
                sr.Close();

                return result;
            }
            catch(Exception e)
            {
                return "";
            }
        }


    }
    
}
