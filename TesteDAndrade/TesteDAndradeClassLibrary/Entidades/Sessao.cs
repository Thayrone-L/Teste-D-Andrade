using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDAndradeClassLibrary.Entidades
{
    public class Sessao
    {
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public List<Palestra> Palestras { get; set; }

        public Sessao(TimeSpan horaInicio, TimeSpan horaFim)
        {
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Palestras = new List<Palestra>();
        }

        public bool AdicionarPalestra(Palestra palestra)
        {
            int duracaoTotal = 0;
            foreach (var p in Palestras)
            {
                duracaoTotal += p.Duracao;
            }

            if (duracaoTotal + palestra.Duracao <= (HoraFim - HoraInicio).TotalMinutes)
            {
                Palestras.Add(palestra);
                Console.WriteLine($"Palestra '{palestra.Titulo}' adicionada à sessão.");
                return true;
            }

            Console.WriteLine($"Palestra '{palestra.Titulo}' não cabe na sessão.");
            return false;
        }

        public TimeSpan CalcularTempoRestante()
        {
            int duracaoTotal = 0;
            foreach (var p in Palestras)
            {
                duracaoTotal += p.Duracao;
            }
            return HoraFim - HoraInicio - TimeSpan.FromMinutes(duracaoTotal);
        }
    }
}
