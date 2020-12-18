using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class frmMain : Form
    {
        MainDal _mainDal = new MainDal();
        int _employeeId;
        public frmMain(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
        }

        #region Variables

        string BookTypeName = "";
        string BookAuthorFullName = "";

        #endregion

        #region FillDataGridViews

        public void FillDgv()
        {
            dgvMainGiveBooks.DataSource = _mainDal.FillCurrentBooks();
            dgvMainTakeBooks.DataSource = _mainDal.FillTemporaryGivenBooks();
            dgvMainBooks.DataSource = _mainDal.FillBooks();
            dgvMainEmployees.DataSource = _mainDal.FillEmployees();
            dgvMainAuthors.DataSource = _mainDal.FillAuthors();

        }

        #endregion

        #region FormLoad

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Author Full Name
            List<string> authorList = _mainDal.cbxFillAuthors();
            foreach (var item in authorList)
            {
                cbxMainBooksAuthorFullName.Items.Add(item);
            }
            //Book Type
            List<BookType> bookTypeList = _mainDal.cbxFillBookType();
            foreach (var item in bookTypeList)
            {
                cbxMainBooksBookType.Items.Add(item.BookTypeName);
            }
            // TODO: This line of code loads data into the 'libraryManagementDBDataSet.BookTypes' table. You can move, or remove it, as needed.
            this.bookTypesTableAdapter.Fill(this.libraryManagementDBDataSet.BookTypes);
            FillDgv();
        }

        #endregion

        #region GiveBook

        private void btnMainCustomersGiveBook_Click(object sender, EventArgs e)
        {
            _mainDal.CustomerAdd(new Customers
            {
                CustomerFirstName = tbxMainCustomerFirstName.Text,
                CustomerLastName = tbxMainCustomerLastName.Text,
                CustomerCity = tbxMainCustomerCity.Text,
                CustomerAdress = tbxMainCustomerAdress.Text,
                CustomerPhoneNumber = Convert.ToInt32(tbxMainCustomerPhoneNumber.Text)
            });

            _mainDal.GiveBook(new TemporaryGivenBooks
            {
                BookId = Convert.ToInt32(dgvMainGiveBooks.CurrentRow.Cells[1].Value),
                BookName = dgvMainGiveBooks.CurrentRow.Cells[2].Value.ToString(),
                CustomerId = _mainDal.GetCustomerByPhone(Convert.ToInt32(tbxMainCustomerPhoneNumber.Text)).CustomerId,
                CustomerFirstName = tbxMainCustomerFirstName.Text,
                CustomerLastName = tbxMainCustomerLastName.Text,
                EmployeeId = _employeeId,
                EmployeeFirstName = _mainDal.FillEmployees().FirstOrDefault(x => x.EmployeeId == _employeeId).EmployeeFirstName,
                EmployeeLastName = _mainDal.FillEmployees().FirstOrDefault(x => x.EmployeeId == _employeeId).EmployeeLastName,
                TakeDate = DateTime.Now,
                GiveBackDate = DateTime.Now.AddDays(7)
            });
            var currentBook = _mainDal.FillCurrentBooks().FirstOrDefault(x => x.BookId == Convert.ToInt32(dgvMainGiveBooks.CurrentRow.Cells[1].Value));
            _mainDal.DeleteCurrentBooks(currentBook);

            FillDgv();
            lblMainResultCustomerId.Text = _mainDal.GetCustomerByPhone(Convert.ToInt32(tbxMainCustomerPhoneNumber.Text)).CustomerId.ToString();
            lblMainResultCustomerFirstName.Text = tbxMainCustomerFirstName.Text;
            lblMainResultCustomerLastName.Text = tbxMainCustomerLastName.Text;
            lblMainResultBook.Text = tbxMainCustomerFindBook.Text;
            lblMainResultEndDate.Text = DateTime.Now.AddDays(7).ToString();
            gbxMainGiveBookResult.BackColor = Color.Green;
        }
        private void btnMainCustomersClear_Click(object sender, EventArgs e)
        {
            tbxMainCustomerFirstName.Clear();
            tbxMainCustomerLastName.Clear();
            tbxMainCustomerCity.Clear();
            tbxMainCustomerAdress.Clear();
            tbxMainCustomerPhoneNumber.Clear();
            tbxMainCustomerFindBook.Clear();
            gbxMainGiveBookResult.BackColor = Color.Transparent;
        }
        private void dgwMainGiveBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxMainCustomerFindBook.Text = dgvMainGiveBooks.CurrentRow.Cells[2].Value.ToString();
        }

        #endregion

        #region TakeBackBook

        private void btnMainTakeBack_Click(object sender, EventArgs e)
        {
            var temporaryGivenBook = _mainDal.FillTemporaryGivenBooks()
                .FirstOrDefault(x => x.BookName == tbxMainTakeFindBookName.Text);

            _mainDal.CurrentBookAdd(new CurrentBooks
            {
                BookId = temporaryGivenBook.BookId,
                BookName = temporaryGivenBook.BookName
            });

            var temporaryBook = _mainDal.FillTemporaryGivenBooks()
                .FirstOrDefault(x => x.BookName == tbxMainTakeFindBookName.Text && x.CustomerFirstName == tbxMainTakeFindFirstName.Text && x.CustomerLastName == tbxMainTakeFindLastName.Text);
            _mainDal.TemporaryGivenBookDelete(temporaryBook);

            FillDgv();
            lblMainResultTakeId.Text = _mainDal.FillTemporaryGivenBooks()
                .FirstOrDefault(x => x.CustomerId == Convert.ToInt32(dgvMainTakeBooks.CurrentRow.Cells[3].Value)).CustomerId.ToString();
            lblMainResultTakeFirstName.Text = tbxMainTakeFindFirstName.Text;
            lblMainResultTakeLastName.Text = tbxMainTakeFindLastName.Text;
            lblMainResultTakeBook.Text = tbxMainTakeFindBookName.Text;
            gbxMainTakeBookResult.BackColor = Color.Green;
        }
        private void btnMainTakeBackClear_Click(object sender, EventArgs e)
        {
            tbxMainTakeFindBookName.Clear();
            tbxMainTakeFindFirstName.Clear();
            tbxMainTakeFindLastName.Clear();
            gbxMainTakeBookResult.BackColor = Color.Transparent;
        }
        private void dgvMainTakeBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxMainTakeFindFirstName.Text = dgvMainTakeBooks.CurrentRow.Cells[4].Value.ToString();
            tbxMainTakeFindLastName.Text = dgvMainTakeBooks.CurrentRow.Cells[5].Value.ToString();
            tbxMainTakeFindBookName.Text = dgvMainTakeBooks.CurrentRow.Cells[2].Value.ToString();
        }
        private void SearchBookName(string key)
        {
            var result = _mainDal.GetBookName(key);
            dgvMainTakeBooks.DataSource = result;
        }
        private void SearchFirstName(string key)
        {
            var result = _mainDal.GetFirstName(key);
            dgvMainTakeBooks.DataSource = result;
        }
        private void SearchLastName(string key)
        {
            var result = _mainDal.GetLastName(key);
            dgvMainTakeBooks.DataSource = result;
        }
        private void tbxMainTakeFindBookName_TextChanged(object sender, EventArgs e)
        {
            SearchBookName(tbxMainTakeFindBookName.Text);
        }
        private void tbxMainTakeFindFirstName_TextChanged(object sender, EventArgs e)
        {
            SearchFirstName(tbxMainTakeFindFirstName.Text);
        }
        private void tbxMainTakeFindLastName_TextChanged(object sender, EventArgs e)
        {
            SearchLastName(tbxMainTakeFindLastName.Text);
        }

        #endregion

        #region Books

        private void btnMainBooksAdd_Click(object sender, EventArgs e)
        {
            _mainDal.BookAdd(new Books
            {
                BookName = tbxMainBooksBookName.Text,
                BookTypeId = _mainDal.cbxFillBookType().FirstOrDefault(x => x.BookTypeName == BookTypeName).BookTypeId,
                BookTypeName = cbxMainBooksBookType.Text,
                BookAuthorId = _mainDal.FillAuthors().FirstOrDefault(x => x.AuthorFirstName + " " + x.AuthorLastName == BookAuthorFullName).BookAuthorId,
                BookAuthorFullName = cbxMainBooksAuthorFullName.Text
            });
            _mainDal.CurrentBookAdd(new CurrentBooks
            {
                BookId = _mainDal.FillBooks().FirstOrDefault(x => x.BookName == tbxMainBooksBookName.Text).BookId,
                BookName = tbxMainBooksBookName.Text
            });

            FillDgv();
            gbxMainBooksResult.BackColor = Color.Green;
        }
        private void btnMainBooksUpdate_Click(object sender, EventArgs e)
        {
            CurrentBooks currentBook = _mainDal.FillCurrentBooks().FirstOrDefault(x => x.BookId == Convert.ToInt32(dgvMainBooks.CurrentRow.Cells[0].Value));

            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("This book is temporary given, are you sure you want to update it?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                _mainDal.BookUpdate(new Books
                {
                    BookId = Convert.ToInt32(dgvMainBooks.CurrentRow.Cells[0].Value),
                    BookName = tbxMainBooksBookName.Text,
                    BookTypeId = _mainDal.cbxFillBookType().FirstOrDefault(x => x.BookTypeName == BookTypeName)
                        .BookTypeId,
                    BookTypeName = cbxMainBooksBookType.Text,
                    BookAuthorId = _mainDal.FillAuthors()
                        .FirstOrDefault(x => x.AuthorFirstName + " " + x.AuthorLastName == BookAuthorFullName)
                        .BookAuthorId,
                    BookAuthorFullName = cbxMainBooksAuthorFullName.Text
                });
                if (currentBook != null)
                {
                    _mainDal.CurrentBookUpdate(new CurrentBooks
                    {
                        CurrentBookId = _mainDal.FillCurrentBooks().FirstOrDefault(x => x.BookId == currentBook.BookId)
                            .CurrentBookId,
                        BookId = Convert.ToInt32(dgvMainBooks.CurrentRow.Cells[0].Value),
                        BookName = tbxMainBooksBookName.Text
                    });
                }
                else
                {
                    var givenBook = _mainDal.FillTemporaryGivenBooks().FirstOrDefault(x =>
                        x.BookId == Convert.ToInt32(dgvMainBooks.CurrentRow.Cells[0].Value));
                    _mainDal.TemporaryGivenBookUpdate(new TemporaryGivenBooks
                    {
                        TemporaryGivenBookId = givenBook.TemporaryGivenBookId,
                        BookId = Convert.ToInt32(dgvMainBooks.CurrentRow.Cells[0].Value),
                        BookName = tbxMainBooksBookName.Text,
                        CustomerFirstName = givenBook.CustomerFirstName,
                        CustomerLastName = givenBook.CustomerLastName,
                        EmployeeFirstName = givenBook.EmployeeFirstName,
                        EmployeeLastName = givenBook.EmployeeLastName,
                        CustomerId = givenBook.CustomerId,
                        EmployeeId = givenBook.EmployeeId,
                        GiveBackDate = givenBook.GiveBackDate,
                        TakeDate = givenBook.TakeDate
                    });
                }
                gbxMainBooksResult.BackColor = Color.Green;
            }
            else
            {
                gbxMainBooksResult.BackColor = Color.Red;
            }
            FillDgv();
        }
        private void btnMainBooksDelete_Click(object sender, EventArgs e)
        {
            CurrentBooks currentBook = _mainDal.FillCurrentBooks().FirstOrDefault(x => x.BookId == Convert.ToInt32(dgvMainBooks.CurrentRow.Cells[0].Value));

            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("This book is temporary given, are you sure you want to delete it?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {

                if (currentBook != null)
                {
                    _mainDal.CurrentBookDelete(new CurrentBooks
                    {
                        CurrentBookId = _mainDal.FillCurrentBooks().FirstOrDefault(x => x.BookId == currentBook.BookId)
                            .CurrentBookId,
                    });
                }
                else
                {
                    _mainDal.TemporaryGivenBookDelete(new TemporaryGivenBooks
                    {
                        TemporaryGivenBookId = Convert.ToInt32(dgvMainTakeBooks.CurrentRow.Cells[0].Value)
                    });
                }

                _mainDal.BookDelete(new Books
                {
                    BookId = Convert.ToInt32(dgvMainBooks.CurrentRow.Cells[0].Value)
                });
                gbxMainBooksResult.BackColor = Color.Green;
            }
            else
            {
                gbxMainBooksResult.BackColor = Color.Red;
            }
            FillDgv();
        }
        private void btnMainBooksClear_Click(object sender, EventArgs e)
        {
            tbxMainBooksBookName.Clear();
            cbxMainBooksBookType.ResetText();
            cbxMainBooksAuthorFullName.ResetText();
            gbxMainBooksResult.BackColor = Color.Transparent;
        }
        private void dgvMainBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxMainBooksBookName.Text = dgvMainBooks.CurrentRow.Cells[1].Value.ToString();
            cbxMainBooksBookType.SelectedItem = dgvMainBooks.CurrentRow.Cells[3].Value.ToString();
            cbxMainBooksAuthorFullName.SelectedItem = dgvMainBooks.CurrentRow.Cells[5].Value.ToString();
        }

        #endregion

        #region Employees

        private void btnMainEmployeesAdd_Click(object sender, EventArgs e)
        {
            _mainDal.EmployeeAdd(new Employees
            {
                EmployeeFirstName = tbxMainEmployeesFirstName.Text,
                EmployeeLastName = tbxMainEmployeesLastName.Text,
                EmployeeCity = tbxMainEmployeesCity.Text,
                EmployeePhoneNumber = Convert.ToInt32(tbxMainEmployeesPhoneNumber.Text),
                EmployeeLoginUserName = tbxMainEmployeesUserName.Text,
                EmployeeLoginPassword = tbxMainEmployeesPassword.Text
            });

            FillDgv();
            lblMainResultEmployeesId.Text = _mainDal.FillEmployees().FirstOrDefault(x => x.EmployeeId == Convert.ToInt32(dgvMainEmployees.CurrentRow.Cells[0].Value)).EmployeeId.ToString();
            lblMainResultEmployeesFirstName.Text = tbxMainEmployeesFirstName.Text;
            lblMainResultEmployeesLastName.Text = tbxMainEmployeesLastName.Text;
            lblMainResultEmployeesUserName.Text = tbxMainEmployeesUserName.Text;
            gbxMainEmployeesResult.BackColor = Color.Green;
        }
        private void btnMainEmployeesUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Are you sure you want to update it?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                var TemporaryGivenBookList = _mainDal.FillTemporaryGivenBooks().Where(x =>
                    x.EmployeeId == Convert.ToInt32(dgvMainEmployees.CurrentRow.Cells[0].Value));

                foreach (var item in TemporaryGivenBookList)
                {
                    item.EmployeeFirstName = tbxMainEmployeesFirstName.Text;
                    item.EmployeeLastName = tbxMainEmployeesLastName.Text;
                    _mainDal.TemporaryGivenBookUpdate(item);
                }

                _mainDal.EmployeeUpdate(new Employees
                {
                    EmployeeId = Convert.ToInt32(dgvMainEmployees.CurrentRow.Cells[0].Value.ToString()),
                    EmployeeFirstName = tbxMainEmployeesFirstName.Text,
                    EmployeeLastName = tbxMainEmployeesLastName.Text,
                    EmployeeCity = tbxMainEmployeesCity.Text,
                    EmployeePhoneNumber = Convert.ToInt32(tbxMainEmployeesPhoneNumber.Text),
                    EmployeeLoginUserName = tbxMainEmployeesUserName.Text,
                    EmployeeLoginPassword = tbxMainEmployeesPassword.Text
                });

                FillDgv();
                lblMainResultEmployeesId.Text = _mainDal.FillEmployees().FirstOrDefault(x => x.EmployeeId == Convert.ToInt32(dgvMainEmployees.CurrentRow.Cells[0].Value)).EmployeeId.ToString();
                lblMainResultEmployeesFirstName.Text = tbxMainEmployeesFirstName.Text;
                lblMainResultEmployeesLastName.Text = tbxMainEmployeesLastName.Text;
                lblMainResultEmployeesUserName.Text = tbxMainEmployeesUserName.Text;
                gbxMainEmployeesResult.BackColor = Color.Green;
            }
            else
            {
                gbxMainEmployeesResult.BackColor = Color.Red;
            }
            FillDgv();
        }
        private void btnMainEmployeesDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Are you sure you want to delete it?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                _mainDal.EmployeeDelete(new Employees
                {
                    EmployeeId = Convert.ToInt32(dgvMainEmployees.CurrentRow.Cells[0].Value.ToString())
                });

                lblMainResultEmployeesId.Text = _mainDal.FillEmployees().FirstOrDefault(x => x.EmployeeId == Convert.ToInt32(dgvMainEmployees.CurrentRow.Cells[0].Value)).EmployeeId.ToString();
                lblMainResultEmployeesFirstName.Text = tbxMainEmployeesFirstName.Text;
                lblMainResultEmployeesLastName.Text = tbxMainEmployeesLastName.Text;
                lblMainResultEmployeesUserName.Text = tbxMainEmployeesUserName.Text;
                gbxMainEmployeesResult.BackColor = Color.Green;
            }
            else
            {
                gbxMainEmployeesResult.BackColor = Color.Red;
            }
            FillDgv();
        }
        private void btnMainEmployeedClear_Click(object sender, EventArgs e)
        {
            tbxMainEmployeesCity.Clear();
            tbxMainEmployeesFirstName.Clear();
            tbxMainEmployeesLastName.Clear();
            tbxMainEmployeesPassword.Clear();
            tbxMainEmployeesPhoneNumber.Clear();
            tbxMainEmployeesUserName.Clear();
            gbxMainEmployeesResult.BackColor = Color.Transparent;
        }
        private void dgvMainEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxMainEmployeesFirstName.Text = dgvMainEmployees.CurrentRow.Cells[1].Value.ToString();
            tbxMainEmployeesLastName.Text = dgvMainEmployees.CurrentRow.Cells[2].Value.ToString();
            tbxMainEmployeesCity.Text = dgvMainEmployees.CurrentRow.Cells[3].Value.ToString();
            tbxMainEmployeesPhoneNumber.Text = dgvMainEmployees.CurrentRow.Cells[4].Value.ToString();
            tbxMainEmployeesUserName.Text = dgvMainEmployees.CurrentRow.Cells[6].Value.ToString();
            tbxMainEmployeesPassword.Text = dgvMainEmployees.CurrentRow.Cells[7].Value.ToString();
        }

        #endregion

        #region Authors

        private void btnMainAuthorsAdd_Click(object sender, EventArgs e)
        {
            _mainDal.AuthorAdd(new Authors
            {
                AuthorFirstName = tbxMainAuthorsFirstName.Text,
                AuthorLastName = tbxMainAuthorsLastName.Text
            });

            FillDgv();
            lblMainResultAuthorsId.Text = _mainDal.FillAuthors().FirstOrDefault(x => x.BookAuthorId == Convert.ToInt32(dgvMainAuthors.CurrentRow.Cells[0].Value)).BookAuthorId.ToString();
            lblMainResultAuthorsFirstName.Text = tbxMainAuthorsFirstName.Text;
            lblMainResultAuthorsLastName.Text = tbxMainAuthorsLastName.Text;
            gbxMainAuthorsResult.BackColor = Color.Green;
        }
        private void btnMainAuthorsUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Are you sure you want to update it?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                var BookList = _mainDal.FillBooks().Where(x =>
                    x.BookAuthorId == Convert.ToInt32(dgvMainAuthors.CurrentRow.Cells[0].Value));

                foreach (var book in BookList)
                {
                    book.BookAuthorFullName = tbxMainAuthorsFirstName.Text+ " " + tbxMainAuthorsLastName.Text;
                    _mainDal.BookUpdate(book);
                }

                _mainDal.AuthorUpdate(new Authors
                {
                    BookAuthorId = Convert.ToInt32(dgvMainAuthors.CurrentRow.Cells[0].Value.ToString()),
                    AuthorFirstName = tbxMainAuthorsFirstName.Text,
                    AuthorLastName = tbxMainAuthorsLastName.Text
                });

                lblMainResultAuthorsId.Text = _mainDal.FillAuthors().FirstOrDefault(x => x.BookAuthorId == Convert.ToInt32(dgvMainAuthors.CurrentRow.Cells[0].Value)).BookAuthorId.ToString();
                lblMainResultAuthorsFirstName.Text = tbxMainAuthorsFirstName.Text;
                lblMainResultAuthorsLastName.Text = tbxMainAuthorsLastName.Text;
                gbxMainAuthorsResult.BackColor = Color.Green;
            }
            else
            {
                gbxMainAuthorsResult.BackColor = Color.Red;
            }
            FillDgv();
        }
        private void btnMainAuthorsDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Are you sure you want to delete it?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                _mainDal.AuthorDelete(new Authors
                {
                    BookAuthorId = Convert.ToInt32(dgvMainAuthors.CurrentRow.Cells[0].Value.ToString())
                });

                lblMainResultAuthorsId.Text = _mainDal.FillAuthors().FirstOrDefault(x => x.BookAuthorId == Convert.ToInt32(dgvMainAuthors.CurrentRow.Cells[0].Value)).BookAuthorId.ToString();
                lblMainResultAuthorsFirstName.Text = tbxMainAuthorsFirstName.Text;
                lblMainResultAuthorsLastName.Text = tbxMainAuthorsLastName.Text;
                gbxMainAuthorsResult.BackColor = Color.Green;
            }
            else
            {
                gbxMainAuthorsResult.BackColor = Color.Red;
            }
            FillDgv();
        }
        private void btnMainAuthorsClear_Click(object sender, EventArgs e)
        {
            tbxMainAuthorsFirstName.Clear();
            tbxMainAuthorsLastName.Clear();
            gbxMainAuthorsResult.BackColor = Color.Transparent;
        }
        private void dgvMainAuthors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxMainAuthorsFirstName.Text = dgvMainAuthors.CurrentRow.Cells[1].Value.ToString();
            tbxMainAuthorsLastName.Text = dgvMainAuthors.CurrentRow.Cells[2].Value.ToString();
        }
        private void cbxMainBooksBookType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookTypeName = this.cbxMainBooksBookType.GetItemText(this.cbxMainBooksBookType.SelectedItem);
        }
        private void cbxMainBooksAuthorFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookAuthorFullName = this.cbxMainBooksAuthorFullName.GetItemText(this.cbxMainBooksAuthorFullName.SelectedItem);
        }

        #endregion
    }
}