using System.Collections.Generic;
using System.Threading.Tasks;
using MessengerRetranslator.Enums;
using MessengerRetranslator.Interfaces;
using MessengerRetranslator.Models;
using MessengerRetranslator.VK;

namespace MessengerRetranslator
{
    public class MessageSenderFactory
    {
        public static IMessageSender GetMessageSender(MessengerType messengerType)
        {
            return messengerType switch
            {
                MessengerType.Vk => new VkMessageSender(),
                _ => null
            };
        }
    }
}