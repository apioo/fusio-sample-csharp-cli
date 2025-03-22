
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
