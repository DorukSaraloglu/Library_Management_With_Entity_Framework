using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public class MainDal
    {
        #region Fill

        public List<CurrentBooks> FillCurrentBooks()
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                return context.CurrentBooks.ToList();
            }
        }
        public List<TemporaryGivenBooks> FillTemporaryGivenBooks()
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                return context.TemporaryGivenBooks.ToList();
            }
        }
        public List<Books> FillBooks()
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                return context.Books.ToList();
            }
        }
        public List<Employees> FillEmployees()
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                return context.Employees.ToList();
            }
        }
        public List<Authors> FillAuthors()
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var a = context.Authors.ToList();
                return a;
            }
        }
        public List<string> cbxFillAuthors()
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var a = context.Authors.Select(x => x.AuthorFirstName + " " + x.AuthorLastName).ToList();
                return a;
            }
        }
        public List<BookType> cbxFillBookType()
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                return context.BookTypes.ToList();
            }
        }

        #endregion

        #region GiveBook

        public void GiveBook(TemporaryGivenBooks book)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(book);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void CustomerAdd(Customers customer)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(customer);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void DeleteCurrentBooks(CurrentBooks currentBook)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(currentBook);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public Customers GetCustomerByPhone(int phone)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var customer = context.Customers.FirstOrDefault(x => x.CustomerPhoneNumber == phone);
                return customer;
            }
        }

        #endregion

        #region TakeBack

        public void TakeBack(TemporaryGivenBooks book)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(book);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public List<TemporaryGivenBooks> GetBookName(string key)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                return context.TemporaryGivenBooks.Where(p => p.BookName.Contains(key)).ToList();
            }
        }
        public List<TemporaryGivenBooks> GetFirstName(string key)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                return context.TemporaryGivenBooks.Where(p => p.CustomerFirstName.Contains(key)).ToList();
            }
        }
        public List<TemporaryGivenBooks> GetLastName(string key)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                return context.TemporaryGivenBooks.Where(p => p.CustomerLastName.Contains(key)).ToList();
            }
        }

        #endregion

        #region Book

        public void BookAdd(Books book)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(book);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void BookUpdate(Books book)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(book);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void BookDelete(Books book)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(book);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void CurrentBookAdd(CurrentBooks currentBook)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(currentBook);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void CurrentBookUpdate(CurrentBooks currentBook)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(currentBook);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void CurrentBookDelete(CurrentBooks currentBook)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(currentBook);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void TemporaryGivenBookUpdate(TemporaryGivenBooks temporaryGivenBooks)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(temporaryGivenBooks);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void TemporaryGivenBookDelete(TemporaryGivenBooks temporaryGivenBooks)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(temporaryGivenBooks);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        #endregion

        #region Employee

        public void EmployeeAdd(Employees employee)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(employee);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void EmployeeUpdate(Employees employee)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(employee);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void EmployeeDelete(Employees employee)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(employee);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        #endregion

        #region Author

        public void AuthorAdd(Authors author)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(author);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void AuthorUpdate(Authors author)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(author);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void AuthorDelete(Authors author)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Entry(author);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        #endregion
    }
}