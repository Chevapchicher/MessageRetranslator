using System.Threading.Tasks;
using MessengerRetranslator.Interfaces;
using MessengerRetranslator.Models;

namespace MessengerRetranslator.VK
{
    public class VkMessageSender : IMessageSender
    {
        public async Task<bool> SendMessage((Message message, MessageInfo messageInfo) mes)
        {
            var response = await VkApi.VkMessageApi.SendMessage(Properties.Resources.VkToken, mes.messageInfo.UserId, mes.message.Text);
            return response is > 0;
        }
    }
}