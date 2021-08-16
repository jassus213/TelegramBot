using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot
{
    class TimeCommand : ICommand
    {
        public string CmdName => "/Time";


        public string Run(string arguments)
        {
            return $"Время сейчас: {DateTime.Now.ToString()}";
        }
    }
}
