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
    public partial class AddConstructionMaterialForm : Form, IAddConstructionMaterialsView
    {
        public AddConstructionMaterialForm()
        {
            InitializeComponent();
        }

        public event EventHandler<CMEventArgs> addCM;
        public event EventHandler<EventArgs> cmEnable;

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void AddConstructionMaterialForm_Load(object sender, EventArgs e)
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

        private void cmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmEnable?.Invoke(this, new EventArgs());
        }

        

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if(sumNumericUpDown.Value != 0 && cmComboBox.SelectedIndex != -1)
            {
                addCMbtn.Enabled = true;
            }
            else
            {
                addCMbtn.Enabled = false;
            }
        }

        private void addCMbtn_Click(object sender, EventArgs e)
        {
            ConstructionMaterial cm = new ConstructionMaterial();
            switch (cmComboBox.SelectedIndex)
            {
                case 0:
                    {
                        cm.Ad = "Taxta";
                        cm.En = (float)taxtaEnNumericUpDown.Value;
                        cm.Hundurluk = (float)taxtaHundurlukNumericUpDown.Value;
                        cm.Uzunluq = (float)taxtaUzunluqNumericUpDown.Value;
                        cm.Eded = (int)taxtaMiqdarNumericUpDown.Value;
                        cm.Kub = (float)taxtaKubNumericUpDown.Value;
                    }
                    break;
                case 1:
                    {
                        cm.Ad = "Pol";
                        cm.En = (float)polEnNumericUpDown.Value;
                        cm.Uzunluq = (float)polUzunluqNumericUpDown.Value;
                        cm.Eded = (int)polMiqdarNumericUpDown.Value;
                        cm.Kvadrat = (float)polKvadratNumericUpDown.Value;
                    }
                    break;
                case 2:
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
                case 3:
                    {
                        cm.Ad = "Obşivka";
                        cm.En = (float)obshivkaEnNumericUpDown.Value;
                        cm.Uzunluq = (float)obshivkaUzunluqNumericUpDown.Value;
                        cm.Eded = (int)obshivkaMiqdarNumericUpDown.Value;
                        cm.Kvadrat = (float)obshivkaKvadratNumericUpDown.Value;

                    }
                    break;
                case 4:
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
                case 5:
                    {
                        cm.Ad = "Dikt";
                        cm.Nomre = (short)diktNomreNumericUpDown.Value;
                        cm.Kub = (float)diktKubNumericUpDown.Value;
                    }
                    break;
                case 6:
                    {
                        cm.Ad = "DVP";
                        cm.Eded = (int)dvpMiqdarNumericUpDown.Value;

                    }
                    break;
                case 7:
                    {
                        cm.Ad = "Şifer";
                        cm.Eded = (int)shiferMiqdarNumericUpDown.Value;
                    }
                    break;
                case 8:
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
            addCM?.Invoke(this, new CMEventArgs() { constructionMaterial = cm  });
            this.Close();
        }

        public void cmComboBoxSelectedIndexChanged()
        {
            if (cmComboBox.SelectedIndex != -1)
            {
                switch (cmComboBox.SelectedIndex)
                {
                    case 0:
                        {
                            taxtaGroupBox.Enabled = true;
                            polGroupBox.Enabled = false;
                            brusGoupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0)
                            {
                                addCMbtn.Enabled = true;
                            }
                            else
                            {
                                addCMbtn.Enabled = false;
                            }

                        }
                        break;
                    case 1:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = true;
                            brusGoupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0)
                            {
                                addCMbtn.Enabled = true;
                            }
                            else
                            {
                                addCMbtn.Enabled = false;
                            }
                        }
                        break;
                    case 2:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGoupBox.Enabled = true;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0)
                            {
                                addCMbtn.Enabled = true;
                            }
                            else
                            {
                                addCMbtn.Enabled = false;
                            }

                        }
                        break;
                    case 3:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGoupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = true;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0)
                            {
                                addCMbtn.Enabled = true;
                            }
                            else
                            {
                                addCMbtn.Enabled = false;
                            }

                        }
                        break;
                    case 4:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGoupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = true;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0)
                            {
                                addCMbtn.Enabled = true;
                            }
                            else
                            {
                                addCMbtn.Enabled = false;
                            }

                        }
                        break;
                    case 5:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGoupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = true;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0)
                            {
                                addCMbtn.Enabled = true;
                            }
                            else
                            {
                                addCMbtn.Enabled = false;
                            }

                        }
                        break;
                    case 6:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGoupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = true;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0)
                            {
                                addCMbtn.Enabled = true;
                            }
                            else
                            {
                                addCMbtn.Enabled = false;
                            }

                        }
                        break;
                    case 7:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGoupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = true;
                            plintusGroupBox.Enabled = false;
                            if (sumNumericUpDown.Value != 0)
                            {
                                addCMbtn.Enabled = true;
                            }
                            else
                            {
                                addCMbtn.Enabled = false;
                            }

                        }
                        break;
                    case 8:
                        {
                            taxtaGroupBox.Enabled = false;
                            polGroupBox.Enabled = false;
                            brusGoupBox.Enabled = false;
                            obshivkaGroupBox.Enabled = false;
                            abloshkaGroupBox.Enabled = false;
                            diktGroupBox.Enabled = false;
                            dvpGroupBox.Enabled = false;
                            shiferGroupBox.Enabled = false;
                            plintusGroupBox.Enabled = true;
                            if (sumNumericUpDown.Value != 0)
                            {
                                addCMbtn.Enabled = true;
                            }
                            else
                            {
                                addCMbtn.Enabled = false;
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
