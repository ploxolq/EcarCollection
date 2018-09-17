using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Common.Model;
using System.Text;
using Common.Bll;

namespace SpaderGet.ajax
{
    /// <summary>
    /// edit_config 的摘要说明
    /// </summary>
    public class edit_config : IHttpHandler
    {
        private string id = "0";//配置id
        private Config_BLL BLL = new Config_BLL();
        #region
        private string uid = string.Empty;
        private string rgname = string.Empty;
        private string series = string.Empty;
        private string source = string.Empty;
        #endregion
        #region//list字段
        string listurl = string.Empty;
        string reg_list = string.Empty;
        string reg_user = string.Empty;
        string reg_car = string.Empty;
        string reg_url = string.Empty;
        string reg_title = string.Empty;
        #endregion
        #region//content字段
        private string conturl = string.Empty;
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
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["rgname"] != null)
            {
                rgname = context.Request["rgname"].Trim().ToString();
            }
            if (context.Request["series"] != null)
            {
                series = context.Request["series"].Trim().ToString();
            }
            if (context.Request["source"] != null)
            {
                source = context.Request["source"].Trim().ToString();
            } 
            if (context.Request["uid"] != null)
            {
                uid = context.Request["uid"].Trim().ToString();
            }

            #region//listReg
            if (context.Request["txt_seedurl"] != null)
            {
                listurl = context.Request["txt_seedurl"].Trim().ToString();
            }
            if (context.Request["tr_liststart"] != null && context.Request["tr_listend"] != null)
            {
                reg_list = AssemblyReg(context.Request["tr_liststart"].Trim().ToString(), context.Request["tr_listend"].ToString().Trim());
            }
            if (context.Request["tr_userstart"] != null && context.Request["tr_userend"] != null)
            {
                reg_user = AssemblyReg(context.Request["tr_userstart"].Trim().ToString(), context.Request["tr_userend"].ToString().Trim());
            }
            if (context.Request["txt_carstart"] != null && context.Request["txt_carend"] != null)
            {
                reg_car = AssemblyReg(context.Request["txt_carstart"].Trim().ToString(), context.Request["txt_carend"].ToString().Trim());
            }

            if (context.Request["txt_urlstart"] != null && context.Request["txt_urlend"] != null)
            {
                reg_url = AssemblyReg(context.Request["txt_urlstart"].Trim().ToString(), context.Request["txt_urlend"].ToString().Trim());
            }

            if (context.Request["txt_titlestart"] != null && context.Request["txt_titleend"] != null)
            {
                reg_title = AssemblyReg(context.Request["txt_titlestart"].Trim().ToString(), context.Request["txt_titleend"].ToString().Trim());
            }
            #endregion

            #region//contentReg
            if (context.Request["txt_cont_url"] != null)
            {
                conturl = context.Request["txt_cont_url"].Trim().ToString();
            }
            if (context.Request["txt_Ccarstart"] != null && context.Request["txt_Ccarend"] != null)
            {
                car = AssemblyReg(context.Request["txt_Ccarstart"].Trim().ToString(), context.Request["txt_Ccarend"].ToString().Trim());
            }
            if (context.Request["txt_Ctitlestart"] != null && context.Request["txt_Ctitleend"] != null)
            {
                title = AssemblyReg(context.Request["txt_Ctitlestart"].Trim().ToString(), context.Request["txt_Ctitleend"].ToString().Trim());
            }
            if (context.Request["txt_Ctypestart"] != null && context.Request["txt_Ctypeend"] != null)
            {
                type = AssemblyReg(context.Request["txt_Ctypestart"].Trim().ToString(), context.Request["txt_Ctypeend"].ToString().Trim());
            }
            if (context.Request["txt_Cdatestart"] != null && context.Request["txt_Cdateend"] != null)
            {
                buydata = AssemblyReg(context.Request["txt_Cdatestart"].Trim().ToString(), context.Request["txt_Cdateend"].ToString().Trim());
            }
            if (context.Request["txt_Caddstart"] != null && context.Request["txt_Caddend"] != null)
            {
                malladdr = AssemblyReg(context.Request["txt_Caddstart"].Trim().ToString(), context.Request["txt_Caddend"].ToString().Trim());
            }
            if (context.Request["txt_Cpricestart"] != null && context.Request["txt_Cprieceend"] != null)
            {
                price = AssemblyReg(context.Request["txt_Cpricestart"].Trim().ToString(), context.Request["txt_Cprieceend"].ToString().Trim());
            }
            if (context.Request["txt_oilstart"] != null && context.Request["txt_oilend"] != null)
            {
                oil = AssemblyReg(context.Request["txt_oilstart"].Trim().ToString(), context.Request["txt_oilend"].ToString().Trim());
            }
            if (context.Request["txt_oilstarstart"] != null && context.Request["txt_oilstarend"] != null)
            {
                oil_star = AssemblyReg(context.Request["txt_oilstarstart"].Trim().ToString(), context.Request["txt_oilstarend"].ToString().Trim());
            }
            if (context.Request["txt_oilsumstart"] != null && context.Request["txt_oilsumend"] != null)
            {
                oil_sum = AssemblyReg(context.Request["txt_oilsumstart"].Trim().ToString(), context.Request["txt_oilsumend"].ToString().Trim());
            }
            if (context.Request["txt_caozuostartstart"] != null && context.Request["txt_caozuostarend"] != null)
            {
                operation_star = AssemblyReg(context.Request["txt_caozuostartstart"].Trim().ToString(), context.Request["txt_caozuostarend"].ToString().Trim());
            }
            if (context.Request["txt_caozuosumstart"] != null && context.Request["txt_caozuosumend"] != null)
            {
                operation = AssemblyReg(context.Request["txt_caozuosumstart"].Trim().ToString(), context.Request["txt_caozuosumend"].ToString().Trim());
            }
            if (context.Request["txt_coststarstart"] != null && context.Request["txt_costend"] != null)
            {
                costperfor_star = AssemblyReg(context.Request["txt_coststarstart"].Trim().ToString(), context.Request["txt_costend"].ToString().Trim());
            }
            if (context.Request["txt_costsumstart"] != null && context.Request["txt_costsumend"] != null)
            {
                costperfor = AssemblyReg(context.Request["txt_costsumstart"].Trim().ToString(), context.Request["txt_costsumend"].ToString().Trim());
            }
            if (context.Request["txt_powerstarstart"] != null && context.Request["txt_powerstarend"] != null)
            {
                power_star = AssemblyReg(context.Request["txt_powerstarstart"].Trim().ToString(), context.Request["txt_powerstarend"].ToString().Trim());
            }
            if (context.Request["txt_powersumstart"] != null && context.Request["txt_powersumend"] != null)
            {
                power = AssemblyReg(context.Request["txt_powersumstart"].Trim().ToString(), context.Request["txt_powersumend"].ToString().Trim());
            }
            if (context.Request["txt_configstarstart"] != null && context.Request["txt_configstarend"] != null)
            {
                config_star = AssemblyReg(context.Request["txt_configstarstart"].Trim().ToString(), context.Request["txt_configstarend"].ToString().Trim());
            }
            if (context.Request["txt_configsumstart"] != null && context.Request["txt_configsumend"] != null)
            {
                config = AssemblyReg(context.Request["txt_configsumstart"].Trim().ToString(), context.Request["txt_configsumend"].ToString().Trim());
            }
            if (context.Request["txt_comfortstarstart"] != null && context.Request["txt_comfortstarend"] != null)
            {
                comfort_star = AssemblyReg(context.Request["txt_comfortstarstart"].Trim().ToString(), context.Request["txt_comfortstarend"].ToString().Trim());
            }
            if (context.Request["txt_comfortsumstart"] != null && context.Request["txt_comfortsumend"] != null)
            {
                comfort = AssemblyReg(context.Request["txt_comfortsumstart"].Trim().ToString(), context.Request["txt_comfortsumend"].ToString().Trim());
            }
            if (context.Request["txt_spacestarstart"] != null && context.Request["txt_spacestarend"] != null)
            {
                space_star = AssemblyReg(context.Request["txt_spacestarstart"].Trim().ToString(), context.Request["txt_spacestarend"].ToString().Trim());
            }
            if (context.Request["txt_spacesumstart"] != null && context.Request["txt_spacesumend"] != null)
            {
                space = AssemblyReg(context.Request["txt_spacesumstart"].Trim().ToString(), context.Request["txt_spacesumend"].ToString().Trim());
            }
            if (context.Request["txt_apprsstarstart"] != null && context.Request["txt_apprsstarend"] != null)
            {
                appearance_star = AssemblyReg(context.Request["txt_apprsstarstart"].Trim().ToString(), context.Request["txt_apprsstarend"].ToString().Trim());
            }
            if (context.Request["txt_apprssumstart"] != null && context.Request["txt_apprssumend"] != null)
            {
                appearance = AssemblyReg(context.Request["txt_apprssumstart"].Trim().ToString(), context.Request["txt_apprssumend"].ToString().Trim());
            }
            if (context.Request["txt_insidestarstart"] != null && context.Request["txt_insidestarend"] != null)
            {
                inside_star = AssemblyReg(context.Request["txt_insidestarstart"].Trim().ToString(), context.Request["txt_insidestarend"].ToString().Trim());
            }
            if (context.Request["txt_insidesumstart"] != null && context.Request["txt_insidesumend"] != null)
            {
                inside = AssemblyReg(context.Request["txt_insidesumstart"].Trim().ToString(), context.Request["txt_insidesumend"].ToString().Trim());
            }
            if (context.Request["txt_allstarstart"] != null && context.Request["txt_allstarend"] != null)
            {
                synthetical_star = AssemblyReg(context.Request["txt_allstarstart"].Trim().ToString(), context.Request["txt_allstarend"].ToString().Trim());
            }
            if (context.Request["txt_allsumstart"] != null && context.Request["txt_allsumend"] != null)
            {
                synthetical = AssemblyReg(context.Request["txt_allsumstart"].Trim().ToString(), context.Request["txt_allsumend"].ToString().Trim());
            }
            if (context.Request["txt_wallstarstart"] != null && context.Request["txt_wallstarend"] != null)
            {
                wsynthetical_star = AssemblyReg(context.Request["txt_wallstarstart"].Trim().ToString(), context.Request["txt_wallstarend"].ToString().Trim());
            }
            if (context.Request["txt_wallsumstart"] != null && context.Request["txt_wallsumend"] != null)
            {
                wsynthetical = AssemblyReg(context.Request["txt_wallsumstart"].Trim().ToString(), context.Request["txt_wallsumend"].ToString().Trim());
            }
            #endregion

            #region//content对象
            RegexCont_Model contmodel = new RegexCont_Model();
            contmodel.url = conturl;
            contmodel.title = title;
            contmodel.car = car;
            contmodel.type = type;
            contmodel.buydata = buydata;
            contmodel.malladdr = malladdr;//购车地址
            contmodel.price = price;
            contmodel.oil = oil;
            contmodel.oil_sum = oil_sum;//
            contmodel.operation = operation;//操控
            contmodel.costperfor = costperfor;//性价比
            contmodel.config = config;
            contmodel.comfort = comfort;//舒适度
            contmodel.space = space;//
            contmodel.power = power;//
            contmodel.appearance = appearance;
            contmodel.inside = inside;
            contmodel.synthetical = synthetical;//综合
            contmodel.wsynthetical = wsynthetical;//综合
            contmodel.oil_star = oil_star;
            contmodel.operation_star = operation_star;//操控
            contmodel.costperfor_star = costperfor_star;//性价比
            contmodel.config_star = config_star;
            contmodel.comfort_star = comfort_star;//舒适度
            contmodel.space_star = space_star;//
            contmodel.power_star = power_star;//
            contmodel.appearance_star = appearance_star;
            contmodel.inside_star = inside_star;
            contmodel.synthetical_star = synthetical_star;//综合    
            contmodel.wsynthetical_star = wsynthetical_star;//综合 
            string contentjson = JsonConvert.SerializeObject(contmodel);
            #endregion

            #region//list对象
            RegexList_Model listmodel = new RegexList_Model();
            listmodel.url = listurl;
            listmodel.userRule = reg_user;
            listmodel.urlRule = reg_url;
            listmodel.carRule = reg_car;
            listmodel.titleRule = reg_title;
            listmodel.listRule = reg_list;
            string listjson = JsonConvert.SerializeObject(listmodel);
            #endregion

            Config_Model configmodel = new Config_Model();
            configmodel.ID = id;
            configmodel.Userid = uid;
            configmodel.ListUrl =listurl;
            configmodel.ListRule = listjson;
            configmodel.ContRule = contentjson;
            configmodel.ContUrl= conturl;
            configmodel.SourceWeb = source;
            configmodel.Series = series;
            configmodel.RegexName = rgname;
            if (id == "0")
            {
                BLL.AddConfig(configmodel);
            }
            else
            {
                BLL.UpdateConfig(configmodel);
            }

            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Write(contentjson);
            context.Response.End();
        }

        private string AssemblyReg(string startstr, string endstr)
        {
            return startstr + "([\\S\\s]*?)" + endstr;
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