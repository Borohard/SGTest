namespace SGTest.Models.OutputModels
{
    internal class DepartmentOutForm
    {
        public Department? department {  get; set; }
        public Dictionary<string, string>? managerToJobTitle { get; set; }
        public Dictionary<string, string>? employeesToJobTitle { get; set; }
        public DepartmentOutForm? parentDepartmentData { get; set; }
        public int hierarchyLevel { get; set; }
    }
}
