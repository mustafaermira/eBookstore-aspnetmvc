using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Models
{
    public class Bookstore
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationships
        //   public List<Book> Books { get; set; }
        public List<Bookstore_Book> Bookstores_Books { get; set; }

    }
}
