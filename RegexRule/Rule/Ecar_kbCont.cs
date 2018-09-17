using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexCenter.Rule
{
    public class Ecar_kbCont
    {
        #region//具体口碑页面的正则表达式
        public Regex title = new Regex("<divclass=\"main-box\">\\s*<h6>([\\s\\S]*?)</h6>");
        public Regex car = new Regex("<divclass=\"con-l\">\\s*?<h6>([\\s\\S]*?)</h6>");//车型
        public Regex address = new Regex("地址：<em>([\\s\\S]*?)</em>");
        public Regex buydate = new Regex("时间：<em>([\\s\\S]*?)</em>");
        public Regex price = new Regex("车价：<emclass=\"red\"><strong>([\\s\\S]*?)</strong>");
        public Regex oil = new Regex("当前油耗：<em>([\\s\\S]*?)L/100km</em>");
        public Regex type = new Regex("<spanclass=\"blue\">([\\s\\S]*?)</span>");
        public Regex satisfied = new Regex("满&nbsp;&nbsp;意：\\s*</div>\\s*<p>([\\S\\s]*?)</p>");
        public Regex unsatisfied = new Regex("不满意：\\s*</div>\\s*<p>([\\S\\s]*?)</p>");

        public Regex oilItem = new Regex("油&nbsp;&nbsp;耗：[\\S\\s]*?width: ([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p>");//油耗分数和评价
        public Regex operationItem = new Regex("操&nbsp;&nbsp;控：[\\S\\s]*?width: ([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p>");//操控分数和评价
        public Regex costperforItem = new Regex("性价比：[\\S\\s]*?width:([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p>");//性价比分数和评价
        public Regex configItem = new Regex(" 配&nbsp;&nbsp;置：[\\S\\s]*?width: ([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p>");//配置分数和评价
        public Regex comfortItem = new Regex("舒适度：[\\S\\s]*?width:([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p>");//舒适度分数和评价
        public Regex spaceItem = new Regex("空&nbsp;&nbsp;间：[\\S\\s]*?width:([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p>");//空间分数和评价
        public Regex powerItem = new Regex("动&nbsp;&nbsp;力：[\\S\\s]*?width:([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p>");//动力分数和评价
        public Regex appearanceItem = new Regex("外&nbsp;&nbsp;观：[\\S\\s]*?width:([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p>");//外观分数和评价
        public Regex insideItem = new Regex("内&nbsp;&nbsp;饰：[\\S\\s]*?width:([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p>");//内饰分数和评价
        public Regex syntheticalItem = new Regex("综&nbsp;&nbsp;合：[\\S\\s]*?width:([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p></div>");//综合分数和评价
        public Regex syntheticalItem_wkb = new Regex("总&nbsp;&nbsp;&nbsp;评：[\\S\\s]*?width:([\\S\\s]*?)%[\\S\\s]*?<p>([\\S\\s]*?)</p></div>");//综合分数和评价(微口碑)
        #endregion

    }
}
