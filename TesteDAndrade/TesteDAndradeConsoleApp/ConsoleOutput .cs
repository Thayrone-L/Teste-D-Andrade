using System;
using TesteDAndradeClassLibrary.Negocios;

namespace TesteDAndradeConsoleApp
{
    public class ConsoleOutput : IMensagemOutput
    {
        public void Escrever(string mensagem)
        {
            Console.Write(mensagem);
        }

        public void EscreverLinha(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}