using System;
using tabuleiro;
using xadrez;

namespace Jogo_Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();

            while(!partida.terminada)
            {
                Console.Clear();
                Tela.imprimirTabuleiro(partida.tab);

                Console.Write("Origem: ");
                Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                Console.Write("Destino: ");
                Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                partida.executaMovimento(origem, destino);
            }

            

            Console.ReadLine();
        }
    }
}
