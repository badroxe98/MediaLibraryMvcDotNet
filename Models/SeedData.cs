using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MiniProjetKhaoudi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context=new MiniProjetKhaoudiContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MiniProjetKhaoudiContext>>()))
            {
                if (context.Book.Any())
                {
                    return;
                }
                context.Book.AddRange(
                    new Book
                    {
                        Title = "Harry Potter",
                        author = "J.K Rowling",
                        Category = "Roman",
                        ReleaseDate = DateTime.Parse("1997-6-26"),
                        Rating = 10
                    },
                    new Book
                    {
                        Title = "Candide",
                        author = "Voltaire",
                        Category = "Conte philosophique",
                        ReleaseDate = DateTime.Parse("1759-2-26"),
                        Rating = 9
                    },
                    new Book
                    {
                        Title = "Le Dernier jour d'un condamné",
                        author = "Victor Hugo",
                        Category = "Roman",
                        ReleaseDate = DateTime.Parse("1829-2-26"),
                        Rating = 10
                    },
                    new Book
                    {
                        Title = "Au coeur des ténebres",
                        author = "Joseph Conrad",
                        Category = "Nouvelle",
                        ReleaseDate = DateTime.Parse("1902-2-05"),
                        Rating = 8
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
