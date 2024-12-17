using Library.Instruments.DataBase;
using Library.Instruments.Dto;

namespace Library.Instruments.services
{
    public class BookService
    {
        public static bool FriteBookToTxt(BookDTO book,string content)
        {
            using (BookDb db = new BookDb())
            {
                if (db.UnmoderatedBooks.FirstOrDefault(b => b.Title == book.Title) == null)
                {
                    try
                    {
                        File.WriteAllText(book.Id.ToString(), content);
                    }
                    catch (ArgumentException)
                    {
                        return false;
                    }
                    db.UnmoderatedBooks.Add(book);
                    return true;
                }
                return false;
            }
            
        }
        public static async Task<bool> AcceptBook(string title)
        {
            using (BookDb db = new BookDb())
            {
                var book = db.UnmoderatedBooks.FirstOrDefault(book => book.Title == title);
                if (book != null)
                {
                    db.UnmoderatedBooks.Remove(book);
                    await db.SaveToReedBooks.AddAsync(book);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
