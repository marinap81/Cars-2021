using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using CarsLib;



namespace CarsApi.Database
{
    public class CarsData
    {
        static string connectionString = "Server=beersdb.cxjl13cbth6s.us-east-1.rds.amazonaws.com;Database=BeersDB;User Id=admin;password=abcd1234";

            SqlConnection connection;

            public string Connect() { 
            connection = new SqlConnection(connectionString); 
            connection.Open(); 

            return "Ok";

            }
              // (3) Return a List of Cars to controller

            public List<Cars> GetAllCarsFromDB() 
            {
                List<Cars> cars = new List<Cars>(); //temp array, sends to controller
            
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    
                    SqlCommand command = new SqlCommand("SELECT * FROM CAR", connection);
                                                                        
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {    
                        //convert the data from DB into the object neeeded how c# will read data from sql DB
                        string registration = reader.GetString(0); //index point in sql table added
                        string make = reader.GetString(1);
                        string model = reader.GetString(2);
                        int yearOfManufacture = reader.GetInt32(3); 
                        int speed = reader.GetInt32(4);
                        
                        connection.Open();
                        cars.Add(new Cars(registration, make, model, yearOfManufacture, speed));
                    }
                }
                
                return cars;
            }

            /*Table Car (
    registration VARCHAR(7) PRIMARY KEY,
    make VARCHAR(25),
    model VARCHAR(25),
    yearOfManufacture INT,
    speed INT*/
               public void addNewcarToDB(Cars newCar)
            {
                
                //SQL PARAMETER IS USED TO PROTECTED AGAINST SQL INJECTION

                using (SqlConnection connection = new SqlConnection(connectionString)) /*using closes a connection*/
                {
                    
                    //SqlCommand command = new SqlCommand("INSERT INTO BEER VALUES (@Name, @Brewery, @Abv, @Ibu, @Amount, @Cost, @Open)");

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    // Create the commands.
                    
                    adapter.InsertCommand = new SqlCommand("INSERT INTO CAR (registration, make, model, yearOfManufacture, amount) " +
                                                            "VALUES (@Rego, @Make, @Model, @Yom, @Speed)", connection);
                                   
                     
                        SqlParameter registrationParam = new SqlParameter();
                        registrationParam.ParameterName = "@Rego";
                        registrationParam.Value = newCar.Rego;

                        SqlParameter makeParam = new SqlParameter();
                        makeParam.ParameterName = "@Make";
                        makeParam.Value = newCar.Make;
                        
                        SqlParameter modelParam = new SqlParameter();
                        modelParam.ParameterName = "@Model";
                        modelParam.Value = newCar.Model;
                        
                        SqlParameter yearManufactureParam = new SqlParameter();
                        yearManufactureParam.ParameterName = "@Yom";
                        yearManufactureParam.Value = newCar.yearOfManufacture;
                      
                        SqlParameter speedParam = new SqlParameter();
                        speedParam.ParameterName = "@Speed";
                        speedParam.Value = newCar.Speed;
                        
                        adapter.InsertCommand.Parameters.Add(registrationParam);
                        adapter.InsertCommand.Parameters.Add(makeParam);
                        adapter.InsertCommand.Parameters.Add(modelParam);
                        adapter.InsertCommand.Parameters.Add(yearManufactureParam);
                        adapter.InsertCommand.Parameters.Add(speedParam);
                 
                        connection.Open();

                        adapter.InsertCommand.ExecuteNonQuery();
          
                        
                }
             

            }