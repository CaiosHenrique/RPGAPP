using AppRpgEtec.ViewModels.Personagens;

namespace AppRpgEtec.Views.Personagens;

public partial class ListagemView : ContentPage
{
	
	ListagemPersonagemViewModel viewModel;
	public ListagemView()
	{
		viewModel = new ListagemPersonagemViewModel();
		InitializeComponent();
		BindingContext = viewModel;
		Title = "Personagens - AppRpg";
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_ = viewModel.ObterPesonagens();
    }
}