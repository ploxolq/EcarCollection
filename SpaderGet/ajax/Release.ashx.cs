using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Bll;

namespace SpaderGet.ajax
{
    /// <summary>
    /// Release 的摘要说明
    /// </summary>
    public class Release : IHttpHandler
    {

        private string U_ID = "5246";
        private string E_ID = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            #region///字段
            string Url = context.Request["Url"];
            string E_ID = context.Request["E_ID"];
            if (E_ID == "null") { E_ID = "0"; }
            string Car_ID = context.Request["Car_ID"];
            string E_Title = context.Request["E_Title"];
            DateTime Buy_Date = DateTime.Parse(context.Request["Buy_Date"].ToString());
            string Buy_Price = context.Request["Buy_Price"];
            string M_ID = context.Request["M_ID"];
            string T_ID = context.Request["T_ID"];
            string Car_Oil = context.Request["Car_Oil"];
            string Oil_Score = context.Request["Oil_Score"];
            string Oil_Summary = context.Request["Oil_Summary"];
            string Power_Score = context.Request["Power_Score"];
            string Power_Summary = context.Request["Power_Summary"];
            string Cost_Score = context.Request["Cost_Score"];
            string Cost_Summary = context.Request["Cost_Summary"];
            string Config_Score = context.Request["Config_Score"];
            string Config_Summary = context.Request["Config_Summary"];
            string Drive_Score = context.Request["Drive_Score"];
            string Drive_Summary = context.Request["Drive_Summary"];
            string Space_Score = context.Request["Space_Score"];
            string Space_Summary = context.Request["Space_Summary"];
            string Appearance_Score = context.Request["Appearance_Score"];
            string Appearance_Summary = context.Request["Appearance_Summary"];
            string Comfort_Score = context.Request["Comfort_Score"];
            string Comfort_Summary = context.Request["Comfort_Summary"];
            string Inside_Score = context.Request["Inside_Score"];
            string Inside_Summary = context.Request["Inside_Summary"];
            string All_Score = context.Request["All_Score"];
            string All_Summary = context.Request["All_Summary"];
            #endregion
            context.Response.ContentType = "text/plain";
            KB_content_BLL BLL = new KB_content_BLL();
            if (
            #region//判断为空
(E_ID.Length == 0) || (U_ID.Length == 0) || (Car_ID.Length == 0) || (E_Title.Length == 0) || (Buy_Date.ToString().Length == 0) || (Buy_Price.Length == 0) || (M_ID.Length == 0) || (T_ID.Length == 0) || (Car_Oil.Length == 0) || (All_Score.Length == 0) || (All_Summary.Length == 0)
            #endregion
            )
            {
                context.Response.Write("0");
            }
            else
            {
                #region//执行口碑发布
                int MSG = BLL.Edit(E_ID, U_ID, Car_ID, E_Title, Buy_Date, Buy_Price, M_ID, T_ID, Car_Oil, Oil_Score, Oil_Summary, Power_Score, Power_Summary, Cost_Score, Cost_Summary, Config_Score, Config_Summary, Drive_Score, Drive_Summary, Space_Score, Space_Summary, Appearance_Score, Appearance_Summary, Comfort_Score, Comfort_Summary, Inside_Score, Inside_Summary, All_Score, All_Summary);
                #endregion
                new KB_list_BLL().Examine(Url);
                context.Response.Write(MSG);
            }
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