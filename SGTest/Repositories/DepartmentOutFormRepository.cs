﻿using SGTest.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            {
                return null;
            }
            DepartmentOutForm departmentHirerchyNode = new DepartmentOutForm();
            departmentHirerchyNode.department = _context.Departments.Find(departmentID);
            if (departmentHirerchyNode.department == null)
            {
                return null;
            }
            

            if (isMainDepartment)
            {
                departmentHirerchyNode.employees = new Dictionary<string, string>();
                var employees = _context.Employees.Where(x => x.DepartmentID == departmentID).ToList();
                foreach ( var employee in employees )
                {
                    departmentHirerchyNode.employees.Add(employee.FullName, _context.JobTitles.Where(x => x.Id == employee.JobTitleID).SingleOrDefault().Title);
                }
                departmentHirerchyNode.managerName = _context.Employees.Find(departmentHirerchyNode.department?.ManagerID)?.FullName;
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
