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
            Peca p = Tabuleiro.Peca(posicao);
            return p == null || p.Cor != Cor;
        }

        public void IncrementarMovimento() {
            Movimentos++;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = ObterMovimentosPossiveis();

            for (int i = 0; i < Tabuleiro.Linhas; i++) {
                for (int j = 0; j < Tabuleiro.Colunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool VerificarDestino(Posicao posicao) {
            return ObterMovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] ObterMovimentosPossiveis();
    }
}
