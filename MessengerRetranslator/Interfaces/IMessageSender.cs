using System.Threading.Tasks;
using MessengerRetranslator.Models;

namespace MessengerRetranslator.Interfaces
{
    public interface IMessageSender
    {
        public Task<bool> SendMessage((Message message, MessageInfo messageInfo) mes);
    }
}