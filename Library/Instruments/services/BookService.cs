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
                        File.WriteAllText("/"+book.Id.ToString(), content);
                    }
                    catch (ArgumentException)
                    {
                        return false;
                    }
                    db.UnmoderatedBooks.Add(book);
                    db.SaveChanges();
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
        public static async Task<(BookDTO,string)> getBookByTitle(string title)
        {
            using (var db = new BookDb())
            {
                var book = db.SaveToReedBooks.FirstOrDefault(book => book.Title == title);
                if (book != null)
                {
                    string text = File.ReadAllText("/" + book.Id.ToString());
                    return (book, title);
                }
                return (null, null);
            }
        }
        public static async Task<(BookDTO,string)> GetUnsafeBookByTitle(string title)
        {
            using (var bookDb = new BookDb())
            {
                var book = bookDb.UnmoderatedBooks.FirstOrDefault(b => b.Title == title);
                if (book != null)
                {
                    string text = File.ReadAllText("/" + book.Id.ToString());
                    return (book, title);
                }
                return (null, null);
            }

        }


        public static async Task<Dictionary<BookDTO, string>> GetUnsafeBookS()
        {
            using ( var bookDb = new BookDb())
            {
                Dictionary<BookDTO, string> BookTextDictionary = new Dictionary<BookDTO, string>();
                List<BookDTO> books = bookDb.UnmoderatedBooks.ToList();
                List<string> texts = new List<string>();
                foreach (var book in books)
                {
                    texts.Add(File.ReadAllText("/"+book.Id.ToString()));
                }
                for (int i = 0; i < books.Count; i++)
                {
                    BookTextDictionary[books[i]] = texts[i];
                }
                return BookTextDictionary;
            }
        }

    }
}
