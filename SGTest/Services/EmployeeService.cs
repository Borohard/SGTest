using SGTest.DTO.Models;
using SGTest.Models;
using SGTest.Repositories;

namespace SGTest.Services
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
                    if (isJobTitleExist != null)
                    {
                        employee.JobTitleID = isJobTitleExist.Id;
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

                var isEmployeeExist = employeeRepository.IsEmployeeExist(employee.FullName);
                if (isEmployeeExist != null)
                {
                    employeeRepository.Update(isEmployeeExist.Id, employee);
                }
                else
                {
                    employeeRepository.Add(employee);
                }

            }



        }
    }
}
