using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface IMainScreenView: IView
    {
        event EventHandler<EventArgs> OpenSalesWindow;
        event EventHandler<EventArgs> OpenConstructionMaterialsWindow;
        event EventHandler<EventArgs> OpenCustomersWindow;
        event EventHandler<EventArgs> OpenCreditsWindow;
    }
}
