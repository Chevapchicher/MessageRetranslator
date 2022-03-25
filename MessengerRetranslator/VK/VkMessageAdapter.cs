using MessengerRetranslator.Enums;
using MessengerRetranslator.Models;

namespace MessengerRetranslator.VK
{
    public class VkMessageAdapter
    {
        public static (Message message, MessageInfo messageInfo)
            ConvertMessage(VkApi.Models.GeneralMessage sourceMes) =>
        (
            new()
            {
                Messenger = MessengerType.Vk,
                From = sourceMes.From,
                Text = sourceMes.Text
            },
            new MessageInfo
            {
                MessengerType = MessengerType.Vk,
                MessageId = sourceMes.MessageId,
                UserId = sourceMes.UserId
            }
        );
    }
}