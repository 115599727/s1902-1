using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using UITestModule.Views;

namespace UITestModule
{
    /// <summary>
    /// ViewTest.xaml 的交互逻辑
    /// </summary>
    public  class ViewTestModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewT));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
