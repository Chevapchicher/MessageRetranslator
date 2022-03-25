namespace MessengerRetranslator
{
    public class Manager
    {
        private TelegramBot tgBot;
        public Manager()
        {
            // тг-бот для отправки уведомлений
            tgBot = new();

            // получатель непрочитанных сообщений
            UnreadMessagesGetter unreadMessagesGetter = new();
            unreadMessagesGetter.OnSendMessage += UnreadMessagesGetter_OnSendMessage;
        }

        /// <summary>
        /// Если нашли новые непрочитанные сообщения- отправляем в ТГ
        /// </summary>
        /// <param name="messages"></param>
        private async void UnreadMessagesGetter_OnSendMessage(System.Collections.Generic.IEnumerable<Models.Message> messages)
        {
            foreach (var message in messages)
            {
                string mes = $"Новое сообщение от: {message.From}\n\n{message.Text}";
                await tgBot.SendMessageAsync(2006556942, mes);
            }
        }
    }
}