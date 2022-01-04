using eBookstore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Controllers
{
    public class BookstoresController : Controller
    {
        private readonly AppDbContext _context; //inject dbcontext, to send data to database

        public BookstoresController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var data = _context.Bookstores.ToList();
            return View(data);
        }
    }
}
