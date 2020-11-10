using tabuleiro;

namespace xadrez {
    class Rei : Peca {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "R";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] tempMatriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao tempPosicao = new Posicao(0, 0);

            // acima
            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            // ne
            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            // direita
            tempPosicao.AlterarPosicao(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            // se
            tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            // abaixo
            tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            // so
            tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            // esquerda
            tempPosicao.AlterarPosicao(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            // no
            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(Posicao) && VerificarMovimento(Posicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            return tempMatriz;
        }
    }
}
