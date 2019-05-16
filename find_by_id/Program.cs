using System;
using MapRDB.Driver;

namespace find_by_id
{
    class Program
    {
        static void Main(string[] args)
        {
        // Create a connection to data access server
        var connectionStr = "dag-4092en.se.corp.maprtech.com:5678?auth=basic;user=mapr;password=maprmapr;ssl=false";
        var connection = ConnectionFactory.CreateConnection(connectionStr);

        // Get a store and assign it as a DocumentStore object
        var store = connection.GetStore("/demo-tables/business");

        // Fetch the OJAI Document by its '_id' field
        var document = store.FindById("TGWhGNusxyMaA4kQVBNeew", "name");

        Console.WriteLine(document.ToJsonString());

        // Close the OJAI connection
        connection.Close();
        }
    }
}
