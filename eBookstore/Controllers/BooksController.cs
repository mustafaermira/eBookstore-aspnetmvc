using eBookstore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context; //inject dbcontext, to send data to database

        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Books.ToListAsync();
            return View();
        }
    }
}
