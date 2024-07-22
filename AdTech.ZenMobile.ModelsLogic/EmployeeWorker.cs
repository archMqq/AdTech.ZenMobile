using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdTech.ZenMobile.Models;
using System.Text.Json;

namespace AdTech.ZenMobile.ModelsLogic
{
    public class EmployeeWorker
    {
        private readonly string _fileRoute;
        private HashSet<Employee>? _employees;

        public EmployeeWorker(string fileRoute) 
        {
            _fileRoute = fileRoute;
        }

        public HashSet<Employee>? getEmployees()
        {
            if (_employees is null)
            {
                var employeesString = File.ReadAllText(_fileRoute);
                _employees = string.IsNullOrEmpty(employeesString) ? null : JsonSerializer.Deserialize<HashSet<Employee>>(employeesString);
                return _employees;
            }
            else { return _employees; }
        }

        public bool saveEmployees()
        {      
            if (_employees is null)
                 return false;
            else
            {
                string result = JsonSerializer.Serialize<HashSet<Employee>>(_employees);
                try
                {
                    File.WriteAllText(_fileRoute, result);
                    return true;
                }
                catch (ArgumentNullException ex)
                {
                    //mb more logic
                    return false;
                }
                catch (UnauthorizedAccessException ex)
                {
                    //mb more logic
                    return false;
                }
            }            
        }

        public void updateEmployees(HashSet<Employee> employees)
        {
            _employees = employees;
        }
    }
}
