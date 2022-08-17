using EmployeeCRUDusingwebAPi.Model;
using EmployeeCRUDusingwebAPi.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDusingwebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepo;
        public EmployeeController(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employee = await _empRepo.GetAllEmployee();
            return Ok(employee);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await _empRepo.GetEmployeeById(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var result = await _empRepo.UpdateEmployee(employee);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var result = await _empRepo.AddnewEmployee(employee);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _empRepo.DeleteEmployee(id);
            return Ok(result);
        }
    }
}
