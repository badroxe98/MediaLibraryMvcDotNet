using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MiniProjetKhaoudi.Models
{
    public static class SeedDataGames
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MiniProjetKhaoudiContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MiniProjetKhaoudiContext>>()))
            {
                if (context.VideoGame.Any())
                {
                    return;
                }
                context.VideoGame.AddRange(
                    new VideoGame
                    {
                        Title = "Resident Evil 2",
                        genre = "Survival Horror",
                        Developer = "Capcom",
                        Plateform = "PlayStation",
                        ReleaseDate = DateTime.Parse("2019-1-25"),
                        Rating = 9
                    },
                    new VideoGame
                    {
                        Title = "Watch Dogs",
                        genre = "Action",
                        Developer = "Ubisoft",
                        Plateform = "Xbox",
                        ReleaseDate = DateTime.Parse("2014-3-05"),
                        Rating = 8
                    },
                     new VideoGame
                     {
                         Title = "the elder scrolls v skyrim",
                         genre = "RPG",
                         Developer = " Bethesda",
                         Plateform = "PC",
                         ReleaseDate = DateTime.Parse("2011-11-11"),
                         Rating = 10
                     },
                      new VideoGame
                      {
                          Title = "Devil May Cry 5",
                          genre = "Action",
                          Developer = " Capcom",
                          Plateform = "PlayStation",
                          ReleaseDate = DateTime.Parse("2019-3-08"),
                          Rating = 10
                      }
                    );
                context.SaveChanges();
            }
        }
    }
}