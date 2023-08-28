using SGTest.DTO.Services;
using SGTest.Parsers;

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
                        Console.WriteLine(entityLine);
                        var employeeDto = parser.ConvertToDto(entityLine);
                        employeeService.SaveEmployee(employeeDto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\tБитая запись, проверьте правильность данных");                       
                        Console.WriteLine("\t" + ex.Message);
                    }
                }
            }
        }
    }
}
