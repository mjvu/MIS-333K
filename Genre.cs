using System;
namespace Project.Properties
{
    public class Genre
    {
        public Int32 GenreID { get; set; }
        public Boolean GenreName { get; set; }

        public List<Book> Books { get; set; }
    }
}
