using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniProjetKhaoudi.Models;

namespace MiniProjetKhaoudi.Models
{
    public class MiniProjetKhaoudiContext : DbContext
    {
        public MiniProjetKhaoudiContext (DbContextOptions<MiniProjetKhaoudiContext> options)
            : base(options)
        {
        }

        public DbSet<MiniProjetKhaoudi.Models.Book> Book { get; set; }

        public DbSet<MiniProjetKhaoudi.Models.VideoGame> VideoGame { get; set; }
    }
}
