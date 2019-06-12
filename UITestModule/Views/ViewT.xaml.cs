using log4net;
using Medicside.UriMeasure.Bussiness;
using Prism.Commands;
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
using C1.WPF.FlexGrid;
using Medicside.UriMeasure.Bussiness.Plant;

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
    }
}
