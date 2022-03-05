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
    public partial class EditSaleForm : Form, IEditSaleView
    {
        public EditSaleForm()
        {
            InitializeComponent();
        }

        public event EventHandler<SEventArgs> updateSale;
        public event EventHandler<EventArgs> loadSale;

        public void LoadSale(Sale sale)
        {
            saleDateTimePicker.Value = sale.saleDate;
            sumNumericUpDown.Value = (decimal)sale.sum;
            switch (sale.Ad)
            {
                case "Taxta":
                    {
                        cmLabel.Text = "Taxta";
                        taxtaEnNumericUpDown.Value = (decimal)sale.En;
                        taxtaHundurlukNumericUpDown.Value = (decimal)sale.Hundurluk;
                        taxtaKubNumericUpDown.Value = (decimal)sale.Kub;
                        taxtaMiqdarNumericUpDown.Value = (decimal)sale.Miqdar;
                        taxtaUzunluqNumericUpDown.Value = (decimal)sale.Uzunluq;
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
                        polEnNumericUpDown.Value = (decimal)sale.En;
                        polKvadratNumericUpDown.Value = (decimal)sale.Kvadrat;
                        polMiqdarNumericUpDown.Value = (decimal)sale.Miqdar;
                        polUzunluqNumericUpDown.Value = (decimal)sale.Uzunluq;
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
                        brusMiqdarNumericUpDown.Value = (decimal)sale.Miqdar;
                        if (sale.Nov == "Ağ")
                        {
                            agRadioButton.Checked = true;
                        }
                        else if (sale.Nov == "Qara")
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
                        obshivkaEnNumericUpDown.Value = (decimal)sale.En;
                        obshivkaKvadratNumericUpDown.Value = (decimal)sale.Kvadrat;
                        obshivkaMiqdarNumericUpDown.Value = (decimal)sale.Miqdar;
                        obshivkaUzunluqNumericUpDown.Value = (decimal)sale.Uzunluq;
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
                        abloshkaMiqdarNumericUpDown.Value = (decimal)sale.Miqdar;
                        if (sale.Nov == "Böyük")
                        {
                            boyukRadioButton.Checked = true;
                        }
                        else if (sale.Nov == "Balaca")
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
                        diktKubNumericUpDown.Value = (decimal)sale.Kub;
                        diktNomreNumericUpDown.Value = (decimal)sale.Nomre;
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
                        dvpMiqdarNumericUpDown.Value = (decimal)sale.Miqdar;
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
                        shiferMiqdarNumericUpDown.Value = (decimal)sale.Miqdar;
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
                        plintusUzunluqNumericUpDown.Value = (decimal)sale.Uzunluq;
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

        private void EditSaleForm_Load(object sender, EventArgs e)
        {
            loadSale?.Invoke(this, new EventArgs());
        }

        private void sumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sumNumericUpDown.Value != 0)
            {
                updateSaleBtn.Enabled = true;
            }
            else
            {
                updateSaleBtn.Enabled = false;
            }
        }

        private void updateSaleBtn_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            switch (cmLabel.Text)
            {
                case "Taxta":
                    {
                        sale.Ad = "Taxta";
                        sale.En = (float)taxtaEnNumericUpDown.Value;
                        sale.Hundurluk = (float)taxtaHundurlukNumericUpDown.Value;
                        sale.Uzunluq = (float)taxtaUzunluqNumericUpDown.Value;
                        sale.Miqdar = (int)taxtaMiqdarNumericUpDown.Value;
                        sale.Kub = (float)taxtaKubNumericUpDown.Value;
                    }
                    break;
                case "Pol":
                    {
                        sale.Ad = "Pol";
                        sale.En = (float)polEnNumericUpDown.Value;
                        sale.Uzunluq = (float)polUzunluqNumericUpDown.Value;
                        sale.Miqdar = (int)polMiqdarNumericUpDown.Value;
                        sale.Kvadrat = (float)polKvadratNumericUpDown.Value;
                    }
                    break;
                case "Brus":
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
                case "Obşivka":
                    {
                        sale.Ad = "Obşivka";
                        sale.En = (float)obshivkaEnNumericUpDown.Value;
                        sale.Uzunluq = (float)obshivkaUzunluqNumericUpDown.Value;
                        sale.Miqdar = (int)obshivkaMiqdarNumericUpDown.Value;
                        sale.Kvadrat = (float)obshivkaKvadratNumericUpDown.Value;

                    }
                    break;
                case "Abloşka":
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
                case "Dikt":
                    {
                        sale.Ad = "Dikt";
                        sale.Nomre = (short)diktNomreNumericUpDown.Value;
                        sale.Kub = (float)diktKubNumericUpDown.Value;
                    }
                    break;
                case "DVP":
                    {
                        sale.Ad = "DVP";
                        sale.Miqdar = (int)dvpMiqdarNumericUpDown.Value;

                    }
                    break;
                case "Şifer":
                    {
                        sale.Ad = "Şifer";
                        sale.Miqdar = (int)shiferMiqdarNumericUpDown.Value;
                    }
                    break;
                case "Plintus":
                    {
                        sale.Ad = "Plintus";
                        sale.Uzunluq = (float)plintusUzunluqNumericUpDown.Value;
                    }
                    break;
                default:
                    break;
            }
            
            
            sale.saleDate = saleDateTimePicker.Value;
            sale.sum = (float)sumNumericUpDown.Value;
            updateSale?.Invoke(this, new SEventArgs() { sale=sale });
            this.Close();
        }
    }
}
