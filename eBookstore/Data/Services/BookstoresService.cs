using eBookstore.Data.Base;
using eBookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Data.Services
{
    public class BookstoresService : EntityBaseRepository<Bookstore>, IBookstoresService
    {
        private readonly AppDbContext _context;
        public BookstoresService(AppDbContext context) : base(context) { }
        
        
    }
}
