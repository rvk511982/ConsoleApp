using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ConsolePractice.MsAzure
{
    //public static class EventPublisherFunction
    //{
    //    [FunctionName("PublishEvent")]
    //    public static async Task<HttpResponseMessage> Run(
    //    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "PublishEvent")] HttpRequestMessage req,
    //    [CosmosDB(
    //        databaseName: "%CosmosDbDatabaseName%",
    //        collectionName: "%CosmosDbCollectionName%",
    //        ConnectionStringSetting = "%CosmosDbConnectionStringSetting%")] IAsyncCollector<InputModel> cosmosDbCollector,
    //    [ServiceBus(
    //        TopicName = "%ServiceBusTopicName%",
    //        Connection = "%ServiceBusConnectionName%",
    //        EntityType = "%ServiceBusEntityType%")] IAsyncCollector<Message> serviceBusCollector,
    //    ILogger log,
    //    TelemetryClient telemetryClient,
    //    ITaskHelper taskHelper)
    //    {
    //        // Get CorrelationId from the headers
    //        var correlationId = req.Headers.Contains("CorrelationId") ? req.Headers.GetValues("CorrelationId").First() : string.Empty;

    //        // Read and deserialize the HTTP request body
    //        var requestBody = await req.Content.ReadAsStringAsync();
    //        var inputModel = taskHelper.Deserialize<InputModel>(requestBody);

    //        // Save to CosmosDB
    //        await cosmosDbCollector.AddAsync(inputModel);

    //        // Track the custom event in Application Insights
    //        var eventTelemetry = new EventTelemetry(inputModel.EventName)
    //        {
    //            Properties = { { "CorrelationId", correlationId } }
    //        };
    //        telemetryClient.TrackEvent(eventTelemetry);

    //        // Publish to Service Bus
    //        var serviceBusMessage = new Message(taskHelper.GetMessageBytes(requestBody))
    //        {
    //            CorrelationId = correlationId
    //        };
    //        await serviceBusCollector.AddAsync(serviceBusMessage);

    //        // Return a 200 OK response
    //        return req.CreateResponse(HttpStatusCode.OK);
    //    }
    //}

    public class InputModel
    {
        public string EventName { get; set; }
        public object EventProperties { get; set; }
    }

    public interface ITaskHelper
    {
        T Deserialize<T>(string json);
        byte[] GetMessageBytes(string message);
    }
}
