using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal class Helper
    {
        public static string GetFirstCharacter(string input)
        {
            //asp.net core
            return input.Substring(0, 1);
        }
    }
}