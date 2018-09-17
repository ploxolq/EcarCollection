using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Bll;
using RegexCenter.Rule;
using Common.Model;
using System.Text.RegularExpressions;
using Common.Helper;

namespace SpaderGet
{
    public partial class kb_content : System.Web.UI.Page
    {
        KB_list_BLL BLL = new KB_list_BLL();
        Ecar_kbCont Rule = new Ecar_kbCont();
        string url = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["url"] != "")
            {
                url = Request["url"].Trim().ToString();
            }
            string source = HtmlHandle.HtmlCode(url);
            if (source != "")
            {
                string data = source.Replace("\n", "").Replace(" ", "").Replace("\r", "");
                ecar_content model = new ecar_content();
                model.car = BLL.One_Match(data,Rule.car);
                model.title = BLL.One_Match(data, Rule.title);
                model.type = BLL.One_Match(data, Rule.type);
                model.malladdr = BLL.One_Match(data, Rule.address);
                model.buydata = BLL.One_Match(data, Rule.buydate);
                model.price = BLL.One_Match(data, Rule.price);
                model.oil = BLL.One_Match(data, Rule.oil);
                model.satisfied = BLL.One_Match(data, Rule.satisfied);
                model.unsatisfied = BLL.One_Match(data, Rule.unsatisfied);

                MatchCollection oilItem = BLL.Matchs(data, Rule.oilItem);
                foreach (Match m in oilItem)
                {
                    model.oil_star = m.Groups[1].Value;
                    model.oil_sum = m.Groups[2].Value;
                    
                }
                MatchCollection operationItem = BLL.Matchs(data, Rule.operationItem);
                foreach (Match m in operationItem)
                {
                    model.operation_star = m.Groups[1].Value;
                    model.operation = m.Groups[2].Value;

                }
                MatchCollection costperforItem = BLL.Matchs(data, Rule.costperforItem);
                foreach (Match m in costperforItem)
                {
                    model.costperfor_star = m.Groups[1].Value;
                    model.costperfor = m.Groups[2].Value;
                    
                }
                MatchCollection configItem = BLL.Matchs(data, Rule.configItem);
                foreach (Match m in configItem)
                {
                    model.config = m.Groups[1].Value;
                    model.config_star = m.Groups[2].Value;
                    
                }
                MatchCollection comfortItem = BLL.Matchs(data, Rule.comfortItem);
                foreach (Match m in comfortItem)
                {
                    model.comfort = m.Groups[1].Value;
                    model.comfort_star = m.Groups[2].Value;
                    
                }
                MatchCollection spaceItem = BLL.Matchs(data, Rule.spaceItem);
                foreach (Match m in spaceItem)
                {
                    model.space_star = m.Groups[1].Value;
                    model.space = m.Groups[2].Value;
                    
                }
                MatchCollection powerItem = BLL.Matchs(data, Rule.powerItem);
                foreach (Match m in powerItem)
                {
                    model.operation_star = m.Groups[1].Value;
                    model.operation = m.Groups[2].Value;
                    
                }
                MatchCollection appearanceItem = BLL.Matchs(data, Rule.appearanceItem);
                foreach (Match m in appearanceItem)
                {
                    model.appearance_star = m.Groups[1].Value;
                    model.appearance = m.Groups[2].Value;
                    
                }
                MatchCollection insideItem = BLL.Matchs(data, Rule.insideItem);
                foreach (Match m in insideItem)
                {
                    model.inside_star = m.Groups[1].Value;
                    model.inside = m.Groups[2].Value;
                    
                }
                MatchCollection syntheticalItem = BLL.Matchs(data, Rule.syntheticalItem);
                foreach (Match m in syntheticalItem)
                {
                    model.synthetical_star = m.Groups[1].Value;
                    model.synthetical = m.Groups[2].Value;

                }


                string showdata = model.car + "/r/n" + model.url + "/r/n" + model.title + "/r/n" +
                model.type + "/r/n" + model.malladdr + "/r/n" + model.buydata + model.price + "/r/n" + model.oil + "/r/n" + model.satisfied + "\n" + model.unsatisfied;
                Response.Write(showdata);

            }
        }
    }
}