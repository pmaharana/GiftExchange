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

        public void AddAGift(Gift present)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var text = @"insert into[Gifts] (Contents, GiftHint, ColorWrappingPaper, Height, Width, Depth, Weight, IsOpened)
                    values(@Contents, @GiftHint, @ColorWrappingPaper, @Height, @Width, @Depth, @Weight, @IsOpened);";

                var addCmd = new SqlCommand(text, connection);

                
                addCmd.Parameters.AddWithValue("@Contents", present.Contents);
                addCmd.Parameters.AddWithValue("@GiftHint", present.GiftHint);
                addCmd.Parameters.AddWithValue("@ColorWrappingPaper", present.ColorWrappingPaper);
                addCmd.Parameters.AddWithValue("@Height", present.Height);
                addCmd.Parameters.AddWithValue("@Width", present.Width);
                addCmd.Parameters.AddWithValue("@Depth", present.Depth);
                addCmd.Parameters.AddWithValue("@Weight", present.Weight);
                addCmd.Parameters.AddWithValue("@IsOpened", present.IsOpened);
                connection.Open();
                addCmd.ExecuteNonQuery();
 
                connection.Close();
            }
        }

        public void UpdateGift(Gift present)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var text = @"update [Gifts] 
 Set Contents = @Contents, GiftHint = @GiftHint, ColorWrappingPaper = @ColorWrappingPaper, Height = @Height, Width = @Width, 
 Depth = @Depth, Weight = @Weight, IsOpened = @IsOpened where Id = @Id;";

                var cmd = new SqlCommand(text, connection);

                cmd.Parameters.AddWithValue("@Contents", present.Contents);
                cmd.Parameters.AddWithValue("@GiftHint", present.GiftHint);
                cmd.Parameters.AddWithValue("@ColorWrappingPaper", present.ColorWrappingPaper);
                cmd.Parameters.AddWithValue("@Height", present.Height);
                cmd.Parameters.AddWithValue("@Width", present.Width);
                cmd.Parameters.AddWithValue("@Depth", present.Depth);
                cmd.Parameters.AddWithValue("@Weight", present.Weight);
                cmd.Parameters.AddWithValue("@IsOpened", present.IsOpened);
                cmd.Parameters.AddWithValue("@Id", present.Id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void OpenGift(Gift present)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var text = @"UPDATE [Gifts] " +
                    " SET IsOpened = @IsOpened WHERE Id = @Id;";

                var cmd = new SqlCommand(text, connection);

                cmd.Parameters.AddWithValue("@IsOpened", true);
                cmd.Parameters.AddWithValue("@Id", present.Id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteGift(Gift present)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var text = @"DELETE FROM [Gifts] " +
                    " WHERE Id = @Id;";

                var cmd = new SqlCommand(text, connection);
                cmd.Parameters.AddWithValue("@Id", present.Id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                
            }
        }



    }

     
}