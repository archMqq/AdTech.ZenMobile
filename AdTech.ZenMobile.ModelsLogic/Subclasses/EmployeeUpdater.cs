using AdTech.ZenMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdTech.ZenMobile.ModelsLogic.Subclasses
{
    public class EmployeeUpdater
    {
        public EmployeeUpdater() { }

        public bool updateEmployee(int id, string firstName, HashSet<Employee> employees)
        {
            try
            {
                employees.FirstOrDefault(x => x.Id == id).FirstName = firstName;
                return true;
            }
            catch (NullReferenceException ex)
            {
                return false;
            }
            
        }
    }
}
