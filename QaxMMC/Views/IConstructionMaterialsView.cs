using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface IConstructionMaterialsView: IView
    {
        event EventHandler<EventArgs> OpenAddConstructionMaterialsWindow;
        void ReloadConstructionMaterials(List<ConstructionMaterial> constructionMaterials);
        event EventHandler<idEventArgs> DeleteConstructionMaterial;
        event EventHandler<idEventArgs> EditConstructionMaterial;
        event EventHandler<EventArgs> LoadCMEvent;

    }
}
