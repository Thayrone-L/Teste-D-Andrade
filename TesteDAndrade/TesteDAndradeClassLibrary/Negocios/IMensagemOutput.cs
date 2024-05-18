using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDAndradeClassLibrary.Negocios
{
    public interface IMensagemOutput
    {
        void Escrever(string mensagem);
        void EscreverLinha(string mensagem);
    }
}
