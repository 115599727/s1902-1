using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;
using Prism.Ioc;
using Prism.Unity;
using log4net;
using Medicside.UriMeasure.Bussiness;
using WpfApp1Metro.Views;
using Medicside.UriMeasure.Bussiness.Plant;

namespace WpfApp1Metro
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        public static readonly ILog Log = LogManager.GetLogger("RollingLogFileAppender");
       
        public override void Initialize()
        {

            base.Initialize();

        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //this.r
        }
        
        protected override Window CreateShell()
        {
            //创建检测类型
            PlantForm.GetInstance(Log,PlantMeasureType.TypeBMorphplogy);
            PlantForm.Log.Info("Start UriMeasure");
            return Container.Resolve<MainWindow>();

        }
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new ConfigurationModuleCatalog();
        //}
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<UITestModule.ViewTestModule>();
            moduleCatalog.AddModule < UIUriMeasure.UIUriMeasureViewModule> ();

        }
    }
}
