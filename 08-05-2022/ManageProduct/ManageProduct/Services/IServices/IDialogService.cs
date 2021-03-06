using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ManageProduct.Service
{
    public interface IDialogService
    {
        Task showAsync(Type dialogViewModelType);
        Task showEditItemDialog();
        Task showDeleteAllDialog();
        Task showDeleteDialog();
        Task showQRCodeDialog();
    }
}
