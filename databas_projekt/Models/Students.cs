using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace databas_projekt.Models
{
    public partial class Students
    {
        public Students()
        {
            Class = new HashSet<Class>();
            Grades = new HashSet<Grades>();
        }

        public int StudentId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<Grades> Grades { get; set; }
    }
}
