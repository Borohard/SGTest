using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.DTO.Models
{
    internal class EmployeeDTO
    {
        public string? DepartmentName { get; set; }
        public string? FullName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? JobTitle { get; set; }
    }
}
