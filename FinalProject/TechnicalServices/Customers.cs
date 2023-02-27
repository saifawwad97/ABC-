using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.TechnicalServices
{
    public class Customers
    {
        public  bool AddCustomer(string CustomerID, string CustomerName, string Addresses, string City, string Province, string PostalCode)
        {
            

                ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
                DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
                DatabaseUsersBuilder.AddJsonFile("appsettings.json");
                IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

                SqlConnection BAIS3150 = new SqlConnection();
                BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
                BAIS3150.Open();


                SqlCommand command = new SqlCommand();
                command.Connection = BAIS3150;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddCustomer";


                SqlParameter customerid = new SqlParameter();
                customerid.Value = CustomerID;
                customerid.SqlDbType = SqlDbType.NVarChar;
                customerid.ParameterName = "@CustomerID";
                command.Parameters.Add(customerid);

                SqlParameter customername = new SqlParameter();
                customername.Value = CustomerName;
                customername.SqlDbType = SqlDbType.NVarChar;
                customername.ParameterName = "@CustomerName";
                command.Parameters.Add(customername);

                SqlParameter address = new SqlParameter();
                address.Value = Addresses;
                address.SqlDbType = SqlDbType.NVarChar;
                address.ParameterName = "@Addresses";
                command.Parameters.Add(address);

                SqlParameter city = new SqlParameter();
                city.Value = City;
                city.SqlDbType = SqlDbType.NVarChar;
                city.ParameterName = "@City";
                command.Parameters.Add(city);

                SqlParameter province = new SqlParameter();
                province.Value = Province;
                province.SqlDbType = SqlDbType.NVarChar;
                province.ParameterName = "@Province";
                command.Parameters.Add(province);

                SqlParameter Postalcode = new SqlParameter();
                Postalcode.Value = PostalCode;
                Postalcode.SqlDbType = SqlDbType.NVarChar;
                Postalcode.ParameterName = "@PostalCode";
                command.Parameters.Add(Postalcode);



                command.ExecuteNonQuery();

                return true;

            }

            public  bool Updatecustomer(string CustomerID, string CustomerName, string Addresses, string City, string Province, string PostalCode)
            {
                

                    ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
                    DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
                    DatabaseUsersBuilder.AddJsonFile("appsettings.json");
                    IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

                    SqlConnection BAIS3150 = new SqlConnection();
                    BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
                    BAIS3150.Open();


                    SqlCommand command = new SqlCommand();
                    command.Connection = BAIS3150;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateCustomer";


                    SqlParameter customerid = new SqlParameter();
                    customerid.Value = CustomerID;
                    customerid.SqlDbType = SqlDbType.NVarChar;
                    customerid.ParameterName = "@CustomerID";
                    command.Parameters.Add(customerid);

                    SqlParameter customername = new SqlParameter();
                    customername.Value = CustomerName;
                    customername.SqlDbType = SqlDbType.NVarChar;
                    customername.ParameterName = "@CustomerName";
                    command.Parameters.Add(customername);

                    SqlParameter address = new SqlParameter();
                    address.Value = Addresses;
                    address.SqlDbType = SqlDbType.NVarChar;
                    address.ParameterName = "@Addresses";
                    command.Parameters.Add(address);

                    SqlParameter city = new SqlParameter();
                    city.Value = City;
                    city.SqlDbType = SqlDbType.NVarChar;
                    city.ParameterName = "@City";
                    command.Parameters.Add(city);

                    SqlParameter province = new SqlParameter();
                    province.Value = Province;
                    province.SqlDbType = SqlDbType.NVarChar;
                    province.ParameterName = "@Province";
                    command.Parameters.Add(province);

                    SqlParameter Postalcode = new SqlParameter();
                    Postalcode.Value = PostalCode;
                    Postalcode.SqlDbType = SqlDbType.NVarChar;
                    Postalcode.ParameterName = "@PostalCode";
                    command.Parameters.Add(Postalcode);



                    command.ExecuteNonQuery();

                    return true;

            }
        
        public bool deleteCustomer(string CustomerID)
        {


            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();


            SqlCommand command = new SqlCommand();
            command.Connection = BAIS3150;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DeleteCustomer";


            SqlParameter customerid = new SqlParameter();
            customerid.Value = CustomerID;
            customerid.SqlDbType = SqlDbType.NVarChar;
            customerid.ParameterName = "@CustomerID";
            command.Parameters.Add(customerid);

          

            command.ExecuteNonQuery();

            return true;

        }

    }
}
