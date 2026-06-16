using ControllerApp.Models;
using System.Collections.ObjectModel;

namespace ControllerApp.ViewModels
{
    public class StartPageViewModel : ViewModelBase, IViewModel
    {
        public ObservableCollection<Consignment> Consignments { get; set; } = [];

        public StartPageViewModel()
        {
              Consignments.Add(new Consignment { Code = "C001", Name = "Consignment 1" });
              Consignments.Add(new Consignment { Code = "C002", Name = "Consignment 2" });
              Consignments.Add(new Consignment { Code = "C003", Name = "Consignment 3" });
              Consignments.Add(new Consignment { Code = "C004", Name = "Consignment 4" });
              Consignments.Add(new Consignment { Code = "C005", Name = "Consignment 5" });
        }
    }
}
