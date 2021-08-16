using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot.Commands
{
    class SubcribersCommand : ICommand
    {
        public string CmdName => "/Subcribers";
        private string _resultsubs;
       

        public string Run(string arguments)
        {

            try
            {
                GetValueSubs subs = new GetValueSubs();
                _resultsubs = subs.CheckTimeForSubs(arguments);

                
            }
            catch
            {
                return "Неизвестный аккаунт";
            }








            var answerforuser = $"Количество подписчиков у {arguments} = {_resultsubs}";

            return answerforuser;


        }

    }
}
