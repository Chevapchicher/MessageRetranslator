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
    }
}