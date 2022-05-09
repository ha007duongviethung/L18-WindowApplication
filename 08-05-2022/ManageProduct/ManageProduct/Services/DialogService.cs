using ManageProduct.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ManageProduct.Service
{
    public class DialogService : IDialogService
    {
        private Dictionary<Type, Type> _dialogs;
        public Dictionary<Type, Type> Dialogs => _dialogs ?? (_dialogs = new Dictionary<Type, Type>());
        public DialogService(Dictionary<Type, Type> dialogs)
        {
            _dialogs = dialogs;
        }
        public DialogService()
        {

        }
        public async Task showAsync(Type dialogViewModelType)
        {
            var dialog = Activator.CreateInstance(Dialogs[dialogViewModelType]) as ContentDialog;
            await dialog.ShowAsync();
        }

        public async Task showEditItemDialog()
        {
            EditingDialog editingDialog = new EditingDialog();
            await editingDialog.ShowAsync();
        }

        public async Task showDeleteAllDialog()
        {
            DeleteAllDialog deleteAllDialog = new DeleteAllDialog();
            await deleteAllDialog.ShowAsync();
        }

        public async Task showDeleteDialog()
        {
            DeleteDialog deleteDialog = new DeleteDialog();
            await deleteDialog.ShowAsync();
        }

        public async Task showQRCodeDialog()
        {
            QRCodeDialog qRCodeDialog = new QRCodeDialog();
            await qRCodeDialog.ShowAsync();
        }
    }
}
