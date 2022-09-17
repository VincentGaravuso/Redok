using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TikTokBot.ResponseObjects
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RedditPosts
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public RedditPostsData Data { get; set; }
    }

    public partial class RedditPostsData
    {

        [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
        public List<Child> Children { get; set; }
    }

    public partial class Child
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public ChildData Data { get; set; }
    }

    public partial class ChildData
    {
       [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }
    }
}
