//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DBMySchool
{
    public partial class DbDepartment
    {
        public DbDepartment()
        {
            this.Courses = new HashSet<DbCourse>();
        }
    
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<int> Administrator { get; set; }
    
        public virtual ICollection<DbCourse> Courses { get; set; }
    }
    
}
