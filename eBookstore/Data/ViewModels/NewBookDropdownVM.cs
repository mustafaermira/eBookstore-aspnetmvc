using eBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Data.ViewModels
{
    public class NewBookDropdownVM
    {
        public NewBookDropdownVM()
        {
            Writers = new List<Writer>();
            Genres = new List<Genre>();
            Bookstores = new List<Bookstore>();
        }
        public List<Writer> Writers { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Bookstore> Bookstores { get; set; }
    }
}
