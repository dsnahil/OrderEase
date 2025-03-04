using System;
using System.Data.SQLite;
using System.Collections.Generic;

public class DatabaseManager
{
    private string connectionString = "Data Source=OrderEase.db;Version=3;";

    public void CreateDatabase()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string createTableQuery = "CREATE TABLE IF NOT EXISTS Orders (Id INTEGER PRIMARY KEY, ItemName TEXT, Quantity INTEGER, Price INTEGER)";
            using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void AddOrder(string itemName, int quantity, int price)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string insertQuery = "INSERT INTO Orders (ItemName, Quantity, Price) VALUES (@ItemName, @Quantity, @Price)";
            using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<Order> GetOrders()
    {
        List<Order> orders = new List<Order>();
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Orders";
            using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            Id = reader.GetInt32(0),
                            ItemName = reader.GetString(1),
                            Quantity = reader.GetInt32(2),
                            Price = reader.GetInt32(3)
                        });
                    }
                }
            }
        }
        return orders;
    }

    public void DeleteOrder(int orderId)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string deleteQuery = "DELETE FROM Orders WHERE Id = @Id";
            using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Id", orderId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

public class Order
{
    public int Id { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
}
