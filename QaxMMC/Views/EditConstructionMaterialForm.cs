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
    public partial class EditConstructionMaterialForm : Form, IEditConstructionMaterialView
    {
        public EditConstructionMaterialForm()
        {
            InitializeComponent();
        }

        

        public event EventHandler<CMEventArgs> updateCM;
        public event EventHandler<EventArgs> loadCM;

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void updateCMbtn_Click(object sender, EventArgs e)
        {
            ConstructionMaterial cm = new ConstructionMaterial();
            switch (cmLabel.Text)
            {
                case "Taxta":
                    {
                        cm.Ad = "Taxta";
                        cm.En = (float)taxtaEnNumericUpDown.Value;
                        cm.Hundurluk = (float)taxtaHundurlukNumericUpDown.Value;
                        cm.Uzunluq = (float)taxtaUzunluqNumericUpDown.Value;
                        cm.Eded = (int)taxtaMiqdarNumericUpDown.Value;
                        cm.Kub = (float)taxtaKubNumericUpDown.Value;
                    }
                    break;
                case "Pol":
                    {
                        cm.Ad = "Pol";
                        cm.En = (float)polEnNumericUpDown.Value;
                        cm.Uzunluq = (float)polUzunluqNumericUpDown.Value;
                        cm.Eded = (int)polMiqdarNumericUpDown.Value;
                        cm.Kvadrat = (float)polKvadratNumericUpDown.Value;
                    }
                    break;
                case "Brus":
                    {
                        cm.Ad = "Brus";
                        cm.Eded = (int)brusMiqdarNumericUpDown.Value;
                        if (agRadioButton.Checked)
                        { cm.Nov = "Ağ"; }
                        else
                        {
                            cm.Nov = "Qara";
                        }
                    }
                    break;
                case "Obşivka":
                    {
                        cm.Ad = "Obşivka";
                        cm.En = (float)obshivkaEnNumericUpDown.Value;
                        cm.Uzunluq = (float)obshivkaUzunluqNumericUpDown.Value;
                        cm.Eded = (int)obshivkaMiqdarNumericUpDown.Value;
                        cm.Kvadrat = (float)obshivkaKvadratNumericUpDown.Value;

                    }
                    break;
                case "Abloşka":
                    {
                        cm.Ad = "Abloşka";
                        cm.Eded = (int)abloshkaMiqdarNumericUpDown.Value;
                        if (boyukRadioButton.Checked)
                        { cm.Nov = "Böyük"; }
                        else
                        {
                            cm.Nov = "Balaca";
                        }
                    }
                    break;
                case "Dikt":
                    {
                        cm.Ad = "Dikt";
                        cm.Nomre = (short)diktNomreNumericUpDown.Value;
                        cm.Kub = (float)diktKubNumericUpDown.Value;
                    }
                    break;
                case "DVP":
                    {
                        cm.Ad = "DVP";
                        cm.Eded = (int)dvpMiqdarNumericUpDown.Value;

                    }
                    break;
                case "Şifer":
                    {
                        cm.Ad = "Şifer";
                        cm.Eded = (int)shiferMiqdarNumericUpDown.Value;
                    }
                    break;
                case "Plintus":
                    {
                        cm.Ad = "Plintus";
                        cm.Uzunluq = (float)plintusUzunluqNumericUpDown.Value;
                    }
                    break;
                default:
                    break;
            }
            cm.Mebleg = (float)sumNumericUpDown.Value;
            cm.date = cmDateTimePicker.Value;
            updateCM?.Invoke(this, new CMEventArgs() { constructionMaterial = cm });
            this.Close();
        }

        private void EditConstructionMaterialForm_Load(object sender, EventArgs e)
        {
            loadCM?.Invoke(this, new EventArgs());
        }

        public void LoadCm(ConstructionMaterial constructionMaterial)
        {
            cmDateTimePicker.Value = constructionMaterial.date;
            sumNumericUpDown.Value = (decimal)constructionMaterial.Mebleg;
            switch (constructionMaterial.Ad)
            {
                case "Taxta":
                            {
                        cmLabel.Text = "Taxta";
                        taxtaEnNumericUpDown.Value = (decimal)constructionMaterial.En;
                        taxtaHundurlukNumericUpDown.Value = (decimal)constructionMaterial.Hundurluk;
                        taxtaKubNumericUpDown.Value = (decimal)constructionMaterial.Kub;
                        taxtaMiqdarNumericUpDown.Value = (decimal)constructionMaterial.Eded;
                        taxtaUzunluqNumericUpDown.Value = (decimal)constructionMaterial.Uzunluq;
                        taxtaGroupBox.Enabled = true;
                        polGroupBox.Enabled = false;
                        brusGoupBox.Enabled = false;
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
                        polEnNumericUpDown.Value = (decimal)constructionMaterial.En;
                        polKvadratNumericUpDown.Value = (decimal)constructionMaterial.Kvadrat;
                        polMiqdarNumericUpDown.Value = (decimal)constructionMaterial.Eded;
                        polUzunluqNumericUpDown.Value = (decimal)constructionMaterial.Uzunluq;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = true;
                        brusGoupBox.Enabled = false;
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
                        brusMiqdarNumericUpDown.Value = (decimal)constructionMaterial.Eded;
                        if(constructionMaterial.Nov == "Ağ")
                        {
                            agRadioButton.Checked = true;
                        }
                        else if(constructionMaterial.Nov == "Qara")
                        {
                            qaraRadioButton.Checked = true;
                        }
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGoupBox.Enabled = true;
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
                        obshivkaEnNumericUpDown.Value = (decimal)constructionMaterial.En;
                        obshivkaKvadratNumericUpDown.Value = (decimal)constructionMaterial.Kvadrat;
                        obshivkaMiqdarNumericUpDown.Value = (decimal)constructionMaterial.Eded;
                        obshivkaUzunluqNumericUpDown.Value = (decimal)constructionMaterial.Uzunluq;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGoupBox.Enabled = false;
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
                        abloshkaMiqdarNumericUpDown.Value = (decimal)constructionMaterial.Eded;
                        if (constructionMaterial.Nov == "Böyük")
                        {
                            boyukRadioButton.Checked = true;
                        }
                        else if (constructionMaterial.Nov == "Balaca")
                        {
                            balacaRadioButton.Checked = true;
                        }
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGoupBox.Enabled = false;
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
                        diktKubNumericUpDown.Value = (decimal)constructionMaterial.Kub;
                        diktNomreNumericUpDown.Value = (decimal)constructionMaterial.Nomre;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGoupBox.Enabled = false;
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
                        dvpMiqdarNumericUpDown.Value = (decimal)constructionMaterial.Eded;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGoupBox.Enabled = false;
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
                        shiferMiqdarNumericUpDown.Value = (decimal)constructionMaterial.Eded;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGoupBox.Enabled = false;
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
                        plintusUzunluqNumericUpDown.Value = (decimal)constructionMaterial.Uzunluq;
                        taxtaGroupBox.Enabled = false;
                        polGroupBox.Enabled = false;
                        brusGoupBox.Enabled = false;
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

        private void sumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(sumNumericUpDown.Value != 0)
            {
                updateCMbtn.Enabled = true;
            }
            else
            {
                updateCMbtn.Enabled = false;
            }
        }
    }
}
