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
    public class GenresController : Controller
    {
        private readonly IGenresService _service; //inject dbcontext, to send data to database

        public GenresController(IGenresService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //GET: genres/details/1
        public async Task<IActionResult> Details( int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);
            if (genreDetails == null) return View("NotFount");
            return View(genreDetails);
        }

        //Get: producers/create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("GenreName, Description")]Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);
            await _service.AddAsync(genre);
            return RedirectToAction(nameof(Index));

        }

        //Get: producers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);
            if (genreDetails == null) return View("NotFound");
            return View(genreDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, GenreName, Description")] Genre genre)
        {

            if (!ModelState.IsValid) return View(genre);
            if(id == genre.Id)
            {
                await _service.UpdateAsync(id, genre);
                return RedirectToAction(nameof(Index));
            }

            return View(genre);

        }


        //Get: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);
            if (genreDetails == null) return View("NotFound");
            return View(genreDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);
            if (genreDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
