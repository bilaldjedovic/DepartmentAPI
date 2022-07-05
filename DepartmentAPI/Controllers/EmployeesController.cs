using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using DepartmentAPI.Models;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DepEmpWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        baza2Context db = new baza2Context();

        [HttpGet]

        public IActionResult getEmployees()
        {
            List<VwEmployee> employees = db.VwEmployees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]

        public IActionResult employee(int id)
        {
            Employee employee = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return Ok(employee);
        }
        [EnableCors]
        [HttpPost]

        public IActionResult addEmployee([FromBody] Employee employee)
        {
            db.Add(employee);
            db.SaveChanges();
            return Ok(employee);
        }
        [EnableCors]
        [HttpPost("{id}")]
        public IActionResult editEmployee(int id, [FromBody] Employee employee)
        {
            Employee rezultat = db.Employees.Where(a => a.EmployeeId.Equals(id)).FirstOrDefault();
            if (rezultat != null)
            {
                rezultat.Ime = (employee.Ime != null) ? employee.Ime : rezultat.Ime;
                rezultat.Prezime = (employee.Prezime != null) ? employee.Prezime : rezultat.Prezime;
                rezultat.Adresa = (employee.Adresa != null) ? employee.Adresa : rezultat.Adresa;
                rezultat.Telefon = (employee.Telefon != null) ? employee.Telefon : rezultat.Telefon;
                rezultat.Email = (employee.Email != null) ? employee.Email : rezultat.Email;
                db.SaveChanges();
            }
            else
            {
                return NotFound($"Employee with id ={employee.EmployeeId} was not found");
            }

            return Ok(rezultat);
        }
        [EnableCors]
        [HttpDelete("{id}")]
        public IActionResult obrisiPodatak(int id)
        {
            Employee employee = db.Employees.Where(a => a.EmployeeId == id).FirstOrDefault();
            if (employee == null)
            {
                return NotFound($"Employee with id = {id} was not found");
            }
            else
            {
                try
                {
                    db.Remove(employee);
                    db.SaveChanges();
                }
                catch
                {
                    return BadRequest("Error while deleting");
                }
            }
            return Ok("Deleted !");
        }
    }
}
