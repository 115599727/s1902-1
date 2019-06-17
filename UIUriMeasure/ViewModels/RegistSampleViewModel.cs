using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIUriMeasure.ViewModels
{
  public  class RegistSampleViewModel : BindableBase, INavigationAware
    {
       

   
        public RegistSampleViewModel()
        {
            


        }
       

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
