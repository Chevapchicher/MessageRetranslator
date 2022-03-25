using MessengerRetranslator.Interfaces;

namespace MessengerRetranslator.VK
{
    public class VkAuthInfo : IAuthInfo
    {
        /// <summary>
        /// Токен ВК
        /// </summary>
        public string Token { get; set; }
    }
}