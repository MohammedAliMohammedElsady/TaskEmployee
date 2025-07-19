using Data_Logic_Layer.Entity;
using Data_Logic_Layer.Services;
using EmployeeApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAngular")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var employees =  _employeeService.GetAll();
            var result = new Response();
            if (employees == null || !employees.Any())
            {
               result.Message =  ("No employees found");
               result.IsSuccess= false;
            }
            else
            {
                result.Message = "Employees retrieved successfully";
                result.IsSuccess = true;
                result.Data = employees;
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var employee = _employeeService.GetById(id);
            var result = new Response();
            if (employee == null)
            {
                result.Message = ("No employees found");
                result.IsSuccess = false;
            }
            else
            {
                result.Message = "Employees retrieved successfully";
                result.IsSuccess = true;
                result.Data = employee;
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is null");
            }
            var status =  _employeeService.Add(employee);
            var result = new Response();
            if (status)
            {
                result.Message = "Employee created successfully";
                result.IsSuccess = true;
                result.Data = employee;
            }
            else
            {
                result.Message = "Failed to create employee";
                result.IsSuccess = false;
            }
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id || employee == null)
            {
                return BadRequest("Invalid employee data");
            }
            var status =  _employeeService.Update(employee);
            var result = new Response();
            if(status)
            {
                result.Message = "Employee updated successfully";
                result.IsSuccess = true;
                result.Data = employee;
            }
            else
            {
                result.Message = "Failed to update employee";
                result.IsSuccess = false;
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var status = _employeeService.Delete(id);
            var result = new Response();
            if(status)
            {
                result.Message = "Employee deleted successfully";
                result.IsSuccess = true;
            }
            else
            {
                result.Message = "Failed to delete employee";
                result.IsSuccess = false;
            }
            return Ok(result);
        }
    }
}
