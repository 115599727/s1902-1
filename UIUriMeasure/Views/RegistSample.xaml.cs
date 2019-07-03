using C1.WPF;
using C1.WPF.FlexGrid;
using C1.WPF.Toolbar;
using CommonServiceLocator;
using Medicside.UriMeasure.Bussiness.Plant;
using Medicside.UriMeasure.Bussiness.UriMeasure;
using Medicside.UriMeasure.Data.UrineMeasure;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
        public RegistSampleBiz RegistSampleBiz { get; set; }

        public ObservableCollection<SampleItem> GridData { get; internal set; }

        public DelegateCommand SelectAllDelegateCommand { get; private set; }
       

        public RegistSample()
        {
            RegistSampleBiz = new RegistSampleBiz();
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


            cobAgeType.ItemsSource = PlantForm.Current.GetDictionaryData(DictionaryDataType.UrineMeasurePatientAgeType);
            cobAgeType.DisplayMemberPath = "Value";
            cobAgeType.SelectedValuePath = "ID";
            cobAgeType.SelectedIndex = 0;

            cobPatientType.ItemsSource = PlantForm.Current.GetDictionaryData(DictionaryDataType.UrineMeasurePatientType);
            cobPatientType.DisplayMemberPath = "Value";
            cobPatientType.SelectedValuePath = "ID";
            cobPatientType.SelectedIndex = 0;

            cobPatientNation.ItemsSource = PlantForm.Current.GetDictionaryData(DictionaryDataType.UrineMeasurePatientNations);
            cobPatientNation.DisplayMemberPath = "Value";
            cobPatientNation.SelectedValuePath = "ID";
            cobPatientNation.SelectedIndex = 0;

            //支付类型
            SetCombox(cobChargeTypes, DictionaryDataType.UrineMeasureChargeTypes);

            if(PlantForm.Current is PlantA)
            {
                rdbTypeM.Visibility = Visibility.Collapsed;
                rdbTypeCM.Visibility = Visibility.Hidden;
                rdbTypeC.IsChecked = true;
            }
            if (PlantForm.Current is PlantB)
            {
                rdbTypeC.Visibility = Visibility.Collapsed;
                rdbTypeCM.Visibility = Visibility.Collapsed;
                rdbTypeM.IsChecked = true;
            }

            var DateTimeFormatString=PlantForm.Current.DateTimeFormatString;
            cdpCollectTime.CustomFormat= DateTimeFormatString;            
            cdpRegistDate.CustomFormat = DateTimeFormatString;
            cdpSendDate.CustomFormat = DateTimeFormatString;
        }

        void SetCombox(C1ComboBox cobBox, DictionaryDataType type)
        {
            cobBox.ItemsSource = PlantForm.Current.GetDictionaryData(type);
            cobBox.DisplayMemberPath = "Value";
            cobBox.SelectedValuePath = "ID";
            cobBox.SelectedIndex = 0;
        }

        private void CheckAllAction()
        {
            if (ckbSelectAll.IsChecked == true)
            {
                foreach (var item in GridData)
                {
                    item.UISelected = true;

                }

            }
            else
            {
                foreach (var item in GridData)
                {
                    item.UISelected = false;
                }
            }

        }
        private void Execute(string CmdName)
        {
            
            
            if (CmdName.Equals("cmdDel"))
            {

                List<int> indexList = new List<int>();
                for (int i = GridData.Count - 1; i >= 0; i--)
                {
                    if (GridData[i].UISelected == true)
                    {
                        GridData.RemoveAt(i);
                    }
                }
                Medicside.UriMeasure.Bussiness.Recognition.BitmapReader.TestImageParser();

            }

            //执行检测
            if (CmdName.Equals("cmdTest"))
            {

                //foreach (var item in GridData)
                //{

                //    RegistSampleBiz.Measure(item);
                   
                //}

                GridData.Clear();


                PlantForm.Log.Info(Application.Current.Resources["UiUriMeasure.Register.Toolbar.Test"].ToString());
                //跳转到labelTitle == Resources["UiUriMeasure.Register.Toolbar.Test"].ToString()
                //var para = new NavigationParameters("Uri=ContactMainWindowView&Param=hello saylor");
                //async

                ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate("ContentRegion", "MeasureResult");
                return;


            }
        }
        private void FlexGrid_Initialized(object sender, EventArgs e)
        {
            flexGrid.AutoGenerateColumns = false;
            flexGrid.SelectionMode = C1.WPF.FlexGrid.SelectionMode.RowRange;

            string[] colNames = RegistSampleBiz.GridColNames;
            string[] mapNames = RegistSampleBiz.GridMapNames;
            flexGrid.Columns.Clear();
            for (int i = 0; i < colNames.Length; i++)
            {
                Column column = new Column();
                column.Header = colNames[i];
                column.ColumnName = mapNames[i];
                column.Binding = new Binding(mapNames[i]);
                flexGrid.Columns.Add(column);
                flexGrid.AutoSizeColumn(i, 0);
            }
            GridData = new ObservableCollection<SampleItem>(RegistSampleBiz.SampleList);
            flexGrid.ItemsSource = GridData;

            //var map = RegistSampleBiz.GrideHeadList;
            //int newindex = 0;
            //foreach (string keyitem in RegistSampleBiz.GridMapNames)
            //{
            //    var col=flexGrid.Columns[keyitem] ;
            //    col.ColumnName =map[keyitem] ;
            //    flexGrid.Columns.Move(col.Index, newindex);
            //    newindex++;
            //}

        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            flexGrid.AutoSizeColumns(0, 20 - 1, 10);
        }


        private void CkbSelectAll_Click(object sender, RoutedEventArgs e)
        {
            CheckAllAction();
        }

        private void FlexGrid_SelectedItemChanged(object sender, EventArgs e)
        {
            var selitem = (SampleItem)flexGrid.SelectedItem;
            DisplayItem(selitem);
         //   MessageBox.Show(selitem.ID.ToString());
        }

        private void DisplayItem(SampleItem selitem)
        {
            this.cdpCollectTime.SelectedDate = selitem.CollectTime;

        }

        private void BtnRegistSample_Click(object sender, RoutedEventArgs e)
        {
          

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
              SampleItem sitem = new SampleItem();
            sitem.CollectTime = DateTime.Now;
            this.GridData.Add(sitem);
        }

        
    }
}
