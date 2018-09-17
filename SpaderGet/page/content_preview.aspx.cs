using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Model;
using Common.Bll;
using RegexCenter.Method;
using Common.Helper;

namespace SpaderGet.page
{
    public partial class content_preview : System.Web.UI.Page
    {
        #region//必要字段
        private string url = string.Empty;
        private string title = string.Empty;
        private string car = string.Empty;
        private string type = string.Empty;
        private string buydata = string.Empty;
        private string malladdr = string.Empty;//购车地址
        private string price = string.Empty;
        private string oil = string.Empty;
        private string satisfied = string.Empty;//
        private string unsatisfied = string.Empty;
        private string oil_sum = string.Empty;//
        private string operation = string.Empty;//操控
        private string costperfor = string.Empty;//性价比
        private string config = string.Empty;
        private string comfort = string.Empty;//舒适度
        private string space = string.Empty;//
        private string power = string.Empty;//
        private string appearance = string.Empty;
        private string inside = string.Empty;
        private string synthetical = string.Empty;//综合
        private string wsynthetical = string.Empty;//综合
        private string oil_star = string.Empty;
        private string operation_star = string.Empty;//操控
        private string costperfor_star = string.Empty;//性价比
        private string config_star = string.Empty;
        private string comfort_star = string.Empty;//舒适度
        private string space_star = string.Empty;//
        private string power_star = string.Empty;//
        private string appearance_star = string.Empty;
        private string inside_star = string.Empty;
        private string synthetical_star = string.Empty;//综合   
        private string wsynthetical_star = string.Empty;//综合   
        #endregion
        Method RegexBLL = new Method();

        protected void Page_Load(object sender, EventArgs e)
        {
            #region//字段赋值
            if (Request.Form["txt_cont_url"] != null)
            {
                url = Request.Form["txt_cont_url"].Trim().ToString();
            }
            if (Request.Form["txt_Ccarstart"] != null && Request.Form["txt_Ccarend"] != null)
            {
                car = AssemblyReg(Request.Form["txt_Ccarstart"].Trim().ToString(), Request.Form["txt_Ccarend"].ToString().Trim());
            }
            if (Request.Form["txt_Ctitlestart"] != null && Request.Form["txt_Ctitleend"] != null)
            {
                title = AssemblyReg(Request.Form["txt_Ctitlestart"].Trim().ToString(), Request.Form["txt_Ctitleend"].ToString().Trim());
            }
            if (Request.Form["txt_Ctypestart"] != null && Request.Form["txt_Ctypeend"] != null)
            {
                type = AssemblyReg(Request.Form["txt_Ctypestart"].Trim().ToString(), Request.Form["txt_Ctypeend"].ToString().Trim());
            }
            if (Request.Form["txt_Cdatestart"] != null && Request.Form["txt_Cdateend"] != null)
            {
                buydata = AssemblyReg(Request.Form["txt_Cdatestart"].Trim().ToString(), Request.Form["txt_Cdateend"].ToString().Trim());
            }
            if (Request.Form["txt_Caddstart"] != null && Request.Form["txt_Caddend"] != null)
            {
                malladdr = AssemblyReg(Request.Form["txt_Caddstart"].Trim().ToString(), Request.Form["txt_Caddend"].ToString().Trim());
            }
            if (Request.Form["txt_Cpricestart"] != null && Request.Form["txt_Cprieceend"] != null)
            {
                price = AssemblyReg(Request.Form["txt_Cpricestart"].Trim().ToString(), Request.Form["txt_Cprieceend"].ToString().Trim());
            }
            if (Request.Form["txt_oilstart"] != null && Request.Form["txt_oilend"] != null)
            {
                oil = AssemblyReg(Request.Form["txt_oilstart"].Trim().ToString(), Request.Form["txt_oilend"].ToString().Trim());
            }
            if (Request.Form["txt_oilstarstart"] != null && Request.Form["txt_oilstarend"] != null)
            {
                oil_star = AssemblyReg(Request.Form["txt_oilstarstart"].Trim().ToString(), Request.Form["txt_oilstarend"].ToString().Trim());
            }
            if (Request.Form["txt_oilsumstart"] != null && Request.Form["txt_oilsumend"] != null)
            {
                oil_sum = AssemblyReg(Request.Form["txt_oilsumstart"].Trim().ToString(), Request.Form["txt_oilsumend"].ToString().Trim());
            }
            if (Request.Form["txt_caozuostartstart"] != null && Request.Form["txt_caozuostarend"] != null)
            {
                operation_star = AssemblyReg(Request.Form["txt_caozuostartstart"].Trim().ToString(), Request.Form["txt_caozuostarend"].ToString().Trim());
            }
            if (Request.Form["txt_caozuosumstart"] != null && Request.Form["txt_caozuosumend"] != null)
            {
                operation = AssemblyReg(Request.Form["txt_caozuosumstart"].Trim().ToString(), Request.Form["txt_caozuosumend"].ToString().Trim());
            }
            if (Request.Form["txt_coststarstart"] != null && Request.Form["txt_costend"] != null)
            {
                costperfor_star = AssemblyReg(Request.Form["txt_coststarstart"].Trim().ToString(), Request.Form["txt_costend"].ToString().Trim());
            }
            if (Request.Form["txt_costsumstart"] != null && Request.Form["txt_costsumend"] != null)
            {
                costperfor = AssemblyReg(Request.Form["txt_costsumstart"].Trim().ToString(), Request.Form["txt_costsumend"].ToString().Trim());
            }
            if (Request.Form["txt_powerstarstart"] != null && Request.Form["txt_powerstarend"] != null)
            {
                power_star = AssemblyReg(Request.Form["txt_powerstarstart"].Trim().ToString(), Request.Form["txt_powerstarend"].ToString().Trim());
            }
            if (Request.Form["txt_powersumstart"] != null && Request.Form["txt_powersumend"] != null)
            {
                power = AssemblyReg(Request.Form["txt_powersumstart"].Trim().ToString(), Request.Form["txt_powersumend"].ToString().Trim());
            }
            if (Request.Form["txt_configstarstart"] != null && Request.Form["txt_configstarend"] != null)
            {
                config_star = AssemblyReg(Request.Form["txt_configstarstart"].Trim().ToString(), Request.Form["txt_configstarend"].ToString().Trim());
            }
            if (Request.Form["txt_configsumstart"] != null && Request.Form["txt_configsumend"] != null)
            {
                config = AssemblyReg(Request.Form["txt_configsumstart"].Trim().ToString(), Request.Form["txt_configsumend"].ToString().Trim());
            }
            if (Request.Form["txt_comfortstarstart"] != null && Request.Form["txt_comfortstarend"] != null)
            {
                comfort_star = AssemblyReg(Request.Form["txt_comfortstarstart"].Trim().ToString(), Request.Form["txt_comfortstarend"].ToString().Trim());
            }
            if (Request.Form["txt_comfortsumstart"] != null && Request.Form["txt_comfortsumend"] != null)
            {
                comfort = AssemblyReg(Request.Form["txt_comfortsumstart"].Trim().ToString(), Request.Form["txt_comfortsumend"].ToString().Trim());
            }
            if (Request.Form["txt_spacestarstart"] != null && Request.Form["txt_spacestarend"] != null)
            {
                space_star = AssemblyReg(Request.Form["txt_spacestarstart"].Trim().ToString(), Request.Form["txt_spacestarend"].ToString().Trim());
            }
            if (Request.Form["txt_spacesumstart"] != null && Request.Form["txt_spacesumend"] != null)
            {
                space = AssemblyReg(Request.Form["txt_spacesumstart"].Trim().ToString(), Request.Form["txt_spacesumend"].ToString().Trim());
            }
            if (Request.Form["txt_apprsstarstart"] != null && Request.Form["txt_apprsstarend"] != null)
            {
                appearance_star = AssemblyReg(Request.Form["txt_apprsstarstart"].Trim().ToString(), Request.Form["txt_apprsstarend"].ToString().Trim());
            }
            if (Request.Form["txt_apprssumstart"] != null && Request.Form["txt_apprssumend"] != null)
            {
                appearance = AssemblyReg(Request.Form["txt_apprssumstart"].Trim().ToString(), Request.Form["txt_apprssumend"].ToString().Trim());
            }
            if (Request.Form["txt_insidestarstart"] != null && Request.Form["txt_insidestarend"] != null)
            {
                inside_star = AssemblyReg(Request.Form["txt_insidestarstart"].Trim().ToString(), Request.Form["txt_insidestarend"].ToString().Trim());
            }
            if (Request.Form["txt_insidesumstart"] != null && Request.Form["txt_insidesumend"] != null)
            {
                inside = AssemblyReg(Request.Form["txt_insidesumstart"].Trim().ToString(), Request.Form["txt_insidesumend"].ToString().Trim());
            }
            if (Request.Form["txt_allstarstart"] != null && Request.Form["txt_allstarend"] != null)
            {
                synthetical_star = AssemblyReg(Request.Form["txt_allstarstart"].Trim().ToString(), Request.Form["txt_allstarend"].ToString().Trim());
            }
            if (Request.Form["txt_allsumstart"] != null && Request.Form["txt_allsumend"] != null)
            {
                synthetical = AssemblyReg(Request.Form["txt_allsumstart"].Trim().ToString(), Request.Form["txt_allsumend"].ToString().Trim());
            }
            if (Request.Form["txt_wallstarstart"] != null && Request.Form["txt_wallstarend"] != null)
            {
                wsynthetical_star = AssemblyReg(Request.Form["txt_wallstarstart"].Trim().ToString(), Request.Form["txt_wallstarend"].ToString().Trim());
            }
            if (Request.Form["txt_wallsumstart"] != null && Request.Form["txt_wallsumend"] != null)
            {
                wsynthetical = AssemblyReg(Request.Form["txt_wallsumstart"].Trim().ToString(), Request.Form["txt_wallsumend"].ToString().Trim());
            }
            #endregion
            Response.Write(GetList(url));

        }

        private string GetList(string url)
        {
            #region//具体业务代码
            string showdata = "";
            string source = HtmlHandle.HtmlCode(url);
            if (source != "")
            {
                string data = source.Replace("\n", "").Replace(" ", "").Replace("\r", "");

                ecar_content model = new ecar_content();
                #region//model赋值
                model.url = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(url));
                model.title = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(title));
                model.car = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(car));
                model.type = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(type));
                model.buydata = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(buydata));
                model.malladdr = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(malladdr));//购车地址
                model.price = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(price));
                model.oil = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(oil));
                model.oil_sum = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(oil_sum));//
                model.operation = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(operation));//操控
                model.costperfor = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(costperfor));//性价比
                model.config = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(config));
                model.comfort = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(comfort));//舒适度
                model.space = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(space));//
                model.power = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(power));//
                model.appearance = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(appearance));
                model.inside = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(inside));
                model.synthetical = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(synthetical));//综合
                model.wsynthetical = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(wsynthetical));//综合
                model.oil_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(oil_star));
                model.operation_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(operation_star));//操控
                model.costperfor_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(costperfor_star));//性价比
                model.config_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(config_star));
                model.comfort_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(comfort_star));//舒适度
                model.space_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(space_star));//
                model.power_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(power_star));//
                model.appearance_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(appearance_star));
                model.inside_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(inside_star));
                model.synthetical_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(synthetical_star));//综合    
                model.wsynthetical_star = RegexBLL.One_Match(data, RegexBLL.GenerateRegex(wsynthetical_star));//综合    
                #endregion

                #region//数据展示
                showdata = "链接：" + model.url + "<br/>" +
                "标题：" + model.title + "<br/>" +
                "车型：" + model.car + "<br/>" +
                "类型：" + model.type + "<br/>" +
                "购车日期：" + model.buydata + "<br/>" +
                "购车地址：" + model.malladdr + "<br/>" +//购车地址
                "购车价格：" + model.price + "<br/>" +
                "油耗：" + model.oil + "<br/>" +

                "油耗评价：" + model.oil_sum + "<br/>" +//
                "油耗评分：" + model.operation + "<br/>" +//操控
                "性价比评价：" + model.costperfor + "<br/>" +//性价比
                "配置评价：" + model.config + "<br/>" +
                "舒适度评价：" + model.comfort + "<br/>" +//舒适度
                "空间评价：" + model.space + "<br/>" +//
                "动力评价：" + model.power + "<br/>" +//
                "外观评价：" + model.appearance + "<br/>" +
                "内饰评价：" + model.inside + "<br/>" +
                "综合评价：" + model.synthetical + "<br/>" +//综合
                "微口碑评价：" + model.wsynthetical + "<br/>" +//综合
                "油耗评分：" + model.oil_star + "<br/>" +
                "操控评分：" + model.operation_star + "<br/>" +//操控
                "性价比评分：" + model.costperfor_star + "<br/>" +//性价比
                "配置评分：" + model.config_star + "<br/>" +
                "舒适度评分：" + model.comfort_star + "<br/>" +//舒适度
                "空间评分：" + model.space_star + "<br/>" +//
                "动力评分：" + model.power_star + "<br/>" +//
                "外观评分：" + model.appearance_star + "<br/>" +
                "内饰评分：" + model.inside_star + "<br/>" +
                "综合评分：" + model.synthetical_star + "<br/>" +//综合
                "微口碑评分：" + model.wsynthetical_star + "<br/>";
                #endregion




            }
            #endregion
            return showdata;

        }


        /// <summary>
        /// 组成正则表达式
        /// </summary>
        /// <param name="startstr"></param>
        /// <param name="endstr"></param>
        /// <returns></returns>
        private string AssemblyReg(string startstr, string endstr)
        {
            return startstr + "([\\S\\s]*?)" + endstr;
        }
    }
}