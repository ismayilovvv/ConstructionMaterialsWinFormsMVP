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
    public class AddCreditPresenter
    {
        private IAddCreditView addCreditView;
        private IConstructionMaterialService constructionMaterialService;
        public Credit credit { get; set; }
        public IView View { get { return addCreditView; } }
        public AddCreditPresenter(IAddCreditView addCreditView, IConstructionMaterialService constructionMaterialService)
        {
            this.constructionMaterialService = constructionMaterialService;
            constructionMaterialService.AddDbContext(new QaxMmcDbContext());
            this.addCreditView = addCreditView;
            EventsSubscription();
        }

        private void EventsSubscription()
        {
            addCreditView.addCreditEvent += AddCreditView_addCreditEvent;
            addCreditView.loadCreditEvent += AddCreditView_loadCreditEvent;
        }

        private void AddCreditView_loadCreditEvent(object sender, EventArgs e)
        {
            addCreditView.loadForm(constructionMaterialService.GetCustomers().ToList());
        }

        private void AddCreditView_addCreditEvent(object sender, CreEventArgs e)
        {
            if (e != null)
            {
                credit = constructionMaterialService.CreateCredit(e);
            }
        }
    }
}
