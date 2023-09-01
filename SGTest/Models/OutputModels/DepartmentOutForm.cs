namespace SGTest.Models.OutputModels
{
    internal class DepartmentOutForm
    {
        public Department? Department {  get; set; }
        public Dictionary<string, string>? ManagerToJobTitle { get; set; }
        public Dictionary<string, string>? EmployeesToJobTitle { get; set; }
        public DepartmentOutForm? ParentDepartmentData { get; set; }
        public int HierarchyLevel { get; set; }
    }
}
