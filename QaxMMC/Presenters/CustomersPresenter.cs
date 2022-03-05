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
    public class CustomersPresenter
    {
        private ICustomersView customersView;
        private IConstructionMaterialService constructionMaterialService;
        public List<Customer> Customers { get; set; }
        public IView View { get { return customersView; } }
        public CustomersPresenter(ICustomersView customersView, IConstructionMaterialService constructionMaterialService)
        {
            this.customersView = customersView;
            this.constructionMaterialService = constructionMaterialService;
            constructionMaterialService.AddDbContext(new QaxMmcDbContext());
            Customers = new List<Customer>();
            EventSubscription();
        }

        private void EventSubscription()
        {
            customersView.OpenAddCustomerWindow += CustomersView_OpenAddCustomerWindow;
            customersView.EditCustomer += CustomersView_EditCustomer;
            customersView.DeleteCustomer += CustomersView_DeleteCustomer;
            customersView.LoadCustomersEvent += CustomersView_LoadCustomersEvent;
        }

        private void CustomersView_LoadCustomersEvent(object sender, EventArgs e)
        {
            Customers = constructionMaterialService.GetCustomers();
            customersView.ReloadCustomers(Customers);
        }

        private void CustomersView_DeleteCustomer(object sender, idEventArgs e)
        {
            constructionMaterialService.DeleteCustomer(e.Id);
            Customers = constructionMaterialService.GetCustomers();
            customersView.ReloadCustomers(Customers);
        }

        private void CustomersView_EditCustomer(object sender, idEventArgs e)
        {
            EditCustomerPresenter editCustomerPresenter = IOC.Resolve<EditCustomerPresenter>();
            editCustomerPresenter.customer = Customers.Where(cus => cus.Id == e.Id).FirstOrDefault();
            if (!editCustomerPresenter.View.ShowDialog())
            {
                constructionMaterialService.EditCustomer(editCustomerPresenter.customer);
                Customers = constructionMaterialService.GetCustomers();
                customersView.ReloadCustomers(Customers);
            }
        }

        private void CustomersView_OpenAddCustomerWindow(object sender, EventArgs e)
        {
            AddCustomerPresenter addCustomerPresenter = IOC.Resolve<AddCustomerPresenter>();
            if (!addCustomerPresenter.View.ShowDialog())
            {
                if (addCustomerPresenter.customer != null)
                {
                    constructionMaterialService.AddCustomer(addCustomerPresenter.customer);
                    Customers = constructionMaterialService.GetCustomers();
                    customersView.ReloadCustomers(Customers);
                }
            }
        }
    }
}
