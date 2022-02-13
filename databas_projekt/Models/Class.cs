using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace databas_projekt.Models
{
    public partial class Class
    {
        public Class()
        {
            Grades = new HashSet<Grades>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int FkstudentId { get; set; }
        public int? Fkteacher { get; set; }

        public virtual Students Fkstudent { get; set; }
        public virtual Employee FkteacherNavigation { get; set; }
        public virtual ICollection<Grades> Grades { get; set; }
    }
}
