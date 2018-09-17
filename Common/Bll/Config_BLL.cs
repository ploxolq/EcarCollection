using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Dal;
using Common.Model;
using System.Data;

namespace Common.Bll
{
    public class Config_BLL
    {
        private Ecar_koubei_Dal BLL = new Ecar_koubei_Dal();
        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddConfig(Config_Model model) {
            return BLL.AddConfig(model);
        }
                
        /// <summary>
        /// 更新配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateConfig(Config_Model model)
        {
            return BLL.UpdateConfig(model);
        }
         /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetConfig(string ID) {
            return BLL.GetConfig(ID);
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetConfig()
        {
            return BLL.GetConfig();
        }
               
        /// <summary>
        /// 删除配置
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DelConfig(string ID) {
            return BLL.DelConfig(ID);
        }
    }
}
