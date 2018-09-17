using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Bll;
using RegexCenter.Rule;
using System.Data;
using Common.Model;
using System.Text.RegularExpressions;
using Common.Helper;

namespace SpaderGet.ajax
{
    /// <summary>
    /// set_url 的摘要说明
    /// </summary>
    public class set_url : IHttpHandler
    {

        KB_list_BLL BLL = new KB_list_BLL();
        Ecar_list Rule = new Ecar_list();
        string series = string.Empty;
        string source = string.Empty;
        string url = string.Empty;
        string min = "1";
        string max = "0";
        int Num_err = 0;
        string Url_err = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["url"] != null)
            {
                url = context.Request["url"].Trim().ToString();
            }
            if (context.Request["series"] != null)
            {
                series = context.Request["series"].Trim().ToString();
            }
            if (context.Request["source"] != null)
            {
                source = context.Request["source"].Trim().ToString();
            }
            if (context.Request["min"] != null)
            {
                min = context.Request["min"].Trim().ToString();
            }
            if (context.Request["max"] != null)
            {
                max = context.Request["max"].Trim().ToString();
            }
            int i = int.Parse(min);
            int j = int.Parse(max);

            List<ecar_list> list = new List<ecar_list>();
            DataTable Dt = new DataTable();
            string data = "";
            if (j >= i && url != "")
            {
                if (i == j)
                {
                    string seed = url.Replace("(*)", i.ToString());
                    data = data + GetList(seed) + "<br/>";
                }
                for (int x = 0; x < j; x++)
                { 
                    string seed = url.Replace("(*)", i.ToString());
                    i++;
                    List<ecar_list> values = GetList(seed);
                    foreach (ecar_list car in values)
                    {
                        car.source = source;
                        car.series = series;
                        try {
                            if (BLL.CheckUrl(car.url) != 1)
                            {
                                BLL.SetList(car);
                            }
                        }
                        catch (Exception ex){
                            Url_err = Url_err + "<" + car.url + ">";
                            Num_err++;
                        }
                    }
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write("失败" + Num_err + "次" + Url_err);

        }

        private List<ecar_list> GetList(string url)
        {
            #region//具体业务代码
            List<ecar_list> list = new List<ecar_list>();

            string source = HtmlHandle.HtmlCode(url);
            if (source != "")
            {
                int start = source.IndexOf("<!--筛选结果 开始-->");
                int end = source.IndexOf("<!--筛选结果 结束-->");
                string data = source.Substring(start, end - start);

                data = data.Replace("\n", "").Replace(" ", "").Replace("\r", "");

                MatchCollection mu = BLL.Matchs(data, Rule.Ueritem);
                foreach (Match u in mu)
                {

                    string car = BLL.One_Match(u.ToString(), Rule.listcar);
                    MatchCollection mc = BLL.Matchs(u.ToString(), Rule.herfItem);
                    foreach (Match m in mc)
                    {
                        ecar_list model = new ecar_list();
                        model.car = car;
                        model.url = m.Groups[1].Value;
                        model.title = m.Groups[2].Value;
                        list.Add(model);
                    }
                }
            }
            #endregion
            return list;
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