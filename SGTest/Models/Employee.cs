﻿using Microsoft.EntityFrameworkCore;

namespace SGTest.Models
{
    [Index(nameof(FullName), IsUnique = true)]
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentID { get; set; }
        public string? FullName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int JobTitleID { get; set; }
    }
}
