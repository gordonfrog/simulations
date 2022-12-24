using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Kaizenko.Vending.DAL
{
    public class ADOPaymentDAO : IPaymentDAO
    {
        public int Retrieve()
        {
            using (var connection = GetConnection())
            {
                var payment = 0;

                var command = new SqlCommand("SELECT Value FROM Payment WHERE ID = 1;", connection);
                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        payment = reader.GetInt32(0);
                    }
                }                
                reader.Close();
                return payment;
            }
        }

        public void Save(int payment)
        {
            using (var connection = GetConnection())
            {
                var sqlCommandString = string.Format("UPDATE Payment SET Value = {0} WHERE ID = 1;", payment);
                var command = new SqlCommand(sqlCommandString, connection);
                connection.Open();

                var rowsChanged = command.ExecuteNonQuery();               
            }
        }      
       

        private SqlConnection GetConnection()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");

            var connectionString = builder
                .Build()
                .GetSection("ConnectionStrings")
                .GetSection("VendingMachineContext")
                .Value;

            return new SqlConnection(connectionString);
        }
    }
}
