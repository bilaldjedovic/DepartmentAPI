using System;
using System.Collections.Generic;

#nullable disable

namespace DepartmentAPI.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public int GradId { get; set; }
        public int DepartmentId { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime DateJoining { get; set; }

        public virtual Department Department { get; set; }
        public virtual Grad Grad { get; set; }
    }
}
