﻿using eBookstore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Models
{
    public class Bookstore: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name= "Logo")]
        [Required(ErrorMessage = "Logo is Required")]
        public string Logo { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Name must be between 3 and 50 chars")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        //Relationships
        //   public List<Book> Books { get; set; }
        public List<Bookstore_Book> Bookstores_Books { get; set; }

    }
}
