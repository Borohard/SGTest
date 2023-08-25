using SGTest.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGTest.Parsers
{
    internal class EmployeeParser
    {
        public EmployeeDTO ConvertToDto(string employeeLine)
        {
            var employeeData = employeeLine.Trim().Split("\t");
            EmployeeDTO dto = new EmployeeDTO();
            dto.DepartmentName = CleanNameField(employeeData[0]);
            dto.FullName = CleanNameField(employeeData[1]);
            dto.Login = employeeData[2];
            dto.Password = employeeData[3];
            dto.JobTitle = CleanNameField(employeeData[4]);
            return dto;
        }

        private string CleanNameField(string name)
        {
            name = name.Trim();
            name = Regex.Replace(name, @"\s+", " ");
            name = name.ToLower();
            return name;
        }
    }
}
