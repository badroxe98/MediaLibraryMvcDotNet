using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjetKhaoudi.Models
{
    public class VideoGame
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string genre { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Developer { get; set; }

        [StringLength(60,MinimumLength=1)]
        [Required]
        public string Plateform { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public double Rating { get; set; }
    }
}
