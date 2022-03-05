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
    public partial class EditCreditForm : Form, IEditCreditView
    {
        public EditCreditForm()
        {
            InitializeComponent();
        }

        public event EventHandler<CreEventArgs> updateCredit;
        public event EventHandler<EventArgs> loadCredit;

        public void LoadCredit(Credit credit)
        {
            cmLabel.Text = credit.sale.Ad;
            customerLabel.Text = credit.customer.Name + ' ' + credit.customer.Surname + ' ' + credit.customer.Lastname;
            creditDateTimePicker.Value = credit.sale.saleDate;
            sumNumericUpDown.Value = (decimal)credit.sale.sum;
            switch (credit.sale.Ad)
            {
                case "Taxta":
                    {
                        cmLabel.Text = "Taxta";
                        taxtaEnNumericUpDown.Value = (decimal)credit.sale.En;
                        taxtaHundurlukNumericUpDown.Value = (decimal)credit.sale.Hundurluk;
                        taxtaKubNumericUpDown.Value = (decimal)credit.sale.Kub;
                        taxtaMiqdarNumericUpDown.Value = (decimal)credit.sale.Miqdar;
                        taxtaUzunluqNumericUpDown.Value = (decimal)credit.sale.Uzunluq;
                        taxtaGroupBox.Enabled = true;
                        polGroupBox.Enabled = false;
                        brusGroupBox.Enabled = false;
                        obshivkaGroupBox.Enabled = false;
                        abloshkaGroupBox.Enabled = false;
                        diktGroupBox.Enabled = false;
                        dvpGroupBox.Enabled = false;
                        shiferGroupBox.Enabled = false;
                        plintusGroupBox.Enabled = false;
                    }
                    break;
                case "Pol":
                    {
                        cmLabel.Text = "Pol";
                        polEnNumericUpDown.Value = (decimal)credit.sale.En;
                        polKvadratNumericUpDown.Value = (decimal)credit.sale.Kvadrat;
                        polMiqdarNumericUpDown.Value = (decimal)credit.sale.Miqdar;
                        polUzunluqNumericUpDown.Value = (decimal)credit.sale.Uzunluq;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = true;
                        brusGroupBox.Enabled = false;
                        obshivkaGroupBox.Enabled = false;
                        abloshkaGroupBox.Enabled = false;
                        diktGroupBox.Enabled = false;
                        dvpGroupBox.Enabled = false;
                        shiferGroupBox.Enabled = false;
                        plintusGroupBox.Enabled = false;
                    }
                    break;
                case "Brus":
                    {
                        cmLabel.Text = "Brus";
                        brusMiqdarNumericUpDown.Value = (decimal)credit.sale.Miqdar;
                        if (credit.sale.Nov == "Ağ")
                        {
                            agRadioButton.Checked = true;
                        }
                        else if (credit.sale.Nov == "Qara")
                        {
                            qaraRadioButton.Checked = true;
                        }
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGroupBox.Enabled = true;
                        obshivkaGroupBox.Enabled = false;
                        abloshkaGroupBox.Enabled = false;
                        diktGroupBox.Enabled = false;
                        dvpGroupBox.Enabled = false;
                        shiferGroupBox.Enabled = false;
                        plintusGroupBox.Enabled = false;
                    }
                    break;
                case "Obşivka":
                    {
                        cmLabel.Text = "Obşivka";
                        obshivkaEnNumericUpDown.Value = (decimal)credit.sale.En;
                        obshivkaKvadratNumericUpDown.Value = (decimal)credit.sale.Kvadrat;
                        obshivkaMiqdarNumericUpDown.Value = (decimal)credit.sale.Miqdar;
                        obshivkaUzunluqNumericUpDown.Value = (decimal)credit.sale.Uzunluq;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGroupBox.Enabled = false;
                        obshivkaGroupBox.Enabled = true;
                        abloshkaGroupBox.Enabled = false;
                        diktGroupBox.Enabled = false;
                        dvpGroupBox.Enabled = false;
                        shiferGroupBox.Enabled = false;
                        plintusGroupBox.Enabled = false;
                    }
                    break;
                case "Abloşka":
                    {
                        cmLabel.Text = "Abloşka";
                        abloshkaMiqdarNumericUpDown.Value = (decimal)credit.sale.Miqdar;
                        if (credit.sale.Nov == "Böyük")
                        {
                            boyukRadioButton.Checked = true;
                        }
                        else if (credit.sale.Nov == "Balaca")
                        {
                            balacaRadioButton.Checked = true;
                        }
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGroupBox.Enabled = false;
                        obshivkaGroupBox.Enabled = false;
                        abloshkaGroupBox.Enabled = true;
                        diktGroupBox.Enabled = false;
                        dvpGroupBox.Enabled = false;
                        shiferGroupBox.Enabled = false;
                        plintusGroupBox.Enabled = false;
                    }
                    break;
                case "Dikt":
                    {
                        cmLabel.Text = "Dikt";
                        diktKubNumericUpDown.Value = (decimal)credit.sale.Kub;
                        diktNomreNumericUpDown.Value = (decimal)credit.sale.Nomre;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGroupBox.Enabled = false;
                        obshivkaGroupBox.Enabled = false;
                        abloshkaGroupBox.Enabled = false;
                        diktGroupBox.Enabled = true;
                        dvpGroupBox.Enabled = false;
                        shiferGroupBox.Enabled = false;
                        plintusGroupBox.Enabled = false;
                    }
                    break;
                case "DVP":
                    {
                        cmLabel.Text = "DVP";
                        dvpMiqdarNumericUpDown.Value = (decimal)credit.sale.Miqdar;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGroupBox.Enabled = false;
                        obshivkaGroupBox.Enabled = false;
                        abloshkaGroupBox.Enabled = false;
                        diktGroupBox.Enabled = false;
                        dvpGroupBox.Enabled = true;
                        shiferGroupBox.Enabled = false;
                        plintusGroupBox.Enabled = false;
                    }
                    break;
                case "Şifer":
                    {
                        cmLabel.Text = "Şifer";
                        shiferMiqdarNumericUpDown.Value = (decimal)credit.sale.Miqdar;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGroupBox.Enabled = false;
                        obshivkaGroupBox.Enabled = false;
                        abloshkaGroupBox.Enabled = false;
                        diktGroupBox.Enabled = false;
                        dvpGroupBox.Enabled = false;
                        shiferGroupBox.Enabled = true;
                        plintusGroupBox.Enabled = false;
                    }
                    break;
                case "Plintus":
                    {
                        cmLabel.Text = "Plintus";
                        plintusUzunluqNumericUpDown.Value = (decimal)credit.sale.Uzunluq;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGroupBox.Enabled = false;
                        obshivkaGroupBox.Enabled = false;
                        abloshkaGroupBox.Enabled = false;
                        diktGroupBox.Enabled = false;
                        dvpGroupBox.Enabled = false;
                        shiferGroupBox.Enabled = false;
                        plintusGroupBox.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void EditCreditForm_Load(object sender, EventArgs e)
        {
            loadCredit?.Invoke(this, new EventArgs());
        }

        private void sumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sumNumericUpDown.Value != 0)
            {
                updateCreditBtn.Enabled = true;
            }
            else
            {
                updateCreditBtn.Enabled = false;
            }
        }

        private void updateCreditBtn_Click(object sender, EventArgs e)
        {
            Credit credit = new Credit();
            credit.sale = new Sale();
            switch (cmLabel.Text)
            {
                case "Taxta":
                    {
                        credit.sale.Ad = "Taxta";
                        credit.sale.En = (float)taxtaEnNumericUpDown.Value;
                        credit.sale.Hundurluk = (float)taxtaHundurlukNumericUpDown.Value;
                        credit.sale.Uzunluq = (float)taxtaUzunluqNumericUpDown.Value;
                        credit.sale.Miqdar = (int)taxtaMiqdarNumericUpDown.Value;
                        credit.sale.Kub = (float)taxtaKubNumericUpDown.Value;
                    }
                    break;
                case "Pol":
                    {
                        credit.sale.Ad = "Pol";
                        credit.sale.En = (float)polEnNumericUpDown.Value;
                        credit.sale.Uzunluq = (float)polUzunluqNumericUpDown.Value;
                        credit.sale.Miqdar = (int)polMiqdarNumericUpDown.Value;
                        credit.sale.Kvadrat = (float)polKvadratNumericUpDown.Value;
                    }
                    break;
                case "Brus":
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
                case "Obşivka":
                    {
                        credit.sale.Ad = "Obşivka";
                        credit.sale.En = (float)obshivkaEnNumericUpDown.Value;
                        credit.sale.Uzunluq = (float)obshivkaUzunluqNumericUpDown.Value;
                        credit.sale.Miqdar = (int)obshivkaMiqdarNumericUpDown.Value;
                        credit.sale.Kvadrat = (float)obshivkaKvadratNumericUpDown.Value;

                    }
                    break;
                case "Abloşka":
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
                case "Dikt":
                    {
                        credit.sale.Ad = "Dikt";
                        credit.sale.Nomre = (short)diktNomreNumericUpDown.Value;
                        credit.sale.Kub = (float)diktKubNumericUpDown.Value;
                    }
                    break;
                case "DVP":
                    {
                        credit.sale.Ad = "DVP";
                        credit.sale.Miqdar = (int)dvpMiqdarNumericUpDown.Value;

                    }
                    break;
                case "Şifer":
                    {
                        credit.sale.Ad = "Şifer";
                        credit.sale.Miqdar = (int)shiferMiqdarNumericUpDown.Value;
                    }
                    break;
                case "Plintus":
                    {
                        credit.sale.Ad = "Plintus";
                        credit.sale.Uzunluq = (float)plintusUzunluqNumericUpDown.Value;
                    }
                    break;
                default:
                    break;
            }


            credit.sale.saleDate = creditDateTimePicker.Value;
            credit.sale.sum = (float)sumNumericUpDown.Value;
            updateCredit?.Invoke(this, new CreEventArgs() { credit = credit });
            this.Close();
        }
    }
}
