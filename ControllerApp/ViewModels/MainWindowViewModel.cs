using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControllerApp.Models;
using ControllerApp.Services;
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
            var result = await DialogService.ConfirmAsync(
                        "Deseja realmente atualizar a base local?");

            //await Consignment.UpdateLocalData();
            //ShowStartPageView();
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
