namespace AppLogin
{
	public partial class pgPrincipal : ContentPage
	{
		public pgPrincipal()
		{
			InitializeComponent();

		

		}
		private void btnVoltar_Clicked(object sender, EventArgs e)
		{
			//Aplicar o POP
			// Removendo a tela atual da pilha 

			Application.Current.MainPage.Navigation.PopAsync();
		}
	} 
}	//Recuperar o usuario logado salvo na classe singleton 
			//crio a variavel que recebe a instancia 
			var usuarioLogado = UsuarioLogado.Instacia;
			lblUsuario.Text = "Nome: " + usuarioLogado.Nome + ", seja bem vindo";
			lblLogin.Text = "Login: " + usuarioLogado.login;
			lblDataNascimento.Text = "Data de nascimento: " + usuarioLogado.DataDeNascimento;
			lblSenha.Text = "A sua senha é: " + usuarioLogado.S; 
