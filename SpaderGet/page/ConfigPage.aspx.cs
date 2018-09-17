using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Bll;
using System.Data;
using Common.Model;
using Newtonsoft.Json;

namespace SpaderGet.page
{
    public partial class Content : System.Web.UI.Page
    {
        public string id = "0";
        private Config_BLL BLL = new Config_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] != null) {
                id = Request["id"].ToString().Trim();
                DataTable ConfigDT =  BLL.GetConfig(id);
                RegexCont_Model RCmodel = JsonConvert.DeserializeObject<RegexCont_Model>(ConfigDT.Rows[0]["ContRule"].ToString());
                RegexList_Model RLmodel = JsonConvert.DeserializeObject<RegexList_Model>(ConfigDT.Rows[0]["ListRule"].ToString());

            }

            

        }
    }
}