using SGTest.DTO.Services;
using SGTest.Parsers;

namespace SGTest.FileLoaders
{
    internal class JobTitlesFileLoader
    {
        JobTitleParser parser;
        JobTitleService jobTitleService;

        public JobTitlesFileLoader()
        {
            parser = new JobTitleParser();
            jobTitleService = new JobTitleService();
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
                        var jobTitleDto = parser.ConvertToDto(entityLine);
                        jobTitleService.SaveJobTitle(jobTitleDto);
                        Console.WriteLine(entityLine);
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
