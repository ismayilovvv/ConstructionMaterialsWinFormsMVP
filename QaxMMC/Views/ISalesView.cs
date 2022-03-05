using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface ISalesView: IView
    {
        event EventHandler<EventArgs> OpenAddSaleWindow;
        void ReloadSales(List<Sale> sales);
        event EventHandler<idEventArgs> DeleteSale;
        event EventHandler<idEventArgs> EditSale;
        event EventHandler<EventArgs> LoadSaleEvent;
    }
}
