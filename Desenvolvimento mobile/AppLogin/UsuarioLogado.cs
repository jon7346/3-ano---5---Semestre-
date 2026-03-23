namespace AppLogin
{
    // Teremos uma classe singleton 
    // responsável por armazenar os dados utilizados durante o login 

    // Uma classe singleton é uma classe de uma única instância (hávera sempre um objeto, o qual pode ter seus valores sobrescritos)
    // Para transformar uma classe em singleton é preciso usar o termo sealed
    public sealed class UsuarioLogado
    {
        // Para que ela funcione é necessário criar uma variavél para que a mesma seja armazenada e acessada na memoria 
        //Uso de _ é para identificar variaveis do tipo private 
        static UsuarioLogado _instancia;

        public static UsuarioLogado Instacia
        {
            get
            {

                if (_instancia is null)
                {
                    return (_instancia = new UsuarioLogado());
                }
                else
                {
                    return _instancia;
                }
                //or return _intancia ?? (_instancia = new UsuarioLogado());   
            }
            // Daqui pra cima é apenas a definição de um classe singleton, senod todas iguais (no capo acima claro)




        }
        public UsuarioLogado() { }

        public string login { get; set; }

        public string Nome { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
