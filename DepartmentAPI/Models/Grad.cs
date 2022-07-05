using System;
using System.Collections.Generic;

#nullable disable

namespace DepartmentAPI.Models
{
    public partial class Grad
    {
        public Grad()
        {
            Employees = new HashSet<Employee>();
        }

        public int GradId { get; set; }
        public string GradIme { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
