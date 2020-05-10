using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniProjetKhaoudi.Models;

namespace MiniProjetKhaoudi.Models
{
    public class VideoGameGenreViewModel
    {
        public List<VideoGame> Games;
        public SelectList Genres;
        public String VideoGameGenre { get; set; }
        public String SearchString { get; set; }
    }
}


