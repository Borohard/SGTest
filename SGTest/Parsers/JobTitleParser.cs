using SGTest.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

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
