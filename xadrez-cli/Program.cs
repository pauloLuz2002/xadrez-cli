using System;
using tabuleiro;

namespace xadrez_cli {
    class Program {
        static void Main(string[] args) {
            Posicao p = new Posicao(3, 4);

            Console.WriteLine("Posição: " + p);
        }
    }
}
