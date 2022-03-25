using System.Collections.Generic;
using System.Threading.Tasks;
using MessengerRetranslator.Models;

namespace MessengerRetranslator.Interfaces
{
    public interface IUnreadMessagesGetter
    {
        // получение непрочитанных сообщений
        public Task<IEnumerable<(Message mes, MessageInfo mesInfo)>> GetUnreadMessages(IAuthInfo authInfo);
    }
}