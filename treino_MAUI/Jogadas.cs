using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using PCLExt;


namespace treino_MAUI
{
    public class Jogadas

    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nome { get; set; }

        public DateTime horario { get; set; }

        public string aposta { get; set; } 

        public string resultado_Moeda { get; set; }

        public string resultado_Jogador { get; set; }

        public int Pontuação { get; set; }

    }


}
