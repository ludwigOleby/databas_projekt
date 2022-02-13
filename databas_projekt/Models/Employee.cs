using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace databas_projekt.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Class = new HashSet<Class>();
            Grades = new HashSet<Grades>();
        }

        public int EmployeeId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime StartDate { get; set; }
        public int? Lön { get; set; }
        public string Roll { get; set; }

        public virtual Departments Departments { get; set; }
        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<Grades> Grades { get; set; }
    }
}
