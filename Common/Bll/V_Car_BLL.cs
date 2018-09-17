using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Common.Dal;

namespace Common.Bll
{
    public class V_Car_BLL
    {
        Product_Dal BLL = new Product_Dal();
        /// <summary>
        /// 根据车系编号获取在售年款
        /// </summary>
        /// <param name="S_ID"></param>
        /// <returns></returns>
        public DataTable Get_Sell_Year(string S_ID)
        {
            return BLL.Get_Sell_Year(S_ID);
        }
        /// <summary>
        /// 根据车系编号获取在售车型
        /// </summary>
        /// <param name="S_ID"></param>
        /// <returns></returns>
        public DataTable Get_Sell_Car(string S_ID)
        {
            return BLL.Get_Sell_Car(S_ID);
        }

        /// <summary>
        /// 根据车系编号、年款编号获取在售车型
        /// </summary>
        /// <param name="S_ID"></param>
        /// <param name="Y_ID"></param>
        /// <returns></returns>
        public DataTable Get_Sell_Car(string S_ID, string Y_ID)
        {
            return BLL.Get_Sell_Car(S_ID, Y_ID);
        }


    }
}
