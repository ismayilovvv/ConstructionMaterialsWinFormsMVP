using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface ICustomersView: IView
    {
        event EventHandler<EventArgs> OpenAddCustomerWindow;
        event EventHandler<idEventArgs> EditCustomer;
        event EventHandler<idEventArgs> DeleteCustomer;
        void ReloadCustomers(List<Customer> customers);
        event EventHandler<EventArgs> LoadCustomersEvent;
    }
}
