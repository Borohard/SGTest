using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.DTO.Models
{
    internal class DepartmentDTO
    {
        public string? ParentName { get; set; }
        public string? ManagerName { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
    }
}
