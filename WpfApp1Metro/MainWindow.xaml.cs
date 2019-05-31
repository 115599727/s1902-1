using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using C1.WPF;
using C1.WPF.Theming;
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
            this.WindowState = WindowState.Maximized;
            this.IgnoreTaskbarOnMaximize = true;

            cmbTheme.ItemsSource = typeof(C1AvailableThemes).GetEnumValues<C1AvailableThemes>();
            cmbTheme.SelectedItem = C1AvailableThemes.Office2016White;

            C1Theme ribbonTheme = new C1.WPF.Theming.Ribbon.C1ThemeRibbonOffice2016White();
            
            ribbonTheme.Apply(ribbon);
            ribbonTheme.Apply(this);
            this.Loaded += MainWindow_Loaded;
            //SetTheme();

            this.ribbon.Loaded += Ribbon_Loaded;
        }

        private void Ribbon_Loaded(object sender, RoutedEventArgs e)
        {
            ((Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0)).RowDefinitions[0].Height = new GridLength(0);

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var v=this.Resources.FindName("appbutton");
        }

        private void SetTheme()
        {
            var theme = C1ThemeFactory.GetTheme(C1AvailableThemes.Office2016Colorful);
            C1Theme.ApplyTheme(LayoutRoot, theme);

            var adornerLayer = AdornerLayer.GetAdornerLayer(LayoutRoot);
            if (adornerLayer != null)
            {
                // this will aplly theme to everything displayed in adorner, including any C1Window instances
                C1Theme.ApplyTheme(adornerLayer, theme);
            }
        }

        private void cmbTheme_SelectedItemChanged(object sender, PropertyChangedEventArgs<object> e)
        {
            C1Theme ribbonTheme = null;
            var theme = C1ThemeFactory.GetTheme((C1AvailableThemes)cmbTheme.SelectedItem);
            C1Theme.ApplyTheme(LayoutRoot, theme);

            var adornerLayer = AdornerLayer.GetAdornerLayer(LayoutRoot);
            if (adornerLayer != null)
            {
                // this will aplly theme to everything displayed in adorner, including any C1Window instances
                C1Theme.ApplyTheme(adornerLayer, theme);
            }
            //gallery.CurrentTheme = theme;   

            SetRibbonTheme(ribbonTheme,(C1AvailableThemes)cmbTheme.SelectedItem);

           // Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(theme.GetNewResourceDictionary());
            if (ribbonTheme != null)
            {
                Application.Current.Resources.MergedDictionaries.Add(ribbonTheme.GetNewResourceDictionary());
            }
           // ribbon.ApplicationMenu.Background = this.Background;

        }

        private void SetRibbonTheme(C1Theme ribbonTheme,C1AvailableThemes selectedThemeItem)
        {
           
            switch (selectedThemeItem)
            {
                case C1AvailableThemes.Cosmopolitan:

                    ribbonTheme = new C1.WPF.Theming.Ribbon.C1ThemeRibbonCosmopolitan();
                    break;
                case C1AvailableThemes.CosmopolitanDark:

                    ribbonTheme = new C1.WPF.Theming.Ribbon.C1ThemeRibbonCosmopolitanDark();
                    break;
                case C1AvailableThemes.Office2013White:

                    ribbonTheme = new C1.WPF.Theming.Ribbon.C1ThemeRibbonOffice2013White();
                    break;
                case C1AvailableThemes.Office2013LightGray:

                    ribbonTheme = new C1.WPF.Theming.Ribbon.C1ThemeRibbonOffice2013LightGray();
                    break;
                case C1AvailableThemes.Office2013DarkGray:

                    ribbonTheme = new C1.WPF.Theming.Ribbon.C1ThemeRibbonOffice2013DarkGray();
                    break;
                case C1AvailableThemes.Office2016Colorful:

                    ribbonTheme = new C1.WPF.Theming.Ribbon.C1ThemeRibbonOffice2016Colorful();
                    break;
                case C1AvailableThemes.Office2016DarkGray:

                    ribbonTheme = new C1.WPF.Theming.Ribbon.C1ThemeRibbonOffice2016DarkGray();
                    break;
                case C1AvailableThemes.Office2016White:

                    ribbonTheme = new C1.WPF.Theming.Ribbon.C1ThemeRibbonOffice2016White();
                    break;
                case C1AvailableThemes.Office2016Black:

                    ribbonTheme = new C1.WPF.Theming.Ribbon.C1ThemeRibbonOffice2016Black();
                    break;
                default:
                    break;
            }
            if (ribbonTheme != null)
            {
                ribbonTheme.Apply(ribbon);
                ribbonTheme.Apply(this);

            }
            


    }
    }
}
