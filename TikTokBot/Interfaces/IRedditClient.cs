using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTokBot.enums;
using TikTokBot.ResponseObjects;

namespace TikTokBot.Interfaces
{
    internal interface IRedditClient
    {
        Task<RedditPosts?> GetTopPosts();
    }
}
