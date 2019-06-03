using log4net;
using Medicside.UriMeasure.Bussiness;
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

namespace UITestModule.Views
{
    /// <summary>
    /// ViewT.xaml 的交互逻辑
    /// </summary>
    public partial class ViewT : UserControl
    {
        
        public ViewT()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Log = PlantForm.Log;
            Log.Debug("Log MessageBox");
            Log.Info("Messagebox");
            MessageBox.Show("MessageBox Show!","Caption",MessageBoxButton.YesNo,MessageBoxImage.Information);
            Log.Warn("messageBox");
        }
    }
}
