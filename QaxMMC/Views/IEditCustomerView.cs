using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface IEditCustomerView : IView
    {
        event EventHandler<CEventArgs> updateC;
        event EventHandler<EventArgs> loadC;
        void LoadCus(Customer customer);
    }
}
