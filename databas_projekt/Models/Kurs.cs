using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace databas_projekt.Models
{
    public partial class Kurs
    {
        public int? PkcourseId { get; set; }
        public int? FkstudentId { get; set; }
        public int? FkteacherId { get; set; }
        public string CourseName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Students Fkstudent { get; set; }
        public virtual Employee Fkteacher { get; set; }
    }
}
