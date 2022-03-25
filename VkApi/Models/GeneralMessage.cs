namespace VkApi.Models
{
    public class GeneralMessage
    {
        /// <summary>
        /// От кого сообщение
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// ID отправителя
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// ID сообщения
        /// </summary>
        public long MessageId { get; set; }
    }
}