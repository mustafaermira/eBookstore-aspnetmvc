using eBookstore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //Genres
                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(new List<Genre>()
                    {
                        new Genre()
                        {
                            GenreName = "Horror",
                            Description = "Shume horrir",

                        },
                        new Genre()
                        {
                            GenreName = "Horror",
                            Description = "Shume horrir",

                        },
                        new Genre()
                        {
                            GenreName = "Horror",
                            Description = "Shume horrir",

                        },

                    });
                    context.SaveChanges();

                }
                //Writers
                if (!context.Writers.Any())
                {
                    context.Writers.AddRange(new List<Writer>()
                    {
                        new Writer()
                        {
                            ProfilePictureURL = "Dukagjini",
                            Name = "JK",
                            LastName = "Rowling",
                            Bio = "hdjieowheiode"
                        },
                        new Writer()
                        {
                            ProfilePictureURL = "Dukagjini",
                            Name = "Will",
                            LastName = "Rowling",
                            Bio = "hdjieowheiode"
                        },
                        new Writer()
                        {
                            ProfilePictureURL = "Dukagjini",
                            Name = "Will",
                            LastName = "Rowling",
                            Bio = "hdjieowheiode"
                        },

                    });
                    context.SaveChanges();

                }

                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Name = "Harry Potter",
                            Description = "Libraria Dukagjini",
                            Price=23.33,
                            ImageURL="url",
                            ReleaseDate =DateTime.Now,
                            WriterId = 1,
                            GenresId = 1

                        },
                         new Book()
                        {
                            Name = "Harry Potter",
                            Description = "Libraria Dukagjini",
                            Price=23.33,
                            ImageURL="url",
                            ReleaseDate =DateTime.Now,
                            WriterId = 1,
                            GenresId = 1

                        },
                          new Book()
                        {
                            Name = "Harry Potter",
                            Description = "Libraria Dukagjini",
                            Price=23.33,
                            ImageURL="url",
                            ReleaseDate =DateTime.Now,
                            WriterId = 1,
                            GenresId = 1

                        }


                    });
                    context.SaveChanges();

                }
                //Bookstores
                if (!context.Bookstores.Any())
                {
                    context.Bookstores.AddRange(new List<Bookstore>()
                    {
                        new Bookstore()
                        {
                            Name = "Dukagjini",
                            Logo = "photo.png",
                            Description = "Libraria Dukagjini"
                        },
                        new Bookstore()
                        {
                            Name = "Dukagjini",
                            Logo = "photo.png",
                            Description = "Libraria Dukagjini"
                        },
                        new Bookstore()
                        {
                            Name = "Dukagjini",
                            Logo = "photo.png",
                            Description = "Libraria Dukagjini"
                        }

                    });
                    context.SaveChanges();

                }
                //Bookstore & Book
                if (!context.Bookstores_Books.Any())
                {
                    context.Bookstores_Books.AddRange(new List<Bookstore_Book>()
                    {
                        new Bookstore_Book()
                        {
                            BookId=5,
                            BookstoreId=1,

                        },


                    });
                    context.SaveChanges();

                }



            }
        }
    }
}
