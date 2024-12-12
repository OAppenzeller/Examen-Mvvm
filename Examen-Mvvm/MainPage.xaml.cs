using Examen_Mvvm.ViewModel;

namespace Examen_Mvvm;

public partial class MainPage : ContentPage
{
    public MainPage(DescuentoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
