using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdTech.ZenMobile.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private decimal _salaryPerHour;
        public decimal SalaryPerHour {
            get 
            {
                return _salaryPerHour;
            }
            set
            {
                if (value < 0)
                    throw new NegativeNumberException("Зарплата не может быть отрицательным числом.");
                _salaryPerHour = value;
            } 
        }

        public Employee (int id, string firstName, string lastName, decimal salaryPerHour)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SalaryPerHour = salaryPerHour;
        }

        public override string ToString()
        {
            return $"Id = {Id}, FirstName = {FirstName}, LastName = {LastName}, SalaryPerHour = {SalaryPerHour}";
        }
    }
}
