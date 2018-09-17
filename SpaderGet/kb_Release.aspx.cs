using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Bll;
using RegexCenter.Rule;
using System.Text.RegularExpressions;
using Common.Helper;
using Common.Model;

namespace SpaderGet
{
    public partial class kb_Release : System.Web.UI.Page
    {
        KB_list_BLL BLL = new KB_list_BLL();
        KB_content_BLL T_BLL = new KB_content_BLL();
        Ecar_kbCont Rule = new Ecar_kbCont();
        public string url = string.Empty;
        public string series = string.Empty;

        public string oilstar = string.Empty;
        public string drivestar = string.Empty;
        public string coststar = string.Empty;
        public string powerstar = string.Empty;
        public string configstar = string.Empty;
        public string comfortstar = string.Empty;
        public string spacestar = string.Empty;
        public string apperstar = string.Empty;
        public string insidestar = string.Empty;
        public string allstar = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["url"] != "")
            {
                url = Request["url"].Trim().ToString();
            }
            if (Request["series"] != "")
            {
                series = Request["series"].Trim().ToString();
            }
            string source = HtmlHandle.HtmlCode(url);
            if (source != "")
            {
                #region//数据获取
                string data = source.Replace("\n", "").Replace(" ", "").Replace("\r", "");
                ecar_content model = new ecar_content();
                model.car = BLL.One_Match(data, Rule.car);
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
                    model.config_star = m.Groups[1].Value;
                    model.config = m.Groups[2].Value;
                }
                MatchCollection comfortItem = BLL.Matchs(data, Rule.comfortItem);
                foreach (Match m in comfortItem)
                {
                    model.comfort_star = m.Groups[1].Value;
                    model.comfort = m.Groups[2].Value;
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
                    model.synthetical = Regex.Replace(m.Groups[2].Value.ToString(), "<[\\S\\s]*?>","").ToString();

                }
                #endregion

                #region//绑定
                lbl_car.InnerText = series + model.car+model.type;
                txt_title.Value = model.title;
                txt_buydate.Value = model.buydata;
                txt_buyprice.Value = model.price;
                txt_car_oil.Value = model.oil;
                txt_oil_summary.Value = model.oil_sum;
                txt_inside_summary.Value = model.inside;
                txt_drive_summary.Value = model.operation;
                txt_config_summary.Value = model.config;
                txt_comfort_summary.Value = model.comfort;
                txt_cost_summary.Value = model.costperfor;
                txt_power_summary.Value = model.power;
                txt_appearance_summary.Value = model.appearance;
                txt_space_summary.Value = model.space;
                txt_all_summary.Value = model.synthetical;
                //type = model.type;//
                allstar = model.synthetical_star;
                powerstar = model.power_star;
                oilstar = model.oil_star;
                drivestar = model.operation_star;
                configstar = model.config_star;
                coststar = model.costperfor_star;
                comfortstar = model.comfort_star;
                apperstar = model.appearance_star;
                spacestar = model.space_star;
                insidestar = model.inside_star;
                #endregion

                rep_type.DataSource = T_BLL.Get_ALL();
                rep_type.DataBind();


            }
        }
    }
}