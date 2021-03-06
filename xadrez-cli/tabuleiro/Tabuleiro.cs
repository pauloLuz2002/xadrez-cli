﻿namespace tabuleiro {
    class Tabuleiro {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca Peca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }

        public Peca Peca(Posicao posicao) {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public bool ExistePeca(Posicao posicao) {
            ValidarPosicao(posicao);
            return Peca(posicao) != null;
        }

        public void ColocarPeca(Peca peca, Posicao posicao) {
            if (ExistePeca(posicao)) {
                throw new TabuleiroException($"Já existe uma peça nesse lugar... ({posicao.Linha},{posicao.Coluna})");
            }
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public Peca RetirarPeca(Posicao posicao) {
            if (Peca(posicao) == null) {
                return null;
            }
            Peca aux = Peca(posicao);
            aux.Posicao = null;
            Pecas[posicao.Linha, posicao.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao posicao) {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas) {
                return false;
            }
            return true;
        }

        public bool ValidarPosicaoXadrez(char coluna, string linha) {
            if (!(coluna >= 'a' && coluna <= 'h')) {
                return false;
            }
            if (!int.TryParse(linha, out int linhaInt)) {
                return false;
            }
            if (!(linhaInt >= 1 && linhaInt <= 8)) {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao) {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas) {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}