using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;

namespace ControllerApp.ViewModels;

public partial class ConfirmationDialogViewModel : ViewModelBase
{
    private readonly TaskCompletionSource<bool> _tcs;

    [ObservableProperty]
    private string message;

    public ConfirmationDialogViewModel(
        string message,
        TaskCompletionSource<bool> tcs)
    {
        Message = message;
        _tcs = tcs;
    }

    [RelayCommand]
    public void YesCommand()
    {
        _tcs.SetResult(true);
    }

    [RelayCommand]
    public void NoCommand()
    {
        _tcs.SetResult(false);
    }
}