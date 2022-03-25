using System.Collections.Generic;

namespace VkApi.Models.ConversationById
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Size
    {
        public int height { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public int width { get; set; }
    }

    public class Photo
    {
        public int album_id { get; set; }
        public int date { get; set; }
        public int id { get; set; }
        public int owner_id { get; set; }
        public string access_key { get; set; }
        public List<Size> sizes { get; set; }
        public string text { get; set; }
        public bool has_tags { get; set; }
    }

    public class Attachment
    {
        public string type { get; set; }
        public Photo photo { get; set; }
    }

    public class ReplyMessage
    {
        public int date { get; set; }
        public int from_id { get; set; }
        public string text { get; set; }
        public List<Attachment> attachments { get; set; }
        public int conversation_message_id { get; set; }
        public int id { get; set; }
        public int peer_id { get; set; }
    }

    public class Item
    {
        public int date { get; set; }
        public int from_id { get; set; }
        public int id { get; set; }
        public int @out { get; set; }
        public List<object> attachments { get; set; }
        public int conversation_message_id { get; set; }
        public List<object> fwd_messages { get; set; }
        public bool important { get; set; }
        public bool is_hidden { get; set; }
        public int peer_id { get; set; }
        public int random_id { get; set; }
        public ReplyMessage reply_message { get; set; }
        public string text { get; set; }
    }

    public class Response
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
    }

    public class UnreadMessageRoot
    {
        public Response response { get; set; }
    }
}