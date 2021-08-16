using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace Tgbot
{
    class GetCurrency
    {
        private WebClient _client;

        public GetCurrency()
        {
            _client = new WebClient();
        }

        public decimal ValuteGet(string type)
        {
            var xml = _client.DownloadString("https://www.cbr-xml-daily.ru/daily.xml");
            XDocument xdoc = XDocument.Parse(xml);
            var el = xdoc.Element("ValCurs").Elements("Valute");

            var value = (el.Where(x => x.Attribute("ID").Value == type).Select(x => x.Element("Value").Value).FirstOrDefault());
            if (string.IsNullOrEmpty(value))
                return 0.0m;

            return decimal.Parse(value);
        }
    }
    public class CurrencyType
    {
        public static string USD = "R01235";
        public static string EUR = "R01239";
    }
}