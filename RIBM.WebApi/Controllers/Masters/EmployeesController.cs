using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RIBM.WebApi.Models;

namespace RIBM.WebApi.Controllers.Masters
{
    [Produces("application/json")]
    [Route("api/Employees")]
    public class EmployeesController : Controller
    {
        private readonly RIBusinessManagementContext _context;

        public EmployeesController(RIBusinessManagementContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<EmployeeViewModel> GetEmployee()
        {
            var employees = _context.Employee.Select(m => new EmployeeViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                MobileNo = m.MobileNo,
                EmailAddress = m.EmailAddress,
                BirthDate = m.BirthDate,
                Address = m.Address,
                StateId = m.StateId,
                CityId = m.CityId,
                PinCode = m.PinCode,
                AadharCardNumber = m.AadharCardNumber,
                LicenceNumber = m.LicenceNumber,
                LicenceExpiryDate = m.LicenceExpiryDate,
                LicenceType = m.LicenceType,
                Esicnumber = m.Esicnumber,
                Epfnumber = m.Epfnumber,
                JoiningDate = m.JoiningDate,
                LeavingDate = m.LeavingDate,
                Location = m.Location,
                IsActive = m.IsActive,
                EntryUserId = m.EntryUserId,
                EntryDate = m.EntryDate,
                UpdateUserId = m.UpdateUserId,
                UpdateDate = m.UpdateDate,
                CityName = _context.City.Where(c => c.Id == m.CityId).FirstOrDefault().CityName,
                StateName = _context.State.Where(s => s.Id == m.StateId).FirstOrDefault().StateName
            }).ToList();
            
            return employees;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employee.Where(m => m.Id == id).Select(m => new
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                MobileNo = m.MobileNo,
                EmailAddress = m.EmailAddress,
                BirthDate = m.BirthDate,
                Address = m.Address,
                StateId = m.StateId,
                CityId = m.CityId,
                PinCode = m.PinCode,
                AadharCardNumber = m.AadharCardNumber,
                LicenceNumber = m.LicenceNumber,
                LicenceExpiryDate = m.LicenceExpiryDate,
                LicenceType = m.LicenceType,
                Esicnumber = m.Esicnumber,
                Epfnumber = m.Epfnumber,
                JoiningDate = m.JoiningDate,
                LeavingDate = m.LeavingDate,
                Location = m.Location,
                IsActive = m.IsActive,
                EntryUserId = m.EntryUserId,
                EntryDate = m.EntryDate,
                UpdateUserId = m.UpdateUserId,
                UpdateDate = m.UpdateDate,
                CityName = _context.City.Where(c => c.Id == m.StateId).FirstOrDefault().CityName,
                StateName = _context.State.Where(s => s.Id == m.StateId).FirstOrDefault().StateName
            }).SingleOrDefaultAsync();

            if (employee == null)
            {
                return NotFound();
            }
            
            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}