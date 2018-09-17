using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Dal;
using System.Data;

namespace Common.Bll
{
    public class V_Series_BLL
    {
        Product_Dal BLL = new Product_Dal();
        /// <summary>
        /// 根据厂商编号获取车系信息
        /// </summary>
        /// <param name="F_ID"></param>
        /// <returns></returns>
        public DataTable Get_Factory_Series(string F_ID)
        {
            return BLL.Get_Factory_Series(F_ID);
        }

        public string Get_Brand(string S_ID) {
            return BLL.Get_Brand(S_ID);
        }

    }
}
