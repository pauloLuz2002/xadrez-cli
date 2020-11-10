using tabuleiro;

namespace xadrez {
    class Bispo : Peca {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "B";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] tempMatriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao tempPosicao = new Posicao(0, 0);

            // NO
            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.AlterarPosicao(tempPosicao.Linha - 1, tempPosicao.Coluna - 1);
            }

            // NE
            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.AlterarPosicao(tempPosicao.Linha - 1, tempPosicao.Coluna + 1);
            }

            // SE
            tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.AlterarPosicao(tempPosicao.Linha + 1, tempPosicao.Coluna + 1);
            }

            // SO
            tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.AlterarPosicao(tempPosicao.Linha + 1, tempPosicao.Coluna - 1);
            }

            return tempMatriz;
        }
    }
}
