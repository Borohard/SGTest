using SGTest.DTO.Services;
using SGTest.Models;
using SGTest.Parsers;
using SGTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.FileLoaders
{
    public class DepartmentsFileLoader
    {
        DepartmentParser parser;
        DepartmentService departmentService;
        public DepartmentsFileLoader()
        {
            parser = new DepartmentParser();
            departmentService = new DepartmentService();
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
                        var departmentDto = parser.ConvertToDto(entityLine);
                        departmentService.SaveDepartment(departmentDto);
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
