using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{


    //выбор объекта из БД по его идентификатору, выбор всех объектов, добавление объекта в БД и его удаление из БД.
    //А также специфичные методы: обновление года выпуска книги (по Id).
    public class BookRepository
    {
        public BookEntity SelectBookForId(int id)
        {
            using (var db = new AppContext())
            {
                var res = db.Books.Where(book => book.Id == id).FirstOrDefault();
                return res;
            }
        }

        public List<BookEntity> SelectAllBook()
        {
            using (var db = new AppContext())
            {
                var res = db.Books.ToList();
                return res;
            }

        }

        public string InsertBook(BookEntity newBook)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(newBook);
                db.SaveChanges();
                string res = $"Book {newBook.BookName} added success";
                return res;
            }
        }

        public string DeleteBook(BookEntity delBook)
        {
            using (var db = new AppContext())
            {
                db.Books.Remove(delBook);
                db.SaveChanges();
                string res = $"Book {delBook.BookName} deleted success";
                return res;
            }
        }


        public BookEntity UpdateBookReleaseYearForId(int id, int newReleaseYear)
        {
            using (var db = new AppContext())
            {
                var bookUpdate = db.Books.Where(book => book.Id == id).FirstOrDefault();
                bookUpdate.ReleaseYear = newReleaseYear;
                db.SaveChanges();
                return bookUpdate;
            }

        }

        public string GiveBookToUser(int bookId, UserEntity userInfo)
        {
            using (var db = new AppContext())
            {
                var selectedBook = db.Books.Where(book => book.Id == bookId).FirstOrDefault();
                selectedBook.Reader = userInfo;
                db.SaveChanges();
                return $"Book {bookId} got by {userInfo}";
            }
        }


        //Получать список книг определенного жанра и вышедших между определенными годами.
        public List<BookEntity> SelectBooksByStyleAndBetweenYears(string style, int yearFrom, int yearTo)
        {
            using (var db = new AppContext())
            {
                var query = db.Books
                .Where(b => b.Style == style && b.ReleaseYear > yearFrom && b.ReleaseYear < yearTo)
                .ToList();
                
                var books = query.ToList();

                var res = db.Books.ToList();
                foreach (var book in books)
                {
                    Console.WriteLine(book.BookName);
                }
                return books;
            }
        }
        //Получать количество книг определенного автора в библиотеке.
        public int SelectCountBooksByAuthor(string author)
        {
            using (var db = new AppContext())
            {
                var query = db.Books
                .Where(b => b.Author == author)
                .Count();

                Console.WriteLine($"{author} написал {query} книг");
                
                return query;
            }
        }


        //Получать количество книг определенного жанра в библиотеке.
        public int SelectCountBooksByStyle(string style)
        {
            using (var db = new AppContext())
            {
                var query = db.Books
                .Where(b => b.Style == style)
                .Count();

                Console.WriteLine($"В жанре {style} написно {query} книг");

                return query;
            }
        }

        //Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool FindBooksByAuthorAndName(string author, string bookName)
        {
            using (var db = new AppContext())
            {
                var query = db.Books
                .Where(b => b.Author == author && b.BookName == bookName)
                .Any();
                
                var res = (query == true) ? "есть" : "нет";
                Console.Write($"Книга {bookName} написанная автором {author} в библиотеке {res}");

                return query;
            }
        }

        //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool FindBooksByNameFromReader(string bookName)
        {
            using (var db = new AppContext())
            {
                var query = db.Books
                .Where(b => b.BookName == bookName && b.Reader != null)
                .Any();

                var book = db.Books
                .Where(b => b.BookName == bookName && b.Reader != null)
                .First();

                Console.Write($"Книга {book.BookName} на руках у - {book.Reader}");

                return query;
            }
        }

        //Получать количество книг на руках у пользователя.
        public int CountBooksByReader(int userId)
        {
            using (var db = new AppContext())
            {
                var res = db.Books
                .Where(b => b.Reader.Id == userId)
                .Count();

                var reader = db.Books
                .Where(b => b.Reader.Id == userId)
                .First();

                Console.Write($"На руках у {reader.Reader.Name} {res} книг");

                return res;
            }
        }


        //Получение последней вышедшей книги.
        public BookEntity SelectNewestBook()
        {
            using (var db = new AppContext())
            {
                var newestYear = db.Books
                .Max(b => b.ReleaseYear);

                var book = db.Books
                    .Where(b => b.ReleaseYear == newestYear)
                    .First();

                Console.Write($"Самая новая книга {book.BookName} написана в {book.ReleaseYear} году");

                return book;
            }
        }

        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<BookEntity> SelectAllBookSortByAZ()
        {
            using (var db = new AppContext())
            {
                var books = db.Books.OrderBy(b => b.BookName).ToList();

                Console.WriteLine("Список всех книг, отсортированный в алфавитном порядке по названию");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }

                return books;
            }
        }
        //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<BookEntity> SelectAllBookSortByReleaseYearDesc()
        {
            using (var db = new AppContext())
            {
                var books = db.Books.OrderByDescending(b => b.ReleaseYear).ToList();

                Console.WriteLine("Список всех книг, отсортированный в порядке убывания по году их выхода");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }

                return books;
            }
        }

    }
}
