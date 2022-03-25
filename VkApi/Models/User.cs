using System.Collections.Generic;

namespace VkApi.Models.User
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class UserInfo
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool can_access_closed { get; set; }
        public bool is_closed { get; set; }
    }

    public class UserRoot
    {
        public List<UserInfo> response { get; set; }
    }


}