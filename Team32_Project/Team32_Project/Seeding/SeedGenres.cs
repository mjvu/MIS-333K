using System;
using System.Collections.Generic;
using Team32_Project.DAL;
using Team32_Project.Models;
using System.Linq;

namespace Team32_Project.Seeding
{
    public static class SeedGenres
    {
        public static void SeedAllGenres(AppDbContext db)
        {
            //check to see if all the genres have already been added
            if (db.Genres.Count() == 7)
            {
                //exit the program - we don't need to do any of this
                NotSupportedException ex = new NotSupportedException("Genre record count is already 7!");
                throw ex;
            }
            Int32 intGenresAdded = 0;
            try
            {
                //Create a list of genres
                List<Genre> Genres = new List<Genre>();

                Genre g1 = new Genre { GenreName = "Contemporary Fiction" };
                Genres.Add(g1);

                Genre g2 = new Genre { GenreName = "Science Fiction" };
                Genres.Add(g2);

                Genre g3 = new Genre { GenreName = "Mystery" };
                Genres.Add(g3);

                Genre g4 = new Genre { GenreName = "Suspense" };
                Genres.Add(g4);

                Genre g5 = new Genre { GenreName = "Romance" };
                Genres.Add(g5);

                Genre g6 = new Genre { GenreName = "Thriller" };
                Genres.Add(g6);

                Genre g7 = new Genre { GenreName = "Fantasy" };
                Genres.Add(g7);

                Genre g;
      
                //loop through the list and see which (if any) need to be added
                foreach (Genre genre in Genres)
                {
                    //see if the genre already exists in the database
                    g = db.Genres.FirstOrDefault(x => x.GenreName == genre.GenreName);

                    //genre was not found
                    if (g == null)
                    {
                        //Add the genre
                        db.Genres.Add(genre);
                        db.SaveChanges();
                        intGenresAdded += 1;
                    }

                }
            }
            catch
            {
                String msg = "Genres Added: " + intGenresAdded.ToString();
                throw new InvalidOperationException(msg);
            }

        }
    }
}
