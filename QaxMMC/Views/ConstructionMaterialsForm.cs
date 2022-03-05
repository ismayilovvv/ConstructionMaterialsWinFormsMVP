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
    public partial class ConstructionMaterialsForm : Form, IConstructionMaterialsView
    {
        public ConstructionMaterialsForm()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> OpenAddConstructionMaterialsWindow;
        public event EventHandler<idEventArgs> DeleteConstructionMaterial;
        public event EventHandler<idEventArgs> EditConstructionMaterial;
        public event EventHandler<EventArgs> OpenStockWindow;
        public event EventHandler<EventArgs> LoadCMEvent;

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void addCMBtn_Click(object sender, EventArgs e)
        {
            OpenAddConstructionMaterialsWindow?.Invoke(this, new EventArgs());
        }

        public void ReloadConstructionMaterials(List<ConstructionMaterial> constructionMaterials)
        {
            cmDataGridView.Rows.Clear();
            if (constructionMaterials != null)
            {
                foreach (var constructionMaterial in constructionMaterials)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(cmDataGridView);
                    row.Cells[0].Value = constructionMaterial.Id;
                    row.Cells[1].Value = constructionMaterial.Ad;
                    row.Cells[2].Value = constructionMaterial.En;
                    row.Cells[3].Value = constructionMaterial.Hundurluk;
                    row.Cells[4].Value = constructionMaterial.Uzunluq;
                    row.Cells[5].Value = constructionMaterial.Eded;
                    row.Cells[6].Value = constructionMaterial.Nomre;
                    row.Cells[7].Value = constructionMaterial.Nov;
                    row.Cells[8].Value = constructionMaterial.Kub;
                    row.Cells[9].Value = constructionMaterial.Kvadrat;
                    row.Cells[10].Value = constructionMaterial.Mebleg;
                    row.Cells[11].Value = constructionMaterial.date.ToShortDateString();
                    row.Cells[12].Value = "Düzəliş etmək";
                    row.Cells[13].Value = "Silmək";
                    cmDataGridView.Rows.Add(row);
                }
            }
        }

        private void cmDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.ColumnIndex == 12)
            {
                EditConstructionMaterial?.Invoke(this, new idEventArgs() { Id =Convert.ToInt32(cmDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()) });
            }
            else if(e.ColumnIndex == 13)
            {
                DeleteConstructionMaterial?.Invoke(this, new idEventArgs() { Id = Convert.ToInt32(cmDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()) });
            }
        }

        private void stockBtn_Click(object sender, EventArgs e)
        {
            OpenStockWindow?.Invoke(this, new EventArgs());
        }

        private void ConstructionMaterialsForm_Load(object sender, EventArgs e)
        {
            LoadCMEvent?.Invoke(this, new EventArgs());
        }
    } 
}
