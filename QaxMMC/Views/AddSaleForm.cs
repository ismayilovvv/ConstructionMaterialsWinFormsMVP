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
    public partial class AddSaleForm : Form, IAddSaleView
    {
        public AddSaleForm()
        {
            InitializeComponent();
        }

        public event EventHandler<SEventArgs> addSaleEvent;

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void AddSaleForm_Load(object sender, EventArgs e)
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
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            switch (cmComboBox.SelectedIndex)
            {
                case 0:
                    {
                        sale.Ad = "Taxta";
                        sale.En = (float)taxtaEnNumericUpDown.Value;
                        sale.Hundurluk = (float)taxtaHundurlukNumericUpDown.Value;
                        sale.Uzunluq = (float)taxtaUzunluqNumericUpDown.Value;
                        sale.Miqdar = (int)taxtaMiqdarNumericUpDown.Value;
                        sale.Kub = (float)taxtaKubNumericUpDown.Value;
                    }
                    break;
                case 1:
                    {
                        sale.Ad = "Pol";
                        sale.En = (float)polEnNumericUpDown.Value;
                        sale.Uzunluq = (float)polUzunluqNumericUpDown.Value;
                        sale.Miqdar = (int)polMiqdarNumericUpDown.Value;
                        sale.Kvadrat = (float)polKvadratNumericUpDown.Value;
                    }
                    break;
                case 2:
                    {
                        sale.Ad = "Brus";
                        sale.Miqdar = (int)brusMiqdarNumericUpDown.Value;
                        if (agRadioButton.Checked)
                        { sale.Nov = "Ağ"; }
                        else
                        {
                            sale.Nov = "Qara";
                        }
                    }
                    break;
                case 3:
                    {
                        sale.Ad = "Obşivka";
                        sale.En = (float)obshivkaEnNumericUpDown.Value;
                        sale.Uzunluq = (float)obshivkaUzunluqNumericUpDown.Value;
                        sale.Miqdar = (int)obshivkaMiqdarNumericUpDown.Value;
                        sale.Kvadrat = (float)obshivkaKvadratNumericUpDown.Value;

                    }
                    break;
                case 4:
                    {
                        sale.Ad = "Abloşka";
                        sale.Miqdar = (int)abloshkaMiqdarNumericUpDown.Value;
                        if (boyukRadioButton.Checked)
                        { sale.Nov = "Böyük"; }
                        else
                        {
                            sale.Nov = "Balaca";
                        }
                    }
                    break;
                case 5:
                    {
                        sale.Ad = "Dikt";
                        sale.Nomre = (short)diktNomreNumericUpDown.Value;
                        sale.Kub = (float)diktKubNumericUpDown.Value;
                    }
                    break;
                case 6:
                    {
                        sale.Ad = "DVP";
                        sale.Miqdar = (int)dvpMiqdarNumericUpDown.Value;

                    }
                    break;
                case 7:
                    {
                        sale.Ad = "Şifer";
                        sale.Miqdar = (int)shiferMiqdarNumericUpDown.Value;
                    }
                    break;
                case 8:
                    {
                        sale.Ad = "Plintus";
                        sale.Uzunluq = (float)plintusUzunluqNumericUpDown.Value;
                    }
                    break;
                default:
                    break;
            }
            sale.Id = new Random().Next(1, 9999);
            sale.Id = new Random().Next(1, 9999);
            sale.sum = (float)sumNumericUpDown.Value;
            sale.saleDate = saleDateTimePicker.Value;
            addSaleEvent?.Invoke(this, new SEventArgs() { sale = sale });
            this.Close();

        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if (sumNumericUpDown.Value != 0 && cmComboBox.SelectedIndex != -1)
            {
                addSaleBtn.Enabled = true;
            }
            else
            {
                addSaleBtn.Enabled = false;
            }
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
                            if (sumNumericUpDown.Value != 0)
                            {
                                addSaleBtn.Enabled = true;
                            }
                            else
                            {
                                addSaleBtn.Enabled = false;
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
                            if (sumNumericUpDown.Value != 0)
                            {
                                addSaleBtn.Enabled = true;
                            }
                            else
                            {
                                addSaleBtn.Enabled = false;
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
                            if (sumNumericUpDown.Value != 0)
                            {
                                addSaleBtn.Enabled = true;
                            }
                            else
                            {
                                addSaleBtn.Enabled = false;
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
                            if (sumNumericUpDown.Value != 0)
                            {
                                addSaleBtn.Enabled = true;
                            }
                            else
                            {
                                addSaleBtn.Enabled = false;
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
                            if (sumNumericUpDown.Value != 0)
                            {
                                addSaleBtn.Enabled = true;
                            }
                            else
                            {
                                addSaleBtn.Enabled = false;
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
                            if (sumNumericUpDown.Value != 0)
                            {
                                addSaleBtn.Enabled = true;
                            }
                            else
                            {
                                addSaleBtn.Enabled = false;
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
                            if (sumNumericUpDown.Value != 0)
                            {
                                addSaleBtn.Enabled = true;
                            }
                            else
                            {
                                addSaleBtn.Enabled = false;
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
                            if (sumNumericUpDown.Value != 0)
                            {
                                addSaleBtn.Enabled = true;
                            }
                            else
                            {
                                addSaleBtn.Enabled = false;
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
                            if (sumNumericUpDown.Value != 0)
                            {
                                addSaleBtn.Enabled = true;
                            }
                            else
                            {
                                addSaleBtn.Enabled = false;
                            }

                        }
                            break;
                        default:
                            break;
                    }
                }

            }
    }
}
