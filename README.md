
Fusio C# CLI sample
=====

# About

This is a simple C# CLI application which shows how to use the C# SDK to access a Fusio instance.
In this example we simply output all registered operations.
Fusio is an open source API management which helps to build and manage great APIs more information at:
https://www.fusio-project.org/

```csharp
using Fusio.SDK;
using Sdkgen.Client;
using Sdkgen.Client.Credentials;
using Sdkgen.Client.TokenStore;

List<string> scopes = ["backend"];
ITokenStore tokenStore = new MemoryTokenStore();

var credentials = new OAuth2("test", "FRsNh1zKCXlB", "https://demo.fusio-project.org/authorization/token", "", tokenStore, scopes);
var client = new Client("https://demo.fusio-project.org", credentials);

try
{
    BackendOperationCollection collection = await client.Backend().Operation().GetAll(0, 16, "");

    Console.WriteLine("Operations:");
    for (int i = 0; i < collection.Entry?.Count; i++)
    {
        Console.WriteLine("* " + collection.Entry[i].HttpMethod + " " + collection.Entry[i].HttpPath);
    }
}
catch (CommonMessageException e)
{
    Console.WriteLine("Error: " + e.Payload.Message);
}

```

# Usage

To run this app simply execute following command:

```
dotnet run
```


