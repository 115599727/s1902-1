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
using MahApps.Metro.Controls;

namespace WpfApp1Metro
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ShowTitleBar = true;
            this.ShowIconOnTitleBar = true;

            this.ShowMinButton = false;
            this.ShowMaxRestoreButton = false;
            this.ShowIconOnTitleBar = true;
            this.ResizeMode = ResizeMode.NoResize;


            
        }
    }
}
