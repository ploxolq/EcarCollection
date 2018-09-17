using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Bll;
using RegexCenter.Method;
using RegexCenter.Rule;
using Common.Model;
using Common.Helper;
using System.Text.RegularExpressions;
using System.Data;

namespace SpaderGet.page
{
    public partial class List : System.Web.UI.Page
    {
        private string series = string.Empty;
        KB_list_BLL BLL = new KB_list_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request["series"]!=null){
                series =Request["series"].ToString().Trim();
            }
            DataTable listDT = BLL.GetList(series);
            rep_list.DataSource = listDT;
            rep_list.DataBind();



        }


    }
}