using Medicside.UriMeasure.Bussiness;
using Medicside.UriMeasure.Bussiness.Plant;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1Metro.ViewModels
{
  public   class MainWindowViewModel:BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
           // PlantForm.Log.InfoFormat("text");
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                var parameters = new NavigationParameters();
                //parameters.add("MenuGroup", this.);

                _regionManager.RequestNavigate("ContentRegion", navigatePath);
            }
            PlantForm.Log.Info("Navigate " + navigatePath);
        }

        // Title="MEDICSIDE"
        private string _title = "MEDICSIDE Urin Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

    }
}
