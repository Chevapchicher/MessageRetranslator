using MessengerRetranslator.Interfaces;
using MessengerRetranslator.Models;
using MessengerRetranslator.VK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace MessengerRetranslator
{
    public class UnreadMessagesGetter
    {
        public event Action<IEnumerable<(Message, MessageInfo)>> OnSendMessage;

        private List<(IUnreadMessagesGetter getter, IAuthInfo authInfo)> _messagesGetters;
        private List<long> _deliveredMessages;
        public UnreadMessagesGetter()
        {
            _deliveredMessages = new();

            // сюда добавлять геттеры от рвзных мессенджеров с параметрами аутентификации
            _messagesGetters = new()
            {
                (
                    new VkUnreadMessagesGetter(),
                    new VkAuthInfo
                    {
                        Token = Properties.Resources.VkToken
                    }
                )
            };

            // проверяем каждые 5 сек новые сообщения
            Timer updater = new(5000);
            updater.Elapsed += Updater_Elapsed;
            updater.Start();
        }

        private async void Updater_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var (getter, authInfo) in _messagesGetters)
            {
                // все непрочитанные сообщения из мессенджера
                var allUnreadMessages = await getter.GetUnreadMessages(authInfo);

                // удаляем из памяти сообщения, которые стали прочитанными
                var removingMessages = _deliveredMessages.Where(x => !allUnreadMessages
                        .Select(d => d.mesInfo.MessageId)
                        .Contains(x))
                    .ToList();

                removingMessages.ForEach(x => _deliveredMessages.Remove(x));

                // только те сообщения, которые еще не доставили
                var unreadMessages = allUnreadMessages.Where(x => !_deliveredMessages.Contains(x.mesInfo.MessageId))
                        .ToList();
                OnSendMessage?.Invoke(unreadMessages);
                _deliveredMessages.AddRange(unreadMessages.Select(x => x.mesInfo.MessageId));
            }
        }
    }
}