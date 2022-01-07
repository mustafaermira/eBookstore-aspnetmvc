using eBookstore.Data.Base;
using eBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Data.Services
{
    public class WritersService : EntityBaseRepository<Writer>, IWritersService
    {
        private readonly AppDbContext _context;
        public WritersService(AppDbContext context) : base(context)
        {

        }
        
    }
}
