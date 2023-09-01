using SGTest.Models.OutputModels;

namespace SGTest.Repositories
{
    internal class DepartmentOutFormRepository : IDisposable
    {

        private readonly ApplicationContext _context;
        public DepartmentOutFormRepository()
        {
            _context = new ApplicationContext();
        }

        public DepartmentOutForm GetDepartmentsHierarchy(int departmentID, bool isMainDepartment)
        {
            if (departmentID == 0)
                return null;

            DepartmentOutForm departmentHirerchyNode = new DepartmentOutForm();

            departmentHirerchyNode.Department = _context.Departments.Find(departmentID);

            if (departmentHirerchyNode.Department == null)
                return null;
            
            if (isMainDepartment)
            {
                departmentHirerchyNode.EmployeesToJobTitle = new Dictionary<string, string>();

                var employees = _context.Employees.Where(x => x.DepartmentID == departmentID).ToList();
                foreach ( var employee in employees )
                {
                    departmentHirerchyNode.EmployeesToJobTitle.Add(employee.FullName, _context.JobTitles.Where(x => x.Id == employee.JobTitleID).SingleOrDefault().Title);
                }

                var manager = _context.Employees.Find(departmentHirerchyNode.Department?.ManagerID);

                try
                {
                    departmentHirerchyNode.ManagerToJobTitle = new Dictionary<string, string>();

                    if (manager.JobTitleID == 0)
                    {
                        departmentHirerchyNode.ManagerToJobTitle.Add(manager.FullName, "В базе данных не содержится сведений о профессии менеджера, Вам нужно добавить их");
                    }
                    else
                    {
                        departmentHirerchyNode.ManagerToJobTitle.Add(manager.FullName, _context.JobTitles.Find(manager.JobTitleID).Title);
                    }                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);                  
                }
            }   
            
            departmentHirerchyNode.ParentDepartmentData = GetDepartmentsHierarchy(departmentHirerchyNode.Department.ParentID, false);

            if (departmentHirerchyNode.ParentDepartmentData == null )
            {
                departmentHirerchyNode.HierarchyLevel = 1;
            }
            else
            {
                departmentHirerchyNode.HierarchyLevel = departmentHirerchyNode.ParentDepartmentData.HierarchyLevel + 1;
            }
            return departmentHirerchyNode;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
