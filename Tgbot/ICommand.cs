using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot
{
    interface ICommand
    {
        string CmdName { get; }
        string Run(string arguments);

    }
}
