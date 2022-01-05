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
        [Display(Name= "Genre")]
        public string GenreName { get; set; }
        [Display(Name = "Genre Description")]
        public string Description { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }
}
