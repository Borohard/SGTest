using SGTest.Models.OutputModels;
using SGTest.Repositories;
using SGTest.Utils.Extentions;

namespace SGTest.OutputService
{
    internal class OutputService
    {
        public void ShowHierarchyByDepartmentID(int departmentID)
        {
            using (var outFormRepository = new DepartmentOutFormRepository())
            {
                var outFormData = outFormRepository.GetDepartmentsHierarchy(departmentID, true);
                ShowFormData(outFormData, true);
            }           
        }

        public void ShowFormData(DepartmentOutForm departmentOutForm, bool isMainDepartment)
        {
            if (departmentOutForm == null)
                return;
           
            Console.WriteLine($"{"=".Repeat(departmentOutForm.hierarchyLevel)} {departmentOutForm.department?.Name}");

            if (isMainDepartment)
            {
                var manager = departmentOutForm.managerToJobTitle.FirstOrDefault();               
                Console.WriteLine($"{" ".Repeat(departmentOutForm.hierarchyLevel - 1)}* {manager.Key} ({manager.Value})");
             
                foreach(var employee in  departmentOutForm.employeesToJobTitle)
                {
                    Console.WriteLine($"{" ".Repeat(departmentOutForm.hierarchyLevel - 1)}- {employee.Key} ({employee.Value})");
                }    
            }
            
            ShowFormData(departmentOutForm.parentDepartmentData, false);
        }
    }
}
