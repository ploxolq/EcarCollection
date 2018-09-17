using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Sqlhelper;
using System.Data;
using System.Data.SqlClient;

namespace Common.Dal
{
    public class Product_Dal
    {
        Product_SQL BLL = new Product_SQL();

        /// <summary>
        /// 获取所的品牌信息
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Brand()
        {
            return BLL.ProcDataTable("get_all_brand");
        }
        /// <summary>
        /// 根据品牌编号获取厂商信息
        /// </summary>
        /// <param name="B_ID"></param>
        /// <returns></returns>
        public DataTable Get_Factory(string B_ID)
        {
            SqlParameter[] pars = new SqlParameter[] { 
            new SqlParameter("@B_ID",B_ID)
            };
            return BLL.ProcDataTable("get_factory", pars);
        }
        /// <summary>
        /// 根据厂商编号获取车系信息
        /// </summary>
        /// <param name="F_ID"></param>
        /// <returns></returns>
        public DataTable Get_Factory_Series(string F_ID)
        {
            SqlParameter[] pars = new SqlParameter[] { 
            new SqlParameter("@F_ID",F_ID)
            };
            return BLL.ProcDataTable("get_series_all", pars);
        }

        /// <summary>
        /// 根据车系编号获取在售年款
        /// </summary>
        /// <param name="S_ID"></param>
        /// <returns></returns>
        public DataTable Get_Sell_Year(string S_ID)
        {
            SqlParameter[] pars = new SqlParameter[] { 
            new SqlParameter("@S_ID",S_ID)
            };
            return BLL.ProcDataTable("get_series_sell_year", pars);
        }

        /// <summary>
        /// 根据车系编号获取在售车型
        /// </summary>
        /// <param name="S_ID"></param>
        /// <returns></returns>
        public DataTable Get_Sell_Car(string S_ID)
        {
            SqlParameter[] pars = new SqlParameter[] { 
            new SqlParameter("@S_ID",S_ID)
            };
            return BLL.ProcDataTable("get_sell_car", pars);
        }
        /// <summary>
        /// 根据车系编号、年款编号获取在售车型
        /// </summary>
        /// <param name="S_ID"></param>
        /// <param name="Y_ID"></param>
        /// <returns></returns>
        public DataTable Get_Sell_Car(string S_ID, string Y_ID)
        {
            SqlParameter[] pars = new SqlParameter[] { 
                new SqlParameter("@S_ID",S_ID),
                new SqlParameter("@Y_ID",Y_ID)
            };
            return BLL.ProcDataTable("get_sell_car", pars);
        }

        /// <summary>
        /// 根据车系编号查品牌
        /// </summary>
        /// <param name="S_ID"></param>
        /// <returns></returns>
        public string Get_Brand(string S_ID) {
            string sql = "select B_ID from V_Car where S_ID=@S_ID";
            SqlParameter[] pars = new SqlParameter[] { 
                new SqlParameter("@S_ID",S_ID)
            };
            return BLL.ExecuteString(sql, pars);
        }

    }
}
