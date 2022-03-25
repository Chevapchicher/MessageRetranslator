using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MessengerRetranslator
{
    public class TelegramBot
    {
        private string botToken = "tg bot token";
        private TelegramBotClient tgClient;
        public TelegramBot()
        {
            tgClient = new(botToken);
            CancellationTokenSource cts = new CancellationTokenSource();
            ReceiverOptions receiverOptions = new();
            tgClient.StartReceiving(HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cts.Token);
        }

        private async Task HandleErrorAsync(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {

        }

        private async Task HandleUpdateAsync(ITelegramBotClient arg1, Update update, CancellationToken arg3)
        {
           
        }

        public async Task SendMessageAsync(long id, string text)
        {
            try
            {
                await tgClient.SendTextMessageAsync(id, text);
            }
            catch
            {
                Console.WriteLine("Пользователя нет в боте!");
            }
        }
    }
}