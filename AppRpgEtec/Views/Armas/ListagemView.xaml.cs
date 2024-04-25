using AppRpgEtec.ViewModels.Armas;

namespace AppRpgEtec.Views.Armas;

public partial class ListagemView : ContentPage
{
	ListagemArmaViewModel viewModel;
	public ListagemView()
	{
		viewModel = new ListagemArmaViewModel();
		InitializeComponent();
		BindingContext = viewModel;
        Title = "Armas - AppRpg";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = viewModel.ObterArmas();
    }
}