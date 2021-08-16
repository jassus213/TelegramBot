using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot
{
    class ConverterFromDollar : ICommand
    {
        private GetCurrency _getCurrency;
        public string CmdName => "/ConverterFromDollar";
        public ConverterFromDollar()
        {
            _getCurrency = new GetCurrency();
        }
        public string Run(string arguments)
        {
            if (!decimal.TryParse(arguments, out var number))
            {
                return "Не является цифрой";
            }

            var result = _getCurrency.ValuteGet(CurrencyType.USD);
            var otvet = result * number;
            var msgotvet = $"{number} Долларов будет равно = {otvet} рублей";

            return msgotvet;

        }
    }
}
