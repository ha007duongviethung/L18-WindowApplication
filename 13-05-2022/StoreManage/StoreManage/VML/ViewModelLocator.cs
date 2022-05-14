using Microsoft.Toolkit.Mvvm.DependencyInjection;
using StoreManage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManage.VML
{
    public class ViewModelLocator
    {
        public MainPageViewModel MainPage => Ioc.Default.GetService<MainPageViewModel>();
    }
}
