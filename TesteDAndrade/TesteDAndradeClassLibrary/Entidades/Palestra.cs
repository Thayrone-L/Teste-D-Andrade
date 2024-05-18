using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDAndradeClassLibrary.Entidades
{
    public class Palestra
    {
        public string Titulo { get; set; }
        public int Duracao { get; set; } 

        public Palestra(string titulo, int duracao, bool eRelampago = false)
        {
            Titulo = titulo;
            Duracao = eRelampago ? 5 : duracao;
        }
    }
}
