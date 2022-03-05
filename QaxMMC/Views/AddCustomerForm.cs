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
    public partial class AddCustomerForm : Form, IAddCustomerView
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        public event EventHandler<CEventArgs> addCustomer;

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void nameTB_TextChanged(object sender, EventArgs e)
        {
            if(phone1TB.Text != null && phone1TB.Text != string.Empty)
            {
                if (nameTB.Text != null && nameTB.Text != string.Empty &&
                surnameTB.Text != null && surnameTB.Text != string.Empty &&
                lastnameTB.Text != null && lastnameTB.Text != string.Empty)
                {
                    addBtn.Enabled = true;
                }
                else if(companynameTB.Text != null && companynameTB.Text != string.Empty)
                {
                    addBtn.Enabled = true;
                }
                else
                {
                    addBtn.Enabled = false;
                }
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void surnameTB_TextChanged(object sender, EventArgs e)
        {
            if (phone1TB.Text != null && phone1TB.Text != string.Empty)
            {
                if (nameTB.Text != null && nameTB.Text != string.Empty &&
                surnameTB.Text != null && surnameTB.Text != string.Empty &&
                lastnameTB.Text != null && lastnameTB.Text != string.Empty)
                {
                    addBtn.Enabled = true;
                }
                else if (companynameTB.Text != null && companynameTB.Text != string.Empty)
                {
                    addBtn.Enabled = true;
                }
                else
                {
                    addBtn.Enabled = false;
                }
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void lastnameTB_TextChanged(object sender, EventArgs e)
        {
            if (phone1TB.Text != null && phone1TB.Text != string.Empty)
            {
                if (nameTB.Text != null && nameTB.Text != string.Empty &&
                surnameTB.Text != null && surnameTB.Text != string.Empty &&
                lastnameTB.Text != null && lastnameTB.Text != string.Empty)
                {
                    addBtn.Enabled = true;
                }
                else if (companynameTB.Text != null && companynameTB.Text != string.Empty)
                {
                    addBtn.Enabled = true;
                }
                else
                {
                    addBtn.Enabled = false;
                }
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void phone1TB_TextChanged(object sender, EventArgs e)
        {
            if (phone1TB.Text != null && phone1TB.Text != string.Empty)
            {
                if (nameTB.Text != null && nameTB.Text != string.Empty &&
                surnameTB.Text != null && surnameTB.Text != string.Empty &&
                lastnameTB.Text != null && lastnameTB.Text != string.Empty)
                {
                    addBtn.Enabled = true;
                }
                else if (companynameTB.Text != null && companynameTB.Text != string.Empty)
                {
                    addBtn.Enabled = true;
                }
                else
                {
                    addBtn.Enabled = false;
                }
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void companynameTB_TextChanged(object sender, EventArgs e)
        {
            if (phone1TB.Text != null && phone1TB.Text != string.Empty)
            {
                if (nameTB.Text != null && nameTB.Text != string.Empty &&
                surnameTB.Text != null && surnameTB.Text != string.Empty &&
                lastnameTB.Text != null && lastnameTB.Text != string.Empty)
                {
                    addBtn.Enabled = true;
                }
                else if (companynameTB.Text != null && companynameTB.Text != string.Empty)
                {
                    addBtn.Enabled = true;
                }
                else
                {
                    addBtn.Enabled = false;
                }
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Id = new Random().Next(1, 99999);
            customer.Name = nameTB.Text;
            customer.Surname = surnameTB.Text;
            customer.Lastname = lastnameTB.Text;
            customer.Birthdate = birthdateDTP.Value.Date;
            customer.BornAddress = birthplaceTB.Text;
            customer.RegisterAddress = livingaddressTB.Text;
            customer.PassportSeriaNumber = serianumberTB.Text;
            customer.PassportFIN = fincodeTB.Text;
            customer.Phone1 = phone1TB.Text;
            customer.Phone2 = phone2TB.Text;
            customer.Company = companynameTB.Text;
            customer.CompanyAddress = companyaddressTB.Text;
            customer.Bank = bankTB.Text;
            customer.AccountNumber = accountnumberTB.Text;
            customer.Account = accountTB.Text;
            customer.VOEN = voenTB.Text;
            customer.Code = codeTB.Text;
            customer.Swift = swiftTB.Text;
            customer.CreatedDate = DateTime.Today;
            addCustomer?.Invoke(this, new CEventArgs() { customer = customer });
            this.Close();
        }
    }
}
