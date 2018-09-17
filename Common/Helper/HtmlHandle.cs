using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Common.Helper
{
    public class HtmlHandle
    {
        #region //获取html页面
        /// <summary>
        /// 获取HTML所有的源代码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string HtmlCode(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return "";
            }
            try
            {
                //创建一个请求
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
                webReq.KeepAlive = false;
                webReq.Method = "GET";
                webReq.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:19.0) Gecko/20100101 Firefox/19.0";
                webReq.ServicePoint.Expect100Continue = false;
                webReq.Timeout = 5000;
                webReq.AllowAutoRedirect = true;//是否允许302
                ServicePointManager.DefaultConnectionLimit = 20;
                //获取响应
                HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse();
                string content = string.Empty;
                using (System.IO.Stream stream = webRes.GetResponseStream())
                {
                    using (System.IO.StreamReader reader =
                        new StreamReader(stream, System.Text.Encoding.GetEncoding("utf-8")))
                    {
                        content = reader.ReadToEnd();
                    }
                }
                webReq.Abort();
                return content;
            }
            catch (Exception)
            {
                return "";
            }

        }
        #endregion

    }
}
