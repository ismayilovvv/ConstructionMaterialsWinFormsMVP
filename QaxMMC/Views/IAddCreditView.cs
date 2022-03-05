using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface IAddCreditView: IView
    {
        event EventHandler<CreEventArgs> addCreditEvent;
        event EventHandler<EventArgs> loadCreditEvent;
        void loadForm(List<Customer> customers);
    }

    public class CreEventArgs
    {
        public Credit credit { get; set; }
    }
}
