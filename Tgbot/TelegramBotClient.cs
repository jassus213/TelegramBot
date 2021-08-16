using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Tgbot
{

    class TelegramBotClient : IBotClientTg
    {
        public readonly List<ICommand> _commands;
        private readonly ITelegramBotClient _client;
        private readonly string _token;


        public TelegramBotClient(string token)
        {

            _commands = new List<ICommand>();
            _token = token;
            _client = new Telegram.Bot.TelegramBotClient(_token);
            _client.OnMessage += OnMessageHandler;
        }
        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void AddCommands(IList<ICommand> commands)
        {
            _commands.AddRange(commands);
        }

        public async void Start()
        {


            _client.StartReceiving();

        }



        public void Stop()
        {
            _client.StopReceiving();
        }
        private async void OnMessageHandler(object sender, MessageEventArgs e)
        {

            var msg = e.Message;

            if (!string.IsNullOrEmpty(msg.Text))
            {
                Console.WriteLine($"{msg.Chat.FirstName} | {msg.Text} | {msg.Chat.Username} | { msg.Date}");
                foreach (var command in _commands)
                {

                    var startIndex = msg.Text.IndexOf(command.CmdName, 0, StringComparison.OrdinalIgnoreCase);
                    if (startIndex >= 0)
                    {
                        var length = startIndex + command.CmdName.Length;
                        var additionaArguments = msg.Text.Substring(length, msg.Text.Length - length);
                        additionaArguments = additionaArguments.Trim();
                        await _client.SendTextMessageAsync(msg.Chat.Id, command.Run(additionaArguments));


                        return;
                    }







                }
                await _client.SendTextMessageAsync(msg.Chat.Id, "Не является командой");
            }
        }
    }
}
