using SGTest.Models;

namespace SGTest.Repositories
{
    public class EmployeeRepository : IDisposable
    {
        private readonly ApplicationContext _context;
        public EmployeeRepository()
        {
            _context = new ApplicationContext();
        }

        public Employee Get(int id)
        {
            var employee = _context.Employees.Find(id);
            return employee;
        }

        public int GetEmployeeID(string? employeeName)
        {
            var employee = _context.Employees.Where(x => x.FullName == employeeName).FirstOrDefault();
            return employee != null ? employee.Id : 0;
        }

        public Employee? IsEmployeeExist(string? employeeName)
        {
            var employee = _context.Employees.Where(x => x.FullName == employeeName).FirstOrDefault();
            return employee != null ? employee : null;
        }

        public List<Employee> GetAllDepartments()
        {
            var employees = _context.Employees.ToList();
            return employees;
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(int id, Employee employeeData)
        {
            var employee = _context.Employees.First(x => x.Id == id);
            employee.DepartmentID = employeeData.DepartmentID;
            employee.Password = employeeData.Password;
            employee.Login = employeeData.Login;
            employee.JobTitleID = employeeData.JobTitleID;
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
