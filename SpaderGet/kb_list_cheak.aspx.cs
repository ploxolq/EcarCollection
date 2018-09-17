using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using Common.Bll;
using RegexCenter.Rule;
using Common.Model;
using System.Text.RegularExpressions;
using Common.Helper;

namespace SpaderGet
{
    public partial class kb_list_cheak : System.Web.UI.Page
    {
        KB_list_BLL BLL = new KB_list_BLL();
        Ecar_list Rule = new Ecar_list();
        public string series = string.Empty;
        //string min = "1";
        //string max = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["series"] != null)
            {
                series = Request["series"].Trim().ToString();
            }
            DataTable dt = BLL.GetList(series);
            Check_List.DataSource = dt;
            Check_List.DataBind();
        }
    }
}