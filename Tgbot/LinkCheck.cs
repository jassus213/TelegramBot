using System;
using System.Collections.Generic;
using System.Text;
using Tgbot.Commands;

namespace Tgbot
{
    
    class LinkCheck
    {
        private string _link;
        public LinkCheck(string link)
        {
            _link = link;
        }
        public string LinkChecker(string arguments)
        {
            ClientForSub clientnew = new ClientForSub();
            clientnew.ClientCall();

           
                _link = clientnew._clientnew.DownloadString("https://socialblade.com/youtube/c/" + arguments.Trim());
                return _link;
        }

    }
}
