using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Bll;

namespace SpaderGet.ajax
{
    /// <summary>
    /// get_brandID 的摘要说明
    /// </summary>
    public class get_brandID : IHttpHandler
    {
        private V_Series_BLL BLL = new V_Series_BLL();
        private string s_id = string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["sid"] != "") {
                s_id = context.Request["sid"];
            }
            string bid = BLL.Get_Brand(s_id);
            context.Response.ContentType = "text/plain";
            context.Response.Write(bid);
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