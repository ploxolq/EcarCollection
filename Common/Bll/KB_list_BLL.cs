using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Model;
using Common.Dal;
using System.Data;

namespace Common.Bll
{
    public class KB_list_BLL
    {
        private Ecar_koubei_Dal BLL = new Ecar_koubei_Dal();

        /// <summary>
        /// 单项项匹配
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public string One_Match(string data, Regex rule)
        {
            string value = rule.Match(data).Groups[1].Value;
            return value;
        }

        /// <summary>
        /// 多项匹配
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public MatchCollection Matchs(string data, Regex rule)
        {
            MatchCollection mc = rule.Matches(data);
            return mc;
        }

        /// <summary>
        /// 保存url（单条）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SetList(ecar_list model) {
            return BLL.Setlist(model);
        }
        /// <summary>
        /// 获取采集到的Url
        /// </summary>
        /// <param name="series"></param>
        /// <returns></returns>
        public DataTable GetList(string series) {
            return BLL.GetList(series);
        }
        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public int CheckUrl(string Url) {
            return BLL.CheckUrl(Url);
        }
        /// <summary>
        /// 标记为已处理
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public int Examine(string Url)
        {
            return BLL.Examine(Url);
        }   

        /// <summary>
        /// 标记为已处理_删除
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public int Examine_Del(string Url)
        {
            return BLL.Examine_Del(Url);
        }

        /// <summary>
        /// 删除Url
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DelUrl(string ID) {
            return BLL.DelUrl(ID);
        }

    }
}
