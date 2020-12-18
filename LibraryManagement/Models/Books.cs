using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public class Books
    {
        [Key]public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookTypeId { get; set; }
        public string BookTypeName { get; set; }
        public int BookAuthorId { get; set; }
        public string BookAuthorFullName { get; set; }
    }
}
