using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Tgbot.Commands
{
    class ClientForSub
    {
        public WebClient _clientnew;
        public void ClientCall()
        {
            _clientnew = new WebClient();
            _clientnew.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4450.0 Iron Safari/537.36");
        }
    }
}
