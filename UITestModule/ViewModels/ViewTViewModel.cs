using Medicside.UriMeasure.Bussiness.Plant;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestModule.ViewModels
{
    public class ViewTViewModel : BindableBase, INavigationAware, IDataErrorInfo
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
        public DelegateCommand ExecuteDelegateCommand { get; private set; }


        public string Error
        {
            get
            {
                return null;
            }
        }
        [Range(0, 10000, ErrorMessage = "Age Error ")]
        public int Age { get; set; }

        public string this[string columnName]
        {
            get
            {
                var vc = new ValidationContext(this, null, null);
                vc.MemberName = columnName;
                var res = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(this.GetType().GetProperty(columnName).GetValue(this, null), vc, res);
                if (res.Count > 0) { return string.Join(Environment.NewLine, res.Select(r => r.ErrorMessage).ToArray()); }
                return string.Empty;


            }
        }



        public ViewTViewModel()
        {
            this._demoText = "Demo Text String";
            ExecuteDelegateCommand = new DelegateCommand(Excute);
        }

        private void Excute()
        {
            DemoText = "按下";


        }
        ///当前的页面被导航到以后发生
        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            PlantForm.Log.Info("NavigatedTo ~~~~ ViewT");
            //throw new NotImplementedException();
        }
        //用来指定当前的视图/模型是否可以重用 false 不重用 true 重用
        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;

            //throw new NotImplementedException();
        }
        // 当前的页面导航到其他页面的时候发生
        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
    }
}
