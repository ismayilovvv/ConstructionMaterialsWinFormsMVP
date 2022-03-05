using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QaxMMC.Presenters;
using QaxMMC.Services;
using QaxMMC.Views;

namespace QaxMMC
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IOC.Register<MainScreenForm, IMainScreenView>();
            IOC.Register<SalesForm, ISalesView>();
            IOC.Register<AddSaleForm, IAddSaleView>();
            IOC.Register<AddCustomerForm, IAddCustomerView>();
            IOC.Register<AddConstructionMaterialForm, IAddConstructionMaterialsView>();
            IOC.Register<AddCreditForm, IAddCreditView>();
            IOC.Register<ConstructionMaterialsForm, IConstructionMaterialsView>();
            IOC.Register<EditConstructionMaterialForm, IEditConstructionMaterialView>();
            IOC.Register<EditCustomerForm, IEditCustomerView>();
            IOC.Register<EditSaleForm, IEditSaleView>();
            IOC.Register<EditCreditForm, IEditCreditView>();
            IOC.Register<CreditsForm, ICreditsView>();
            IOC.Register<CustomersForm, ICustomersView>();
            IOC.Register<MainScreenPresenter>();
            IOC.Register<SalesPresenter>();
            IOC.Register<AddSalePresenter>();
            IOC.Register<AddCustomerPresenter>();
            IOC.Register<AddCreditPresenter>();
            IOC.Register<ConstructionMaterialsPresenter>();
            IOC.Register<CreditsPresenter>();
            IOC.Register<EditConstructionMaterialPresenter>();
            IOC.Register<EditCustomerPresenter>();
            IOC.Register<EditSalePresenter>();
            IOC.Register<EditCreditPresenter>();
            IOC.Register<CustomersPresenter>();
            IOC.Register<AddConstructionMaterialsPresenter>();
            IOC.Register<ConstructionMaterialService, IConstructionMaterialService>();
            IOC.Build();


            MainScreenPresenter mainScreenPresenter = IOC.Resolve<MainScreenPresenter>();
            Application.Run((Form)mainScreenPresenter.View);

        }
    }
}
