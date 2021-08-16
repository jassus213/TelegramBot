using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot
{
    class HelpCommand : ICommand
    {
        private IList<ICommand> _commands;
        public string CmdName => "/Help";

        public HelpCommand(IList<ICommand> commands)
        {
            _commands = commands;
        }


        public string Run(string arguments)
        {
            string result = string.Empty;

            foreach (var command in _commands)
            {
                result += command.CmdName + "\n";
            }



            return result;
        }
    }
}
