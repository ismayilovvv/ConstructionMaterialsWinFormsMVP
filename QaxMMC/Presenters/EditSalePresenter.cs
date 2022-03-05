using QaxMMC.Models;
using QaxMMC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Presenters
{
    public class EditSalePresenter
    {
        private IEditSaleView editSaleView;
        public IView View { get { return editSaleView; } }
        public Sale sale { get; set; }
        public EditSalePresenter(IEditSaleView editSaleView)
        {
            this.editSaleView = editSaleView;
            sale = new Sale();
            EventSubscription();
        }

        private void EventSubscription()
        {
            editSaleView.updateSale += EditSaleView_updateSale;
            editSaleView.loadSale += EditSaleView_loadSale;
        }

        private void EditSaleView_loadSale(object sender, EventArgs e)
        {
            editSaleView.LoadSale(sale);
        }

        private void EditSaleView_updateSale(object sender, SEventArgs e)
        {
            sale.saleDate = e.sale.saleDate;
            sale.sum = e.sale.sum;
            sale.Ad = e.sale.Ad;
            sale.En= e.sale.En;
            sale.Hundurluk = e.sale.Hundurluk;
            sale.Uzunluq = e.sale.Uzunluq;
            sale.Miqdar = e.sale.Miqdar;
            sale.Kub = e.sale.Kub;
            sale.Kvadrat = e.sale.Kvadrat;
            sale.Nomre = e.sale.Nomre;
            sale.Nov = e.sale.Nov;
        }
    }
}
