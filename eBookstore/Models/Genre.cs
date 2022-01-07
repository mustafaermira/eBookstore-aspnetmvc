using eBookstore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Models
{
    public class Genre : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name= "Genre")]
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "GenreName must be between 3 and 50 chars")]
        public string GenreName { get; set; }
        [Display(Name = "Genre Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Descripion must be between 3 and 50 chars")]

        public string Description { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }
}
