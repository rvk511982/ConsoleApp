//using ConsolePractice.Polymorphism;
//using Google.Protobuf.WellKnownTypes;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.Azure.Cosmos;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Json;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsolePractice.Test
//{
//    public class Entelera
//    {
//        var builder = WebApplication.CreateBuilder(args);

//        builder.Services.AddHttpClient("SocialMediaClient")

//    .AddPolicyHandler(PollyPolicies.GetRetryPolicy())

//    .AddPolicyHandler(PollyPolicies.GetCircuitBreakerPolicy());

//        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

//.AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
 
//builder.Services.AddAuthorization();
 
//builder.Services.AddSingleton(new CosmosClient("Your-CosmosDB-ConnectionString"));

//builder.Services.AddSingleton<SocialMediaService>();
 
//var app = builder.Build();

//        app.UseAuthentication();

//app.UseAuthorization();
 
//app.MapGet("/GetUserSocialMediaPosts/{userId}", async(string userId, SocialMediaService service) =>

//{

//    var posts = await service.GetAllSocialMediaPostsAsync(userId);

//    return Results.Ok(posts);

//}).RequireAuthorization();

//    app.MapPost("/PostToSocialMedia", async(string userId, SocialMediaEnum[] socialMediaAccounts, string post, SocialMediaService service) =>

//{

//    var postId = await service.PostToSocialMediaAsync(userId, socialMediaAccounts, post);

//    return Results.Ok(new { PostId = postId
//});

//}).RequireAuthorization();

//app.Run();

//public enum SocialMediaEnum { Facebook, LinkedIn, Twitter }

//public static class PollyPolicies

//{

//    public static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy() =>

//        Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)

//            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

//    public static AsyncCircuitBreakerPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() =>

//        Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)

//            .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));

//}


//public class SocialMediaService

//{

//    private readonly IHttpClientFactory _httpClientFactory;

//    private readonly CosmosClient _cosmosClient;

//    public SocialMediaService(IHttpClientFactory httpClientFactory, CosmosClient cosmosClient)

//    {

//        _httpClientFactory = httpClientFactory;

//        _cosmosClient = cosmosClient;

//    }

//    public async Task<List<string>> GetAllSocialMediaPostsAsync(string userId)

//    {

//        var tasks = new List<Task<List<string>>>

//        {

//            GetPostsFromPlatformAsync(userId, "https://api.facebook.com/posts"),

//            GetPostsFromPlatformAsync(userId, "https://api.linkedin.com/posts"),

//            GetPostsFromPlatformAsync(userId, "https://api.twitter.com/posts")

//        };

//        var results = await Task.WhenAll(tasks);

//        var allPosts = new List<string>();

//        foreach (var result in results) allPosts.AddRange(result);

//        return allPosts;

//    }

//    private async Task<List<string>> GetPostsFromPlatformAsync(string userId, string apiUrl)

//    {

//        var client = _httpClientFactory.CreateClient("SocialMediaClient");

//        var response = await client.GetAsync($"{apiUrl}?userId={userId}");

//        response.EnsureSuccessStatusCode();

//        return await response.Content.ReadFromJsonAsync<List<string>>() ?? new List<string>();

//    }

//    public async Task<string> PostToSocialMediaAsync(string userId, SocialMediaEnum[] socialMediaAccounts, string post)

//    {

//        var postId = Guid.NewGuid().ToString();

//        var tasks = new List<Task>();

//        foreach (var platform in socialMediaAccounts)

//        {

//            var url = platform switch

//            {

//                SocialMediaEnum.Facebook => "https://api.facebook.com/post",

//                SocialMediaEnum.LinkedIn => "https://api.linkedin.com/post",

//                SocialMediaEnum.Twitter => "https://api.twitter.com/post",

//                _ => throw new ArgumentException("Invalid platform")

//            };

//            tasks.Add(PostToPlatformAsync(userId, url, post));

//        }

//        await Task.WhenAll(tasks);

//        await SaveToCosmosDBAsync(userId, post, postId);

//        return postId;

//    }

//    private async Task PostToPlatformAsync(string userId, string apiUrl, string post)

//    {

//        var client = _httpClientFactory.CreateClient("SocialMediaClient");

//        var response = await client.PostAsJsonAsync(apiUrl, new { userId, post });

//        if (!response.IsSuccessStatusCode)

//        {

//            await AddToRetryQueueAsync(userId, post);

//        }

//    }

//    private async Task SaveToCosmosDBAsync(string userId, string post, string postId)

//    {

//        var container = _cosmosClient.GetContainer("SocialMediaDB", "Posts");

//        await container.CreateItemAsync(new { id = postId, userId, post });

//    }

//    private async Task AddToRetryQueueAsync(string userId, string post)

//    {

//        var queueClient = new Azure.Storage.Queues.QueueClient("Your-Queue-ConnectionString", "failed-posts");

//        await queueClient.SendMessageAsync(JsonSerializer.Serialize(new { userId, post }));

//    }

//}



