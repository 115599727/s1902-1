using C1.WPF.FlexGrid;
using C1.WPF.Toolbar;
using Medicside.UriMeasure.Bussiness.UriMeasure;
using Medicside.UriMeasure.Data.UrineMeasure;
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
                      cmd, (s, e) => Execute(key.ToString()), (s, e) => e.CanExecute = true));
                }
            }
            FlexGridSamples_Initialized();
        }

        private void Execute(string CmdName)
        {
            if (CmdName.Equals("cmdFind"))
            {

            }
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






        }
    }
}
