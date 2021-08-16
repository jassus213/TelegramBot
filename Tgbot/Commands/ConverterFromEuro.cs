using System;
using System.Collections.Generic;
using System.Text;

namespace Tgbot
{
    class ConverterFromEur : ICommand
    {

        private GetCurrency _getCurrency;
        public string CmdName => "/ConverterFromEur";
        public ConverterFromEur()
        {
            _getCurrency = new GetCurrency();
        }
        public string Run(string arguments)
        {
            if (!decimal.TryParse(arguments, out var number))
            {
                return "Не является цифрой";
            }

            var result = _getCurrency.ValuteGet(CurrencyType.EUR);
            var otvet = result * number;
            var msgotvet = $"{number} Евро будет равно = {otvet} рублей";
            return msgotvet;

        }


    }
}
