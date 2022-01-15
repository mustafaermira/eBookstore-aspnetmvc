using eBookstore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Models
{
    public class NewBookVM
    {
        public int Id { get; set; }
        [Display(Name = "Book name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Book Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Book URL")]
        [Required(ErrorMessage = "Image is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Release date")]
        [Required(ErrorMessage = "Release Date is required")]
        public DateTime ReleaseDate { get; set; }

        //Relationships
        [Display(Name = "Select bookstores")]
        [Required(ErrorMessage = "Bookstore is required")]
        public List<int> BookstoreIds { get; set; }

        [Display(Name = "Select a Genre")]
        [Required(ErrorMessage = "Genre is required")]
        public int GenresId { get; set; }

        [Display(Name = "Select a Writer")]
        [Required(ErrorMessage = "Writer is required")]
        public int WriterId { get; set; }
        
    }
}
