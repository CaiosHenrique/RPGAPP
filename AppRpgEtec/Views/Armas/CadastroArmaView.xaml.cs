using AppRpgEtec.ViewModels.Armas;

namespace AppRpgEtec.Views.Armas;

public partial class CadastroArma : ContentPage
{
	private CadastroArmaViewModel cadViewModel;

    public CadastroArma()
	{
		InitializeComponent();

		cadViewModel = new CadastroArmaViewModel();
        BindingContext = cadViewModel;
		Title = "Nova Arma";
    }
}