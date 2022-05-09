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
        public CardPageViewModel CardPage => Ioc.Default.GetService<CardPageViewModel>();
        public DocumentPageViewModel DocumentPage => Ioc.Default.GetService<DocumentPageViewModel>();
        public EmailPageViewModel EmailPage => Ioc.Default.GetService<EmailPageViewModel>();
        public EmptyPageViewModel EmptyPage => Ioc.Default.GetService<EmptyPageViewModel>();
        public FacebookPageViewModel FacebookPage => Ioc.Default.GetService<FacebookPageViewModel>();
        public MainPageViewModel MainPage => Ioc.Default.GetService<MainPageViewModel>();
        public PhonePageViewModel PhonePage => Ioc.Default.GetService<PhonePageViewModel>();
        public SMSPageViewModel SMSPage => Ioc.Default.GetService<SMSPageViewModel>();
        public WebsitePageViewModel WebsitePage => Ioc.Default.GetService<WebsitePageViewModel>();
        public WifiPageViewModel WifiPage => Ioc.Default.GetService<WifiPageViewModel>();
    }
}
