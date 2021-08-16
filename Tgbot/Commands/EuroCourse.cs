using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot
{
    class ConverterEur : ICommand
    {
        private GetCurrency _getCurrency;
        public string CmdName => "/course_Euro";
        public decimal result;


        public ConverterEur(GetCurrency getCurrency)
        {
            _getCurrency = getCurrency;
        }


        public string Run(string arguments)
        {
            result = _getCurrency.ValuteGet(CurrencyType.EUR);
            var otvet = $"Курс Евро равен: {result}";
            return otvet;
        }
    }
}
