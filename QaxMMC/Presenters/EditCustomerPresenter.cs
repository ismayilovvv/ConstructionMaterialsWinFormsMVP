using QaxMMC.Models;
using QaxMMC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Presenters
{
    public class EditCustomerPresenter
    {
        private IEditCustomerView editCustomerView;
        public IView View { get { return editCustomerView; } }
        public Customer customer { get; set; }
        public EditCustomerPresenter(IEditCustomerView editCustomerView)
        {
            customer = new Customer();
            this.editCustomerView = editCustomerView;
            EventSubscription();
        }

        private void EventSubscription()
        {
            editCustomerView.updateC += EditCustomerView_updateC;
            editCustomerView.loadC += EditCustomerView_loadC;
        }

        private void EditCustomerView_loadC(object sender, EventArgs e)
        {
            editCustomerView.LoadCus(customer);
        }

        private void EditCustomerView_updateC(object sender, CEventArgs e)
        {
            customer.Name = e.customer.Name;
            customer.Surname = e.customer.Surname;
            customer.Lastname = e.customer.Lastname;
            customer.Birthdate = e.customer.Birthdate;
            customer.BornAddress = e.customer.BornAddress;
            customer.RegisterAddress = e.customer.RegisterAddress;
            customer.PassportSeriaNumber = e.customer.PassportSeriaNumber;
            customer.PassportFIN = e.customer.PassportFIN;
            customer.Phone1 = e.customer.Phone1;
            customer.Phone2 = e.customer.Phone2;
            customer.Company = e.customer.Company;
            customer.CompanyAddress = e.customer.CompanyAddress;
            customer.Bank = e.customer.Bank;
            customer.AccountNumber = e.customer.AccountNumber;
            customer.Account = e.customer.Account;
            customer.Code = e.customer.Code;
            customer.VOEN = e.customer.VOEN;
            customer.Swift = e.customer.Swift;
        }
    }
}
