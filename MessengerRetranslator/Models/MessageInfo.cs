using MessengerRetranslator.Enums;

namespace MessengerRetranslator.Models
{
    public class MessageInfo
    {
        /// <summary>
        /// ID сообщения
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// ID пользователя
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Тип мессенджера
        /// </summary>
        public MessengerType MessengerType { get; set; }
    }
}