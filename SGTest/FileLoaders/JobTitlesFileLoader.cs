using SGTest.Parsers;
using SGTest.Services;
using System.Diagnostics;

namespace SGTest.FileLoaders
{
    internal class JobTitlesFileLoader
    {
        private readonly JobTitleParser parser;
        private readonly JobTitleService jobTitleService;
        private const int linesCountToShowProgress = 2;

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
                var currentLinesCount = 0;
                var sw = new Stopwatch();
                var allReadEntityTime = new TimeSpan();

                while ((entityLine = streamReader.ReadLine()) != null)
                {
                    sw.Start();
                    try
                    {
                        var jobTitleDto = parser.ConvertToDto(entityLine);
                        jobTitleService.SaveJobTitle(jobTitleDto);                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(entityLine);
                        Console.WriteLine("\tБитая запись, проверьте правильность данных");
                        Console.WriteLine("\t" + ex.Message);
                    }
                
                    sw.Stop();
                    currentLinesCount++;
                    allReadEntityTime += sw.Elapsed;
                    
                    if (currentLinesCount % linesCountToShowProgress == 0)
                    {
                        Console.WriteLine($"Прочитано {currentLinesCount} записей...");
                        Console.WriteLine($"Времени прошло: {allReadEntityTime}");
                        Console.WriteLine($"Среднее время чтения: {allReadEntityTime / currentLinesCount}");
                    }
                    sw.Reset();
                }
                Console.WriteLine("Импорт данных завершен!");
            }
        }      
    }
}
