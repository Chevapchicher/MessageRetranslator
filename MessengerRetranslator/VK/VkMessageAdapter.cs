using MessengerRetranslator.Models;

namespace MessengerRetranslator.VK
{
    public class VkMessageAdapter
    {
        public static Message ConvertMessage(VkApi.Models.GeneralMessage sourceMes) =>
            new()
            {
                From = sourceMes.From,
                Text = sourceMes.Text
            };
    }
}