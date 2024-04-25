using AppRpgEtec.ViewModels.Personagens;
using AppRpgEtec.Views.Personagens;
using AppRpgEtec.Views.Armas;

namespace AppRpgEtec
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("cadPersonagemView", typeof(CadastroPesonagemView));
            Routing.RegisterRoute("cadArmaView", typeof(CadastroArma));

            string login = Preferences.Get("UsuarioUsername", string.Empty);
            lblLogin.Text = $"Login: {login}";
        }
    }
}
