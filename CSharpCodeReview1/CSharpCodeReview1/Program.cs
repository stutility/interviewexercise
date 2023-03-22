using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CSharpCodeReview1
{
    public static class Program
    {
        // a database client class that is a wrapper for a sql server connection
        private static DbClient dbClient; 
        
        public static void Main(string[] args)
        {
            List<Employee> employeeArray = new List<Employee>();
            var filename = "employeelist.csv";
            dbClient = new DbClient("a connection string here");
            dbClient.openDbConnection();
            try
            {
                StreamReader streamReader = new StreamReader(filename);
                string line;    
                while ((line = streamReader.ReadLine()) != null)
                {
                    employeeArray.Add(parseRow(line));

                    SaveToDb(parseRow(line));
                }
                
                streamReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: "+ex.Message);
            }

            for(var i = 0; i <= employeeArray.Count; i++)
            {
                Console.WriteLine($"Position {i} has ID of {employeeArray[i].Id} and name of {employeeArray[i].FullName}");
            }

            dbClient.closeDbConnection();
        }

        /// <summary>
        /// Parses a cvs text string to an employee object
        /// </summary>
        /// <param name="csvdatarow"></param>
        /// <returns></returns>
        private static Employee parseRow(string csvdatarow)
        {
            // you can assume all fields are present and in the order of
            // Firstname, Lastname, Jobtitle, Birthday, Salary
            try
            {
                // pretend parsing code is here 

                // return hard coded values since we arent parsing anything real
                return new Employee(
                    Guid.NewGuid().ToString(),
                    "John ", "Doe", "Engineer",
                    DateTime.Parse("1980-5-3"), 5000.00);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void SaveToDb(Employee employee)
        {
            var insertSql = 
                $"insert into employees (id, firstname, lastname, jobtitle) VALUES " +
                $"({employee.Id}, '{employee.FirstName}', '{employee.LastName}', '{employee.JobTitle}')";

            if (dbClient.runCommand(insertSql) < 0)
            {
                Console.WriteLine("Write to db failed");
            }
        }
    }
}