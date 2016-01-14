ARIN-Whois.NET
==============

.NET client for ARIN's [Whois RESTful Web Service](https://www.arin.net/resources/whoisrws/index.html), the API to accessing ARIN's Whois data.


The [American Registry for Internet Numbers](https://www.arin.net/) (ARIN) is the Regional Internet Registry (RIR) for North America. Their API is a directory service to access data in their registration database, such as networks, organizations, and point of contacts.

This is a simple .NET client to access the RESTful API programmatically with a set of statically typed helper classes.

Install
============

Use the [NuGet](https://www.nuget.org/packages/ArinWhois) package, run the following command in the Package Manager Console:

    PM> Install-Package ArinWhois



Sample Usage
============

```csharp
var arinClient = new ArinClient();

// Check single IP
var ipResponse = await arinClient.QueryIpAsync(IPAddress.Parse("69.63.176.0"));

Console.WriteLine(ipResponse.Network.Name);
Console.WriteLine(ipResponse.Network.NetBlocks.NetBlock.Cidr);

// Find out more about organization or customer
if (ipResponse.Network.OrgRef != null)
{
	var orgResponse = await arinClient.QueryResourceAsync(ipResponse.Network.OrgRef.Handle, 
								ArinClient.ResourceType.Organization);
	Console.WriteLine(orgResponse.Organization.Name);
	Console.WriteLine(orgResponse.Organization.City);
}
else if (ipResponse.Network.CustomerRef != null)
{
	var customerResponse = await arinClient.QueryResourceAsync(ipResponse.Network.CustomerRef.Handle, 
								ArinClient.ResourceType.Customer);
	Console.WriteLine(customerResponse.Organization.Name);
	Console.WriteLine(customerResponse.Organization.City);
}
```

If you don't wanna do async, use `.Result`: 

```csharp
    var response = arinClient.QueryIpAsync(IPAddress.Parse("69.63.176.0")).Result;
```

But you should do async, really.


Limitations
===========
* Read-only



Contributors
============
* [MaxHorstmann](https://github.com/MaxHorstmann) (Max Horstmann)



