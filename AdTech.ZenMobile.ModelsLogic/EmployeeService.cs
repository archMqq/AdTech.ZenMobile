using AdTech.ZenMobile.ModelsLogic.Subclasses;

namespace AdTech.ZenMobile.ModelsLogic
{
    public class EmployeeService
    {
        private EmployeeWorker worker;

        public EmployeeService(string fileRoute) 
        {
            worker = new EmployeeWorker(fileRoute);
        }

        public void call(string[] callLine)
        {
            var employees = worker.getEmployees();
            bool employeesIsNull = employees is null;
            switch (callLine[0])
            {
                case "-add":
                    if (employees is null)
                        employees = new HashSet<Models.Employee>();

                    var adder = new EmployeeAdder();
                    bool addRes = adder.addEmployee(callLine[1].Substring(10, callLine[1].Length - 10), 
                        callLine[2].Substring(9, callLine[2].Length - 9), 
                        decimal.Parse(callLine[3].Substring(7, callLine[3].Length - 7)), employees);

                    if (employeesIsNull && addRes)
                        employeesIsNull = true;

                    worker.updateEmployees(employees);
                    worker.saveEmployees();
                    break;

                case "-update":
                    var updater = new EmployeeUpdater();
                    bool updRes = updater.updateEmployee(int.Parse(callLine[1].Substring(3, callLine[1].Length - 3)),
                        callLine[2].Substring(10, callLine[2].Length - 10), employees);

                    if (!updRes)
                        Console.WriteLine("Пользователя с таким id не существует.");
                    else
                    {
                        worker.updateEmployees(employees);
                        worker.saveEmployees();
                    }
                    break;

                case "-get":
                    if (!employeesIsNull)
                    {
                        var getter = new EmployeeGetter();
                        var getRes = getter.getEmployee(int.Parse(callLine[1].Substring(3, callLine[1].Length - 3)),
                            employees);

                        Console.WriteLine(getRes is not null ? getRes.ToString() : "Пользователя с таким id не существует.");
                    }
                    else
                        Console.WriteLine("Пользователя с таким id не существует.");
                    break;

                case "-delete":
                    if (employeesIsNull)
                        Console.WriteLine("Список сотрудников пуст!");
                    var deleter = new EmployeeDeleter();
                    bool delRes = deleter.deleteEmployee(int.Parse(callLine[1].Substring(3, callLine[1].Length - 3)), 
                        employees);

                    if (!delRes)
                        Console.WriteLine("Пользователя с таким id не существует.");
                    else
                    {
                        worker.updateEmployees(employees);
                        worker.saveEmployees();
                    }
                    break;

                case "-getall":
                    foreach (var employee in employees)
                        Console.WriteLine(employee.ToString());
                    break;

                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }

            
        }
    }
}
