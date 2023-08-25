using SGTest.Models;
using SGTest.Models.OutputModels;
using SGTest.Repositories;
using SGTest.Utils.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.OutputService
{
    internal class OutputService
    {
        public void ShowHierarchyByDepartmentID(int departmentID)
        {
            using (var outFormRepository = new DepartmentOutFormRepository())
            {
                var outFormData = outFormRepository.GetDepartmentsHierarchy(departmentID, true);
                ShowFormData(outFormData);
            }           
        }

        public void ShowFormData(DepartmentOutForm departmentOutForm)
        {
            if (departmentOutForm == null)
            {
                return;
            }
           
            Console.WriteLine($"{"=".Repeat(departmentOutForm.hierarchyLevel)} {departmentOutForm.department?.Name}");
            if (departmentOutForm.employees != null)
            {
                Console.WriteLine($"{" ".Repeat(departmentOutForm.hierarchyLevel - 1)}* {departmentOutForm.managerName}");
                foreach(var employee in  departmentOutForm.employees)
                {
                    Console.WriteLine($"{" ".Repeat(departmentOutForm.hierarchyLevel - 1)}- {employee.Key} ({employee.Value})");
                }
                
            }
            ShowFormData(departmentOutForm.parentDepartmentData);
        }
    }
}
