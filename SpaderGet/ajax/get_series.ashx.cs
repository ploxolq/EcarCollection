using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Bll;
using System.Text;
using System.Data;

namespace SpaderGet.ajax
{
    /// <summary>
    /// get_series 的摘要说明
    /// </summary>
    public class get_series : IHttpHandler
    {

        private Factory_Letter_BLL BLL = new Factory_Letter_BLL();
        public void ProcessRequest(HttpContext context)
        {
            StringBuilder strClass = new StringBuilder();
            string bid = context.Request["bid"];
            try
            {
                DataTable dt = BLL.Get_Factory(bid);
                if (dt != null)
                {
                    strClass.Append("[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strClass.Append("{");
                        strClass.Append("\"id\":\"" + dt.Rows[i]["F_ID"].ToString() + "\",");
                        strClass.Append("\"name\":\"" + dt.Rows[i]["F_Name"].ToString() + "\",");
                        strClass.Append("\"data\":" + Get_Series(dt.Rows[i]["F_ID"].ToString()) + "");
                        if (i != dt.Rows.Count - 1)
                        {
                            strClass.Append("},");
                        }
                    }
                    strClass.Append("}");
                    strClass.Append("]");
                }
            }
            catch { }
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Write(strClass.ToString());
            context.Response.End();
        }

        public string Get_Series(string F_ID)
        {
            StringBuilder strClass = new StringBuilder();
            DataTable dt = new V_Series_BLL().Get_Factory_Series(F_ID);
            if (dt != null)
            {
                strClass.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strClass.Append("{");
                    strClass.Append("\"id\":\"" + dt.Rows[i]["S_ID"].ToString() + "\",");
                    strClass.Append("\"name\":\"" + dt.Rows[i]["S_Name"].ToString() + "\"");
                    if (i != dt.Rows.Count - 1)
                    {
                        strClass.Append("},");
                    }
                }
                strClass.Append("}");
                strClass.Append("]");
            }
            return strClass.ToString();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}