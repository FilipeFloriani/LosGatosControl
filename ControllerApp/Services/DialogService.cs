using Avalonia.Controls;
using ControllerApp.ViewModels;
using ControllerApp.Views;
using System.Threading.Tasks;

namespace ControllerApp.Services;

public static class DialogService
{
    public static async Task<bool> ConfirmAsync(
        string message)
    {
        var tcs = new TaskCompletionSource<bool>();

        var dialog = new ConfirmationDialog
        {
            DataContext =
                new ConfirmationDialogViewModel(
                    message,
                    tcs)
        };

        dialog.Show();

        bool result = await tcs.Task;

        dialog.Close();

        return result;
    }
}