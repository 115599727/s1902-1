using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestModule.ViewModels
{
    public class ViewTViewModel : BindableBase
    {

        private string _demoText;
        public string DemoText
        {
            get { return _demoText; }
            set
            {
                SetProperty(ref _demoText, value);
                // BtnRunDelegateCommand.RaiseCanExecuteChanged();
            }
        }

        public ViewTViewModel()
        {
            this._demoText = "Demo Text String";

        }
    }
}
