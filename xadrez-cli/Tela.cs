using tabuleiro;
using System;
using xadrez_cli.xadrez;
using xadrez;
using System.Collections.Generic;

namespace xadrez_cli {
    class Tela {
        public static void ImprimirPartida(Partida partida) {
            string corPecaJogador = partida.CorPecaJogador.ToString().ToLower();
            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno: {partida.Turno}");
            if (!partida.Terminada) {
                Console.WriteLine($"Vez das {corPecaJogador}s...");
                if (partida.Xeque) {
                    Console.WriteLine($"Rei da cor {corPecaJogador} está em xeque!");
                }
            } else {
                Console.WriteLine("XEQUE-MATE!");
                Console.WriteLine($"Vencedor: {corPecaJogador}s");
            }
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
                    Console.Write(", " + peca);
                }
                cont++;
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

        public static PosicaoXadrez LerPosicaoXadrez(Tabuleiro tabuleiro) {
            string s = Console.ReadLine();

            char coluna = s[0];
            string linha = s[1].ToString();

            if (!tabuleiro.ValidarPosicaoXadrez(coluna, linha)) {
                throw new TabuleiroException("Não foi possível ler a posição informada, digite algo como por exemplo: h2.");
            }

            return new PosicaoXadrez(coluna, int.Parse(linha));
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
