using System;

namespace tabuleiro {
    abstract class Peca {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int Movimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) {
            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            Movimentos = 0;
        }

        protected bool VerificarMovimento(Posicao posicao) {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public void IncrementarMovimento() {
            Movimentos++;
        }

        public void DecrementarMovimento() {
            Movimentos--;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();

            for (int i = 0; i < Tabuleiro.Linhas; i++) {
                for (int j = 0; j < Tabuleiro.Colunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool ObterMovimentosPossiveis(Posicao posicao) {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
