using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Bll;
using Common.Model;
using RegexCenter.Rule;
using System.Text.RegularExpressions;
using Common.Helper;
using RegexCenter.Method;

namespace SpaderGet
{
    public partial class kb_list : System.Web.UI.Page
    {
        KB_list_BLL BLL = new KB_list_BLL();
        Method RegexBLL = new Method();
        Ecar_list Rule = new Ecar_list();
        string url = string.Empty;
        string liststart = string.Empty;
        string listend = string.Empty;
        string userstart = string.Empty;
        string userend = string.Empty;
        string carstart = string.Empty;
        string urlstart = string.Empty;
        string titlestart = string.Empty;
        string carend = string.Empty;
        string urlend = string.Empty;
        string titleend = string.Empty;
        string min = "1";
        string max = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (Request.Form["tr_liststart"] != "")
            {
                liststart = Request.Form["tr_liststart"].Trim().ToString();
            }
            if (Request.Form["tr_listend"] != "")
            {
                listend = Request.Form["tr_listend"].Trim().ToString();
            }
            if (Request.Form["tr_userstart"] != "")
            {
                userstart = Request.Form["tr_userstart"].Trim().ToString();
            }
            if (Request.Form["tr_userend"] != "")
            {
                userend = Request.Form["tr_userend"].Trim().ToString();
            }
            if (Request.Form["txt_carstart"] != "")
            {
                carstart = Request.Form["txt_carstart"].Trim().ToString();
            }
            if (Request.Form["txt_carend"] != "")
            {
                carend = Request.Form["txt_carend"].Trim().ToString();
            }
            if (Request.Form["txt_urlstart"] != "")
            {
                urlstart = Request.Form["txt_urlstart"].Trim().ToString();
            }
            if (Request.Form["txt_urlend"] != "")
            {
                urlend = Request.Form["txt_urlend"].Trim().ToString();
            }
            if (Request.Form["txt_titlestart"] != "")
            {
                titlestart = Request.Form["txt_titlestart"].Trim().ToString();
            }
            if (Request.Form["txt_titleend"] != "")
            {
                titleend = Request.Form["txt_titleend"].Trim().ToString();
            }
            int i = int.Parse(min);
            int j = int.Parse(max);
            string data = "";
            if (j >= i && url != "")
            {
                for (int x = i-1; x < j; x++) {
                    string seed = url.Replace("(*)", i.ToString());
                    i++;
                    data = data+ GetList(seed)+"<br/>";
                }
            }
            Response.Write( data);

            #region//具体业务代码
            //string source = HtmlHandle.HtmlCode(url);
            //if (source != "")
            //{
            //    int start = source.IndexOf("<!--筛选结果 开始-->");
            //    int end = source.IndexOf("<!--筛选结果 结束-->");
            //    string data = source.Substring(start, end - start);
            //    data = data.Replace("\n", "").Replace(" ", "").Replace("\r", "");

            //    List<ecar_list> list = new List<ecar_list>();
            //    MatchCollection mu = BLL.Matchs(data, Rule.Ueritem);
            //    foreach (Match u in mu)
            //    {

            //        ecar_list model = new ecar_list();
            //        model.car = BLL.One_Match(u.ToString(), Rule.listcar);
            //        MatchCollection mc = BLL.Matchs(u.ToString(), Rule.herfItem);
            //        foreach (Match m in mc)
            //        {
            //            model.url = m.Groups[1].Value;
            //            model.title = m.Groups[2].Value;
            //            list.Add(model);
            //        }
            //    }
            //    string showdata = "";
            //    foreach (ecar_list m in list)
            //    {
            //        showdata = showdata + m.car + "\n" + m.url + "\n" + m.title + "<br>";
            //    }
            //    Response.Write(showdata);

            //}
            #endregion
        }

        private string GetList(string url) 
        {
            #region//具体业务代码              
            string showdata = "";
            string source = HtmlHandle.HtmlCode(url);
            if (source != "")
            {
                #region
                //int start = source.IndexOf("<!--筛选结果 开始-->");
                //int end = source.IndexOf("<!--筛选结果 结束-->");
                //string data = source.Substring(start, end - start);
                //data = data.Replace("\n", "").Replace(" ", "").Replace("\r", "");
                #endregion

                string data = source.Replace("\n", "").Replace(" ", "").Replace("\r", "");

                List<ecar_list> list = new List<ecar_list>();

                MatchCollection mu = BLL.Matchs(data, RegexBLL.GenerateRegex(liststart + "([\\S\\s]*?)" + listend));
                foreach (Match u in mu)
                {
                    string car = BLL.One_Match(u.ToString(), RegexBLL.GenerateRegex(carstart + "([\\S\\s]*?)" + carend));
                    MatchCollection mc = BLL.Matchs(u.ToString(), RegexBLL.GenerateRegex(userstart + "([\\S\\s]*?)" + userend));



                    foreach (Match m in mc)
                    {
                        ecar_list model = new ecar_list();
                        model.car = car;
                        model.url = RegexBLL.One_Match(m.Groups[0].Value, RegexBLL.GenerateRegex(urlstart + "([\\S\\s]*?)" + urlend));
                        model.title = RegexBLL.One_Match(m.Groups[0].Value, RegexBLL.GenerateRegex(titlestart + "([\\S\\s]*?)" + titleend));
                        list.Add(model);
                    }
                }

                #region
                //MatchCollection mu = BLL.Matchs(data, Rule.Ueritem);
                //foreach (Match u in mu)
                //{
                //    string car = BLL.One_Match(u.ToString(), Rule.listcar);
                //    MatchCollection mc = BLL.Matchs(u.ToString(), Rule.herfItem);



                //    foreach (Match m in mc)
                //    {
                //        ecar_list model = new ecar_list();
                //        model.car = car;
                //        model.url = m.Groups[1].Value;
                //        model.title = m.Groups[2].Value;
                //        list.Add(model);
                //    }
                //}
                #endregion
                foreach (ecar_list m in list)
                {
                    showdata = showdata + m.car + "\n" + m.url + "\n" + m.title + "<br>";
                }
            }
            #endregion
            return showdata;

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
        }
    }
}