using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentID { get; set; }
        public string? FullName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int JobTitleID { get; set; }
    }
}
