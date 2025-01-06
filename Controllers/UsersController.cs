using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Data;
using MyMvcApp.Models;


namespace MyMvcApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersContext _context;
        
        public UsersController(UsersContext context)
        {
            _context = context;
        }
        

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.FromSqlRaw("select * from Users").ToListAsync());
        }


        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FromSqlRaw($"select * from Users where ID={id}").FirstOrDefaultAsync();
            
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }
        

        // POST: Users/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Password,PhoneNumber,IsActive")] User user)
        {
            if (ModelState.IsValid)
            {   
                user.IsActive = true;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
                
        }

        // POST: Users/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Password,PhoneNumber,IsActive")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/InActive
        public async Task<IActionResult> InActive()
        {
          return View(await _context.Users.FromSqlRaw("select * from Users where IsActive=0 order by Name asc").ToListAsync());
        }

        // GET: Users/Active
        public async Task<IActionResult> Active()
        {
          return View(await _context.Users.FromSqlRaw("select * from Users where IsActive=1 order by Name asc").ToListAsync());
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }

    }
}
