using C1.WPF.FlexGrid;
using C1.WPF.Toolbar;
using CommonServiceLocator;
using Medicside.UriMeasure.Bussiness.UriMeasure;
using Medicside.UriMeasure.Data.UrineMeasure;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// MeasureResult.xaml 的交互逻辑
    /// </summary>
    public partial class MeasureResult : UserControl
    {
        ObservableCollection<UrineTestResultItem> UrineTestResult;
        MeasureResultBiz measureResultBiz = new MeasureResultBiz();
        public MeasureResult()
        {
            InitializeComponent();

            foreach (var key in Resources.Keys)
            {
                var cmd = Resources[key] as C1ToolbarCommand;
                if (cmd != null)
                {
                    CommandManager.RegisterClassCommandBinding(GetType(), new CommandBinding(
                      cmd, (s, e) => Execute(key.ToString()), (s, e) => e.CanExecute = CanExecute));
                }
            }
            FlexGridSamples_Initialized();
            FlexGridResults_Initialized();

        }

        private void FlexGridResults_Initialized()
        {
            //this.flexGridSamples
            flexGridResults.AutoGenerateColumns = false;
            flexGridResults.SelectionMode = C1.WPF.FlexGrid.SelectionMode.RowRange;

            string[] colNames = measureResultBiz.GridResultColNames;
            string[] mapNames = measureResultBiz.GridResultMapNames;
            flexGridResults.Columns.Clear();
            for (int i = 0; i < colNames.Length; i++)
            {
                Column column = new Column();
                column.Header = colNames[i];
                column.ColumnName = mapNames[i];
                column.Binding = new Binding(mapNames[i]);
                flexGridResults.Columns.Add(column);
                flexGridResults.AutoSizeColumn(i, 0);
            }

            var list=new ObservableCollection<UrineTestResultItem>(measureResultBiz.GetUrineTestResultItems());
            flexGridResults.ItemsSource = list;
        }

        private void Execute(string CmdName)
        {
            if (CmdName.Equals("cmdFind"))
            {
                
            }
            if(CmdName.Equals("cmdEditResult"))
            {
                NavigationParameters par = new NavigationParameters();
                par.Add("result", CurrentResult);
                ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate("ContentRegion", "MeasureResultEdit",par);
                return;
            }
            if (CmdName.Equals("cmdDelResult"))
            {
                int SampleId = CurrentResult.SampleNo;
                measureResultBiz.DeleteResult(CurrentResult);

                SamplesList.Remove(CurrentResult);
               // flexGridSamples.ItemsSource=
            }

        }
        public List<UrineTestResult> SamplesList
        {
            get; set;

        }

        private void FlexGridSamples_Initialized()
        {
            //this.flexGridSamples
            flexGridSamples.AutoGenerateColumns = false;
            flexGridSamples.SelectionMode = C1.WPF.FlexGrid.SelectionMode.RowRange;

            string[] colNames = measureResultBiz.GridSampleColNames;
            string[] mapNames = measureResultBiz.GridSampleMapNames;
            flexGridSamples.Columns.Clear();
            for (int i = 0; i < colNames.Length; i++)
            {
                Column column = new Column();
                column.Header = colNames[i];
                column.ColumnName = mapNames[i];
                column.Binding = new Binding(mapNames[i]);
                flexGridSamples.Columns.Add(column);
                flexGridSamples.AutoSizeColumn(i, 0);
            }
            // GridData = new ObservableCollection<SampleItem>(measureResultBiz.SampleList);
            // flexGrid.ItemsSource = GridData;
            SamplesList=measureResultBiz.GetUrineTestResult();
            flexGridSamples.ItemsSource = new ObservableCollection<UrineTestResult>(SamplesList);

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            flexGridSamples.AutoSizeColumns(0, 11 - 1, 10);
        }

        private void FlexGridSamples_SelectedItemChanged(object sender, EventArgs e)
        {
            CurrentResult = flexGridSamples.SelectedItem as UrineTestResult;

            txtPaintName.Text = CurrentResult.PatientName;
            txtPaintSex.Text = CurrentResult.PatientSex;

            //txtPaintNation.Text = CurrentResult.Nation;

            txtPaintAge.Text = CurrentResult.PatientAge+CurrentResult.PatientAgeType;
            
            txtSampleNo.Text = CurrentResult.SampleNo.ToString();

            txtTubeNumber.Text = CurrentResult.TubeNumber.ToString();
            txtShelfNumber.Text = CurrentResult.ShelfNumber.ToString();
            txtPaintType.Text = CurrentResult.PatientType;
            txtSendDepartment.Text = CurrentResult.SendDepartment;
            txtDilution.Text = CurrentResult.DilutionMultiples.ToString();

            if (CurrentResult.TestType == "干化学+形态学")
            {
                UrineTestResult = new ObservableCollection<UrineTestResultItem>(CurrentResult.ChmResult);
                UrineTestResult.AddRange<UrineTestResultItem>(CurrentResult.MphResult);
            }

            flexGridResults.ItemsSource = UrineTestResult;
            
        }

        public UrineTestResult CurrentResult
        { get; set; }

        public bool CanExecute
        {
            get {
                if (CurrentResult is null)
                    return false;
                return true;
            } 
        }



    }
}
