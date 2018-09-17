using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Bll;
using Common.Model;
using System.Data;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Common.Helper;
using RegexCenter.Method;

namespace SpaderGet.ajax
{
    /// <summary>
    /// saveurl 的摘要说明
    /// </summary>
    public class saveurl : IHttpHandler
    {
        private KB_list_BLL List_BLL = new KB_list_BLL();
        private Config_BLL Config_BLL = new Config_BLL();
        private Method RegexBLL = new Method();

        private string min = "1";
        private string max = "0";
        private string ID = string.Empty;
        
        int Num_err = 0;
        string Url_err = string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["id"] != null)
            {
                ID = context.Request["id"].Trim().ToString();
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
            DataTable ConfigDT = Config_BLL.GetConfig(ID);
            RegexList_Model RLmodel = JsonConvert.DeserializeObject<RegexList_Model>(ConfigDT.Rows[0]["ListRule"].ToString());

            string url = RLmodel.url;
            string source = ConfigDT.Rows[0]["SourceWeb"].ToString();
            string series = ConfigDT.Rows[0]["Series"].ToString();
            string data = "";
            if (j >= i && url != "")
            {
                if (i == j)
                {
                    string seed = url.Replace("(*)", i.ToString());
                    data = data + GetList(seed,RLmodel) + "<br/>";
                }
                for (int x = 0; x < j; x++)
                {
                    string seed = url.Replace("(*)", i.ToString());
                    i++;
                    List<ecar_list> values = GetList(seed, RLmodel);
                    foreach (ecar_list car in values)
                    {
                        car.source = source;
                        car.series = series;
                        try
                        {
                            if (List_BLL.CheckUrl(car.url) != 1)
                            {
                                List_BLL.SetList(car);
                            }
                        }
                        catch (Exception ex)
                        {
                            Url_err = Url_err + "<" + car.url + ">";
                            Num_err++;
                        }
                    }
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write("失败" + Num_err + "次" + Url_err);

        }
        private List<ecar_list> GetList(string url, RegexList_Model RLmodel)
        {
            #region//具体业务代码
            List<ecar_list> list = new List<ecar_list>();

            string source = HtmlHandle.HtmlCode(url);
            if (source != "")
            {
                //int start = source.IndexOf("<!--筛选结果 开始-->");
                //int end = source.IndexOf("<!--筛选结果 结束-->");
                //string data = source.Substring(start, end - start);

                //data = data.Replace("\n", "").Replace(" ", "").Replace("\r", "");

                string data = source.Replace("\n", "").Replace(" ", "").Replace("\r", "");

                MatchCollection mu = List_BLL.Matchs(data, RegexBLL.GenerateRegex(RLmodel.listRule));
                foreach (Match u in mu)
                {
                    string car = List_BLL.One_Match(u.ToString(), RegexBLL.GenerateRegex(RLmodel.carRule));
                    MatchCollection mc = List_BLL.Matchs(u.ToString(), RegexBLL.GenerateRegex(RLmodel.userRule));
                    foreach (Match m in mc)
                    {
                        ecar_list model = new ecar_list();
                        model.rgid = ID;
                        model.car = car;
                        model.url = RegexBLL.One_Match(m.Groups[0].Value, RegexBLL.GenerateRegex(RLmodel.urlRule));
                        model.title = RegexBLL.One_Match(m.Groups[0].Value, RegexBLL.GenerateRegex(RLmodel.titleRule));
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