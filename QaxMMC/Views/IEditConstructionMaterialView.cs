using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface IEditConstructionMaterialView : IView
    {
        event EventHandler<CMEventArgs> updateCM;
        event EventHandler<EventArgs> loadCM;
        void LoadCm(ConstructionMaterial constructionMaterial);
    }
}
