using SGTest.Models;
using SGTest.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;
using SGTest.FileLoaders;
using SGTest.OutputService;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Здравствуйте! Вы можете импортировать TSV файл или вывести текущую структуру данных");
        Console.WriteLine("\t -input --Импорт данных");
        Console.WriteLine("\t -info --вывести текущую структуру данных ");

        string? userMode = Console.ReadLine();
        switch (userMode)
        {
            case "-input":
                InputUserData();
                break;
            case "-info":
                ShowData();
                break;
        }       
    }

    private static void ShowData()
    {
        Console.WriteLine("Введите индекс подразделения:");
        int userInputResult;
        int.TryParse(Console.ReadLine(), out userInputResult);
        OutputService outputService = new OutputService();
        outputService.ShowHierarchyByDepartmentID(userInputResult);
    }

    private static void InputUserData()
    {
        DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);
        string folder = di.Parent.Parent.Parent.Parent.ToString(); 

        Console.WriteLine("Введите название TSV файла, который содержится в папке data: ");
        string? userFileName = Console.ReadLine();

        Console.WriteLine("Укажите тип импорта: ");
        Console.WriteLine("\t -dpt --Подразделение");
        Console.WriteLine("\t -emp --Сотрудник");
        Console.WriteLine("\t -jtt --Название должности");

        var userInputMode = Console.ReadLine();
        switch (userInputMode)
        {
            case "-dpt":
                Console.WriteLine("department");
                DepartmentsFileLoader departmentsFileLoader = new DepartmentsFileLoader();
                departmentsFileLoader.LoadData(folder + "\\data\\" + userFileName + ".tsv");
                break;
            case "-emp":
                Console.WriteLine("employee");
                EmployeeFileLoader employeeFileLoader = new EmployeeFileLoader();
                employeeFileLoader.LoadData(folder + "\\data\\" + userFileName + ".tsv");
                break;
            case "-jtt":
                JobTitlesFileLoader jobTitlesFileLoader = new JobTitlesFileLoader();
                jobTitlesFileLoader.LoadData(folder + "\\data\\" + userFileName + ".tsv");
                break;
        }
    }


}