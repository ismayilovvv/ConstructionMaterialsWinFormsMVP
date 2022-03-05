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
    public partial class EditCustomerForm : Form, IEditCustomerView
    {
        public EditCustomerForm()
        {
            InitializeComponent();
        }

        public event EventHandler<CEventArgs> updateC;
        public event EventHandler<EventArgs> loadC;

        public void LoadCus(Customer customer)
        {
            nameTB.Text = customer.Name;
            surnameTB.Text = customer.Surname;
            lastnameTB.Text = customer.Lastname;
            if (customer.Company != null && customer.Company != string.Empty)
            {
                birthdateDTP.Value = DateTime.Now;
            }
            else
            {
                birthdateDTP.Value = customer.Birthdate;
            }
            birthplaceTB.Text = customer.BornAddress;
            livingaddressTB.Text = customer.RegisterAddress;
            serianumberTB.Text = customer.PassportSeriaNumber;
            fincodeTB.Text = customer.PassportFIN;
            phone1TB.Text = customer.Phone1;
            phone2TB.Text = customer.Phone2;
            companynameTB.Text = customer.Company;
            companyaddressTB.Text = customer.CompanyAddress;
            bankTB.Text = customer.Bank;
            accountnumberTB.Text = customer.AccountNumber;
            accountTB.Text = customer.Account;
            voenTB.Text = customer.VOEN;
            codeTB.Text = customer.Code;
            swiftTB.Text = customer.Swift;
        }

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void EditCustomerForm_Load(object sender, EventArgs e)
        {
            loadC?.Invoke(this, new EventArgs());
        }

        private void nameTB_TextChanged(object sender, EventArgs e)
        {
            if (phone1TB.Text != null && phone1TB.Text != string.Empty)
            {
                if (nameTB.Text != null && nameTB.Text != string.Empty &&
                surnameTB.Text != null && surnameTB.Text != string.Empty &&
                lastnameTB.Text != null && lastnameTB.Text != string.Empty)
                {
                    updateBtn.Enabled = true;
                }
                else if (companynameTB.Text != null && companynameTB.Text != string.Empty)
                {
                    updateBtn.Enabled = true;
                }
                else
                {
                    updateBtn.Enabled = false;
                }
            }
            else
            {
                updateBtn.Enabled = false;
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
                    updateBtn.Enabled = true;
                }
                else if (companynameTB.Text != null && companynameTB.Text != string.Empty)
                {
                    updateBtn.Enabled = true;
                }
                else
                {
                    updateBtn.Enabled = false;
                }
            }
            else
            {
                updateBtn.Enabled = false;
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
                    updateBtn.Enabled = true;
                }
                else if (companynameTB.Text != null && companynameTB.Text != string.Empty)
                {
                    updateBtn.Enabled = true;
                }
                else
                {
                    updateBtn.Enabled = false;
                }
            }
            else
            {
                updateBtn.Enabled = false;
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
                    updateBtn.Enabled = true;
                }
                else if (companynameTB.Text != null && companynameTB.Text != string.Empty)
                {
                    updateBtn.Enabled = true;
                }
                else
                {
                    updateBtn.Enabled = false;
                }
            }
            else
            {
                updateBtn.Enabled = false;
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
                    updateBtn.Enabled = true;
                }
                else if (companynameTB.Text != null && companynameTB.Text != string.Empty)
                {
                    updateBtn.Enabled = true;
                }
                else
                {
                    updateBtn.Enabled = false;
                }
            }
            else
            {
                updateBtn.Enabled = false;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
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

            updateC?.Invoke(this, new CEventArgs() { customer = customer });
            this.Close();
        }
    }
}
