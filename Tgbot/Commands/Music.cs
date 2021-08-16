using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot
{
    class Music : ICommand
    {

        public string CmdName => "/Music";


        public string Run(string arguments)
        {
            Random link = new Random();
            string[] strs = System.IO.File.ReadAllLines("C:\\music.txt", Encoding.Default);
            string s = strs[link.Next(strs.Length)];
            string otvet = s.Split("\n")[0];



            return otvet;

        }
    }
}
