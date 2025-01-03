using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspnetCore.Mvc;
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
            return View(await _context.Users.ToListAsync());
        }


        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            
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
    }
