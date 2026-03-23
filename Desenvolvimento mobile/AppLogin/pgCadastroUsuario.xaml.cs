namespace AppLogin;

public partial class pgCadastroUsuario : ContentPage
{
    public pgCadastroUsuario()
    {
        InitializeComponent();
    }

    private void btnCadastrar(object sender, EventArgs e)
    {
        if (
            !(string.IsNullOrEmpty(txtEmail.Text)
            && string.IsNullOrEmpty(txtLogin.Text)
            && string.IsNullOrEmpty(txtNome.Text)
            && string.IsNullOrEmpty(txtSenha.Text))
            )
        {

            var usuarioLogado = UsuarioLogado.Instacia;

            // atribuindo valores ao atributos 
            usuarioLogado.login = txtLogin.Text;

            usuarioLogado.Email = txtEmail.Text;

            usuarioLogado.Senha = txtSenha.Text;

            try
            {
                usuarioLogado.DataDeNascimento = DateTime.Parse(DataNascimento.Text);
            }
            catch
            {

                DisplayAlert("Atenção!", "Preencha de maneira adequada o campo data de nascimento, com o formato de data valido", "Ok");
                return;
            }
            Application.Current.MainPage.Navigation.PopAsync();
        }
        else
        {
            DisplayAlert("Atenção!", "Preencha todos os campos!!", "Ok");
        }

    }
}