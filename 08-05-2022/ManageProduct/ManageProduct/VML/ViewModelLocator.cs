using ManageProduct.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProduct.VML
{
    public class ViewModelLocator
    {
        public AddDialogViewModel AddDialog => Ioc.Default.GetService<AddDialogViewModel>();
        public DeleteAllDialogViewModel DeleteAllDialog => Ioc.Default.GetService<DeleteAllDialogViewModel>();
        public DeleteDialogViewModel DeleteDialog => Ioc.Default.GetService<DeleteDialogViewModel>();
        public EdittingDialogViewModel EdittingDialog => Ioc.Default.GetService<EdittingDialogViewModel>();
        public MainPageViewModel MainPage => Ioc.Default.GetService<MainPageViewModel>();
        public ProductPageViewModel ProductPage => Ioc.Default.GetService<ProductPageViewModel>();
        public QRCodeDialogViewModel QRCodeDialog => Ioc.Default.GetService<QRCodeDialogViewModel>();
    }
}
