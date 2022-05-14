using Microsoft.Toolkit.Mvvm.DependencyInjection;
using MinhTamShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhTamShop.VML
{
    public class ViewModelLocator
    {
        public AddDialogViewModel AddDialog => Ioc.Default.GetService<AddDialogViewModel>();
        public DeleteDialogViewModel DeleteDialog => Ioc.Default.GetService<DeleteDialogViewModel>();
        public EditDialogViewModel EditDialog => Ioc.Default.GetService<EditDialogViewModel>();
        public MainPageViewModel MainPage => Ioc.Default.GetService<MainPageViewModel>();
        public StatusDialogViewModel StatusDialog => Ioc.Default.GetService<StatusDialogViewModel>();
    }
}
