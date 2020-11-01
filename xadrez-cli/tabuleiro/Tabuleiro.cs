using tabuleiro;

namespace tabuleiro {
    class Tabuleiro {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas { get; private set; }

        public Tabuleiro(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public bool ExistePeca(Posicao posicao) {
            ValidarPosicao(posicao);
            return Pecas[posicao.Linha, posicao.Coluna] != null;
        } 

        public void ColocarPeca(Peca peca, Posicao posicao) {
            if (ExistePeca(posicao)) {
                throw new TabuleiroException($"Já existe uma peça nesse lugar... ({posicao.Linha},{posicao.Coluna})");
            }
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public Peca RetirarPeca(Posicao posicao) {
            if (Pecas[posicao.Linha, posicao.Coluna] == null) {
                return null;
            }
            Peca aux = Pecas[posicao.Linha, posicao.Coluna];
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

        public void ValidarPosicao(Posicao posicao) {
            if  (!PosicaoValida(posicao)) {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}