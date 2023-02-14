using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mpsPlus.API.Data;
using mpsPlus.API.Models;

namespace mpsPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly mpsPlusDbContext _mpsPlusDbContext;

        public EmployeesController(mpsPlusDbContext mpsPlusDbContext)
        {
            _mpsPlusDbContext = mpsPlusDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees =await _mpsPlusDbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
            await _mpsPlusDbContext.Employees.AddAsync(employeeRequest);
            await _mpsPlusDbContext.SaveChangesAsync();
            
            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee= await _mpsPlusDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployeeRequest)
        {
            var employee = await _mpsPlusDbContext.Employees.FindAsync(id);
            
            if (employee == null)
            {
                return NotFound();
            }

            employee.Name= updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Department = updateEmployeeRequest.Department;
            employee.Password = updateEmployeeRequest.Password;

            await _mpsPlusDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _mpsPlusDbContext.Employees.FindAsync(id); 

            if( employee == null)
            {
                return NotFound();
            }

            _mpsPlusDbContext.Employees.Remove(employee);
            await _mpsPlusDbContext.SaveChangesAsync();
            
            return Ok(employee);
        }


    }
}
