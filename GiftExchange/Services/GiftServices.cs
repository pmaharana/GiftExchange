using GiftExchange.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GiftExchange.Services
{
    public class GiftServices
    {

        const string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=GiftExchange;Trusted_Connection=True;";

        public List<Gift> GetAllGifts()
        {
            var rv = new List<Gift>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select * from [Gifts]";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Gift(reader));
                }
                connection.Close();
            }
            return rv;
        }
    }
     
}