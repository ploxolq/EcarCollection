using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheadContral
{
    class Program
    {
        delegate void talk();
        static void Main(string[] args)
        {
            string a = "abcdefg";
            string[] b = new string[a.Length];
            for (int i = 0; i < a.Length / 2; i++)
            {
                b[i] = a.Substring(i * 2, 2);
                Console.WriteLine(b[i]);
            }
            Console.Read();
        }

        public static void say() {
            Console.WriteLine("盗将行");
        }
    }
}
