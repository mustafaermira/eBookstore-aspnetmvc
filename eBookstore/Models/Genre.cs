using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }
}
