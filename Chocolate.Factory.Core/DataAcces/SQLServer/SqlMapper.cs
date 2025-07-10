using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.Core.Domain.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.DataAcces.SQLServer
{
    internal class SqlMapper
    {
        internal static Product MapProduct(SqlDataReader reader)
        {
            return new Product
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                CompanyName = (string)reader["CompanyName"],
                StandartWeight = (decimal)reader["StandartWeight"]
            };
        }


        internal static Ingredient MapIngredient(SqlDataReader reader)
        {
            return new Ingredient
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                UseTime = (UseTimeType)(int)reader["UseTime"],

                InStock = (decimal)reader["InStock"]
            };
        }
       
        internal static Dosage MapDosage(SqlDataReader reader)
        {
            return new Dosage
            {
                Id = (int)reader["DosageId"],
                Quantity = (decimal)reader["Quantity"],
                Deviation = (decimal)reader["Deviation"],
                Product = new Product
                {
                    Id = (int)reader["ProductID"],
                    Name = (string)reader["ProductName"],
                    CompanyName = (string)reader["CompanyName"],
                    StandartWeight = (decimal)reader["StandartWeight"]
                },
                Ingredient=new Ingredient
                {
                    Id = (int)reader["IngredientID"],
                    Name = (string)reader["IngredientName"],
                    UseTime = (UseTimeType)(int)reader["UseTime"],
                    InStock = (decimal)reader["InStock"]
                }


            };
        }

        

               internal static Machine MapMachine(SqlDataReader reader)
               {
                   return new Machine
                   {
                       Id = (int)reader["ID"],
                       MachineType = (MachinType)(int)reader["MachineType"],
                       BrandName = (string)reader["BrandName"],
                       SerialNumber = (string)reader["SerialNumber"],
                       HourlyElectricWaste = (int)reader["HourlyElectricWaste"],
                       UsePeriod = (int)reader["UsePeriod"],
                       PurchaseDate = (DateTime)reader["PurchaseDate"]


                   };
               }
        
        
        
        
        internal static WorkTime MapWorkTime(SqlDataReader reader)
               {
                   return new WorkTime
                   {
                       Id = (int)reader["ID"],
                       ThisDay = (DateTime)reader["ThisDay"],
                       StartTime = (TimeSpan)reader["StartTime"],
                       StopTime = (TimeSpan)reader["StopTime"],
                       Production = (int)reader["Production"],
                       IsInspected = (bool)reader["IsInspected"],
                       Machine=new Machine
                       {
                           Id = (int)reader["ID"],
                           MachineType = (MachinType)(int)reader["MachineType"],
                           BrandName = (string)reader["BrandName"],
                           SerialNumber = (string)reader["SerialNumber"],
                           HourlyElectricWaste = (int)reader["HourlyElectricWaste"],
                           UsePeriod = (int)reader["UsePeriod"],
                           PurchaseDate = (DateTime)reader["PurchaseDate"]


                       }


                   };
               }

//down
        internal static Car MapCar(SqlDataReader reader)
        {
            return new Car
            {
                Id = (int)reader["ID"],
                CarType = (CarType)(int)reader["CarType"],
                BrandName = (string)reader["BrandName"],
                SerialNumber = (string)reader["SerialNumber"],
                UsePeriod = (int)reader["UsePeriod"],
                PurchaseDate = (DateTime)reader["PurchaseDate"]


            };
        }




        internal static CarWorkTime MapCarWorkTime(SqlDataReader reader)
        {
            return new CarWorkTime
            {
                Id = (int)reader["ID"],
                ThisDay = (DateTime)reader["ThisDay"],
                StartTime = (TimeSpan)reader["StartTime"],
                StopTime = (TimeSpan)reader["StopTime"],
                TranslateProduction = (int)reader["TranslateProduction"],
                WastedGas = (int)reader["WastedGas"],
                IsInspected = (bool)reader["IsInspected"],
                Car = new Car
                {
                    Id = (int)reader["ID"],
                    CarType = (CarType)(int)reader["CarType"],
                    BrandName = (string)reader["BrandName"],
                    SerialNumber = (string)reader["SerialNumber"],
                    UsePeriod = (int)reader["UsePeriod"],
                    PurchaseDate = (DateTime)reader["PurchaseDate"]


                }


            };
        }


        internal static User MapUser(SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["id"],
                Username = (string)reader["username"],
                PasswordHash = (string)reader["passwordHash"],
                Created = (DateTime)reader["created"],


            };
        }



    }
}
