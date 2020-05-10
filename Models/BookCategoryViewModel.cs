using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiniProjetKhaoudi.Models
{
    public class BookCategoryViewModel
    {
        public List<Book> Books;
        public SelectList Categories;
        public String BookCategory { get; set; }
        public String SearchString { get; set; }
    }
}
