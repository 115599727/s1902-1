using Medicside.UriMeasure.Data.UrineMeasure;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIUriMeasure.Views
{
    /// <summary>
    /// MeasureResultEdit.xaml 的交互逻辑
    /// </summary>
    public partial class MeasureResultEdit : UserControl,INavigationAware
    {
        public MeasureResultEdit()
        {
            InitializeComponent();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
           
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var result = navigationContext.Parameters["result"] as UrineTestResult;
            Console.WriteLine(result.SampleNo);
            //throw new NotImplementedException();
        }
    }
}
