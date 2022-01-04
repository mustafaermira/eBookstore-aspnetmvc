using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime ReleaseDate { get; set; }
        //Relationships
        public List<Bookstore_Book> Bookstores_Books { get; set; }

        //Genre
        public int GenresId { get; set; }
        [ForeignKey("GenresId")]
        public Genre Genres { get; set; }

        //Writer
        public int WriterId { get; set; }
        [ForeignKey("WriterId")]
        public Writer Writers { get; set; }
    }
}
