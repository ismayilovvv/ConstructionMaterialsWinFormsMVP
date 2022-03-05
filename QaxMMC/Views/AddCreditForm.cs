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
    public partial class AddCreditForm : Form, IAddCreditView
    {
        public AddCreditForm()
        {
            InitializeComponent();
        }

        public event EventHandler<CreEventArgs> addCreditEvent;
        public event EventHandler<EventArgs> loadCreditEvent;

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void addCMbtn_Click(object sender, EventArgs e)
        {
            Credit credit = new Credit();
            credit.sale = new Sale();
            switch (cmComboBox.SelectedIndex)
            {
                case 0:
                    {
                        credit.sale.Ad = "Taxta";
                        credit.sale.En = (float)taxtaEnNumericUpDown.Value;
                        credit.sale.Hundurluk = (float)taxtaHundurlukNumericUpDown.Value;
                        credit.sale.Uzunluq = (float)taxtaUzunluqNumericUpDown.Value;
                        credit.sale.Miqdar = (int)taxtaMiqdarNumericUpDown.Value;
                        credit.sale.Kub = (float)taxtaKubNumericUpDown.Value;
                    }
                    break;
                case 1:
                    {
                        credit.sale.Ad = "Pol";
                        credit.sale.En = (float)polEnNumericUpDown.Value;
                        credit.sale.Uzunluq = (float)polUzunluqNumericUpDown.Value;
                        credit.sale.Miqdar = (int)polMiqdarNumericUpDown.Value;
                        credit.sale.Kvadrat = (float)polKvadratNumericUpDown.Value;
                    }
                    break;
                case 2:
                    {
                        credit.sale.Ad = "Brus";
                        credit.sale.Miqdar = (int)brusMiqdarNumericUpDown.Value;
                        if (agRadioButton.Checked)
                        { credit.sale.Nov = "Ağ"; }
                        else
                        {
                            credit.sale.Nov = "Qara";
                        }
                    }
                    break;
                case 3:
                    {
                        credit.sale.Ad = "Obşivka";
                        credit.sale.En = (float)obshivkaEnNumericUpDown.Value;
                        credit.sale.Uzunluq = (float)obshivkaUzunluqNumericUpDown.Value;
                        credit.sale.Miqdar = (int)obshivkaMiqdarNumericUpDown.Value;
                        credit.sale.Kvadrat = (float)obshivkaKvadratNumericUpDown.Value;

                    }
                    break;
                case 4:
                    {
                        credit.sale.Ad = "Abloşka";
                        credit.sale.Miqdar = (int)abloshkaMiqdarNumericUpDown.Value;
                        if (boyukRadioButton.Checked)
                        { credit.sale.Nov = "Böyük"; }
                        else
                        {
                            credit.sale.Nov = "Balaca";
                        }
                    }
                    break;
                case 5:
                    {
                        credit.sale.Ad = "Dikt";
                        credit.sale.Nomre = (short)diktNomreNumericUpDown.Value;
                        credit.sale.Kub = (float)diktKubNumericUpDown.Value;
                    }
                    break;
                case 6:
                    {
                        credit.sale.Ad = "DVP";
                        credit.sale.Miqdar = (int)dvpMiqdarNumericUpDown.Value;

                    }
                    break;
                case 7:
                    {
                        credit.sale.Ad = "Şifer";
                        credit.sale.Miqdar = (int)shiferMiqdarNumericUpDown.Value;
                    }
                    break;
                case 8:
                    {
                        credit.sale.Ad = "Plintus";
                        credit.sale.Uzunluq = (float)plintusUzunluqNumericUpDown.Value;
                    }
                    break;
                default:
                    break;
            }
            credit.Id = new Random().Next(1, 99999);
            credit.sale.sum = (float)sumNumericUpDown.Value;
            credit.sale.saleDate = creditDateTimePicker.Value;
            credit.customer = new Customer();
            string[] customerList = Convert.ToString(customerComboBox.SelectedItem).Split(' ');
            credit.customer.Id = Int32.Parse(customerList.First());
            addCreditEvent?.Invoke(this, new CreEventArgs() { credit = credit });
            this.Close();
        }

        private void AddCreditForm_Load(object sender, EventArgs e)
        {
            loadCreditEvent?.Invoke(this, new EventArgs());
        }

        private void cmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmComboBox.SelectedIndex != -1)
            {
                switch (cmComboBox.SelectedIndex)
                {
                    case 0:
                        {
                            taxtaGroupBox.Enabled = true;
                            polGroupBox.Enabled = false;
                            brusGroupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0 && customerComboBox.SelectedIndex != -1)
                            {
                                addCreditBtn.Enabled = true;
                            }
                            else
                            {
                                addCreditBtn.Enabled = false;
                            }

                        }
                        break;
                    case 1:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = true;
                            brusGroupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0 && customerComboBox.SelectedIndex != -1)
                            {
                                addCreditBtn.Enabled = true;
                            }
                            else
                            {
                                addCreditBtn.Enabled = false;
                            }

                        }
                        break;
                    case 2:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGroupBox.Enabled = true;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0 && customerComboBox.SelectedIndex != -1)
                            {
                                addCreditBtn.Enabled = true;
                            }
                            else
                            {
                                addCreditBtn.Enabled = false;
                            }

                        }
                        break;
                    case 3:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGroupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = true;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0 && customerComboBox.SelectedIndex != -1)
                            {
                                addCreditBtn.Enabled = true;
                            }
                            else
                            {
                                addCreditBtn.Enabled = false;
                            }

                        }
                        break;
                    case 4:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGroupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = true;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0 && customerComboBox.SelectedIndex != -1)
                            {
                                addCreditBtn.Enabled = true;
                            }
                            else
                            {
                                addCreditBtn.Enabled = false;
                            }

                        }
                        break;
                    case 5:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGroupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = true;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0 && customerComboBox.SelectedIndex != -1)
                            {
                                addCreditBtn.Enabled = true;
                            }
                            else
                            {
                                addCreditBtn.Enabled = false;
                            }

                        }
                        break;
                    case 6:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGroupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = true;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0 && customerComboBox.SelectedIndex != -1)
                            {
                                addCreditBtn.Enabled = true;
                            }
                            else
                            {
                                addCreditBtn.Enabled = false;
                            }

                        }
                        break;
                    case 7:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGroupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = true;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0 && customerComboBox.SelectedIndex != -1)
                            {
                                addCreditBtn.Enabled = true;
                            }
                            else
                            {
                                addCreditBtn.Enabled = false;
                            }

                        }
                        break;
                    case 8:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGroupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = true;
                            if (sumNumericUpDown.Value != 0 && customerComboBox.SelectedIndex != -1)
                            {
                                addCreditBtn.Enabled = true;
                            }
                            else
                            {
                                addCreditBtn.Enabled = false;
                            }

                        }
                        break;
                    default:
                        break;
                }
            }

        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmComboBox.SelectedIndex != -1 && sumNumericUpDown.Value != 0)
            {
                addCreditBtn.Enabled = true; 
            }
            else
            {
                addCreditBtn.Enabled = false;
            }
        }

        private void sumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (cmComboBox.SelectedIndex != -1 && customerComboBox.SelectedIndex != -1 && sumNumericUpDown.Value != 0)
            {
                addCreditBtn.Enabled = true;
            }
            else
            {
                addCreditBtn.Enabled = false;
            }
        }

        public void loadForm(List<Customer> customers)
        {
            cmComboBox.Items.Add("Taxta");
            cmComboBox.Items.Add("Pol");
            cmComboBox.Items.Add("Brus");
            cmComboBox.Items.Add("Obşivka");
            cmComboBox.Items.Add("Abloşka");
            cmComboBox.Items.Add("Dikt");
            cmComboBox.Items.Add("DVP");
            cmComboBox.Items.Add("Şifer");
            cmComboBox.Items.Add("Plintus");

            foreach (var customer in customers)
            {
                if (customer.Company == string.Empty)
                {
                    customerComboBox.Items.Add(customer.Id.ToString() + ' ' + customer.Name + ' ' + customer.Surname + ' ' + customer.Lastname);
                }
                else
                {
                    customerComboBox.Items.Add(customer.Id.ToString() + ' ' + customer.Company);
                }
            }
        }
    }
}
