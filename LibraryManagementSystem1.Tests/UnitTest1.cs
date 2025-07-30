using NUnit.Framework;
using LibraryManagementSystem;
using System.Linq;
using LibraryManagementSystem1;

namespace LibraryManagementSystem.Tests
{
    public class LibraryTests
    {
        private Library library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }

        [Test]
        public void Test_AddBook()
        {
            var book = new Book { Title = "Book A", Author = "Author A", ISBN = "123" };
            library.AddBook(book);

            Assert.Contains(book, library.Books);
        }

        [Test]
        public void Test_RegisterBorrower()
        {
            var borrower = new Borrower { Name = "John", LibraryCardNumber = "L001" };
            library.RegisterBorrower(borrower);

            Assert.Contains(borrower, library.Borrowers);
        }

        [Test]
        public void Test_BorrowBook()
        {
            var book = new Book { Title = "Book B", Author = "Author B", ISBN = "456" };
            var borrower = new Borrower { Name = "Jane", LibraryCardNumber = "L002" };

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("456", "L002");

            Assert.IsTrue(book.IsBorrowed);
            Assert.Contains(book, borrower.BorrowedBooks);
        }

        [Test]
        public void Test_ReturnBook()
        {
            var book = new Book { Title = "Book C", Author = "Author C", ISBN = "789" };
            var borrower = new Borrower { Name = "Ram", LibraryCardNumber = "L003" };

            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook("789", "L003");
            library.ReturnBook("789", "L003");

            Assert.IsFalse(book.IsBorrowed);
            Assert.IsFalse(borrower.BorrowedBooks.Contains(book));
        }
    }
}