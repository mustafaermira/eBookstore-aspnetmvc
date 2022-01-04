using eBookstore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Controllers
{
    public class WritersController : Controller
    {
        private readonly AppDbContext _context; //inject dbcontext, to send data to database

        public WritersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allWriters = await _context.Writers.ToListAsync();
            return View(allWriters);
        }
    }
}
