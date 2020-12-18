using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class BookType
    {
        [Key]public int BookTypeId { get; set; }
        public string BookTypeName { get; set; }
    }
}
