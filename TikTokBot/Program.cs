using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using TikTokBot.Clients;

RedditClient rc = new RedditClient("E9imfDVr1XEOPVnZ9Wnt9A", "MW0uJkmwEIedk0M3A3sf_C_Nxm1Tfg");
var result = await rc.GetTopPosts();
