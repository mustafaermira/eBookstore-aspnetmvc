using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Models
{
    public class Bookstore_Book
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int BookstoreId { get; set; }
        public Bookstore Bookstore { get; set; }
    }
}
