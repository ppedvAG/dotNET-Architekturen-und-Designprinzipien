using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace HalloFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var sqlConString = "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=true";
            var liteConString = "Data Source=c:\\DB\\northwind.sqlite;Version=3;";

            string conString = null;
            DbProviderFactory factory = null;


            if (!true)
            {
                factory = System.Data.SQLite.SQLiteFactory.Instance;
                conString = liteConString;
            }
            else
            {
                factory = System.Data.SqlClient.SqlClientFactory.Instance;
                conString = sqlConString;
            }

            DbConnection con = factory.CreateConnection();
            con.ConnectionString = conString;
            con.Open();
            using (DbCommand cmd = factory.CreateCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT Count(*) FROM Employees";
                var result = cmd.ExecuteScalar();
                Console.WriteLine($"{result} Employees in DB");
            }

            using (DbCommand cmd = factory.CreateCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM  Employees";
                DbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}");
            }


            //konrekt SQLite
            //SQLiteConnection con = new SQLiteConnection(liteConString);
            //con.Open();
            //using (SQLiteCommand cmd = new SQLiteCommand())
            //{
            //    cmd.Connection = con;
            //    cmd.CommandText = "SELECT Count(*) FROM Employees";
            //    var result = cmd.ExecuteScalar();
            //    Console.WriteLine($"{result} Employees in DB");
            //}

            //using (var cmd = new SQLiteCommand())
            //{
            //    cmd.Connection = con;
            //    cmd.CommandText = "SELECT * FROM  Employees";
            //    SQLiteDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //        Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}");
            //}

            //konrekt SQL Server
            //SqlConnection con = new SqlConnection(sqlConString);
            //con.Open();
            //using (SqlCommand cmd = new SqlCommand())
            //{
            //    cmd.Connection = con;
            //    cmd.CommandText = "SELECT Count(*) FROM Employees";
            //    var result = cmd.ExecuteScalar();
            //    Console.WriteLine($"{result} Employees in DB");
            //}

            //using (var cmd = new SqlCommand())
            //{
            //    cmd.Connection = con;
            //    cmd.CommandText = "SELECT * FROM  Employees";
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while(reader.Read())
            //        Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}");
            //}


            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
