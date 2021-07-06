using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EKbanaTest.DAL;
using EKbanaTest.Models;
using EKbanaTest.Commands;
using EKbanaTest.Queries;
using EKbanaTest.DTO;
using Microsoft.AspNetCore.Authorization;

namespace EKbanaTest.Controllers
{
  
    public class EmployeesController : Controller
    {
        //private readonly ApplicationDBContext _context;


        private readonly IEmployeeCommandsRepo _employeeCommandRepo;
        private readonly IEmployeeQueriesRepo _employeeQueriesRepo;

        private readonly IRoleQueriesRepo _roleQueriesRepo;   
        public EmployeesController(IEmployeeCommandsRepo employeeCommandRepo, IEmployeeQueriesRepo employeeQueriesRepo, IRoleQueriesRepo roleQueriesRepo)
        {
            _employeeCommandRepo = employeeCommandRepo;
            _employeeQueriesRepo = employeeQueriesRepo;
            _roleQueriesRepo = roleQueriesRepo;
        }

       
        // GET: Employees
        public async Task<IActionResult> Index()
        {

            return View(_employeeQueriesRepo.GetAll());

            //var applicationDBContext = _context.Employees.Include(e => e.Roles);
            //return View(await applicationDBContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeQueriesRepo.Find(id.GetValueOrDefault());

           /* var employee = await _context.Employees
                .Include(e => e.Roles)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);

            */

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
     
            ViewBag.RoleId = new SelectList(_roleQueriesRepo.GetAll(), "RoleId", "RoleName");
            ViewBag.EmployeeParentId = new SelectList(_employeeQueriesRepo.GetAll(), "EmployeeId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeParentId,Name,Email,Passsword,RoleId,DateOfBirth")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeCommandRepo.Add(employee);         
                return RedirectToAction(nameof(Index));
            }

             
             /*ViewBag.RoleId = new SelectList(_context.Roles, "RoleId", "RoleName");
             ViewBag.EmployeeParentId = new SelectList(_context.Employees, "EmployeeId", "Name");

            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", employee.RoleId);
             ViewData["EmployeeParentId"] = new SelectList(_context.Employees, "EmployeeId", "Name", employee.EmployeeId);

             */


            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeCommandRepo.Find(id.GetValueOrDefault());


            ViewBag.RoleId = new SelectList(_roleQueriesRepo.GetAll(), "RoleId", "RoleName");
            ViewBag.EmployeeParentId = new SelectList(_employeeQueriesRepo.GetAll(), "EmployeeId", "Name");

            //var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            //ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", employee.RoleId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeParentId,Name,Email,Passsword,RoleId,DateOfBirth")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _employeeCommandRepo.Update(employee);
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                   /* if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                    */
                }
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", employee.RoleId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", employee.RoleId);
            */

           // ViewBag.RoleId = new SelectList(_context.Roles, "RoleId", "RoleName");
           // ViewBag.EmployeeParentId = new SelectList(_context.Employees, "EmployeeId", "Name");

            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeQueriesRepo.Find(id.GetValueOrDefault());
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {    

           _employeeCommandRepo.Remove(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
