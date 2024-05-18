using System.Collections.Generic;
using Xunit;
using TesteDAndradeClassLibrary.Entidades;
using TesteDAndradeClassLibrary.Negocios;

namespace TesteDAndradeTest
{
    public class AgendadorTests
    {
        [Fact]
        public void TestarAgendamentoDePalestras()
        {
            List<Palestra> palestras = new List<Palestra>
            {
                new Palestra("Writing Fast Tests Against Enterprise .Net", 60),
                new Palestra("Overdoing it in Python", 45),
                new Palestra("Lua for the Masses", 30),
                new Palestra(".Net Errors from Mismatched Nuget Versions", 45),
                new Palestra("Common .Net Errors", 45),
                new Palestra("Python for .Net Developers", 0, true),
                new Palestra("Communicating Over Distance", 60),
                new Palestra("Accounting-Driven Development", 45),
                new Palestra("Woah", 30),
                new Palestra("Sit Down and Write", 30),
                new Palestra("Pair Programming vs Noise", 45),
                new Palestra(".Net Magic", 60),
                new Palestra(".Net Core: Why We Should Move On", 60),
                new Palestra("Clojure Ate Scala (on my project)", 45),
                new Palestra("Programming in the Boondocks of Seattle", 30),
                new Palestra(".Net vs. Clojure for Back-End Development", 30),
                new Palestra(".Net Core Legacy App Maintenance", 60),
                new Palestra("A World Without HackerNews", 30),
                new Palestra("User Interface CSS in .Net Apps", 30)
            };

            var consoleOutputMock = new ConsoleOutputMock();

            AgendadorNegocios agendadorNegocios = new AgendadorNegocios();
            agendadorNegocios.AgendarPalestras(palestras, consoleOutputMock);

            Assert.NotEmpty(agendadorNegocios.Conferencia.Trilhas);

            var trilha = agendadorNegocios.Conferencia.Trilhas[0];

            Assert.NotEmpty(trilha.SessaoMatutina.Palestras);
            Assert.NotEmpty(trilha.SessaoVespertina.Palestras);

            Assert.Contains(trilha.SessaoVespertina.Palestras, p => p.Titulo == "Python for .Net Developers" && p.Duracao == 5);
        }

        public class ConsoleOutputMock : IMensagemOutput
        {
            public List<string> Mensagens { get; } = new List<string>();

            public void Escrever(string mensagem)
            {
                Mensagens.Add(mensagem);
            }

            public void EscreverLinha(string mensagem)
            {
                Mensagens.Add(mensagem);
            }
        }
    }
}