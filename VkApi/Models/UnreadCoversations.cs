using System.Collections.Generic;

namespace VkApi.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Peer
    {
        public long id { get; set; }
        public string type { get; set; }
        public long local_id { get; set; }
    }

    public class SortId
    {
        public long major_id { get; set; }
        public long minor_id { get; set; }
    }

    public class PushSettings
    {
        public bool disabled_forever { get; set; }
        public bool no_sound { get; set; }
        public bool disabled_mentions { get; set; }
        public bool disabled_mass_mentions { get; set; }
    }

    public class CanWrite
    {
        public bool allowed { get; set; }
        public long? reason { get; set; }
    }

    public class Photo
    {
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public string photo_200 { get; set; }
        public bool is_default_photo { get; set; }
        public bool is_default_call_photo { get; set; }
        public long album_id { get; set; }
        public long date { get; set; }
        public long id { get; set; }
        public long owner_id { get; set; }
        public string access_key { get; set; }
        public long post_id { get; set; }
        public List<Size> sizes { get; set; }
        public string text { get; set; }
        public long user_id { get; set; }
        public bool has_tags { get; set; }
    }

    public class Acl
    {
        public bool can_change_info { get; set; }
        public bool can_change_invite_link { get; set; }
        public bool can_change_pin { get; set; }
        public bool can_invite { get; set; }
        public bool can_promote_users { get; set; }
        public bool can_see_invite_link { get; set; }
        public bool can_moderate { get; set; }
        public bool can_copy_chat { get; set; }
        public bool can_call { get; set; }
        public bool can_use_mass_mentions { get; set; }
        public bool can_change_style { get; set; }
    }

    public class PinnedMessage
    {
        public long id { get; set; }
        public long date { get; set; }
        public long from_id { get; set; }
        public List<object> attachments { get; set; }
        public long conversation_message_id { get; set; }
        public long peer_id { get; set; }
        public string text { get; set; }
    }

    public class ChatSettings
    {
        public string title { get; set; }
        public long members_count { get; set; }
        public long friends_count { get; set; }
        public long owner_id { get; set; }
        public string state { get; set; }
        public Photo photo { get; set; }
        public List<long> active_ids { get; set; }
        public bool is_group_channel { get; set; }
        public Acl acl { get; set; }
        public bool is_disappearing { get; set; }
        public bool is_service { get; set; }
        public PinnedMessage pinned_message { get; set; }
    }

    public class CurrentKeyboard
    {
        public bool one_time { get; set; }
        //public List<List<>> buttons { get; set; }
        public long author_id { get; set; }
        public bool inline { get; set; }
    }

    public class Button
    {
        public string layout { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public string callback_data { get; set; }
        public Action action { get; set; }
        public string color { get; set; }
    }

    public class ConversationBar
    {
        public string name { get; set; }
        public string text { get; set; }
        public List<Button> buttons { get; set; }
        public string icon { get; set; }
    }

    public class Conversation
    {
        public Peer peer { get; set; }
        public long last_message_id { get; set; }
        public long in_read { get; set; }
        public long out_read { get; set; }
        public SortId sort_id { get; set; }
        public long last_conversation_message_id { get; set; }
        public long in_read_cmid { get; set; }
        public long out_read_cmid { get; set; }
        public int unread_count { get; set; }
        public bool is_marked_unread { get; set; }
        public bool important { get; set; }
        public List<long> mentions { get; set; }
        public List<long> mention_cmids { get; set; }
        public List<object> expire_messages { get; set; }
        public List<object> expire_cmids { get; set; }
        public PushSettings push_settings { get; set; }
        public CanWrite can_write { get; set; }
        public bool can_send_money { get; set; }
        public bool can_receive_money { get; set; }
        public ChatSettings chat_settings { get; set; }
        public bool is_new { get; set; }
        public CurrentKeyboard current_keyboard { get; set; }
        public ConversationBar conversation_bar { get; set; }
    }

    public class Size
    {
        public long height { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public long width { get; set; }
    }

    public class Link
    {
        public string url { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string target { get; set; }
        public bool is_favorite { get; set; }
    }

    public class Attachment2
    {
        public string type { get; set; }
        public Photo photo { get; set; }
        public Link link { get; set; }
        public Wall wall { get; set; }
    }

    public class PostSource
    {
        public string platform { get; set; }
        public string type { get; set; }
    }

    public class Comments
    {
        public long can_post { get; set; }
        public long count { get; set; }
        public bool groups_can_post { get; set; }
    }

    public class Likes
    {
        public long can_like { get; set; }
        public long count { get; set; }
        public long user_likes { get; set; }
        public long can_publish { get; set; }
    }

    public class Reposts
    {
        public long count { get; set; }
        public long user_reposted { get; set; }
    }

    public class Views
    {
        public long count { get; set; }
    }

    public class Donut
    {
        public bool is_donut { get; set; }
    }

    public class Attachment
    {
        public string type { get; set; }
        public Photo photo { get; set; }
        public Link link { get; set; }
    }
    public class Wall
    {
        public long id { get; set; }
        public long from_id { get; set; }
        public long to_id { get; set; }
        public long date { get; set; }
        public string post_type { get; set; }
        public string text { get; set; }
        public long marked_as_ads { get; set; }
        public List<Attachment> attachments { get; set; }
        public PostSource post_source { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Reposts reposts { get; set; }
        public Views views { get; set; }
        public bool is_favorite { get; set; }
        public Donut donut { get; set; }
        public string access_key { get; set; }
        public double short_text_rate { get; set; }
        public long carousel_offset { get; set; }
    }

    public class Keyboard
    {
        public bool one_time { get; set; }
        //public List<List<>> buttons { get; set; }
        public long author_id { get; set; }
        public bool inline { get; set; }
    }

    public class Action
    {
        public string type { get; set; }
        public string label { get; set; }
        public string payload { get; set; }
    }

    public class Element
    {
        public Action action { get; set; }
        public Photo photo { get; set; }
        public List<Button> buttons { get; set; }
    }

    public class Template
    {
        public string type { get; set; }
        public List<Element> elements { get; set; }
    }

    public class LastMessage
    {
        public long date { get; set; }
        public long from_id { get; set; }
        public long id { get; set; }
        public long @out { get; set; }
        public List<Attachment> attachments { get; set; }
        public long conversation_message_id { get; set; }
        public List<object> fwd_messages { get; set; }
        public bool important { get; set; }
        public bool is_hidden { get; set; }
        public long peer_id { get; set; }
        public long random_id { get; set; }
        public string @ref { get; set; }
        public string ref_source { get; set; }
        public string text { get; set; }
        public string message_tag { get; set; }
        public Keyboard keyboard { get; set; }
        public Template template { get; set; }
    }

    public class Item
    {
        public Conversation conversation { get; set; }
        public LastMessage last_message { get; set; }
    }

    public class Response
    {
        public long count { get; set; }
        public List<Item> items { get; set; }
        public long unread_count { get; set; }
    }

    public class UnreadConversationsRoot
    {
        public Response response { get; set; }
    }


}