using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Bll;

namespace SpaderGet.ajax
{
    /// <summary>
    /// get_province_code 的摘要说明
    /// </summary>
    public class get_province_code : IHttpHandler
    {

        private City_BLL BLL = new City_BLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string province = "0";
            string city = context.Request["city"];
            if (city != "undefind" && city != "--选择城市--" && city != "--请选择--")
            {
                province = BLL.Get_Province(city);
            }
            context.Response.Write(province);
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