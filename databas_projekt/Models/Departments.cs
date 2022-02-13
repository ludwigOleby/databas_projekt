using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace databas_projekt.Models
{
    public partial class Departments
    {
        public int PkdepartmentId { get; set; }
        public string DepartmentName { get; set; }
        
        public int? FkemployeeId { get; set; }

        public virtual Employee Pkdepartment { get; set; }
    }
}
