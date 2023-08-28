using SGTest.Models.OutputModels;

namespace SGTest.Repositories
{
    internal class DepartmentOutFormRepository : IDisposable
    {

        ApplicationContext _context;
        public DepartmentOutFormRepository()
        {
            _context = new ApplicationContext();
        }

        public DepartmentOutForm GetDepartmentsHierarchy(int departmentID, bool isMainDepartment)
        {
            if (departmentID == 0)
                return null;

            DepartmentOutForm departmentHirerchyNode = new DepartmentOutForm();

            departmentHirerchyNode.department = _context.Departments.Find(departmentID);

            if (departmentHirerchyNode.department == null)
                return null;
            
            if (isMainDepartment)
            {
                departmentHirerchyNode.employeesToJobTitle = new Dictionary<string, string>();

                var employees = _context.Employees.Where(x => x.DepartmentID == departmentID).ToList();
                foreach ( var employee in employees )
                {
                    departmentHirerchyNode.employeesToJobTitle.Add(employee.FullName, _context.JobTitles.Where(x => x.Id == employee.JobTitleID).SingleOrDefault().Title);
                }

                var manager = _context.Employees.Find(departmentHirerchyNode.department?.ManagerID);

                try
                {
                    departmentHirerchyNode.managerToJobTitle = new Dictionary<string, string>();

                    if (manager.JobTitleID == 0)
                    {
                        departmentHirerchyNode.managerToJobTitle.Add(manager.FullName, "В базе данных не содержится сведений о профессии менеджера, Вам нужно добавить их");
                    }
                    else
                    {
                        departmentHirerchyNode.managerToJobTitle.Add(manager.FullName, _context.JobTitles.Find(manager.JobTitleID).Title);
                    }                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);                  
                }
            }   
            
            departmentHirerchyNode.parentDepartmentData = GetDepartmentsHierarchy(departmentHirerchyNode.department.ParentID, false);

            if (departmentHirerchyNode.parentDepartmentData == null )
            {
                departmentHirerchyNode.hierarchyLevel = 1;
            }
            else
            {
                departmentHirerchyNode.hierarchyLevel = departmentHirerchyNode.parentDepartmentData.hierarchyLevel + 1;
            }
            return departmentHirerchyNode;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
