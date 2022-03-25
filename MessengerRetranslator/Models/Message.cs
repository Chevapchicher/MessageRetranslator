using MessengerRetranslator.Enums;

namespace MessengerRetranslator.Models
{
    public record Message
    {
        /// <summary>
        /// От кого сообщение
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }

        
    }
}