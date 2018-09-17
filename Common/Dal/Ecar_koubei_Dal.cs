using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Sqlhelper;
using Common.Model;
using System.Data.SqlClient;
using System.Data;

namespace Common.Dal
{
    public class Ecar_koubei_Dal
    {
        Ecar_koubei_DB BLL = new Ecar_koubei_DB();

        /// <summary>
        /// 保存口碑具体数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Save(ecar_content model)
        {
            string sql = "insert into Ecar_Koubei (url,title,type,buydata,malladdr,price,oil,satisfied,unsatisfied,operation_star,operation,costperfor_star,costperfor,config_star,config,comfort_star,comfort,space_star,space,power_star,power,appearance_star,appearance,inside_star,inside,synthetical_star,synthetical,Car,oil_star,oil_sumy)values(@url,@title,@type,@buydata,@malladdr,@price,@oil,@satisfied,@unsatisfied,@operation_star,@operation,@costperfor_star,@costperfor,@config_star,@config,@comfort_star,@comfort,@space_star,@space,@power_star,@power,@appearance_star,@appearance,@inside_star,@inside,@synthetical_star,@synthetical,@Car,@oil_star,@oil_sumy);";

            SqlParameter[] pars = new SqlParameter[] {
            new SqlParameter("@url",model.url),
            new SqlParameter("@title",model.title),
            new SqlParameter("@type",model.type),
            new SqlParameter("@buydata",model.buydata),
            new SqlParameter("@malladdr",model.malladdr),
            new SqlParameter("@price",model.price),
            new SqlParameter("@oil",model.oil),
            new SqlParameter("@satisfied",model.satisfied),
            new SqlParameter("@unsatisfied",model.unsatisfied),
            new SqlParameter("@operation_star",model.operation_star),
            new SqlParameter("@operation",model.operation),
            new SqlParameter("@costperfor_star",model.costperfor_star),
            new SqlParameter("@costperfor",model.costperfor),
            new SqlParameter("@config_star",model.config_star),
            new SqlParameter("@config",model.config),
            new SqlParameter("@comfort_star",model.comfort_star),
            new SqlParameter("@comfort",model.comfort),
            new SqlParameter("@space_star",model.space_star),
            new SqlParameter("@space",model.space),
            new SqlParameter("@power_star",model.power_star),
            new SqlParameter("@power",model.power),
            new SqlParameter("@appearance_star",model.appearance_star),
            new SqlParameter("@appearance",model.appearance),
            new SqlParameter("@inside_star",model.inside_star),
            new SqlParameter("@inside",model.inside),
            new SqlParameter("@synthetical_star",model.synthetical_star),
            new SqlParameter("@synthetical",model.synthetical),
            new SqlParameter("@Car",model.car),
            new SqlParameter("@oil_star",model.oil_star),
            new SqlParameter("@oil_sumy",model.oil_sum)
        };
            return BLL.ExecuteNonQuery(sql, pars);
        }

        /// <summary>
        /// 保存列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Setlist(ecar_list model) {
            string sql = "insert into UrlList (Series,Car,Titile,Url,SourceWeb,RGid) values(@Series,@Car,@Titile,@Url,@SourceWe,@RGid)";
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@Series",model.series),
                new SqlParameter("@Car",model.car),
                new SqlParameter("@Titile",model.title),
                new SqlParameter("@Url",model.url),
                new SqlParameter("@SourceWe",model.source),
                new SqlParameter("@RGid",model.rgid)
            };
            return BLL.ExecuteNonQuery(sql, pars);

        }

        /// <summary>
        /// 获取未处理链接
        /// </summary>
        /// <param name="series"></param>
        /// <returns></returns>
        public DataTable GetList(string series) 
        {
            string sql = "select * from UrlList where Series =@series and Is_examine ='0' and ID in (select ID from (select ID,ROW_NUMBER() over (order by ID asc) as IDRank from UrlList) as lis_tab where IDRank > 0 and IDRank < 11)order by ID desc ";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter ("@series",series)
            };
            return BLL.GetTable(sql,pars);
        }

        /// <summary>
        /// 检查链接是否已采集
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public int CheckUrl(string Url)
        {
            string sql = "select COUNT(ID) from UrlList where Url =@Url";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter ("@Url",Url)
            };
            return BLL.ExecuteInt(sql, pars);
        }

        /// <summary>
        /// 已处理方法
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public int Examine(string Url) {
            string sql = "update UrlList set Is_examine = '1' where Url = @Url";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter ("@Url",Url)
            };
            return BLL.ExecuteNonQuery(sql, pars);
        }

        /// <summary>
        /// 已处理方法_删除
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public int Examine_Del(string Url)
        {
            string sql = "update UrlList set Is_examine = '2' where Url = @Url";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter ("@Url",Url)
            };
            return BLL.ExecuteNonQuery(sql, pars);
        }

        /// <summary>
        /// 删除配置
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DelConfig(string ID) 
        {
            string sql = "delete WebRegexConfig where ID=@ID";
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@ID",ID)
            };
            return BLL.ExecuteNonQuery(sql,pars);
        }

        /// <summary>
        /// 获取配置列表
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetConfig(string ID)
        {
            string sql = "select ID,Userid,ListUrl,ContUrl,ListRule,ContRule,SourceWeb,RegexName,Series from WebRegexConfig where ID =@ID";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ID",ID)
            };
            return BLL.GetTable(sql, pars);
        }
        /// <summary>
        /// 获取配置列表
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetConfig()
        {
            string sql = "select ID,Userid,SourceWeb,RegexName,Series from WebRegexConfig where ID in (select ID from (select ID,ROW_NUMBER() over (order by ID asc) as IDRank from WebRegexConfig) as lis_tab where IDRank > 0 and IDRank < 11)order by ID desc ";

            return BLL.GetTable(sql);
        }        
        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddConfig(Config_Model model) {
            string sql = "insert WebRegexConfig (Userid,ListUrl,ContUrl,ListRule,ContRule,SourceWeb,RegexName,Series)values            (@Userid,@ListUrl,@ContUrl,@ListRule,@ContRule,@SourceWeb,@RegexName,@Series)";
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@Userid",model.Userid),
                new SqlParameter("@ListUrl",model.ListUrl),
                new SqlParameter("@ContUrl",model.ContUrl),
                new SqlParameter("@ListRule",model.ListRule),
                new SqlParameter("@ContRule",model.ContRule),
                new SqlParameter("@SourceWeb",model.SourceWeb),
                new SqlParameter("@RegexName",model.RegexName),
                new SqlParameter("@Series",model.Series)
            };
            return BLL.ExecuteNonQuery(sql, pars);
        }

        /// <summary>
        /// 更新配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateConfig(Config_Model model) {
            string sql = "update WebRegexConfig set ListUrl=@ListUrl,ContUrl=@ContUrl,ListRule=@ListRule,ContRule=@ContRule,SourceWeb=@SourceWeb,Series=@Series,RegexName=@RegexName where ID=@ID";
            SqlParameter[] pars = new SqlParameter[] { 
                new SqlParameter("@ListUrl",model.ListUrl),
                new SqlParameter("@ContUrl",model.ContUrl),
                new SqlParameter("@ListRule",model.ContUrl),
                new SqlParameter("@ContRule",model.ContRule),
                new SqlParameter("@SourceWeb",model.SourceWeb),
                new SqlParameter("@RegexName",model.RegexName),
                new SqlParameter("@ID",model.ID),
                new SqlParameter("@Series",model.Series)
            };
            return BLL.ExecuteNonQuery(sql, pars);
        }

        /// <summary>
        /// 删除Url
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DelUrl(string ID) {
            string sql = "delete UrlList where ID=@ID;";
            SqlParameter[] pars = new SqlParameter[] { 
                new SqlParameter("@ID",ID)
            };
            return BLL.ExecuteNonQuery(sql,pars);
        }
    }
}
