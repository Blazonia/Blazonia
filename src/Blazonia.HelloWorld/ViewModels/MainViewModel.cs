using CommunityToolkit.Mvvm.ComponentModel;

namespace Blazonia.HelloWorld.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
}
