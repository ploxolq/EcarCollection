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

namespace SpaderGet.page
{
    public partial class list_preview : System.Web.UI.Page
    {
        KB_list_BLL BLL = new KB_list_BLL();
        Method RegexBLL = new Method();
        string url = string.Empty;
        string reg_list = string.Empty;
        string reg_user = string.Empty;
        string reg_car = string.Empty;
        string reg_url = string.Empty;
        string reg_title = string.Empty;
        string min = "1";
        string max = "0";


        protected void Page_Load(object sender, EventArgs e)
        {
            #region//接收Questring
            if (Request.Form["txt_seedurl"] != "")
            {
                url = Request.Form["txt_seedurl"].Trim().ToString();
            }
            if (Request.Form["txt_min"] != "")
            {
                min = Request.Form["txt_min"].Trim().ToString();
            }
            if (Request.Form["txt_max"] != "")
            {
                max = Request.Form["txt_max"].Trim().ToString();
            }
            if (Request.Form["tr_liststart"] != "" && Request.Form["tr_listend"] != "")
            {
                reg_list = AssemblyReg(Request.Form["tr_liststart"].Trim().ToString(), Request.Form["tr_listend"].ToString().Trim());
            }
            if (Request.Form["tr_userstart"] != "" && Request.Form["tr_userend"] != "")
            {
                reg_user = AssemblyReg(Request.Form["tr_userstart"].Trim().ToString(), Request.Form["tr_userend"].ToString().Trim());
            }

            if (Request.Form["txt_carstart"] != "" && Request.Form["txt_carend"] != "")
            {
                reg_car = AssemblyReg(Request.Form["txt_carstart"].Trim().ToString(), Request.Form["txt_carend"].ToString().Trim());
            }

            if (Request.Form["txt_urlstart"] != "" && Request.Form["txt_urlend"] != "")
            {
                reg_url = AssemblyReg(Request.Form["txt_urlstart"].Trim().ToString(), Request.Form["txt_urlend"].ToString().Trim());
            }

            if (Request.Form["txt_titlestart"] != "" && Request.Form["txt_titleend"] != "")
            {
                reg_title = AssemblyReg(Request.Form["txt_titlestart"].Trim().ToString(), Request.Form["txt_titleend"].ToString().Trim());
            }
            #endregion

            int i = int.Parse(min);
            int j = int.Parse(max);
            string data = "";
            if (j >= i && url != "")
            {
                for (int x = i - 1; x < j; x++)
                {
                    string seed = url.Replace("(*)", i.ToString());
                    i++;
                    data = data + GetList(seed) + "<br/>";
                }
            }
            Response.Write(data);
        }

        private string GetList(string url)
        {
            #region//具体业务代码
            string showdata = "";
            string source = HtmlHandle.HtmlCode(url);
            if (source != "")
            {
                string data = source.Replace("\n", "").Replace(" ", "").Replace("\r", "");

                List<ecar_list> list = new List<ecar_list>();

                MatchCollection mu = BLL.Matchs(data, RegexBLL.GenerateRegex(reg_list));
                foreach (Match u in mu)
                {
                    string car = BLL.One_Match(u.ToString(), RegexBLL.GenerateRegex(reg_car));
                    MatchCollection mc = BLL.Matchs(u.ToString(), RegexBLL.GenerateRegex(reg_user));
                    foreach (Match m in mc)
                    {
                        ecar_list model = new ecar_list();
                        model.car = car;
                        model.url = RegexBLL.One_Match(m.Groups[0].Value, RegexBLL.GenerateRegex(reg_url));
                        model.title = RegexBLL.One_Match(m.Groups[0].Value, RegexBLL.GenerateRegex(reg_title));
                        list.Add(model);
                    }
                }
                foreach (ecar_list m in list)
                {
                    showdata = showdata + m.car + "\n" + m.url + "\n" + m.title + "<br>";
                }
            }
            #endregion
            return showdata;

        }

        private string AssemblyReg(string startstr, string endstr)
        {
            return startstr + "([\\S\\s]*?)" + endstr;
        }
    }
}