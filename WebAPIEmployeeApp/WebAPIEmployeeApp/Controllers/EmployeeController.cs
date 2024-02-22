using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIEmployeeApp.Models;
using WebAPIEmployeeApp.Services.EmployeeServices;

namespace WebAPIEmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeInterface;
        public EmployeeController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployee()
        {
            return Ok(await _employeeInterface.GetEmployee());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> GetEmployeeById(int id)
        {
            return Ok(await _employeeInterface.GetEmployeeById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> CreateEmployee(EmployeeModel newEmployee)
        {
            return Ok(await _employeeInterface.CreateEmployee(newEmployee));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> DeleteEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.DeleteEmployee(id);

            return Ok(serviceResponse);
        }

        [HttpPut("inactiveEmployee")]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> InactiveEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.InactiveEmployee(id);

            return Ok(serviceResponse);
        }

        [HttpPut("activeEmployee")]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> ActiveEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.ActiveEmployee(id);

            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> UpdateEmployee(EmployeeModel updatedEmployee)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.UpdateEmployee(updatedEmployee);

            return Ok(serviceResponse);
        }
    }
}
