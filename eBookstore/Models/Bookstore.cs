﻿using System;
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
        [Display(Name= "Logo")]
        public string Logo { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        //Relationships
        //   public List<Book> Books { get; set; }
        public List<Bookstore_Book> Bookstores_Books { get; set; }

    }
}
