using Avalonia.Controls;
using ControllerApp.ViewModels;
using System;

namespace ControllerApp.Views;

public partial class ConfirmationDialog : Window
{
    public ConfirmationDialog()
    {
        InitializeComponent();
    }

    protected override void OnDataContextChanged(EventArgs e)
    {
        base.OnDataContextChanged(e);

        if (DataContext is ConfirmationDialogViewModel vm)
        {
            vm.PropertyChanged += (_, _) =>
            {
            };
        }
    }
}