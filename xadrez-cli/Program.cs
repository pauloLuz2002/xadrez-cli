using System;
using tabuleiro;
using xadrez;

namespace xadrez_cli {
    class Program {
        static void Main(string[] args) {
            try {
                Partida partida = new Partida();

                while (!partida.Terminada) {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.Write("\nOrigem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ConverterPosicao();

                    bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).ObterMovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ConverterPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }
            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
