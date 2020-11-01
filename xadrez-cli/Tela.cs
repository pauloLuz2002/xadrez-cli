﻿using tabuleiro;
using System;

namespace xadrez_cli {
    class Tela {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {
            for (int i = 0; i < tabuleiro.Linhas; i++) {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Colunas; j++) {
                    if (tabuleiro.Pecas[i,j] == null) {
                        Console.Write("- ");
                    } else {
                        ImprimirPeca(tabuleiro.Pecas[i, j]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca) {
            if (peca.Cor == Cor.Branca) {
                Console.Write($"{peca} ");
            } else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{peca} ");
                Console.ForegroundColor = aux;
            }
        }
    }
}
