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

        private async void TgBot_OnSendAnswer(Message mes)
        {
            var response = await VkApi.VkMessageApi.SendMessage(Properties.Resources.VkToken, long.Parse(mes.From), mes.Text);

            if (response != 0)
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
                string mes = $"Новое сообщение из {message.Messenger} от: {message.From}\n\n{message.Text}";
                await tgBot.SendMessageAsync(long.Parse(Properties.Resources.TgId), mes, mesInfo);
            }
        }
    }
}