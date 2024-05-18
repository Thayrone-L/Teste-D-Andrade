using System;
using System.Collections.Generic;
using TesteDAndradeClassLibrary.Entidades;
using TesteDAndradeClassLibrary.Negocios;
using TesteDAndradeConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        string arquivo;

        //caminho do arquivo de teste ..\..\..\..\Agenda.txt

        while (true)
        {
            Console.WriteLine("Por favor, insira o caminho do arquivo de entrada:");
            arquivo = Console.ReadLine();

            if (System.IO.File.Exists(arquivo))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
                Console.WriteLine("Deseja tentar novamente? (S/N)");

                string resposta = Console.ReadLine().Trim().ToUpper();

                if (resposta != "S")
                {
                    return; 
                }
            }
        }

        string[] linhas = System.IO.File.ReadAllLines(arquivo);
        List<Palestra> palestras = new List<Palestra>();

        foreach (string linha in linhas)
        {
            string[] partes = linha.Split(' ');
            int duracao;
            if (partes.Length < 2 || (!int.TryParse(partes[partes.Length - 1], out duracao) && partes[partes.Length - 1] != "relâmpago"))
            {
                Console.WriteLine($"Formato inválido na linha: {linha}. Ignorando esta palestra.");
                continue;
            }

            string titulo = string.Join(" ", partes, 0, partes.Length - 1);

            if (partes[partes.Length - 1] == "relâmpago")
            {
                palestras.Add(new Palestra(titulo, 0, true));
            }
            else
            {
                palestras.Add(new Palestra(titulo, duracao));
            }
        }

        var consoleOutput = new ConsoleOutput();

        AgendadorNegocios agendadorNegocios = new AgendadorNegocios();
        agendadorNegocios.AgendarPalestras(palestras, consoleOutput);

        foreach (var trilha in agendadorNegocios.Conferencia.Trilhas)
        {
            Console.WriteLine(trilha.Nome + ":");

            TimeSpan currentTime = trilha.SessaoMatutina.HoraInicio;
            foreach (var palestra in trilha.SessaoMatutina.Palestras)
            {
                Console.WriteLine($"{currentTime:hh\\:mm} {palestra.Titulo} {palestra.Duracao}min");
                currentTime = currentTime.Add(TimeSpan.FromMinutes(palestra.Duracao));
            }

            Console.WriteLine("12:00 Almoço");

            currentTime = trilha.SessaoVespertina.HoraInicio;
            foreach (var palestra in trilha.SessaoVespertina.Palestras)
            {
                Console.WriteLine($"{currentTime:hh\\:mm} {palestra.Titulo} {palestra.Duracao}min");
                currentTime = currentTime.Add(TimeSpan.FromMinutes(palestra.Duracao));
            }

            Console.WriteLine($"{trilha.GetHorarioEventoNetworking():hh\\:mm} Networking Event\n");
        }
    }
}
