﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MinhTamShop.Service
{
    public interface IDialogService
    {
        Task showAsync(Type dialogViewModelType);
    }
}
