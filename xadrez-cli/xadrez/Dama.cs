using tabuleiro;

namespace xadrez {
    class Dama : Peca {
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "D";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] tempMatriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao tempPosicao = new Posicao(0, 0);

            // esquerda
            tempPosicao.AlterarPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.AlterarPosicao(tempPosicao.Linha, tempPosicao.Coluna - 1);
            }

            // direita
            tempPosicao.AlterarPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.AlterarPosicao(tempPosicao.Linha, tempPosicao.Coluna + 1);
            }

            // acima
            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.AlterarPosicao(tempPosicao.Linha - 1, tempPosicao.Coluna);
            }

            // abaixo
            tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.AlterarPosicao(tempPosicao.Linha + 1, tempPosicao.Coluna);
            }

            // NO
            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.AlterarPosicao(tempPosicao.Linha - 1, tempPosicao.Coluna - 1);
            }

            // SE
            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.AlterarPosicao(tempPosicao.Linha - 1, tempPosicao.Coluna + 1);
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
