using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMTrackingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var credentials = SdkContext.AzureCredentialsFactory.FromFile("./my.azureauth");
                const string versionString = "MyVersion";

                // see: https://docs.microsoft.com/en-us/azure/marketplace/azure-partner-customer-usage-attribution#create-guids
                string AZURE_HTTP_USER_AGENT = "pid-eb7927c8-dd66-43e1-b0cf-c346a422063";

                // using .WithUserAgent
                // https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.management.resourcemanager.fluent.core.azureconfigurable-1.withuseragent?view=azure-dotnet
                var azure = Azure
                        .Configure()
                        .WithUserAgent(AZURE_HTTP_USER_AGENT, versionString)
                        .Authenticate(credentials)
                        .WithDefaultSubscription();

                CreateRG(azure);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Done... Press any key to exit...");
            Console.ReadKey();
        }

        private static void CreateRG(IAzure azure)
        {
            var groupName = "ARMSDKCreatedRG" + new Random().Next().ToString();
            var location = Region.EuropeNorth;

            var resourceGroup = azure.ResourceGroups.Define(groupName)
                .WithRegion(location)
                .Create();

            Console.WriteLine("Created RG " + groupName);

        }
    }
}
