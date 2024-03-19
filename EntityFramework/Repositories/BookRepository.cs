using EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{


    //выбор объекта из БД по его идентификатору, выбор всех объектов, добавление объекта в БД и его удаление из БД.
    //А также специфичные методы: обновление года выпуска книги (по Id).
    public class BookRepository
    {
        public BookEntity SelectBookForId(int id)
        {
            var db = new AppContext();
            var res = db.Books.Where(book => book.Id == id).FirstOrDefault();
            return res;
        }

        public List<BookEntity> SelectAllBook()
        {
            var db = new AppContext();
            var res = db.Books.ToList();
            return res;

        }

        public string InsertBook(BookEntity newBook)
        {
            var db = new AppContext();
            db.Books.Add(newBook);
            db.SaveChanges();
            string res = $"Book {newBook.BookName} added success";
            return res;
        }

        public string DeleteBook(BookEntity delBook)
        {
            var db = new AppContext();
            db.Books.Remove(delBook);
            db.SaveChanges();
            string res = $"Book {delBook.BookName} deleted success";
            return res;
        }


        public BookEntity UpdateBookReleaseYearForId(int id, string newReleaseYear)
        {
            var db = new AppContext();
            var bookUpdate = db.Books.Where(book => book.Id == id).FirstOrDefault();
            bookUpdate.ReleaseYear = newReleaseYear;
            db.SaveChanges();
            return bookUpdate;

        }

    }
}
