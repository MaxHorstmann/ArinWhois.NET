ARIN-Whois-RWS.NET
==================

.NET client for ARIN's [Whois RESTful Web Service](https://www.arin.net/resources/whoisrws/index.html), the API to accessing ARIN's Whois data.


The [American Registry for Internet Numbers](https://www.arin.net/) (ARIN) is the Regional Internet Registry (RIR) for North America. Their API is a directory service to access data in their registration database, such as networks, organizations, and point of contacts.

This is a simple .NET client to access the RESTful API programmatically with a set of statically typed helper classes.

Install
============

<coming to Nuget soon>



Sample Usage
============

    var arinClient = new ArinClient();
    var response = await arinClient.QueryAsync(IPAddress.Parse("69.63.176.0"));

    Console.WriteLine(response.Network.Name);
    Console.WriteLine(response.Network.NetBlocks.NetBlock.Cidr);
    Console.WriteLine(response.Organization.Name);
    Console.WriteLine(response.Organization.City);

If you don't wanna do async, replace the second line with 


    var response = await arinClient.QueryAsync(IPAddress.Parse("69.63.176.0")).Result;
    
But you should do async, really.




