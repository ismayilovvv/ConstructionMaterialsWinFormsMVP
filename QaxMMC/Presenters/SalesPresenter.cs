using QaxMMC.EntityFramework;
using QaxMMC.Models;
using QaxMMC.Services;
using QaxMMC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Presenters
{
    public class SalesPresenter
    {
        public List<Sale> sales { get; set; }
        private ISalesView salesView;
        private IConstructionMaterialService constructionMaterialService;
        public IView View { get { return salesView; } }
        public SalesPresenter(ISalesView salesView, IConstructionMaterialService constructionMaterialService)
        {
            sales = new List<Sale>();
            this.salesView = salesView;
            this.constructionMaterialService = constructionMaterialService;
            constructionMaterialService.AddDbContext(new QaxMmcDbContext());
            EventSubscribtion();
        }

        private void EventSubscribtion()
        {
            salesView.OpenAddSaleWindow += SalesView_OpenAddSaleWindow;
            salesView.LoadSaleEvent += SalesView_LoadSaleEvent;
            salesView.DeleteSale += SalesView_DeleteSale;
            salesView.EditSale += SalesView_EditSale;
        }

        private void SalesView_EditSale(object sender, idEventArgs e)
        {
            EditSalePresenter editSalePresenter = IOC.Resolve<EditSalePresenter>();
            editSalePresenter.sale = sales.Where(s => s.Id == e.Id).FirstOrDefault();
            if (!editSalePresenter.View.ShowDialog())
            {
                constructionMaterialService.EditSale(editSalePresenter.sale);
                sales = constructionMaterialService.GetSales();
                salesView.ReloadSales(sales);
            }
        }

        private void SalesView_DeleteSale(object sender, idEventArgs e)
        {
            constructionMaterialService.DeleteSale(e.Id);
            sales = constructionMaterialService.GetSales();
            salesView.ReloadSales(sales);
        }

        private void SalesView_LoadSaleEvent(object sender, EventArgs e)
        {
            sales = constructionMaterialService.GetSales();
            salesView.ReloadSales(sales);
        }

        private void SalesView_OpenAddSaleWindow(object sender, EventArgs e)
        {
            AddSalePresenter addSalePresenter = IOC.Resolve<AddSalePresenter>();
            if (!addSalePresenter.View.ShowDialog())
            {
                if(addSalePresenter.sale != null)
                {
                    constructionMaterialService.AddSale(addSalePresenter.sale);
                    sales = constructionMaterialService.GetSales();
                    salesView.ReloadSales(sales);
                }
            }
        }
    }
}
