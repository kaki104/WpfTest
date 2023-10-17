using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismStep7.ViewModels
{
    /// <summary>
    /// Injection ViewModel
    /// </summary>
    public class InjectionViewModel : BindableBase
    {
        private DateTime _injectionDateTime;
        public DateTime InjectionDateTime
        {
            get { return _injectionDateTime; }
            set { SetProperty(ref _injectionDateTime, value); }
        }
        //기본 생성자
        public InjectionViewModel()
        {
            InjectionDateTime = DateTime.Now;
        }
    }
}
