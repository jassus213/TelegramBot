using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot
{
    interface IBotClientTg
    {
        void Start();
        void Stop();
        void AddCommand(ICommand command);
        void AddCommands(IList<ICommand> commands);
    }
}
