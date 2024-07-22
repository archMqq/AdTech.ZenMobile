using AdTech.ZenMobile.ModelsLogic;
using System.Globalization;

partial class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); 
        //Изменение культуры для возможности перевода 100.50 в дробное число

        string fileRoute = "C:\\app.json"; //Здесь путь файла (или с аргументами в main его передавать)

        var service = new EmployeeService(fileRoute);
        service.call(args);
    }
}