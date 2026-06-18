using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControllerApp.Models;
using ControllerApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerApp.ViewModels
{
    public partial class CreateConsignmentViewModel : ViewModelBase, IViewModel
    {
        MainWindowViewModel _mainVM;

        [ObservableProperty]
        private Consignment consignment;

        [RelayCommand]
        public void SaveConsignmentCommand()
        {
            Consignment.AddLocalConsignment(Consignment);
        }

        [RelayCommand]
        public void CancelCommand()
        {
            _mainVM.ShowStartPageView();
        }

        public CreateConsignmentViewModel(MainWindowViewModel mainVM)
        {
            _mainVM = mainVM;
            Consignment = new Consignment();
        }
    }
}
