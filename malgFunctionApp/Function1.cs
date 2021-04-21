using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using malgFunctionApp.Models;
using System.Threading.Tasks;

namespace malgFunctionApp
{
    public static class Function1
    {
            [FunctionName("Function1")]
            public static async Task RunAsync(

                [ServiceBusTrigger(
                    "malgqueue",
                    Connection = "MyConn"
            )] string myQueueItem,

                [CosmosDB(
                    databaseName:"dbRaspberry",
                                        collectionName:"Eventos",
                    ConnectionStringSetting = "strCosmos"
             )] IAsyncCollector<object> datos,

                ILogger log)
            {
                try
                {
                    log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                    var data = JsonConvert.DeserializeObject<Data>(myQueueItem);
                    await datos.AddAsync(data);
                }
                catch (Exception ex)
                {
                    log.LogError($"No es posible insertar datos: {ex.Message}");
                }
            }
        }
}
