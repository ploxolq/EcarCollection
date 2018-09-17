using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Dal;
using System.Data;

namespace Common.Bll
{
    public class City_BLL
    {
        City_Dal BLL = new City_Dal();
        /// <summary>
        /// 根据省份编号获取城市信息
        /// </summary>
        /// <returns></returns>
        public DataTable Get_City(string P_Code)
        {
            return BLL.Get_City(P_Code);
        }
        /// <summary>
        /// 获取所有省份信息
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Province()
        {
            return BLL.Get_Province();
        }
        /// <summary>
        /// 根据城市编码获取省份编号
        /// </summary>
        /// <param name="C_Code"></param>
        /// <returns></returns>
        public string Get_Province(string C_Code)
        {
            return BLL.Get_Province_C(C_Code);
        }
        /// <summary>
        /// 根据城市id获取城市信息
        /// </summary>
        /// <param name="C_Code"></param>
        /// <returns></returns>
        public DataTable Get_CityInfo(string C_Code)
        {
            return BLL.Get_CityInfo(C_Code);
        }
    }
}
