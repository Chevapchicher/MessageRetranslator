using System.Collections.Generic;
using System.Threading.Tasks;
using MessengerRetranslator.Models;

namespace MessengerRetranslator.Interfaces
{
    public interface IUnreadMessagesGetter
    {
        // получение непрочитанных сообщений
        public Task<IEnumerable<Message>> GetUnreadMessages(IAuthInfo authInfo);
    }
}