using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerRetranslator.Interfaces;
using MessengerRetranslator.Models;

namespace MessengerRetranslator.VK
{
    public class VkUnreadMessagesGetter : IUnreadMessagesGetter
    {
        public async Task<IEnumerable<(Message mes, MessageInfo mesInfo)>> GetUnreadMessages(IAuthInfo authInfo)
        {
            if (authInfo is not VkAuthInfo vkAuthInfo) return null;

            var unreadMessagesVk = await VkApi.VkMessageApi.GetUnreadMessages(vkAuthInfo.Token);
            return unreadMessagesVk.Select(VkMessageAdapter.ConvertMessage);
        }
    }
}