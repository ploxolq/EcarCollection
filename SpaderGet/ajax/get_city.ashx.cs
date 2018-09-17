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
    /// get_city 的摘要说明
    /// </summary>
    public class get_city : IHttpHandler
    {

        private City_BLL BLL = new City_BLL();
        public void ProcessRequest(HttpContext context)
        {
            StringBuilder strClass = new StringBuilder();
            string pro_code = context.Request["getpro"];
            try
            {
                DataTable dt = BLL.Get_City(pro_code);
                if (dt != null)
                {
                    strClass.Append("[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strClass.Append("{");
                        strClass.Append("\"id\":\"" + dt.Rows[i]["C_Code"].ToString() + "\",");
                        strClass.Append("\"name\":\"" + dt.Rows[i]["C_Name"].ToString() + "\"");
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}