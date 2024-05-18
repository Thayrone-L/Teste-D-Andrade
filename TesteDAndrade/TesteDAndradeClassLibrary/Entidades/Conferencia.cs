using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDAndradeClassLibrary.Entidades
{
    public class Conferencia
    {
        public List<Trilha> Trilhas { get; set; }

        public Conferencia()
        {
            Trilhas = new List<Trilha>();
        }

        public void AdicionarTrilha(Trilha trilha)
        {
            Trilhas.Add(trilha);
        }
    }
}
