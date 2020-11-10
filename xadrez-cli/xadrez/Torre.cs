using tabuleiro;

namespace xadrez {
    class Torre : Peca {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "T";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] tempMatriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao tempPosicao = new Posicao(0, 0);

            // acima
            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.Linha -= 1;
            }

            // abaixo
            tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.Linha += 1;
            }

            // direita
            tempPosicao.AlterarPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.Coluna += 1;
            }

            // esquerda
            tempPosicao.AlterarPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.Peca(tempPosicao) != null && Tabuleiro.Peca(tempPosicao).Cor != Cor) {
                    break;
                }
                tempPosicao.Coluna -= 1;
            }

            return tempMatriz;
        }
    }
}
