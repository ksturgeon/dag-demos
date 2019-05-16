using System;
using MapRDB.Driver;

public class FindById
{
    public void FindById()
	{
        // Create a connection to data access server
        var connectionStr = $"ldag-4092en.se.corp.maprtech.com:5678?auth=basic;" +
            $"user=mapr;" +
            $"password=maprmapr;" +
            $"ssl=false;";
        var connection = ConnectionFactory.CreateConnection(connectionStr);

        // Get a store and assign it as a DocumentStore object
        var store = connection.GetStore("/demo_tables/business");

        // Fetch the OJAI Document by its '_id' field
        var document = store.FindById("TGWhGNusxyMaA4kQVBNeew");

        // Print the OJAI Document
        Console.WriteLine(document);

        // Close the OJAI connection
        connection.Close();
    }
}