using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot.Commands
{
    class HelloCommand : ICommand
    {
        public string CmdName => "/Hello";


        public string Run(string arguments)
        {
            return "test";
        }
    }
}
