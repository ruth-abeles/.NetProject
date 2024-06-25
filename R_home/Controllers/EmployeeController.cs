using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using R_home.Core.DTOs;
using R_home.Core.Models;
using R_home.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace R_home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = _employeeService.GetAllEmployeesAsync();
            var listDto = _mapper.Map<IEnumerable<EmployeeDto>>(list);
            return Ok(listDto);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var employee = _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound();
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employee employee)
        {
            var employeeToAdd = _mapper.Map<Employee>(employee);
            var newEmployee = await _employeeService.AddEmployeeAsync(employeeToAdd);
            return Ok(_mapper.Map<EmployeeDto>(newEmployee));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Employee employee)
        {
            var employeeToEdit = _mapper.Map<Employee>(employee);
            await _employeeService.UpdateEmployeeAsync(id, employeeToEdit);
            return Ok(employeeToEdit);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
        }
    }
}
