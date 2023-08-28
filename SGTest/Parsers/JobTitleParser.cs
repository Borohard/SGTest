using SGTest.DTO.Models;
using System.Text.RegularExpressions;

namespace SGTest.Parsers
{
    internal class JobTitleParser
    {
        public JobTitleDTO ConvertToDto(string jobTitleLine)
        {           
            JobTitleDTO dto = new JobTitleDTO();
            dto.Title = CleanTitleField(jobTitleLine);
            return dto;
        }

        private string CleanTitleField(string title)
        {
            title = title.Trim();
            title = Regex.Replace(title, @"\s+", " ");
            title = title.ToLower();
            return title;
        }
    }
}
