using Medicside.UriMeasure.Data.UrineMeasure;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIUriMeasure.ViewModels
{
   public class MeasureResultViewModels : BindableBase
    {
       

        //bool CanDoAction(object parameter)
        //{
        //    if (CurrentResult != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

       public DelegateCommand selectResultCommand
        { get; private set; }


        MeasureResultViewModels()
        {

            selectResultCommand = new DelegateCommand(selectResult);
        }
        void selectResult()
        {
        
        }
    }
}
