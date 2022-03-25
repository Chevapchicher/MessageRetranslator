using MessengerRetranslator.Models;

namespace MessengerRetranslator
{
    public class Manager
    {
        private TelegramBot.TelegramBot tgBot;
        public Manager()
        {
            // тг-бот для отправки уведомлений
            tgBot = new();
            tgBot.OnSendAnswer += TgBot_OnSendAnswer;

            // получатель непрочитанных сообщений
            UnreadMessagesGetter unreadMessagesGetter = new();
            unreadMessagesGetter.OnSendMessage += UnreadMessagesGetter_OnSendMessage;
        }

        private async void TgBot_OnSendAnswer((Message message, MessageInfo messageInfo) mes)
        {
            var response = false;

            var mesSender = MessageSenderFactory.GetMessageSender(mes.messageInfo.MessengerType);

            if (mesSender is not null)
            {
                response = await mesSender.SendMessage(mes.message);
            }

            if (response)
            {
                await tgBot.SendMessageAsync(long.Parse(Properties.Resources.TgId), "Сообщение отправлено!");
            }
            else
            {
                await tgBot.SendMessageAsync(long.Parse(Properties.Resources.TgId), "Сообщение не отправлено!");
            }
        }

        /// <summary>
        /// Если нашли новые непрочитанные сообщения- отправляем в ТГ
        /// </summary>
        /// <param name="messages"></param>
        private async void UnreadMessagesGetter_OnSendMessage(System.Collections.Generic.IEnumerable<(Message, MessageInfo)> messages)
        {
            foreach (var (message, mesInfo) in messages)
            {
                string mes = $"Новое сообщение из {mesInfo.MessengerType} от: {message.From}\n\n{message.Text}";
                await tgBot.SendMessageAsync(long.Parse(Properties.Resources.TgId), mes, mesInfo);
            }
        }
    }
}