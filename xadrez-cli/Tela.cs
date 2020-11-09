using tabuleiro;
using System;
using xadrez_cli.xadrez;
using xadrez;
using System.Collections.Generic;

namespace xadrez_cli {
    class Tela {
        public static void ImprimirPartida(Partida partida) {
            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno: {partida.Turno}");
            Console.WriteLine($"Aguardando jogada do jogador que controla as peças de cor {partida.CorPecaJogador.ToString().ToLower()}...");
        }

        private static void ImprimirPecasCapturadas(Partida partida) {
            Console.WriteLine("Pecas capturadas: ");

            Console.Write("Brancas: ");
            ImprimirConjunto(partida.ObterPecasCapturadas(Cor.Branca));

            Console.WriteLine();

            Console.Write("Pretas: ");

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            ImprimirConjunto(partida.ObterPecasCapturadas(Cor.Preta));

            Console.ForegroundColor = aux;

            Console.WriteLine();
        }

        private static void ImprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            int cont = 0;
            foreach (Peca peca in conjunto) {
                if (cont == 0) {
                    Console.Write(peca);
                } else {
                    Console.Write(peca + " ");
                }
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {
            for (int i = 0; i < tabuleiro.Linhas; i++) {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Colunas; j++) {
                    ImprimirPeca(tabuleiro.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis) {
            ConsoleColor fundo = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.Linhas; i++) {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Colunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    } else {
                        Console.BackgroundColor = fundo;
                    }
                    ImprimirPeca(tabuleiro.Peca(i, j));
                    Console.BackgroundColor = fundo;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundo;
        }

        public static PosicaoXadrez LerPosicaoXadrez() {
            try {
                string s = Console.ReadLine();
                char coluna = s[0];
                int linha = int.Parse(s[1].ToString());
                return new PosicaoXadrez(coluna, linha);
            } catch (Exception) {
                throw new TabuleiroException("Não foi possível ler a posição informada, digite algo como por exemplo: h2.");
            }
        }

        public static void ImprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("- ");
            } else {
                if (peca.Cor == Cor.Branca) {
                    Console.Write(peca);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
