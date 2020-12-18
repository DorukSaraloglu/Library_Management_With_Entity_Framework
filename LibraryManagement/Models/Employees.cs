using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Employees
    {
        [Key]public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeCity { get; set; }
        public int EmployeePhoneNumber { get; set; }
        public int EmployeeLoginId { get; set; }
        public string EmployeeLoginUserName { get; set; }
        public string EmployeeLoginPassword { get; set; }
    }
}
