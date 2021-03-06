# C Sharp sample for ARM Customer Usage Attribution

To install:

Ensure that you have installed the Azure CLI tool:

https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest

Browse to the Solution directory, and use the Azure CLI to create an authentication file:

```shell
az ad sp create-for-rbac --sdk-auth > my.azureauth
```

Then you can open the solution in visual studio and try it out.

Currently we are just using a "Sample" GUID.

You would need to replace this with the GUID you have registered for your MPN ID.

https://docs.microsoft.com/en-us/azure/marketplace/azure-partner-customer-usage-attribution

**Please Note:**

The the Version number in the **WithUserAgent()** call must not be StringEmpty or Null, otherwise the UserAgent string will not be appended.
Whilst the apended string is different to the Python and CLI implementation, the format pid-\<GUID\>/SomeString will be valid.

```csharp
var azure = Azure
                        .Configure()
                        .WithUserAgent("pid-<your gui here>", "your version string")
                        .Authenticate(credentials)
                        .WithDefaultSubscription();
```