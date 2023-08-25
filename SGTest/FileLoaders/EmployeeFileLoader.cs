using SGTest.DTO.Services;
using SGTest.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.FileLoaders
{
    internal class EmployeeFileLoader
    {
        EmployeeParser parser;
        EmployeeService employeeService;
        public EmployeeFileLoader()
        {
            parser = new EmployeeParser();
            employeeService = new EmployeeService();
        }
        public void LoadData(string fileName)
        {
            using (StreamReader streamReader = new(fileName))
            {
                string? entityLine;
                entityLine = streamReader.ReadLine();

                while ((entityLine = streamReader.ReadLine()) != null)
                {
                    try
                    {
                        var employeeDto = parser.ConvertToDto(entityLine);
                        employeeService.SaveEmployee(employeeDto);
                        Console.WriteLine(entityLine);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
