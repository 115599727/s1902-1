using Medicside.UriMeasure.Bussiness.UriMeasure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UIUriMeasure.ViewModels
{
  public  class RegistSampleViewModel : BindableBase, INavigationAware
    {
       
        public DelegateCommand NewSampleCommand { get; private set; }

        private RegistSampleBiz RegistSampleBiz;

        /// <summary>
        /// 稀释倍数
        /// </summary>
        private readonly CollectionView dilutionCollectionView;

        private readonly CollectionView sendDoctorsCollectionView;

        private readonly CollectionView sendDepartmentsCollectionView;

        public CollectionView DilutionCollectionView
        {
            get {
                return dilutionCollectionView;
                    }
        }
        public CollectionView SendDoctorsCollectionView
        {
            get
            {
                return sendDoctorsCollectionView;
            }
        }
        public CollectionView SendDepartmentsCollectionView
        {
            get
            {
                return sendDepartmentsCollectionView;
            }
        }

        public RegistSampleViewModel()
        {
            NewSampleCommand = new DelegateCommand(NewSample);
            RegistSampleBiz = new RegistSampleBiz();

            //this.datacon

            dilutionCollectionView = new CollectionView(RegistSampleBiz.GetDilutionItems());
            sendDoctorsCollectionView = new CollectionView(RegistSampleBiz.GetSendDoctors());
            sendDepartmentsCollectionView = new CollectionView(RegistSampleBiz.GetSendDepartments());
        }

        private void NewSample()
        {
            
        }

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }


        
        public int PpSampleNo { get; set; }

    }
}
