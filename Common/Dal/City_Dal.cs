using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Sqlhelper;
using System.Data;
using System.Data.SqlClient;

namespace Common.Dal
{
    public class City_Dal
    {
        private City_SQL BLL = new City_SQL();

        #region
        /// <summary>
        /// 根据省份编号获取城市信息()
        /// </summary>
        /// <returns></returns>
        public DataTable Get_City(string P_Code)
        {
            SqlParameter[] pars = new SqlParameter[] { 
            new SqlParameter("@P_Code",P_Code)
            };
            return BLL.ProcDataTable("get_city", pars);
        }
        /// <summary>
        /// 根据城市编码获取省份编号
        /// </summary>
        /// <param name="C_Code"></param>
        /// <returns></returns>
        public string Get_Province_C(string C_Code)
        {
            SqlParameter[] pars = new SqlParameter[] { 
            new SqlParameter("@C_Code",C_Code)
            };
            return BLL.ProcExecuteString("get_city_province", pars);
        }
        public DataTable Get_CityInfo(string C_Code)
        {
            string sql = "select C_Name ,C_Code,P_Name from V_City as a join  V_Province as b on a.P_Code= b.P_Code where C_Code = @C_Code ";
            SqlParameter[] pars = { 
                       new SqlParameter("@C_Code",C_Code)           
                                  };
            return BLL.GetTable(sql, pars);
        }
        #endregion

        #region//省份
        /// <summary>
        /// 获取所有省份信息
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Province()
        {
            return BLL.ProcDataTable("get_province");
        }
        /// <summary>
        /// 根据省份编号获取省份信息
        /// </summary>
        /// <param name="P_Code"></param>
        /// <returns></returns>
        public DataTable Get_Province_P(string P_Code)
        {
            SqlParameter[] pars = new SqlParameter[] { 
            new SqlParameter("@P_Code",P_Code)
            };
            return BLL.ProcDataTable("get_province", pars);
        }
        #endregion
    }
}
