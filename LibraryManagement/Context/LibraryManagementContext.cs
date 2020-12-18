using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext(): base("name=name") { }
        public DbSet<CurrentBooks> CurrentBooks { get; set; }
        public DbSet<TemporaryGivenBooks> TemporaryGivenBooks { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public  DbSet<Customers> Customers { get; set; }
    }
}