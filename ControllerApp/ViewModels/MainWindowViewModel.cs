using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControllerApp.Models;
using System.Threading.Tasks;

namespace ControllerApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private IViewModel currentView;

        public MainWindowViewModel()
        {
            ShowStartPageView();
        }

        [RelayCommand]
        public async Task ResetBaseCommand()
        {
            await Consignment.UpdateLocalData();
            ShowStartPageView();
        }

        [RelayCommand]
        public async Task CommitToRemoteBaseCommand()
        {
            await Consignment.CommitToRemoteBase();
        }

        public void ShowStartPageView()
        {
            CurrentView = new StartPageViewModel(this);
        }

        public void ShowCreateConsignmentView()
        {
            CurrentView = new CreateConsignmentViewModel(this);
        }
    }
}
