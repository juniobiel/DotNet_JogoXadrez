﻿using System;
using tabuleiro;

namespace Jogo_Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            Console.Write(tab.linhas);
        }
    }
}
