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
    public partial class SalesForm : Form, ISalesView
    {
        public SalesForm()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> OpenAddSaleWindow;
        public event EventHandler<idEventArgs> DeleteSale;
        public event EventHandler<idEventArgs> EditSale;
        public event EventHandler<EventArgs> LoadSaleEvent;

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void addSaleBtn_Click(object sender, EventArgs e)
        {
            OpenAddSaleWindow?.Invoke(this, new EventArgs());
        }

        public void ReloadSales(List<Sale> sales)
        {
            saleDataGridView.Rows.Clear();
            if (sales != null)
            {
                foreach (var sale in sales)
                {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(saleDataGridView);
                        row.Cells[0].Value = sale.Id;
                        row.Cells[1].Value = sale.Ad;
                        row.Cells[2].Value = sale.En;
                        row.Cells[3].Value = sale.Hundurluk;
                        row.Cells[4].Value = sale.Uzunluq;
                        row.Cells[5].Value = sale.Miqdar;
                        row.Cells[6].Value = sale.Nomre;
                        row.Cells[7].Value = sale.Nov;
                        row.Cells[8].Value = sale.Kub;
                        row.Cells[9].Value = sale.Kvadrat;
                        row.Cells[10].Value = sale.sum;
                        row.Cells[11].Value = sale.saleDate.ToShortDateString();
                        row.Cells[12].Value = "Düzəliş etmək";
                        row.Cells[13].Value = "Silmək";
                        saleDataGridView.Rows.Add(row);
                    
                }
            }
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            LoadSaleEvent?.Invoke(this, new EventArgs());
        }

        private void saleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                EditSale?.Invoke(this, new idEventArgs() { Id = Convert.ToInt32(saleDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()) });
            }
            else if (e.ColumnIndex == 13)
            {
                DeleteSale?.Invoke(this, new idEventArgs() { Id = Convert.ToInt32(saleDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()) });
            }
        }
    }
}
