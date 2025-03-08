using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace mnogopotok
{
    public class DatabaseHelper
    {
        private const string ConnectionString = "Data Source=purchases.db;Version=3;";

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(@"
                CREATE TABLE IF NOT EXISTS purchases (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    first_name TEXT NOT NULL,
                    last_name TEXT NOT NULL,
                    purchase_date TEXT NOT NULL,
                    order_number TEXT NOT NULL
                )", connection);
                command.ExecuteNonQuery();
            }
        }

        public static void InsertPurchase(string firstName, string lastName, string purchaseDate, string orderNumber)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(@"
                INSERT INTO purchases (first_name, last_name, purchase_date, order_number)
                VALUES (@firstName, @lastName, @purchaseDate, @orderNumber)", connection);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@purchaseDate", purchaseDate);
                command.Parameters.AddWithValue("@orderNumber", orderNumber);
                command.ExecuteNonQuery();
            }
        }

        public static DataTable GetPurchases()
        {
            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT first_name, last_name, purchase_date, order_number FROM purchases", connection);
                using (var reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            return dataTable;
        }
    }
}
