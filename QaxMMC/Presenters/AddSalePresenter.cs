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
    public class AddSalePresenter
    {
        private IAddSaleView addSaleView;
        private IConstructionMaterialService constructionMaterialService;
        public Sale sale { get; set; }
        public IView View { get { return addSaleView; } }
        public AddSalePresenter(IAddSaleView addSaleView, IConstructionMaterialService constructionMaterialService)
        {
            this.constructionMaterialService = constructionMaterialService;
            this.addSaleView = addSaleView;
            EventSubscription();
        }

        private void EventSubscription()
        {
            addSaleView.addSaleEvent += AddSaleView_addSaleEvent;
        }

        private void AddSaleView_addSaleEvent(object sender, SEventArgs e)
        {
            if (e != null)
            {
                sale = constructionMaterialService.CreateSale(e);
            }
        }
    }
}
