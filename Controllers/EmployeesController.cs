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

    [Authorize]
     public class EmployeesController : Controller
    {
       


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

           
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
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

          
            if (employee == null)
            {
                return NotFound();
            }
          
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
                
             _employeeCommandRepo.Update(employee);
               return RedirectToAction(nameof(Index));
            }
            

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
