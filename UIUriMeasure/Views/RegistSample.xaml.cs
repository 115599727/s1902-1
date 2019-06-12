using C1.WPF.FlexGrid;
using C1.WPF.Toolbar;
using CommonServiceLocator;
using Medicside.UriMeasure.Bussiness.Plant;
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
using System.Windows.Shapes;

namespace UIUriMeasure.Views
{
    /// <summary>
    /// RegistSample.xaml 的交互逻辑
    /// </summary>
    public partial class RegistSample : UserControl
    {
        public RegistSample()
        {
            InitializeComponent();
            foreach (var key in Resources.Keys)
            {
                var cmd = Resources[key] as C1ToolbarCommand;
                if (cmd != null)
                {
                    CommandManager.RegisterClassCommandBinding(GetType(), new CommandBinding(
                      cmd, (s, e) => Execute(key.ToString()), (s, e) => e.CanExecute = true));
                }
            }

            FlexGrid_Initialized(this, null);



        }

        private void Execute(string CmdName)
        {
            //执行检测
            if (CmdName.Equals("cmdTest")) 
            {
                PlantForm.Log.Info(Application.Current.Resources["UiUriMeasure.Register.Toolbar.Test"].ToString());
                //跳转到labelTitle == Resources["UiUriMeasure.Register.Toolbar.Test"].ToString()
                //var para = new NavigationParameters("Uri=ContactMainWindowView&Param=hello saylor");
                ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate("ContentRegion", "ViewT");
                return;
            }
            
            MessageBox.Show(CmdName+"clicked ");
            

           
        }
        private void FlexGrid_Initialized(object sender, EventArgs e)
        {
            flexGrid.AutoGenerateColumns = false;
            flexGrid.SelectionMode = C1.WPF.FlexGrid.SelectionMode.RowRange;

            string cols = "选择|架号|管号|样本编号|条码号|病患名字|性别|年|齢|民族|病历号|病患类型|收费类型|样本类型|稀释|采样时间|送检时间|登记时间|送检科室|送检医生|检测时间|备注";
            string maps = "UISelected|ShelfNumber|TubeNumber|SampleNo|BarCode|PatientName|PatientSex|PatientAge|PatientAgeType|Nation|RecordNo|PatientType|ChargeType|SampleType|DilutionMultiples|CollectTime|SendDate|RegisterDate|SendDepartment|SendtDoctor|SendDate|Note";
            string[] colNames = cols.Split(new char[] { '|' });
            string[] mapNames = maps.Split(new char[] { '|' });
            flexGrid.Columns.Clear();
            for (int i = 0; i < colNames.Length; i++)
            {
                Column column = new Column();
                column.Header = colNames[i];

                flexGrid.Columns.Add(column);
                flexGrid.AutoSizeColumn(i, 0);
            }
        }

        private void C1ToolbarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
