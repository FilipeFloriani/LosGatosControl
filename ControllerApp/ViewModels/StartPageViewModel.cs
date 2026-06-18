using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControllerApp.Models;
using ControllerApp.Repository;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace ControllerApp.ViewModels
{
    public partial class StartPageViewModel : ViewModelBase, IViewModel
    {
        MainWindowViewModel _mainVM;

        [ObservableProperty]
        private ObservableCollection<Consignment> consignments;

        [RelayCommand]
        public void CreateConsignment()
        {
            _mainVM.ShowCreateConsignmentView();
        }

        [RelayCommand]
        public void DeleteLocalConsignment(Consignment consignment)
        {
            Consignment.DeleteLocalConsignment(consignment);
            UpdateConsignments();
        }

        [RelayCommand]
        public void ViewConsignmentCommand(object param)
        {

        }

        public StartPageViewModel(MainWindowViewModel mainVM)
        {
            _mainVM = mainVM;

            UpdateConsignments();
        }

        private void UpdateConsignments()
        {
            Consignments = [.. Consignment.FindAllLocalConsignment()];
        }
    }
}
