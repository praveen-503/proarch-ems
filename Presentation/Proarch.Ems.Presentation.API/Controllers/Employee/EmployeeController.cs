using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Usecases;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;

namespace Proarch.Ems.Presentation.API.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmsDbContext _context;
        private readonly IEmployeeUsecase _employeeUsecase;

        public EmployeeController(EmsDbContext context,IEmployeeUsecase employeeUsecase)
        {
            _context = context;
            _employeeUsecase = employeeUsecase;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            var listEmployees = await _employeeUsecase.GetEmployees().ConfigureAwait(true);
            if(listEmployees == null)
            {
                return NotFound();
            }
            return Ok(listEmployees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeModel(int Id)
        {
            var employee = await _employeeUsecase.GetEmployeeById(Id).ConfigureAwait(true);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeModel(int id, EmployeeModel employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            var isUpdated = await _employeeUsecase.UpdateEmployeeAsync(employee).ConfigureAwait(true);
            if (!isUpdated)
            {
                return NotFound();
            }
            return NoContent();

           
        }

        // POST: api/Employee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployeeModel(EmployeeModel employeeModel)
        {
            var employeeId = await _employeeUsecase.CreateEmployeeAsync(employeeModel);
            if(employeeId == 0)
            {
                return BadRequest("Employee alredy reisterd with this id or email");
            }
            return CreatedAtAction("GetEmployeeModel", new { id = employeeId }, employeeModel);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        async public  Task<ActionResult> DeleteEmployeeModel(int id)
        {
            var isDeleted = await _employeeUsecase.DeleteEmployeeAsync(id).ConfigureAwait(true);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok(); ;
        }
    }
}
