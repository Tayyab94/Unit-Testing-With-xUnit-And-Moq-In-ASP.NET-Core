using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTest_API.Models;
using UnitTest_API.Serivces;

namespace UnitTest_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private IGenericRepository<Employee> repo = null;

        public EmployeeController(IGenericRepository<Employee> repo)
        {
            this.repo = repo;
        }

        [HttpGet(Name = "GetEmployee")]
        [Route("GetEmployee")]
        public ActionResult<IEnumerable<Employee>> GetEmployee()
        {
            var model = repo.GetAll();
            return Ok(model);
        }

        [HttpGet("GetEmployeeById/{id}")]
        public ActionResult<Employee> GetEmployeeById(long id)
        {
            Employee employee = repo.GetById(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody]Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null");
            }
            repo.Insert(employee);

        //    return Ok();
          return CreatedAtRoute("GetEmployeeById", new { Id = employee.EmployeeId }, employee);
        }

        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null");
            }
            repo.Update(employee);
            return NoContent();
        }

        public bool checkIfUserCanBeVoter(int age)
        {
            return (age >= 18) ? true : false;
        }
    }
}
