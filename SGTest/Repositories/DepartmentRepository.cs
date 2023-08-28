using SGTest.Models;

namespace SGTest.Repositories
{
    public class DepartmentRepository : IDisposable
    {
        private ApplicationContext _context;
        public DepartmentRepository()
        {
            _context = new ApplicationContext();
        }

        public Department Get(int id)
        {
            var department = _context.Departments.Find(id);
            return department;
        }

        public int GetDepatmentID(string? departmentName)
        {
            var department = _context.Departments.Where(x => x.Name == departmentName).FirstOrDefault();
            return department != null ? department.Id : 0;
        }
        public bool IsDepartmentExist(string? departmentName)
        {
            var department = _context.Departments.Where(x => x.Name == departmentName).FirstOrDefault();
            return department != null ? true : false;
        }

        public List<Department> GetAllDepartment()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }
        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(int id, Department departmentData)
        {
            var department = _context.Departments.First(x => x.Id == id);
            department.ParentID = departmentData.ParentID;
            department.Phone = departmentData.Phone;
            department.ManagerID = departmentData.ManagerID;
            _context.SaveChanges();
        }
    
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
