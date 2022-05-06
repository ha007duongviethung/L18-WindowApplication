using IQRCode.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQRCode.VML
{
    public class ViewModelLocator
    {
        public MainPageViewModel MainPage => Ioc.Default.GetService<MainPageViewModel>();
    }
}
