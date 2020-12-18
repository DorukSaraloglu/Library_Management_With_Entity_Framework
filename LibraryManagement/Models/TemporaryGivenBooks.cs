using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class TemporaryGivenBooks
    {
        [Key]public int TemporaryGivenBookId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime GiveBackDate { get; set; }
    }
}
