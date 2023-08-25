using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Models.OutputModels
{
    internal class DepartmentOutForm
    {
        public Department? department {  get; set; }
        public string? managerName { get; set; }
        public Dictionary<string, string>? employees { get; set; }
        public DepartmentOutForm? parentDepartmentData { get; set; }
        public int hierarchyLevel { get; set; }
    }
}
