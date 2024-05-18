using System;
using System.Collections.Generic;
using TesteDAndradeClassLibrary.Entidades;

namespace TesteDAndradeClassLibrary.Negocios
{
    public class AgendadorNegocios
    {
        public Conferencia Conferencia { get; private set; }

        public AgendadorNegocios()
        {
            Conferencia = new Conferencia();
        }

        public void AgendarPalestras(List<Palestra> palestras, IMensagemOutput mensagemOutput)
        {
            int trilhaCount = 1;
            while (palestras.Count > 0)
            {
                var trilha = new Trilha($"Trilha {trilhaCount++}");

                mensagemOutput.Escrever($"Agendando palestras para {trilha.Nome}...\n");

                AgendarPalestrasParaSessao(trilha.SessaoMatutina, palestras, mensagemOutput);
                AgendarPalestrasParaSessao(trilha.SessaoVespertina, palestras, mensagemOutput);

                mensagemOutput.EscreverLinha($"Trilha {trilha.Nome} agendada. Palestras Matutinas: {trilha.SessaoMatutina.Palestras.Count}, Palestras Vespertinas: {trilha.SessaoVespertina.Palestras.Count}\n");
                Conferencia.AdicionarTrilha(trilha);
            }
        }

        private void AgendarPalestrasParaSessao(Sessao sessao, List<Palestra> palestras, IMensagemOutput mensagemOutput)
        {
            for (int i = 0; i < palestras.Count; i++)
            {
                var palestra = palestras[i];
                if (sessao.AdicionarPalestra(palestra))
                {
                    mensagemOutput.EscreverLinha($"Palestra '{palestra.Titulo}' adicionada à sessão {sessao.HoraInicio}-{sessao.HoraFim}");
                    palestras.RemoveAt(i);
                    i--;
                }
                else
                {
                    mensagemOutput.EscreverLinha($"Palestra '{palestra.Titulo}' não cabe na sessão {sessao.HoraInicio}-{sessao.HoraFim}");
                }
            }
        }
    }
}
