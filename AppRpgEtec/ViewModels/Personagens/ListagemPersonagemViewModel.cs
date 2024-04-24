using AppRpgEtec.Models;
using AppRpgEtec.Services.Personagens;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Personagens
{
    class ListagemPersonagemViewModel : BaseViewModel
    {
        private PersonagemService _pService;
        public ObservableCollection<Personagem> Personagens { get; set; }
        public ListagemPersonagemViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            _pService = new PersonagemService(token);
            Personagens = new ObservableCollection<Personagem>();

            // descarte do retorno
            _ = ObterPesonagens();

            RemoverPersonagemCommand = new Command<Personagem>(async (p) => { await RemoverPersonagem(p); });
            NovoPersonagem = new Command(async() => { await ExibirCadastroPersonagem(); });
        }

        public ICommand RemoverPersonagemCommand { get; }
        public ICommand NovoPersonagem { get; set; }

        public async Task ObterPesonagens()
        {
            try
            {
                Personagens = await _pService.GetPersonagensAsync();
                OnPropertyChanged(nameof(Personagens));
            }
            catch (Exception ex) 
            {
                await Application.Current.MainPage
                        .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task ExibirCadastroPersonagem()
        {
            try
            {
                await Shell.Current.GoToAsync("cadPersonagemView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                        .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        private Personagem _personagemSelecionado;
        public Personagem PersonagemSelecionado
        {
            get => _personagemSelecionado;
            set
            {
                if (value != null)
                {
                    _personagemSelecionado = value;
                    Shell.Current.GoToAsync($"cadPersonagemView?pId={_personagemSelecionado.Id}");
                }
            }
        }

        public async Task RemoverPersonagem(Personagem p)
        {
            try
            {
                if(await Application.Current.MainPage.DisplayAlert("Atenção", "Deseja realmente excluir o personagem?", "Sim", "Não"))
                {
                    await _pService.DeletePersonagemAsync(p.Id);
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Personagem excluído com sucesso", "Ok");
                    _ = ObterPesonagens();
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage
                        .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
