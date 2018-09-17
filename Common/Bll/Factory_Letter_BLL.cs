using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Common.Dal;

namespace Common.Bll
{
    public class Factory_Letter_BLL
    {
        Product_Dal BLL = new Product_Dal();
        /// <summary>
        /// 根据品牌编号获取厂商信息
        /// </summary>
        /// <param name="B_ID"></param>
        /// <returns></returns>
        public DataTable Get_Factory(string B_ID)
        {
            return BLL.Get_Factory(B_ID);
        }
    }
}
