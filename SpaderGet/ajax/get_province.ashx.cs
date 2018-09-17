using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using Common.Bll;

namespace SpaderGet.ajax
{
    /// <summary>
    /// get_province 的摘要说明
    /// </summary>
    public class get_province : IHttpHandler
    {

        private City_BLL BLL = new City_BLL();

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder strClass = new StringBuilder();
            try
            {
                DataTable dt = BLL.Get_Province();
                if (dt != null)
                {
                    strClass.Append("[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strClass.Append("{");
                        strClass.Append("\"id\":\"" + dt.Rows[i]["P_Code"].ToString() + "\",");
                        strClass.Append("\"name\":\"" + dt.Rows[i]["P_Name"].ToString() + "\"");
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