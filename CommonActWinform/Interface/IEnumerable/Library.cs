using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActWinform.Interface.IEnumerable
{
    class Library
    {
        private readonly List<Book> _books;
        public Library()
        {
            _books = GetAllBooks();
        }
        public IEnumerable<Book> GetBooks()
        {
            //IEnumerable로 제한시 읽기만 가능
            return _books;
        }

        private List<Book> GetAllBooks()
        {
            return new List<Book>
            {
                new Book()
                {
                    ID = 1,
                    이름 = "찰스",
                    지은이 = "찰스 페돌츠",
                    출판사 = "명랑",
                },
                new Book()
                {
                    ID = 2,
                    이름 = "찰스",
                    지은이 = "찰스 페돌츠",
                    출판사 = "명랑",
                },
                new Book()
                {
                    ID = 3,
                    이름 = "찰스",
                    지은이 = "찰스 페돌츠",
                    출판사 = "명랑",
                },
                new Book()
                {
                    ID = 4,
                    이름 = "찰스",
                    지은이 = "찰스 페돌츠",
                    출판사 = "명랑",
                },
                new Book()
                {
                    ID = 5,
                    이름 = "찰스",
                    지은이 = "찰스 페돌츠",
                    출판사 = "명랑",
                }
            };
        }
    }
}
