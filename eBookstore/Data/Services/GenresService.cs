using eBookstore.Data.Base;
using eBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Data.Services
{
    public class GenresService : EntityBaseRepository<Genre>, IGenresService
    {
        public GenresService(AppDbContext context) : base(context)
        {

        }
    }
}
