using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QaxMMC.Views
{
    public partial class CustomersForm : Form, ICustomersView
    {
        public CustomersForm()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> OpenAddCustomerWindow;
        public event EventHandler<idEventArgs> EditCustomer;
        public event EventHandler<idEventArgs> DeleteCustomer;
        public event EventHandler<EventArgs> LoadCustomersEvent;

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            OpenAddCustomerWindow?.Invoke(this, new EventArgs());
        }

        public void ReloadCustomers(List<Customer> customers)
        {
            cusDataGridView.Rows.Clear();
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(cusDataGridView);
                    row.Cells[0].Value = customer.Id;
                    row.Cells[1].Value = customer.Name;
                    row.Cells[2].Value = customer.Surname;
                    row.Cells[3].Value = customer.Lastname;
                    row.Cells[4].Value = customer.Birthdate.ToShortDateString();
                    row.Cells[5].Value = customer.BornAddress;
                    row.Cells[6].Value = customer.RegisterAddress;
                    row.Cells[7].Value = customer.PassportSeriaNumber;
                    row.Cells[8].Value = customer.PassportFIN;
                    row.Cells[9].Value = customer.Company;
                    row.Cells[10].Value = customer.CompanyAddress;
                    row.Cells[11].Value = customer.Phone1;
                    row.Cells[12].Value = customer.Phone2;
                    row.Cells[13].Value = customer.VOEN;
                    row.Cells[14].Value = customer.Bank;
                    row.Cells[15].Value = customer.AccountNumber;
                    row.Cells[16].Value = customer.Account;
                    row.Cells[17].Value = customer.Code;
                    row.Cells[18].Value = customer.Swift;
                    row.Cells[19].Value = customer.CreatedDate.ToShortDateString();
                    row.Cells[20].Value = "Düzəliş etmək";
                    row.Cells[21].Value = "Silmək";
                    cusDataGridView.Rows.Add(row);
                }
            }
        }

        private void cusDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 20)
            {
                EditCustomer?.Invoke(this, new idEventArgs() { Id = Convert.ToInt32(cusDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()) });
            }
            else if (e.ColumnIndex == 21)
            {
                DeleteCustomer?.Invoke(this, new idEventArgs() { Id = Convert.ToInt32(cusDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()) });
            }
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            LoadCustomersEvent?.Invoke(this, new EventArgs());
        }
    }
}
