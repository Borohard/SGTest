using SGTest.DTO.Models;
using SGTest.Models;
using SGTest.Repositories;

namespace SGTest.Services
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
                    if (isManagerExist != null)
                    {
                        department.ManagerID = isManagerExist.Id;
                    }
                    else
                    {
                        employeeRepository.Add(new Employee { FullName = departmentDto.ManagerName });
                        department.ManagerID = employeeRepository.GetEmployeeID(departmentDto.ManagerName);
                    }
                }
                var existingDepartment = departmentRepository.IsDepartmentExist(department.Name);
                if (existingDepartment != null)
                {
                    departmentRepository.Update(existingDepartment.Id, department);
                }
                else
                {
                    departmentRepository.Add(department);
                }

            }
        }
    }
}
