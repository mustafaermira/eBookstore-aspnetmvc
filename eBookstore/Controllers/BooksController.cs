using eBookstore.Data;
using eBookstore.Data.Services;
using eBookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAllAsync(n => n.Genres);
            return View(allBooks);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync(n => n.Genres);
            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allBooks.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allBooks);
        }

        //GET: Books/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var bookDetail = await _service.GetBookByIdAsync(id);
            return View(bookDetail);
        }

        //Get: Books/Create
        public async Task<IActionResult> Create()
        {
            var bookDropdownsData = await _service.GetNewBookDropdownsValues();
            ViewBag.Genres = new SelectList(bookDropdownsData.Genres, "Id", "GenreName");
            ViewBag.Writers = new SelectList(bookDropdownsData.Writers, "Id", "Name");
            ViewBag.Bookstores = new SelectList(bookDropdownsData.Bookstores, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book)
        {
            if(!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.Genres = new SelectList(bookDropdownsData.Genres, "Id", "GenreName");
                ViewBag.Writers = new SelectList(bookDropdownsData.Writers, "Id", "Name");
                ViewBag.Bookstores = new SelectList(bookDropdownsData.Bookstores, "Id", "Name");
                return View(book);
            }

            await _service.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }


        //Get: Books/Edit/1
        public async Task<IActionResult> Edit(int id)
        {

            var bookDetails = await _service.GetBookByIdAsync(id);
            if (bookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                Name = bookDetails.Name,
                Description = bookDetails.Description,
                Price = bookDetails.Price,
                ReleaseDate = bookDetails.ReleaseDate,
                ImageURL = bookDetails.ImageURL,
                GenresId = bookDetails.GenresId,
                WriterId = bookDetails.WriterId,
                BookstoreIds = bookDetails.Bookstores_Books.Select(n => n.BookstoreId).ToList(),
            };

            var bookDropdownsData = await _service.GetNewBookDropdownsValues();
            ViewBag.Genres = new SelectList(bookDropdownsData.Genres, "Id", "GenreName");
            ViewBag.Writers = new SelectList(bookDropdownsData.Writers, "Id", "Name");
            ViewBag.Bookstores = new SelectList(bookDropdownsData.Bookstores, "Id", "Name");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {

            if (id != book.Id) return View("NotFound");


            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.Genres = new SelectList(bookDropdownsData.Genres, "Id", "GenreName");
                ViewBag.Writers = new SelectList(bookDropdownsData.Writers, "Id", "Name");
                ViewBag.Bookstores = new SelectList(bookDropdownsData.Bookstores, "Id", "Name");
                return View(book);
            }

            await _service.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

    }
}
