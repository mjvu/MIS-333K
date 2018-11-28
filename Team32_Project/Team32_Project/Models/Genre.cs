using System;
using System.Collections.Generic;

namespace Team32_Project.Models
{
    public class Genre
    {
        public Int32 GenreID { get; set; }
        public String GenreName { get; set; }

        public List<Book> Books { get; set; }
    }
}
