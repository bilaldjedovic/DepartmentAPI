using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using DepartmentAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DepEmpWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradController : ControllerBase
    {
        baza2Context db = new baza2Context();

        [HttpGet]

        public IActionResult getGradovi()
        {
            List<Grad> gradovi = db.Grads.ToList();
            return Ok(gradovi);
        }
    }
}
