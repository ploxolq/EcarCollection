using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexCenter.Rule
{
    public  class Ecar_list
    {
        #region//url采集正则表达式
        public  Regex Gengduo = new Regex("aTopicListUrl\" href=\"([\\S\\s]*?)\" rel");//检查是否存在多页
        public  Regex Ueritem = new Regex("<divclass=\"kb-list-box\">([\\S\\s]*?)</div></div></div></div>");//用户组

        public  Regex herfItem = new Regex("<divclass=\"main\"style=\"display:block\">([\\S\\s]*?)</a>");//口碑Url组
        public  Regex title = new Regex("<divclass=\"titbox\"><a[\\S\\s]*?>([\\S\\s]*?)</a>");
        public  Regex Url = new Regex("<divclass=\"titbox\"><ahref=\"([\\S\\s]*?)\"targe");

        public  Regex listcar = new Regex("<h6>([\\S\\s]*?)</h6>");//车型
        public  Regex maxpage = new Regex("pageCount = ([\\d]{1,5});");//获取最大页码
        public  Regex carid = new Regex("koubei/gengduo/([\\d]{1,9})-0");//获取carId
        #endregion

    }

}
