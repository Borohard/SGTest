using SGTest.DTO.Models;
using SGTest.Models;
using SGTest.Repositories;

namespace SGTest.DTO.Services
{
    internal class EmployeeService
    {
        public void SaveEmployee(EmployeeDTO employeeDto)
        {
            using (var employeeRepository = new EmployeeRepository())
            {
                Employee employee = new Employee();
                employee.FullName = employeeDto.FullName;
                employee.Login = employeeDto.Login;
                employee.Password = employeeDto.Password;
                
                using (var jobTitleRepository = new JobTitleRepository())
                {
                    var isJobTitleExist = jobTitleRepository.IsJobTitleExist(employeeDto.JobTitle);
                    if (isJobTitleExist)
                    {
                        employee.JobTitleID = jobTitleRepository.GetJobTitleID(employeeDto.JobTitle);
                    }
                    else
                    {
                        jobTitleRepository.Add(new JobTitle { Title = employeeDto.JobTitle });
                        employee.JobTitleID = jobTitleRepository.GetJobTitleID(employeeDto.JobTitle);
                    }                 
                }
                using (var departmentRepository = new DepartmentRepository())
                {
                    var departmentId = departmentRepository.GetDepatmentID(employeeDto.DepartmentName);
                    if (departmentId != 0)
                    {
                        employee.DepartmentID = departmentId;
                    }
                    else
                    {
                        departmentRepository.Add(new Department { Name = employeeDto.DepartmentName });
                        employee.DepartmentID = departmentRepository.GetDepatmentID(employeeDto.DepartmentName);
                    }
                }
                if (employeeRepository.IsEmployeeExist(employee.FullName))
                {
                    employeeRepository.Update(employeeRepository.GetEmployeeID(employee.FullName), employee);
                }
                else
                {
                    employeeRepository.Add(employee);
                }
                
            }
            


        }
    }
}
