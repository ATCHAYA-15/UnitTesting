using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem1
{
    public class Borrower
    {
        public string Name { get; set; }
        public string LibraryCardNumber { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new();

        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
            book.Borrow();
        }

        public void ReturnBook(Book book)
        {
            BorrowedBooks.Remove(book);
            book.Return();
        }
    }
}
