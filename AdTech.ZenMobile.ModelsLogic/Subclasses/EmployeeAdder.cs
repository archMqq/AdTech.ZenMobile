using AdTech.ZenMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdTech.ZenMobile.ModelsLogic.Subclasses
{
    public class EmployeeAdder
    {
        public EmployeeAdder() { }


        public bool addEmployee(string firstName, string lastName, decimal salary, HashSet<Employee> employees)
        {
            int newEmployeeId = employees.Count > 0 ? employees.Max(x => x.Id) + 1 : 1;
            Employee newEmployee;
            try 
            {
                newEmployee = new Employee(newEmployeeId, firstName, lastName, salary);
            }
            catch (NegativeNumberException ex)
            {
                return false;
            }
            
            employees.Add(newEmployee);
            return true;

        }
    }
}
