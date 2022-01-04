using eBookstore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Controllers
{
    public class GenresController : Controller
    {
        private readonly AppDbContext _context; //inject dbcontext, to send data to database

        public GenresController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Genres.ToListAsync();
            return View();
        }
    }
}
