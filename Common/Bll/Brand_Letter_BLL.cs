using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Dal;
using System.Data;

namespace Common.Bll
{
    public class Brand_Letter_BLL
    {
        Product_Dal BLL = new Product_Dal();
        /// <summary>
        /// 获取所的品牌信息
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Brand()
        {
            return BLL.Get_Brand();
        }

    }
}
