using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tgbot.Commands;

namespace Tgbot
{




    class Program
    {


        static void Main(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: true)
                .Build();


            var commandList = new List<ICommand>();
            commandList.Add(new TimeCommand());
            commandList.Add(new HelloCommand());
            var converterEur = new ConverterEur(new GetCurrency());
            var converterUsd = new ConverterDollar(new GetCurrency());
            var convertFromEur = new ConverterFromEur();
            var convertFromDollar = new ConverterFromDollar();
            var music = new Music();
            var subs = new SubcribersCommand();
            var finderpoisk = new FinderCommand();

            commandList.Add(subs);
            commandList.Add(converterEur);
            commandList.Add(converterUsd);
            commandList.Add(convertFromEur);
            commandList.Add(convertFromDollar);
            commandList.Add(music);
            commandList.Add(finderpoisk);



            //commandList.Add(new OffComputer());
            //commandList.Add(new CancelOFF());


            var telegrambot = new TelegramBotClient(configuration["tgToken"]);

            telegrambot.AddCommands(commandList);
            telegrambot.AddCommand(new HelpCommand(commandList));
            telegrambot.Start();

            Console.ReadLine();




        }


    }










}






/*private async void OnMessageHandler(object sender, MessageEventArgs e)
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

                            await _client.SendTextMessageAsync(msg.Chat.Id, command.Run(additionaArguments));


                            return;
                        }







                    }
                    await _client.SendTextMessageAsync(msg.Chat.Id, "Не является командой");*/
/*class DiscordBotCLient : IBotClietnDs, IBotClientTg
{

    public string Token { get; }
    public DiscordSocketClient Client { get; private set; }
    public IServiceProvider Service { get; private set; }
    public static CommandService _comands { get; private set; }


    public DiscordBotCLient(string tokenDiscord)
    {
        Token = tokenDiscord;
        Client = new DiscordSocketClient(Token);
        _comands = new List<ICommand>();

    }
    public async Task RunBotAsync()
    {

        await Task.Delay(-1);
        await Client.LoginAsync(TokenType.Bot, Token);
        await Client.StartAsync();
    }

    public Task Client_Ready()
    {
        Console.WriteLine("Ready");
        return Task.CompletedTask;
    }

    public void Start()
    {
        Client = new DiscordSocketClient();
        _comands = new CommandService();

        var Service = new ServiceCollection()
            .AddSingleton(Client)
            .AddSingleton<CommandService>()
            .BuildServiceProvider();

        Client.MessageReceived += Client_MessageReceived();
        Client.Ready += Client_Ready;


    }



    public void Stop()
    {
        throw new NotImplementedException();
    }

    public void AddCommand(ICommand command)
    {

    }

    public void AddCommands(IList<ICommand> commands)
    {

    }
    private async static Task Client_MessageReceived(SocketMessage arg, MessageEventArgs e)
    {
        int argPos = 0;
        var msg = e.Message;


        string message = e.Message.Text;
        if (message.StartsWith("&"))
        {
            Console.WriteLine($"{msg.Chat.FirstName} | {msg.Text} | {msg.Chat.Username} | { msg.Date}");
            foreach (var command in _commands)
            {

                var startIndex = msg.Text.IndexOf(command.CmdName, 0, StringComparison.OrdinalIgnoreCase);
                if (startIndex >= 0)
                {
                    var length = startIndex + command.CmdName.Length;
                    var additionaArguments = msg.Text.Substring(length, msg.Text.Length - length);

                    await _client.SendTextMessageAsync(msg.Chat.Id, command.Run(additionaArguments));


                    return;
                }
            }
        }*/
