using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot.Commands
{
    class FinderCommand : ICommand
    {
        public string CmdName => "/Finder";

        public string Run(string arguments)
        {
            FinderMethod finder = new FinderMethod();
            var otvet = finder.Finder();
            return otvet;
        }
    }
}
