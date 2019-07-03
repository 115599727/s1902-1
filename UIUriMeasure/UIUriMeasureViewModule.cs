using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using UIUriMeasure.Views;

namespace UIUriMeasure
{
  public  class UIUriMeasureViewModule : IModule
    {
        void IModule.OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        

        void IModule.RegisterTypes(IContainerRegistry containerRegistry)
        {
            //throw new NotImplementedException();

            containerRegistry.RegisterForNavigation<RegistSample>();
            containerRegistry.RegisterForNavigation<MeasureResult>();
            containerRegistry.RegisterForNavigation<MeasureResultEdit>();
        }
    }
}
