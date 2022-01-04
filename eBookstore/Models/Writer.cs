using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Models
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }

}
