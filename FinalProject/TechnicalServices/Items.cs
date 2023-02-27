using FinalProject.Domain;
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
    public class Items
    {
       

        public List<Item> AddtoCart(String ItemCode, int Quantity)
        {

            List<Item> name = new List<Item>();

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
            command.CommandText = "AddToCart";




            SqlParameter itemcode = new SqlParameter();
            itemcode.Value = ItemCode;
            itemcode.SqlDbType = SqlDbType.NVarChar;
            itemcode.ParameterName = "@ItemCode";
            command.Parameters.Add(itemcode);


            SqlParameter quantity = new SqlParameter();
            quantity.Value = Convert.ToInt32(Quantity) ;
            quantity.SqlDbType = SqlDbType.Int;
            quantity.ParameterName = " @Quantity";
            command.Parameters.Add(quantity);


            SqlDataReader exampledatareader;

            exampledatareader = command.ExecuteReader();




            if (exampledatareader.HasRows)
            {

                for (int i = 0; i < exampledatareader.FieldCount; i++)
                {

                    Console.Write(exampledatareader.GetName(i) + " ");

                }
                Console.WriteLine();



                while (exampledatareader.Read())
                {

                    Item add = new Item();
                    string tempprice;
                    string tempquantity;
                   

                    add.ItemCode = exampledatareader[0].ToString();
                    add.Description = exampledatareader[1].ToString();
                    tempprice = (exampledatareader[2].ToString());
                    tempquantity = exampledatareader[3].ToString();
                 
                    add.UnitPrice = Int16.Parse(tempprice);
                    add.Quantity = Int16.Parse(tempquantity);

                    add.ItemTotal = exampledatareader[4].ToString();




                    name.Add(add);

                }

            }

            exampledatareader.Close();
            BAIS3150.Close();





            return name;



        }


        public static bool AddItem(string ItemCode, string Description, int UnitPrice, int Quantity)
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
            command.CommandText = "AddItem";


            SqlParameter itemcode = new SqlParameter();
            itemcode.Value = ItemCode;
            itemcode.SqlDbType = SqlDbType.NVarChar;
            itemcode.ParameterName = "@ItemCode";
            command.Parameters.Add(itemcode);

            SqlParameter description = new SqlParameter();
            description.Value = Description;
            description.SqlDbType = SqlDbType.NVarChar;
            description.ParameterName = "@Description";
            command.Parameters.Add(description);

            SqlParameter unitprice = new SqlParameter();
            unitprice.Value = Convert.ToInt32(UnitPrice);
            
            unitprice.SqlDbType = SqlDbType.Int;
            unitprice.ParameterName = "@UnitPrice";
            command.Parameters.Add(unitprice);

            SqlParameter quantity = new SqlParameter();
            quantity.Value = Convert.ToInt32(Quantity);
            
            quantity.SqlDbType = SqlDbType.Int;
            quantity.ParameterName = "@Quantity";
            command.Parameters.Add(quantity);


            

            command.ExecuteNonQuery();

            return true;
        }

        

       public static bool UpdateItem(string ItemCode, string Description, int UnitPrice, int Quantity)
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
            command.CommandText = "UpdateItem";


            SqlParameter itemcode = new SqlParameter();
            itemcode.Value = ItemCode;
            itemcode.SqlDbType = SqlDbType.NVarChar;
            itemcode.ParameterName = "@ItemCode";
            command.Parameters.Add(itemcode);

            SqlParameter description = new SqlParameter();
            description.Value = Description;
            description.SqlDbType = SqlDbType.NVarChar;
            description.ParameterName = "@Description";
            command.Parameters.Add(description);

            SqlParameter unitprice = new SqlParameter();
            unitprice.Value = UnitPrice;
            unitprice.SqlDbType = SqlDbType.Int;
            unitprice.ParameterName = "@UnitPrice";
            command.Parameters.Add(unitprice);

            SqlParameter quantity = new SqlParameter();
            quantity.Value = Quantity;
            quantity.SqlDbType = SqlDbType.Int;
            quantity.ParameterName = "@Quantity";
            command.Parameters.Add(quantity);




            command.ExecuteNonQuery();

            return true;
        }

        public static bool DeleteItem(string ItemCode)
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
            command.CommandText = "DeleteItem";


            SqlParameter itemcode = new SqlParameter();
            itemcode.Value = ItemCode;
            itemcode.SqlDbType = SqlDbType.NVarChar;
            itemcode.ParameterName = "@ItemCode";
            command.Parameters.Add(itemcode);


            command.ExecuteNonQuery();

            return true;
        }

        

         public List<Item> ReturnItem(String ItemCode)
        {

            List<Item> name = new List<Item>();

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
            command.CommandText = "GetItem";




            SqlParameter AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.Char,
                Direction = ParameterDirection.Input,
                SqlValue = ItemCode
            };

            command.Parameters.Add(AnAddCommandParameter);
            SqlDataReader exampledatareader;
            exampledatareader = command.ExecuteReader();




            if (exampledatareader.HasRows)
            {

                for (int i = 0; i < exampledatareader.FieldCount; i++)
                {

                    Console.Write(exampledatareader.GetName(i) + " ");

                }
                Console.WriteLine();



                while (exampledatareader.Read())
                {

                    Item getitem = new Item();
                    string tempprice;
                    string tempquantity;

                    getitem.ItemCode = exampledatareader[0].ToString();
                    getitem.Description = exampledatareader[1].ToString();
                    tempprice = (exampledatareader[2].ToString());
                    tempquantity = exampledatareader[3].ToString();

                    getitem.UnitPrice = Int16.Parse(tempprice);
                    getitem.Quantity = Int16.Parse(tempquantity);
             


                    name.Add(getitem);

                }

            }

            exampledatareader.Close();
            BAIS3150.Close();





            return name;



        }

    }
}
