using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using DepartmentAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DepEmpWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        baza2Context db = new baza2Context();

        [HttpGet]

        public IActionResult getDepartments()
        {
            List<Department> departments = db.Departments.ToList();
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult addDepartment([FromBody] Department department)
        {
            db.Add(department);
            db.SaveChanges();
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public IActionResult obrisiPodatak(int id)
        {
            Department department = db.Departments.Where(a => a.DepartmentId == id).FirstOrDefault();
            if (department == null)
            {
                return NotFound($"Podatak sa ID = {id} nije pronadjen");
            }
            else
            {
                try
                {
                    db.Remove(department);
                    db.SaveChanges();
                }
                catch
                {
                    return BadRequest("Error while deleting");
                }
            }
            return Ok("Deleted");
        }

        [HttpPost("{id}")]
        public IActionResult editCategory(int id, [FromBody] Department dep)
        {
            Department rezultat = db.Departments.Where(a => a.DepartmentId.Equals(id)).FirstOrDefault();
            if (rezultat != null)
            {
                rezultat.DepartmentName = (dep.DepartmentName != null) ? dep.DepartmentName : rezultat.DepartmentName;




                db.SaveChanges();
            }
            else
            {
                return NotFound($"Pjesma sa id {dep.DepartmentId} nije pronadjena");
            }

            return Ok(rezultat);
        }


    }
}
