using EMS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository depatrmentRepository;

        public DepartmentController(IDepartmentRepository depatrmentRepository)
        {
            this.depatrmentRepository = depatrmentRepository;
        }

        // GET: api/Department
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var dept = (this.depatrmentRepository.GetDepartments());
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }


        // GET: api/Department/active
        [HttpGet("active")]
        public IActionResult GetActiveDepartments()
        {
            var dept = (this.depatrmentRepository.GetActiveDepartments());
            if(dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }


        // GET: api/Department/2
        [HttpGet("{id}")]
        public IActionResult GetDepartmentDetailById(int id)
        {
            var dept = (this.depatrmentRepository.GetDepartmentDetailById(id));
            if(dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }


        //GET: 
        [HttpGet("{id}/Employees")]
        public IActionResult GetAllEmployeeByDepartment(int id)
        {
            var dept = (this.depatrmentRepository.GetAllEmployeeByDepartment(id));
            if(dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }


        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var dept = (this.depatrmentRepository.DeleteDepartment(id));
            if(dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }



    }
}
