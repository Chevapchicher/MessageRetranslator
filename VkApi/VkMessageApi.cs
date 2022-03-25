using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using VkApi.Models;
using VkApi.Models.ConversationById;
using VkApi.Models.User;
using Item = VkApi.Models.Item;

namespace VkApi
{
    public class VkMessageApi
    {
        /// <summary>
        /// Получение непрочитанных сообщений ВК
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<GeneralMessage>> GetUnreadMessages(string accessToken)
        {
            List<GeneralMessage> mesList = new();

            UnreadConversationsRoot response;

            using var webClient = new WebClient();
            {
                var responseString = await webClient.DownloadStringTaskAsync($"https://api.vk.com/method/messages.getConversations?v=5.131&access_token={accessToken}&filter=unread");
                response = JsonSerializer.Deserialize<UnreadConversationsRoot>(responseString);
            }

            foreach (var conversation in response?.response?.items ?? new List<Item>())
            {
                var unreadCount = conversation.conversation?.unread_count;
                var peerId = conversation.conversation?.peer?.type == "user"
                    ? conversation.conversation?.peer?.id
                    : null;

                if (unreadCount.HasValue && peerId.HasValue)
                {
                    var messages = await GetHistory(peerId.Value, unreadCount.Value, accessToken);
                    mesList.AddRange(messages);
                }
            }

            return mesList;
        }

        /// <summary>
        /// Возвращает Историю сообщений с пользователем 
        /// </summary>
        /// <param name="peerId">ID пользователя</param>
        /// <param name="count">Количество сообщений</param>
        /// <param name="accessToken">Токен</param>
        /// <returns></returns>
        private static async Task<IEnumerable<GeneralMessage>> GetHistory(long peerId, int count, string accessToken)
        {
            using var webClient = new WebClient();
            {
                var responseString = await webClient.DownloadStringTaskAsync(
                    $"https://api.vk.com/method/messages.getHistory?v=5.131&access_token={accessToken}&count={count}&peer_id={peerId}");

                var response = JsonSerializer.Deserialize<UnreadMessageRoot>(responseString);

                var userInfo = await GetUserInfo(accessToken, peerId);
                if (userInfo is null) return new List<GeneralMessage>();

                var userName = string.Concat(userInfo.first_name, " ", userInfo.last_name);

                return (response?.response?.items ?? new List<Models.ConversationById.Item>())
                    .Select(item => new GeneralMessage { From = userName, Text = item.text, MessageId = item.id, UserId = item.from_id })
                    .ToList();
            }
        }

        /// <summary>
        /// Получить по ID информациб о пользователе
        /// </summary>
        /// <param name="accessToken">токен</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private static async Task<UserInfo> GetUserInfo(string accessToken, long userId)
        {
            using var webClient = new WebClient();
            {
                var responseString = await webClient.DownloadStringTaskAsync(
                    $"https://api.vk.com/method/users.get?v=5.131&access_token={accessToken}&user_ids={userId}");

                var response = JsonSerializer.Deserialize<UserRoot>(responseString);

                return response?.response?.FirstOrDefault();
            }
        }

        public static async Task<long?> SendMessage(string accessToken, long userId, string text)
        {
            using var webClient = new WebClient();
            {
                var responseString = await webClient.DownloadStringTaskAsync(
                    $"https://api.vk.com/method/messages.send?v=5.131&access_token={accessToken}&user_id={userId}&peer_id={userId}&message={text}&random_id=23632");

                var response = JsonSerializer.Deserialize<SendingResponseRoot>(responseString);
                return response?.response;
            }
        }
    }
}
