using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot.Commands
{
    class GetValueSubs
    {
        private static DateTime _time;
        private static string _result;
        private string _link;

        public string GetSubs(string arguments)
        {
            ClientForSub clientnew = new ClientForSub();
            clientnew.ClientCall();
            LinkCheck link = new LinkCheck(arguments);
            _link = link.LinkChecker(arguments);
            try
            {


                var el = "\"youtube-stats-header-subs\" style = \"display: none;\">";
                var end = "</span>";
                var startindex = _link.IndexOf(el);

                if (startindex >= 0)
                {
                    var lenght = startindex + el.Length;
                    var endindex = _link.IndexOf(end, lenght, 20);
                    var result = _link.Substring(lenght, endindex - lenght);
                    _time = DateTime.Now;
                    
                    




                    Console.WriteLine($"Значение обновлено {result}");
                    return result;

                }
                return string.Empty;
            }
            catch
            {
                return "error";
            }
        }


        public string CheckTimeForSubs(string arguments)
        {

            
            if ((DateTime.Now - _time).TotalMinutes > 60)
            {

                _result = GetSubs(arguments);
            }



            
            return _result;

        }



    }
}
