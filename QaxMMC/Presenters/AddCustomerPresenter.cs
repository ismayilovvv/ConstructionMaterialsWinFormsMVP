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
    public class AddCustomerPresenter
    {
        private IAddCustomerView addCustomerView;
        private IConstructionMaterialService constructionMaterialService;
        public Customer customer { get; set; }
        public IView View { get { return addCustomerView; } }
        public AddCustomerPresenter(IAddCustomerView addCustomerView, IConstructionMaterialService constructionMaterialService)
        {
            this.constructionMaterialService = constructionMaterialService;
            this.addCustomerView = addCustomerView;
            EventSubscription();
        }

        private void EventSubscription()
        {
            addCustomerView.addCustomer += AddCustomerView_addCustomer;
        }

        private void AddCustomerView_addCustomer(object sender, CEventArgs e)
        {
            if (e != null)
            {
                customer = constructionMaterialService.CreateCustomer(e);
            }
        }
    }
}
