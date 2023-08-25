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
    internal class DepartmentParser
    {
        public DepartmentDTO ConvertToDto(string departmentLine)
        {
            var departmentData = departmentLine.Trim().Split("\t");
            DepartmentDTO dto = new DepartmentDTO();
            dto.Name = CleanNameField(departmentData[0]);
            dto.ParentName = CleanNameField(departmentData[1]);
            dto.ManagerName = CleanNameField(departmentData[2]);
            dto.Phone = CleanPhoneField(departmentData[3]);
            return dto;           
        }

        private string CleanNameField(string name)
        {
            name = name.Trim();
            name = Regex.Replace(name, @"\s+", " ");
            name = name.ToLower();
            return name;
        }

        private string CleanPhoneField(string phone)
        {
            phone = phone.Trim();
            //phone = Regex.Replace(phone, "+7", "8");
            phone = Regex.Replace(phone, @"[^\w\s]", "");
            phone = Regex.Replace(phone, " ", "");
            phone = phone.ToLower();
            return phone;
        }
    }
}
