using System;

namespace CSharpCodeReview1
{
    public class Employee
    {
        private DateTime _birthDate;
        
        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }

        private string id;
        
        public string Id
        {
            get => id; 
            set => id = value ?? Guid.NewGuid().ToString();
        }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string JobTitle { get; set; }
        
        public double MonthlySalary { get; set; }

        public static double TaxRate => 0.21;

        public string FullName { get; private set; }

        public Employee(string id, string firstName, string lastName, string jobTitle, DateTime birthDate, double monthlySalary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            BirthDate = birthDate;
            MonthlySalary = monthlySalary;

            FullName = firstName + lastName;
        }

        public Employee() { }


        /// <summary>
        /// Method to count sum of 12 salaries (one per month) of the employee
        /// based on attribute monthlySalaryCZK
        /// </summary>
        /// <returns>Sum of all the 12 salaries</returns>
        public double CalcYearlySalary()
        {
            return MonthlySalary * 12;
        }

        /// <summary>
        /// Method to calculate salary after taxation
        /// </summary>
        /// <param name="salary">Salary of employee</param>
        /// <returns>Salary after to taxation</returns>
        protected virtual double ApplyTaxRateToSalary(double salary)
        {
            return salary * (1 - TaxRate);
        }

        public override string ToString() => $"ID:  {Id}; NAME: {FirstName} {LastName}; JOB:{JobTitle}; SALARY: {MonthlySalary}";

    }
}