using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public class LoginDal
    {
        public void loginMain()
        {
            //Check Username and Password
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        public bool CheckLogin(string employeeLoginUserName, string employeeLoginPassword)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var entity = context.Employees.FirstOrDefault(x => x.EmployeeLoginUserName == employeeLoginUserName && x.EmployeeLoginPassword == employeeLoginPassword);
                return entity==null?false:true;
            }
        }

        public int GetUserIdByUserName(string employeeLoginUserName)
        {
            using (LibraryManagementContext context = new LibraryManagementContext())
            {
                var user = context.Employees.FirstOrDefault(x => x.EmployeeLoginUserName == employeeLoginUserName);
                return user.EmployeeId;
            }
        }
    }
}