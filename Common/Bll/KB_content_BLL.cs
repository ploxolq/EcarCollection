using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Dal;
using System.Data;

namespace Common.Bll
{
    public class KB_content_BLL
    {
        Ecar_koubeiC__Dal BLL = new Ecar_koubeiC__Dal();
        /// <summary>
        /// 获取所有口碑类型
        /// </summary>
        /// <returns></returns>
        public DataTable Get_ALL()
        {
            return BLL.Get_ALL();
        }

        /// <summary>
        /// 编辑口碑信息(添加\修改)
        /// </summary>
        /// <param name="E_ID"></param>
        /// <param name="U_ID"></param>
        /// <param name="Car_ID"></param>
        /// <param name="E_Title"></param>
        /// <param name="Buy_Date"></param>
        /// <param name="Buy_Price"></param>
        /// <param name="M_ID"></param>
        /// <param name="T_ID"></param>
        /// <param name="Car_Oil"></param>
        /// <param name="Use_Cost"></param>
        /// <param name="Use_Mile"></param>
        /// <param name="Oil_Score"></param>
        /// <param name="Oil_Summary"></param>
        /// <param name="Power_Score"></param>
        /// <param name="Power_Summary"></param>
        /// <param name="Cost_Score"></param>
        /// <param name="Cost_Summary"></param>
        /// <param name="Config_Score"></param>
        /// <param name="Config_Summary"></param>
        /// <param name="Drive_Score"></param>
        /// <param name="Drive_Summary"></param>
        /// <param name="Space_Score"></param>
        /// <param name="Space_Summary"></param>
        /// <param name="Appearance_Score"></param>
        /// <param name="Appearance_Summary"></param>
        /// <param name="Comfort_Score"></param>
        /// <param name="Comfort_Summart"></param>
        /// <param name="Inside_Score"></param>
        /// <param name="Inside_Summary"></param>
        /// <param name="All_Score"></param>
        /// <param name="All_Summary"></param>
        /// <param name="Edit_Date"></param>
        /// <param name="L_ID"></param>
        /// <returns></returns>
        public int Edit(string E_ID, string U_ID, string Car_ID, string E_Title, DateTime Buy_Date, string Buy_Price, string M_ID, string T_ID, string Car_Oil, string Oil_Score, string Oil_Summary, string Power_Score, string Power_Summary, string Cost_Score, string Cost_Summary, string Config_Score, string Config_Summary, string Drive_Score, string Drive_Summary, string Space_Score, string Space_Summary, string Appearance_Score, string Appearance_Summary, string Comfort_Score, string Comfort_Summary, string Inside_Score, string Inside_Summary, string All_Score, string All_Summary)
        {
            return BLL.Edit(E_ID, U_ID, Car_ID, E_Title, Buy_Date, Buy_Price, M_ID, T_ID, Car_Oil, Oil_Score, Oil_Summary, Power_Score, Power_Summary, Cost_Score, Cost_Summary, Config_Score, Config_Summary, Drive_Score, Drive_Summary, Space_Score, Space_Summary, Appearance_Score, Appearance_Summary, Comfort_Score, Comfort_Summary, Inside_Score, Inside_Summary, All_Score, All_Summary);
        }

    }
}
