using Team32_Project.Models;
using Team32_Project.DAL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Team32_Project.Seeding
{
	public static class SeedBooks
	{
		public static void SeedAllBooks(AppDbContext db)
		{
			if (db.Books.Count() == 10)
			{
				throw new NotSupportedException("The database already contains all 10 books!");
			}

			Int32 intBooksAdded = 0;
			String bookName = "Begin"; //helps to keep track of error on books
			List<Book> Books = new List<Book>();

			try
			{
				Book b1 = new Book();
                b1.PublicationDate = new DateTime(2008, 5, 24);
                b1.UniqueID = 789001;
				b1.Title = "The Art Of Racing In The Rain";
				b1.Author = "Garth Stein";
                b1.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Contemporary Fiction");
                b1.Description = "A Lab-terrier mix with great insight into the human condition helps his owner, a struggling race car driver.";
				b1.Price = 23.95m;
                b1.Cost = 10.30m;
                b1.ReorderPoint = 1m;
                b1.CopiesOnHand = 2m;
                b1.LastOrdered = new DateTime(2018, 10, 1);
				Books.Add(b1);

				Book b2 = new Book();
                b2.PublicationDate = new DateTime(2008, 5, 24);
                b2.UniqueID = 789002;
                b2.Title = "The Host";
                b2.Author = "Stephenie Meyer";
                b2.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Science Fiction");
                b2.Description = "Aliens have taken control of the minds and bodies of most humans, but one woman won’t surrender.";
                b2.Price = 25.99m;
                b2.Cost = 13.25m;
                b2.ReorderPoint = 7m;
                b2.CopiesOnHand = 8m;
                b2.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b2);

				Book b3 = new Book();
                b3.PublicationDate = new DateTime(2008, 7, 5);
                b3.UniqueID = 789003;
                b3.Title = "Chasing Darkness";
                b3.Author = "Robert Crais";
                b3.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b3.Description = "The Los Angeles private eye Elvis Cole responsible for the release of a serial killer?";
                b3.Price = 25.95m;
                b3.Cost = 9.08m;
                b3.ReorderPoint = 7m;
                b3.CopiesOnHand = 10m;
                b3.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b3);

				Book b4 = new Book();
                b4.PublicationDate = new DateTime(2008, 7, 19);
                b4.UniqueID = 789004;
                b4.Title = "Say Goodbye";
                b4.Author = "Lisa Gardner";
                b4.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Suspense");
                b4.Description = "An F.B.I. agent tracks a serial killer who uses spiders as a weapon.";
                b4.Price = 25.00m;
                b4.Cost = 11.25m;
                b4.ReorderPoint = 2m;
                b4.CopiesOnHand = 5m;
                b4.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b4);

				Book b5 = new Book();
                b5.PublicationDate = new DateTime(2008, 8, 9);
                b5.UniqueID = 789005;
                b5.Title = "The Gargoyle";
                b5.Author = "Andrew Davidson";
                b5.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Romance");
                b5.Description = "A hideously burned man is cared for by a sculptress who claims they were lovers seven centuries ago.";
                b5.Price = 25.95m;
                b5.Cost = 16.09m;
                b5.ReorderPoint = 3m;
                b5.CopiesOnHand = 5m;
                b5.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b5);

				Book b6 = new Book();
                b6.PublicationDate = new DateTime(2008, 8, 9);
                b6.UniqueID = 789006;
                b6.Title = "Foreign Body";
                b6.Author = "Robin Cook";
                b6.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Thriller");
                b6.Description = "A medical student investigates a rising number of deaths among medical tourists at foreign hospitals.";
                b6.Price = 25.95m;
                b6.Cost = 24.65m;
                b6.ReorderPoint = 6m;
                b6.CopiesOnHand = 11m;
                b6.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b6);

				Book b7 = new Book();
                b7.PublicationDate = new DateTime(2008, 8, 9);
                b7.UniqueID = 789007;
                b7.Title = "Acheron";
                b7.Author = "Sherrilyn Kenyon";
                b7.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Fantasy");
                b7.Description = "Book 12 of the Dark-Hunter paranormal series.";
                b7.Price = 24.95m;
                b7.Cost = 13.72m;
                b7.ReorderPoint = 2m;
                b7.CopiesOnHand = 2m;
                b7.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b7);

				Book b8 = new Book();
                b8.PublicationDate = new DateTime(2008, 8, 23);
                b8.UniqueID = 789008;
                b8.Title = "Being Elizabeth";
                b8.Author = "Barbara Taylor Bradford";
                b8.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Contemporary Fiction");
                b8.Description = "A 25-year-old newly in control of her family’s corporate empire faces tough choices in business and in love.";
                b8.Price = 27.95m;
                b8.Cost = 21.80m;
                b8.ReorderPoint = 5m;
                b8.CopiesOnHand = 9m;
                b8.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b8);

				Book b9 = new Book();
                b9.PublicationDate = new DateTime(2008, 8, 30);
                b9.UniqueID = 789009;
                b9.Title = "Just Breathe";
                b9.Author = "Susan Wiggs";
                b9.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Romance");
                b9.Description = "Her marriage broken, the author of a syndicated comic strip flees to California, where romance and surprise await.";
                b9.Price = 25.95m;
                b9.Cost = 5.45m;
                b9.ReorderPoint = 8m;
                b9.CopiesOnHand = 8m;
                b9.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b9);

				Book b10 = new Book();
                b10.PublicationDate = new DateTime(2008, 8, 30);
                b10.UniqueID = 789010;
                b10.Title = "The Gypsy Morph";
                b10.Author = "Terry Brooks";
                b10.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Fantasy");
                b10.Description = "In the third volume of the Genesis of Shannara series, champions of the Word and the Void clash.";
                b10.Price = 27.00m;
                b10.Cost = 6.75m;
                b10.ReorderPoint = 6m;
                b10.CopiesOnHand = 6m;
                b10.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b10);

				//loop through books
				foreach (Book book in Books)
				{
					//set name of book to help debug
					bookName = book.Title;

					//see if book exists in database
					Book dbBook = db.Books.FirstOrDefault(b => b.Title == book.Title);

					if (dbBook == null) //repository does not exist in database
					{
						db.Books.Add(book);
						db.SaveChanges();
						intBooksAdded += 1;
					}
					else
					{
                        dbBook.PublicationDate = book.PublicationDate;
                        dbBook.UniqueID = book.UniqueID;
                        dbBook.Title = book.Title;
                        dbBook.Author = book.Author;
                        dbBook.Genre = db.Genres.FirstOrDefault(g => g.GenreID == book.Genre.GenreID);
                        dbBook.Description = book.Description;
                        dbBook.Price = book.Price;
                        dbBook.Cost = book.Cost;
                        dbBook.ReorderPoint = book.ReorderPoint;
                        dbBook.CopiesOnHand = book.CopiesOnHand;
                        dbBook.LastOrdered = book.LastOrdered;
                        db.Update(dbBook);
						db.SaveChanges();
					}
				}
			}
			catch
			{
				String msg = "Books added:" + intBooksAdded + "; Error on " + bookName;
				throw new InvalidOperationException(msg);
			}
		}
	}
}
