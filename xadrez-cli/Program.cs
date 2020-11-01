using System;
using tabuleiro;
using xadrez;
using xadrez_cli.xadrez;

namespace xadrez_cli {
    class Program {
        static void Main(string[] args) {
            PosicaoXadrez posicao = new PosicaoXadrez('a', 1);

            Console.WriteLine(posicao);

            Console.WriteLine(posicao.ConverterPosicao());
        }
    }
}
