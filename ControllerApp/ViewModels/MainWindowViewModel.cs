namespace ControllerApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public string Greeting { get; } = "Welcome to Avalonia!";

        public IViewModel CurrentView { get; set; }


        public MainWindowViewModel()
        {
            CurrentView = new StartPageViewModel();
        }
    }
}
