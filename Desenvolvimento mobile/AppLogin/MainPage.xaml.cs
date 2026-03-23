namespace AppLogin
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {

            if ((txtUsuario.Text == UsuarioLogado.Instacia.login && txtSenha.Text == UsuarioLogado.Instacia.Senha) && !(string.IsNullOrEmpty(txtUsuario.Text) && string.IsNullOrEmpty(txtSenha.Text)))
            {
                // com o usuario e senha corretos podemos adicionar o login singleton 
                // significa uma variavel do tipo variante ou seja coringa 
                var usuarioLogado = UsuarioLogado.Instacia;

                // atribuindo valores ao atributos 
                usuarioLogado.login = txtUsuario.Text;


                //Chamada da nova tela 
                Application.Current.MainPage.Navigation.PushAsync(new pg());
            }
            else
            {
                //messagebox onde
                // Titulo, texto e botão
                DisplayAlert("Atenção!", "Usuário ou Senha inválidos.", "Ok");
            }
        }
        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {

            //Chamada da nova tela 
            Application.Current.MainPage.Navigation.PushAsync(new pgCadastroUsuario());


        }

        private void ckbMostrarSenha_Check(object sender, CheckedChangedEventArgs e)
        {
            txtSenha.IsPassword = !ckbMostrarSenha.IsChecked;
        }

        private void lblMostrarSenha_Tapped(object sender, TappedEventArgs e)
        {
            txtSenha.IsPassword = !ckbMostrarSenha.IsChecked;
        }
    }

}
