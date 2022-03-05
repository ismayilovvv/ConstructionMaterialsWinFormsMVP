using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface IEditSaleView : IView
    {
        event EventHandler<SEventArgs> updateSale;
        event EventHandler<EventArgs> loadSale;
        void LoadSale(Sale sale);
    }
}
