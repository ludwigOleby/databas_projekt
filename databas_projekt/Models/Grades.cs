using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace databas_projekt.Models
{
    public partial class Grades
    {
        public int GradeId { get; set; }
        public int StudentGradeId { get; set; }
        public int Grade { get; set; }
        public int FkstaffId { get; set; }
        public DateTime? GradeDate { get; set; }
        public int? ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Employee Fkstaff { get; set; }
        public virtual Students StudentGrade { get; set; }
    }
}
