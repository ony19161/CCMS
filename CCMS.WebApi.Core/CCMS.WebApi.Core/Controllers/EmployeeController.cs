using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DatabaseModels;
using App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return _employeeService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetEmployee")]
        public ActionResult<Employee> Get(string id)
        {
            var book = _employeeService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Employee> Create(Employee employee)
        {
            _employeeService.Create(employee);

            return CreatedAtRoute("GetEmployee", new { id = employee.Id.ToString() }, employee);
        }
    }
}