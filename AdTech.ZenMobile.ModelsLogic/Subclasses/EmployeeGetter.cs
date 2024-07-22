using AdTech.ZenMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdTech.ZenMobile.ModelsLogic.Subclasses
{
    public class EmployeeGetter
    {
        public EmployeeGetter() { }

        public Employee? getEmployee (int id, HashSet<Employee> employees)
        {
            var employee = employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }
    }
}
