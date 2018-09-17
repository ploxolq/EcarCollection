using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Common.Helper;
using Common.Model;
using Common.Dal;
using System.Threading;
using RegexCenter;
using RegexCenter.Rule;
using RegexCenter.Method;
using Common.Bll;

namespace SpaderGet
{
    public partial class demo : System.Web.UI.Page
    {
        HtmlHandle HtmlGet = new HtmlHandle();
        #region//具体口碑页面的正则表达式
        Regex title = new Regex("<divclass=\"main-box\">\\s*<h6>([\\s\\S]*?)</h6>");
        Regex car = new Regex("<divclass=\"con-l\">\\s*?<h6>([\\s\\S]*?)</h6>");//车型
        Regex address = new Regex("地址：<em>([\\s\\S]*?)</em>");
        Regex buydate = new Regex("时间：<em>([\\s\\S]*?)</em>");
        Regex price = new Regex("车价：<em class=\"red\"><strong>([\\s\\S]*?)</strong>");
        Regex oil = new Regex("当前油耗：<em>([\\s\\S]*?)L/100km</em>");
        Regex type = new Regex("<span class=\"blue\">([\\s\\S]*?)</span>");
        Regex satisfied = new Regex("满&nbsp;&nbsp;意：\\s*</div>\\s*<p>([\\S\\s]*?)</p>");
        Regex unsatisfied = new Regex("不满意：\\s*</div>\\s*<p>([\\S\\s]*?)</p>");

        Regex oilItem = new Regex("油&nbsp;&nbsp;耗：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//油耗分数和评价
        Regex operationItem = new Regex("操&nbsp;&nbsp;控：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//操控分数和评价
        Regex costperforItem = new Regex("性价比：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//性价比分数和评价
        Regex configItem = new Regex(" 配&nbsp;&nbsp;置：：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//配置分数和评价
        Regex comfortItem = new Regex("舒适度：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//舒适度分数和评价
        Regex spaceItem = new Regex("空&nbsp;&nbsp;间：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//空间分数和评价
        Regex powerItem = new Regex("动&nbsp;&nbsp;力：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//动力分数和评价
        Regex appearanceItem = new Regex("外&nbsp;&nbsp;观：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//外观分数和评价
        Regex insideItem = new Regex("内&nbsp;&nbsp;饰：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//内饰分数和评价
        Regex syntheticalItem = new Regex("综&nbsp;&nbsp;合：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//综合分数和评价
        Regex syntheticalItem_wkb = new Regex("总&nbsp;&nbsp;&nbsp;评：[\\S\\s]*?width: ([\\D\\d]{1,3})%[\\S\\s]*?<p>([\\W\\w]*?)</p>");//综合分数和评价(微口碑)
        #endregion

        Method Regex_BLL = new Method();
        Ecar_list Rule = new Ecar_list();
        
        #region//url采集正则表达式
        Regex hergItem = new Regex("titbox\">[\\S\\s]*?href=\"([\\S\\s]*?)\" target");//口碑Url组
        Regex Gengduo = new Regex("aTopicListUrl\" href=\"([\\S\\s]*?)\" rel");//检查是否存在多页
        Regex Ueritem = new Regex("<divclass=\"kb-list-box\">([\\S\\s]*?)</div></div></div></div>");//用户组
        Regex herfItem = new Regex("titbox\">[\\S\\s]*?href=\"([\\S\\s]*?)\"target=\"_blank\">([\\S\\s]*?)</a>");//口碑Url组
        Regex listcar = new Regex("<h6>([\\S\\s]*?)</h6>");//车型
        Regex maxpage = new Regex("pageCount = ([\\d]{1,5});");//获取最大页码
        Regex carid = new Regex("koubei/gengduo/([\\d]{1,9})-0");//获取carId
        #endregion


        List<string> list = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            string url = "http://car.bitauto.com/xinbaolai/koubei/";
            string data = HtmlHandle.HtmlCode(url);

            //data=data.Replace(" ","").Replace("\r\n\r\n","\r\n").Replace("\r\n\r\n","\r\n");
            int start = data.IndexOf("<!--筛选结果 开始-->");
            int end = data.IndexOf("<!--筛选结果 结束-->");
            string show = data.Substring(start, end - start);
            show=show.Replace("\n", "").Replace(" ","").Replace("\r","");
            List<ecar_list> list = new List<ecar_list>();
            string showdata = "";
            //string[] sArray = show.Split( new string[]{"<divclass=\"kb-list-box\">","</div></div></div></div>"}, StringSplitOptions.RemoveEmptyEntries);

            string regx = "<divclass=\"titbox\"><a[\\S\\s]*?>([\\S\\s]*?)</a>";
            string regq = "<divclass=\"titbox\"><ahref=\"([\\S\\s]*?)\"targe";

            #region //业务代码
            MatchCollection mu = Regex_BLL.Matchs(show, Rule.Ueritem);
            foreach (Match u in mu)
            {
                ecar_list model = new ecar_list();
                model.car = Regex_BLL.One_Match(u.ToString(), Rule.listcar);
                MatchCollection mc = Regex_BLL.Matchs(u.ToString(), Rule.herfItem);
                foreach (Match m in mc)
                {
                    model.url = Regex_BLL.One_Match(m.Groups[0].Value, Regex_BLL.GenerateRegex(regq));
                    model.title = Regex_BLL.One_Match(m.Groups[0].Value, Regex_BLL.GenerateRegex(regx));
                    list.Add(model);
                }
            }
            #endregion
            SavetoDb("http://car.bitauto.com/leikesasies/koubei/948884/");

            #region//弃用
            //MatchCollection mu = herfItem.Matches(show);
            //foreach (Match u in mu)
            //{
            //    ecar_list model = new ecar_list();
            //    model.car = listcar.Match(u.ToString()).Groups[1].Value;
            //    MatchCollection mc = herfItem.Matches(u.ToString());
            //    foreach (Match m in mc)
            //    {
            //        model.url = m.Groups[1].Value;
            //        model.title = m.Groups[2].Value;
            //        list.Add(model);
            //    }
            //}
            #endregion


            #region//弃用
            //for (int i = 1; i < sArray.Length; i++)
            //{
            //    ecar_list model = new ecar_list();
            //    int titstart = sArray[i].IndexOf("<divclass=\"titbox\">");
            //    int titend = sArray[i].IndexOf("</div><pclass");
            //    if (titstart != -1)
            //    {
            //        model.title = sArray[i].Substring(titstart, titend - titstart);
            //    }
            //    int urlstart = sArray[i].IndexOf("ahref=\"");
            //    int urlend = sArray[i].IndexOf("\"rel");
            //    if (urlstart != -1)
            //    {
            //        model.url = sArray[i].Substring(urlstart, urlend - urlstart);
            //    }
            //    int carstart = sArray[i].IndexOf("<h6>");
            //    int carend = sArray[i].IndexOf("</h6>");
            //    if (carstart != -1)
            //    {
            //        model.car = sArray[i].Substring(carstart, carend - carstart);
            //    }
            //    list.Add(model);
            //}
            #endregion

            foreach (ecar_list m in list)
            {
                showdata = showdata + m.car + "\n" + m.url + "\n" + m.title + "<br>";
            }
            Response.Write(showdata);
            //string carPy = "baomax5";
            //GetUrl Geturl = new demo.GetUrl(GetUrlList);
            //Thread UrlThread = new Thread(new ThreadStart(Geturl(carPy)));
            //UrlThread.Start();
            //savetodb stod = new savetodb(GotoSave);
            //Thread StoDb = new Thread(new ThreadStart(stod(list)));
            //StoDb.Start();
        }
        public int SavetoDb(string url) {
            ecar_content model = new ecar_content();
            string source = HtmlHandle.HtmlCode(url);
            string data = source.Replace("\n", "").Replace(" ", "").Replace("\r", "");
            #region//绑定数据
            model.title = title.Match(data).Groups[1].Value;
            if (model.title == "")
            {
                model.title = "微口碑";
            }
            model.url = url;
            model.type = type.Match(data).Groups[1].Value;
            model.car = car.Match(data).Groups[1].Value;
            model.malladdr = address.Match(data).Groups[1].Value;
            model.buydata = buydate.Match(data).Groups[1].Value;
            model.price = price.Match(data).Groups[1].Value;
            model.oil = oil.Match(data).Groups[1].Value;
            model.satisfied = satisfied.Match(data).Groups[1].Value;
            model.unsatisfied = unsatisfied.Match(data).Groups[1].Value;
            //具体内容
            model.oil_star = oilItem.Match(data).Groups[1].Value;
            model.oil_sum = oilItem.Match(data).Groups[2].Value;
            model.operation_star = operationItem.Match(data).Groups[1].Value;
            model.operation = operationItem.Match(data).Groups[2].Value;
            model.power_star = powerItem.Match(data).Groups[1].Value;
            model.power = powerItem.Match(data).Groups[2].Value;
            model.space_star = spaceItem.Match(data).Groups[1].Value;
            model.space = spaceItem.Match(data).Groups[2].Value;
            if (model.title == "微口碑")
            {
                model.synthetical_star = syntheticalItem_wkb.Match(data).Groups[1].Value;
                model.synthetical = syntheticalItem_wkb.Match(data).Groups[2].Value;
            }
            else
            {
                model.synthetical_star = syntheticalItem.Match(data).Groups[1].Value;
                model.synthetical = syntheticalItem.Match(data).Groups[2].Value;
            }
            model.appearance_star = appearanceItem.Match(data).Groups[1].Value;
            model.appearance = appearanceItem.Match(data).Groups[2].Value;
            model.comfort_star = comfortItem.Match(data).Groups[1].Value;
            model.comfort = comfortItem.Match(data).Groups[2].Value;
            model.config_star = configItem.Match(data).Groups[1].Value;
            model.config = configItem.Match(data).Groups[2].Value;
            model.costperfor_star = costperforItem.Match(data).Groups[1].Value;
            model.costperfor = costperforItem.Match(data).Groups[2].Value;
            model.inside_star = insideItem.Match(data).Groups[1].Value;
            model.inside = insideItem.Match(data).Groups[2].Value;
            #endregion
            return 0;//new Ecar_koubei_Dal().Save(model);//具体存储
        }
        public void GotoSave(List<string> list) {
            foreach (string url in list) {
                SavetoDb(url);
            }

        }
        public List<string> GetUrlList(string carpy) {
            string seed = "http://car.bitauto.com/" + carpy + "/koubei/";
            string seeddata = Common.Helper.HtmlHandle.HtmlCode(seed);
            string index = Gengduo.Match(seeddata).Groups[1].Value;
            string SecendSeed = Common.Helper.HtmlHandle.HtmlCode(index);
            if (index == "")
            {
                //**
                MatchCollection mc = hergItem.Matches(seeddata);
                foreach (Match m in mc)
                {
                    list.Add(m.Groups[1].Value);
                }
                //**

            }
            else
            {
                string morepage = Common.Helper.HtmlHandle.HtmlCode(index);

                string id = carid.Match(morepage).Groups[1].Value;
                string max = maxpage.Match(morepage).Groups[1].Value;
                int maxs = int.Parse(max);
                for (int i = 1; i < maxs; i++)
                {
                    string forurl = "http://car.bitauto.com/" + carpy + "/koubei/gengduo/" + id + "-0-0-0-0-0-0-0-0-0-0--" + i + "-10.html";
                    string fordata = Common.Helper.HtmlHandle.HtmlCode(forurl);
                    MatchCollection mc = hergItem.Matches(fordata);
                    foreach (Match m in mc)
                    {
                        list.Add(m.Groups[1].Value);
                    }
                }


            }
            return list;
        }
    }
}