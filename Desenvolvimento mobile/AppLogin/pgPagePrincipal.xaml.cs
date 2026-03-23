namespace AppLogin;

public partial class NewPage1 : ContentPage
{
    public NewPage1()
    {
        InitializeComponent();

        lblDataNascimento.Text = UsuarioLogado

    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PopAsync();
    }
}