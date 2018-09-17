using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Sqlhelper;
using System.Data;
using System.Data.SqlClient;

namespace Common.Dal
{
    public class Ecar_koubeiC__Dal
    {
        private Ecar_KB_CHM_DB BLL = new Ecar_KB_CHM_DB();
        /// <summary>
        /// 获取所有口碑类型
        /// </summary>
        /// <returns></returns>
        public DataTable Get_ALL()
        {
            return BLL.ProcDataTable("get_evaluate_type");
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
            SqlParameter[] pars = new SqlParameter[] { 
            new SqlParameter("@E_ID",E_ID),
            new SqlParameter("@U_ID",U_ID),
            new SqlParameter("@Car_ID",Car_ID),
            new SqlParameter("@E_Title",E_Title),
            new SqlParameter("@Buy_Date",Buy_Date),
            new SqlParameter("@Buy_Price",Buy_Price),
            new SqlParameter("@M_ID",M_ID),
            new SqlParameter("@T_ID",T_ID),
            new SqlParameter("@Car_Oil",Car_Oil),
            new SqlParameter("@Oil_Score",Oil_Score),
            new SqlParameter("@Oil_Summary",Oil_Summary),
            new SqlParameter("@Power_Score",Power_Score),
            new SqlParameter("@Power_Summary",Power_Summary),
            new SqlParameter("@Cost_Score",Cost_Score),
            new SqlParameter("@Cost_Summary",Cost_Summary),
            new SqlParameter("@Config_Score",Config_Score),
            new SqlParameter("@Config_Summary",Config_Summary),
            new SqlParameter("@Drive_Score",Drive_Score),
            new SqlParameter("@Drive_Summary",Drive_Summary),
            new SqlParameter("@Space_Score",Space_Score),
            new SqlParameter("@Space_Summary",Space_Summary),
            new SqlParameter("@Appearance_Score",Appearance_Score),
            new SqlParameter("@Appearance_Summary",Appearance_Summary),
            new SqlParameter("@Comfort_Score",Comfort_Score),
            new SqlParameter("@Comfort_Summary",Comfort_Summary),
            new SqlParameter("@Inside_Score",Inside_Score),
            new SqlParameter("@Inside_Summary",Inside_Summary),
            new SqlParameter("@All_Score",All_Score),
            new SqlParameter("@All_Summary",All_Summary),
            //new SqlParameter("@Edit_Date",Edit_Date),
            //new SqlParameter("@L_ID",L_ID)
            };
            return BLL.ProcExecuteNonQuery("edit_times_evaluate", pars);
        }
    }
}
