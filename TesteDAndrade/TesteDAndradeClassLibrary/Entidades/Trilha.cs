using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDAndradeClassLibrary.Entidades
{
    public class Trilha
    {
        public string Nome { get; set; }
        public Sessao SessaoMatutina { get; set; }
        public Sessao SessaoVespertina { get; set; }

        public Trilha(string nome)
        {
            Nome = nome;
            SessaoMatutina = new Sessao(new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0));
            SessaoVespertina = new Sessao(new TimeSpan(13, 0, 0), new TimeSpan(17, 0, 0));
        }

        public TimeSpan GetHorarioEventoNetworking()
        {
            TimeSpan fimUltimaPalestra = new TimeSpan(16, 0, 0);
            if (SessaoVespertina.Palestras.Any())
            {
                fimUltimaPalestra = SessaoVespertina.HoraInicio + TimeSpan.FromMinutes(SessaoVespertina.Palestras.Sum(p => p.Duracao));
            }
            return fimUltimaPalestra < new TimeSpan(16, 0, 0) ? new TimeSpan(16, 0, 0) : fimUltimaPalestra;
        }
    }
}
