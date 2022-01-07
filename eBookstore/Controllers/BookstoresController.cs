using eBookstore.Data;
using eBookstore.Data.Services;
using eBookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Controllers
{
    public class BookstoresController : Controller
    {
        private readonly IBookstoresService _service; 

        public BookstoresController(IBookstoresService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var allBookstores =await _service.GetAllAsync();
            return View(allBookstores);
        }

        //Get Request: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Logo,Description")]Bookstore bookstore)
        {
            if(!ModelState.IsValid)
            {
                return View(bookstore);
            }
            await _service.AddAsync(bookstore);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var bookstoreDetails =await _service.GetByIdAsync(id);

            if (bookstoreDetails == null) return View("NotFound");
            return View(bookstoreDetails);
        }

        //Get Request: Bookstores/Create
        public async Task <IActionResult> Edit(int id)
        {
            var bookstoreDetails = await _service.GetByIdAsync(id);
            if (bookstoreDetails == null) return View("NotFound");
            return View(bookstoreDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,Description")] Bookstore bookstore)
        {
            if (!ModelState.IsValid)
            {
                return View(bookstore);
            }
            await _service.UpdateAsync(id, bookstore);
            return RedirectToAction(nameof(Index));
        }

        //Get Request: Bookstores/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var bookstoreDetails = await _service.GetByIdAsync(id);
            if (bookstoreDetails == null) return View("NotFound");
            return View(bookstoreDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookstoreDetails = await _service.GetByIdAsync(id);
            if (bookstoreDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
