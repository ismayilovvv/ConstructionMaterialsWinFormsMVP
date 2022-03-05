using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface IAddCustomerView: IView
    {
        event EventHandler<CEventArgs> addCustomer;
    }

    public class CEventArgs
    {
        public Customer customer { get; set; }
    }
}
