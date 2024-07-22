using AdTech.ZenMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdTech.ZenMobile.ModelsLogic.Subclasses
{
    public class EmployeeDeleter
    {
        public EmployeeDeleter() { }

        public bool deleteEmployee(int id, HashSet<Employee> employees)
        {
            if (employees is null)
                return false;

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                return true;
            }
            return false;
        }
    }
}
