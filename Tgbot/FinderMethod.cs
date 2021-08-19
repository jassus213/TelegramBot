using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot.Commands
{
    class FinderMethod
    {
        
        public string Finder()
        {
            Random people = new Random();
            string[] strs = System.IO.File.ReadAllLines("C:\\BaseForPeoples.txt", Encoding.Default);
            string s = strs[people.Next(strs.Length)];
            string otvet = s.Split("\n")[0];
            return otvet;
        }
        
    }
}
