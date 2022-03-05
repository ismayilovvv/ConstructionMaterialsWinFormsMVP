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
    public class MainScreenPresenter
    {
        private IMainScreenView mainScreenView;
        public IView View { get { return mainScreenView; } }
        public MainScreenPresenter(IMainScreenView mainScreenView)
        {
            this.mainScreenView = mainScreenView;
            EventSubscribtion();
        }

        private void EventSubscribtion()
        {
            mainScreenView.OpenSalesWindow += MainScreenView_OpenSalesWindow;
            mainScreenView.OpenConstructionMaterialsWindow += MainScreenView_OpenConstructionMaterialsWindow;
            mainScreenView.OpenCustomersWindow += MainScreenView_OpenCustomersWindow;
            mainScreenView.OpenCreditsWindow += MainScreenView_OpenCreditsWindow;
        }

        private void MainScreenView_OpenCreditsWindow(object sender, EventArgs e)
        {
            CreditsPresenter creditsPresenter = IOC.Resolve<CreditsPresenter>();
            if(!creditsPresenter.View.ShowDialog())
            {

            }
        }

        private void MainScreenView_OpenCustomersWindow(object sender, EventArgs e)
        {
            CustomersPresenter customersPresenter = IOC.Resolve<CustomersPresenter>();
            if (!customersPresenter.View.ShowDialog())
            {
                
            }
        }

        private void MainScreenView_OpenConstructionMaterialsWindow(object sender, EventArgs e)
        {
            ConstructionMaterialsPresenter constructionMaterialsPresenter = IOC.Resolve<ConstructionMaterialsPresenter>();
            if (!constructionMaterialsPresenter.View.ShowDialog())
            {

            }
        }

        private void MainScreenView_OpenSalesWindow(object sender, EventArgs e)
        {
            SalesPresenter salesPresenter = IOC.Resolve<SalesPresenter>();
            if (!salesPresenter.View.ShowDialog())
            {

            }
        }
    }
}
