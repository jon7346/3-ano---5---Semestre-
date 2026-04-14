using SQLite;
using PCLExt;
using PCLExt.FileStorage.Folders;
namespace treino_MAUI
{
    /*
         -Campo para informar o nome do jogador
    -Pontuação
    -Botão Reiniciar: Ao clicar será resetada a pontuação e a solicitação de um novo Jogador
    -Imagem referente a moeda
    -Opção de escolha do usuário (Cara ou Coroa)
    -Botão Jogar: Ao clicar no botão jogar, gerar um resultado randômico e salvar o resultado no banco de dados
    -Label com o resultado da moeda (Cara ou Coroa)
    -Label com o resultado da jogada (Ganhou ou Perdeu)
    -Perdeu: alterar o text da label para "Perdeu!" e deixar a cor do texto em vermelho
    -Ganhou: alterar o text da label para "Ganhou!" e deixar a cor do texto em verde
    -Lista com as jogas e seus resultados
    Lista de Jogadas:
    -Nome do Jogador
    -Data e Hora da Jogada
    -Aposta do Jogador (Cara ou Coroa)
    -Resultado da Jogada (Cara ou Coroa)
    -Resultado da Jogada (Ganhou Perdeu)
    -Pontuação (Pontuação atual do Jogador)
    Regras de Jogo:
    -Jogador Inicia com 10 pontos
    -Ganhou aumenta um ponto na pontuação do Jogador
    -Perdeu remove um ponto da pontuação do Jogador
     */
    public partial class MainPage : ContentPage
    {

        int pontuação = 10;
        SQLiteConnection conexao;

        
        public SQLiteConnection GetConnection()
        {

            var pastaRaiz = new LocalRootFolder();

            var arquivoBD =
                pastaRaiz.CreateFile(
                    "oraculo", PCLExt.FileStorage.
                        CreationCollisionOption.OpenIfExists);


            return new SQLiteConnection(arquivoBD.Path);
        }
        void AtualizarListView()
        {
            //Realizar uma consulta na tabela Pessoa
            //correspondendo a query:
            //SELECT * FROM Pessoa
            Histórico.ItemsSource =
                conexao.Table<Jogadas>().ToList();
        }


        public MainPage()
        {
            InitializeComponent();
            conexao = GetConnection();

            //Mapear a tabela do banco com o objeto
            //Ou seja a tabela será criada/atualizada
            //espelhando o objeto
            //neste caso iremos utilizar o objeto Pessoa
            //Similar ao CREATE TABLE e ao ALTER TABLE
            conexao.CreateTable<Jogadas>();

            //Carrego a listView
            AtualizarListView();
        }



        public string RandomSorteio() 
        {
            int numero = 0;

            Random random = new Random();

            numero = random.Next(1, 3);

            if (numero == 1)
            {
                return "Cara"; 
            }
            else
            { 
                return "Coroa"; 
            }
                

        }
      
        public string ValidarAposta()
        {
            
            if (Escolha.SelectedIndex == -1)
            {
                DisplayAlert("Erro", "por favor selecione cara ou coroa.", "OK");

                return null ;
            }
            else
            {
                return Escolha.SelectedItem.ToString();
            }
        }
       

        public void reiniciar(string nome) 
        {

            var command = conexao.CreateCommand($"DELETE from Jogadas where Jogadas.nome = '{nome}' ");

            pontuação = 10;

            command.ExecuteNonQuery();
        }
  
        private void btnGirarClicked(object sender, EventArgs e)
        {
            Sorteio.Text = "";
           

            if (ValidarAposta() != null)
            {
                string item = ValidarAposta();
                string Resultado = RandomSorteio();
                Sorteio.Text = Resultado;
                
                
                
                
                if (Resultado == item)
                {
                    pontuação++;
                    Jogadas Atual = new Jogadas();
                    Atual.nome = NomeUsuario.Text;
                    Atual.horario = DateTime.Now;
                    Atual.aposta = item;
                    Atual.Pontuação = pontuação;
                    Atual.resultado_Jogador = "Acertouu!";
                    Atual.resultado_Moeda = Resultado;

                    txtResultado.Text = "Acertou!";

                    conexao.Insert(Atual);
                    AtualizarListView();
                }
                else
                {
                    pontuação--;
                    Jogadas Atual = new Jogadas();
                    Atual.nome = NomeUsuario.Text;
                    Atual.horario = DateTime.Now;
                    Atual.aposta = item;
                    Atual.Pontuação = pontuação;
                    Atual.resultado_Jogador = "Errou!";
                    Atual.resultado_Moeda = Resultado;

                    txtResultado.Text = "Errou!";
;
                    conexao.Insert(Atual);
                    AtualizarListView();
                  
                }
            }
         
            
        }

        private void btnReiniciarClicked(object sender, EventArgs e)
        {
            reiniciar(NomeUsuario.Text);
            AtualizarListView();
        }
    }

}
