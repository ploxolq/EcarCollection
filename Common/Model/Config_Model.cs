using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model
{
    public class Config_Model
    {
        public string ID { get; set; }
        public string Series { get; set; }
        public string Userid { get; set; }
        public string ListUrl { get; set; }
        public string ContUrl{get;set;}
        public string ListRule{get;set;}
        public string ContRule{get;set;}
        public string SourceWeb{get;set;}
        public string RegexName { get; set; }
    }
}
