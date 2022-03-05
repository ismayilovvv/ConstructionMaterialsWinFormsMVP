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
    public class AddConstructionMaterialsPresenter
    {
        private IAddConstructionMaterialsView addConstructionMaterialsView;
        private IConstructionMaterialService constructionMaterialService;
        public IView View { get { return addConstructionMaterialsView; } }
        public ConstructionMaterial constructionMaterial { get; set; }
        public AddConstructionMaterialsPresenter(IAddConstructionMaterialsView addConstructionMaterialsView, IConstructionMaterialService constructionMaterialService)
        {
            this.addConstructionMaterialsView = addConstructionMaterialsView;
            this.constructionMaterialService = constructionMaterialService;
            EventSubscription();
        }

        private void EventSubscription()
        {
            addConstructionMaterialsView.addCM += AddConstructionMaterialsView_addCM;
            addConstructionMaterialsView.cmEnable += AddConstructionMaterialsView_cmEnable;
        }

        private void AddConstructionMaterialsView_cmEnable(object sender, EventArgs e)
        {
            addConstructionMaterialsView.cmComboBoxSelectedIndexChanged();
        }

        private void AddConstructionMaterialsView_addCM(object sender, CMEventArgs e)
        {
            if (e != null) {
                constructionMaterial = constructionMaterialService.CreateConstructionMaterial(e);
            }
        }
    }
}
