using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot
{
    class ConverterDollar : ICommand
    {
        private GetCurrency _getCurrency;
        public string CmdName => "/course_Dollar";


        public ConverterDollar(GetCurrency getCurrency)
        {
            _getCurrency = getCurrency;
        }


        public string Run(string arguments)
        {
            var result = _getCurrency.ValuteGet(CurrencyType.USD);
            var otvet = $"Курс Доллара равен: {result}";
            return otvet;
        }
    }
}
