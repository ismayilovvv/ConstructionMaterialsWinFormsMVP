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
    public partial class CreditsForm : Form, ICreditsView
    {
        public CreditsForm()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> OpenAddCreditWindow;
        public event EventHandler<EventArgs> LoadCreditEvent;
        public event EventHandler<idEventArgs> DeleteCredit;
        public event EventHandler<idEventArgs> EditCredit;

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void addSaleBtn_Click(object sender, EventArgs e)
        {
            OpenAddCreditWindow?.Invoke(this, new EventArgs());
        }

        public void ReloadCredits(List<Credit> credits)
        {
            creditDataGridView.Rows.Clear();
            if (credits != null)
            {
                foreach (var credit in credits)
                {
                    if (credit.customer != null && credit.sale != null)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(creditDataGridView);
                        row.Cells[0].Value = credit.Id;
                        row.Cells[1].Value = credit.sale.Ad;
                        row.Cells[2].Value = credit.sale.En;
                        row.Cells[3].Value = credit.sale.Hundurluk;
                        row.Cells[4].Value = credit.sale.Uzunluq;
                        row.Cells[5].Value = credit.sale.Miqdar;
                        row.Cells[6].Value = credit.sale.Nomre;
                        row.Cells[7].Value = credit.sale.Nov;
                        row.Cells[8].Value = credit.sale.Kub;
                        row.Cells[9].Value = credit.sale.Kvadrat;
                        row.Cells[10].Value = credit.sale.sum;
                        row.Cells[11].Value = credit.sale.saleDate.ToShortDateString();
                        if (credit.customer.Company == string.Empty)
                        {
                            row.Cells[12].Value = credit.customer.Name + " " + credit.customer.Surname + " " + credit.customer.Lastname;
                        }
                        else
                        {
                            row.Cells[12].Value = credit.customer.Company;
                        }
                        row.Cells[13].Value = "Düzəliş etmək";
                        row.Cells[14].Value = "Silmək";
                        creditDataGridView.Rows.Add(row);
                    }
                }
            }
        }

        private void CreditsForm_Load(object sender, EventArgs e)
        {
            LoadCreditEvent?.Invoke(this, new EventArgs());
        }

        private void creditDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                EditCredit?.Invoke(this, new idEventArgs() { Id = Convert.ToInt32(creditDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()) });
            }
            else if (e.ColumnIndex == 14)
            {
                DeleteCredit?.Invoke(this, new idEventArgs() { Id = Convert.ToInt32(creditDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()) });
            }
        }
    }
}
