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
using Microsoft.AspNetCore.Authorization;

namespace EKbanaTest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly IRoleCommandsRepo _roleCommandRepo;
        private readonly IRoleQueriesRepo _roleQueriesRepo;

        public RolesController(IRoleCommandsRepo roleCommandRepo, IRoleQueriesRepo roleQueriesRepo)
        {
            _roleCommandRepo = roleCommandRepo;
            _roleQueriesRepo = roleQueriesRepo;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Roles.ToListAsync());

            return View(_roleQueriesRepo.GetAll());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

   
            var role = _roleQueriesRepo.Find(id.GetValueOrDefault());
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName")] Role role)
        {
            if (ModelState.IsValid)
            {
                _roleCommandRepo.Add(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = _roleQueriesRepo.Find(id.GetValueOrDefault());
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName")] Role role)
        {
            if (id != role.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _roleCommandRepo.Update(role);
               /* try
                {
                    _roleCommandRepo.Update(role);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.RoleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               */
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var role = _roleQueriesRepo.Find(id.GetValueOrDefault());


            if (role == null)
            {
                return NotFound();
            }


            return View(role);
        }

        
        
        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _roleCommandRepo.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        
 
    }
}
