using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexCenter.Method
{
    public class Method
    {
        /// <summary>
        /// 单项项匹配
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public string One_Match(string data, Regex rule)
        {
            string value = rule.Match(data).Groups[1].Value;
            return value;
        }

        /// <summary>
        /// 多项匹配
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public MatchCollection Matchs(string data, Regex rule)
        {
            MatchCollection mc = rule.Matches(data);
            return mc;
        }

        /// <summary>
        /// 生成regex
        /// </summary>
        /// <param name="regex"></param>
        /// <returns></returns>
        public Regex GenerateRegex(string regex) 
        {
            return new Regex(regex);
        }

    }
}
