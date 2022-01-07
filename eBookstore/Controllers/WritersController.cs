using eBookstore.Data;
using eBookstore.Data.Services;
using eBookstore.Models;
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
        private readonly IWritersService _service;
        public WritersController(IWritersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allWriters = await _service.GetAllAsync();
            return View(allWriters);
        }


        //Get: Writers/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, Name, LastName, Bio")]Writer writer)
        {
            if (!ModelState.IsValid) return View(writer);
            await _service.AddAsync(writer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Writers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var writerDetails = await _service.GetByIdAsync(id);
            if (writerDetails == null) return View("NotFound");
            return View(writerDetails);
        }


        //Get: Writers/Edit/1
        
        public async Task<IActionResult> Edit(int id)
        {
            var writerDetails = await _service.GetByIdAsync(id);
            if (writerDetails == null) return View("NotFound");
            return View(writerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL, Name, LastName, Bio")] Writer writer)
        {
            if (!ModelState.IsValid)
            {
                return View(writer);
            }
            await _service.UpdateAsync(id, writer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Writers/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var writerDetails = await _service.GetByIdAsync(id);
            if (writerDetails == null) return View("NotFound");
            return View(writerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var writerDetails = await _service.GetByIdAsync(id);
            if (writerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
