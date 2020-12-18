using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class CurrentBooks
    {
        [Key]public int CurrentBookId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
    }
}
