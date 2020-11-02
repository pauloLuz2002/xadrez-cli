using System;
using tabuleiro;
using xadrez;

namespace xadrez_cli {
    class Program {
        static void Main(string[] args) {
            try {
                Partida partida = new Partida();
                while (!partida.Terminada) {
                    try {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro);

                        Console.WriteLine();

                        Console.WriteLine($"Turno: {partida.Turno}");
                        Console.WriteLine($"Aguardando jogador que controla as peças de cor {partida.CorPecaJogador.ToString().ToLower()}...");

                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ConverterPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).ObterMovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ConverterPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    } catch (TabuleiroException e) {
                        Console.WriteLine($"{e.Message} Pressione ENTER para continuar.");
                        Console.ReadLine();
                    }
                }
            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
