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
    /// get_car 的摘要说明
    /// </summary>
    public class get_car : IHttpHandler
    {

        private V_Car_BLL BLL = new V_Car_BLL();
        public void ProcessRequest(HttpContext context)
        {
            StringBuilder strClass = new StringBuilder();
            string sid = context.Request["sid"];
            try
            {
                DataTable dt = BLL.Get_Sell_Year(sid);
                if (dt != null)
                {
                    strClass.Append("[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strClass.Append("{");
                        strClass.Append("\"id\":\"" + dt.Rows[i]["S_ID"].ToString() + "\",");
                        strClass.Append("\"name\":\"" + dt.Rows[i]["Y_Name"].ToString() + "\",");
                        strClass.Append("\"data\":" + Get_Car(dt.Rows[i]["S_ID"].ToString(), dt.Rows[i]["Y_ID"].ToString()) + "");
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
        public string Get_Car(string S_ID, string Y_ID)
        {
            StringBuilder strClass = new StringBuilder();
            DataTable dt = BLL.Get_Sell_Car(S_ID, Y_ID);
            if (dt != null)
            {
                strClass.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strClass.Append("{");
                    strClass.Append("\"id\":\"" + dt.Rows[i]["Car_ID"].ToString() + "\",");
                    strClass.Append("\"name\":\"" + dt.Rows[i]["Y_Name"].ToString() + " 款 " + dt.Rows[i]["Car_Name"].ToString() + "\"");
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