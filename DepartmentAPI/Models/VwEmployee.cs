using System;
using System.Collections.Generic;

#nullable disable

namespace DepartmentAPI.Models
{
    public partial class VwEmployee
    {
        public int EmployeeId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string GradIme { get; set; }
        public string DepartmentName { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime DateJoining { get; set; }
    }
}
