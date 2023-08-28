using SGTest.DTO.Models;
using SGTest.Models;
using SGTest.Repositories;

namespace SGTest.DTO.Services
{
    internal class DepartmentService
    {
        public void SaveDepartment(DepartmentDTO departmentDto)
        {
            using (var departmentRepository = new DepartmentRepository())
            {
                Department department = new Department();

                department.Name = departmentDto.Name;                
                department.ParentID = departmentRepository.GetDepatmentID(departmentDto.ParentName);
                department.Phone = departmentDto.Phone;
             
                using (var employeeRepository = new EmployeeRepository())
                {
                    var isManagerExist = employeeRepository.IsEmployeeExist(departmentDto.ManagerName);
                    if (isManagerExist)
                    {
                        department.ManagerID = employeeRepository.GetEmployeeID(departmentDto.ManagerName);
                    }
                    else
                    {
                        employeeRepository.Add(new Employee { FullName = departmentDto.ManagerName });
                        department.ManagerID = employeeRepository.GetEmployeeID(departmentDto.ManagerName);
                    }
                }
                if (departmentRepository.IsDepartmentExist(department.Name))
                {
                    departmentRepository.Update(departmentRepository.GetDepatmentID(department.Name), department);
                }
                else
                {
                    departmentRepository.Add(department);
                }
                
            }
        }
    }
}
