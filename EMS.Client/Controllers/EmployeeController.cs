using EMS.Interface;
using EMS.Model;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeDetailById(int id)
        {
            var emp = (this.employeeRepository.GetEmployeeDetailById(id));
            if(emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }


        // GET: api/Employee/Active
        [HttpGet()]
        public IActionResult GetActiveEmployee()
        {
            var emp = (this.employeeRepository.GetActiveEmployee());
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public IActionResult UpdateEmployeeDetail( Employee employee)
        {

            if (employee == null)
            {
                return BadRequest();
            }
            var emp = (this.employeeRepository.UpdateEmployeeDetail(employee));
            return Ok(emp);
        }


        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult CreateEmployeeDetail(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            var emp = (this.employeeRepository.CreateEmployeeDetail(employee));
            return Ok(emp);
        }


        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = (this.employeeRepository.DeleteEmployee(id));
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        //public bool EmployeeDetailExists(int id)
        //{
        //    try
        //    {
        //        return Ok(this.employeeRepository.EmployeeDetailExists(id));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

    }
}

