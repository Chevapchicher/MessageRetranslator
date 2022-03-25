using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MessengerRetranslator.Enums;
using MessengerRetranslator.Models;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Message = MessengerRetranslator.Models.Message;

namespace MessengerRetranslator.TelegramBot
{
    public class TelegramBot
    {
        private string botToken = "1706915469:AAFyS2UqQhSP4nrPjxNk73I1TaO4WWaob20";
        private TelegramBotClient tgClient;
        private SessionState sessionState = SessionState.None;
        private MessageInfo currentMessageInfo;

        public event Action<(Message mes, MessageInfo mesInfo)> OnSendAnswer;
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
            var data = update.CallbackQuery?.Data;

            if (!string.IsNullOrEmpty(data))
            {
                await SendMessageAsync(2006556942, "Введите сообщение:");
                currentMessageInfo = JsonSerializer.Deserialize<MessageInfo>(data);
                sessionState = SessionState.SendingAnswer;
            }

            if (update.Message?.Type == MessageType.Text && sessionState == SessionState.SendingAnswer && currentMessageInfo is not null)
            {
                OnSendAnswer?.Invoke((new Message
                    {
                        Text = update.Message?.Text
                    },
                    currentMessageInfo));

                sessionState = SessionState.None;
                currentMessageInfo = null;
            }
        }

        public async Task SendMessageAsync(long id, string text, MessageInfo messageInfo = null)
        {
            InlineKeyboardMarkup inlineKeyboard = null;
            if (messageInfo is not null)
            {
                inlineKeyboard = new(new[]
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Ответить", callbackData: JsonSerializer.Serialize(messageInfo))
                    }
                });
            }

            try
            {
                await tgClient.SendTextMessageAsync(id, text, replyMarkup: inlineKeyboard);
            }
            catch
            {
                Console.WriteLine("Пользователя нет в боте!");
            }
        }
    }
}