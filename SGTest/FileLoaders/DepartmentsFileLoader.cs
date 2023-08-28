using SGTest.DTO.Services;
using SGTest.Parsers;

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
                        Console.WriteLine(entityLine);
                        var departmentDto = parser.ConvertToDto(entityLine);
                        departmentService.SaveDepartment(departmentDto);
                        
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
