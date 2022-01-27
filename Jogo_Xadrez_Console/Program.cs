using System;
using tabuleiro;
using xadrez;

namespace Jogo_Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez pos = new PosicaoXadrez('e', 5);

            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosicao());

            Console.ReadLine();
        }
    }
}
