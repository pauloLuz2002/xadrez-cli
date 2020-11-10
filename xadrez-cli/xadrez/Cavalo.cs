using tabuleiro;

namespace xadrez {
    class Cavalo : Peca {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "C";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] tempMatriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao tempPosicao = new Posicao(0, 0);

            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            tempPosicao.AlterarPosicao(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            tempPosicao.AlterarPosicao(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            tempPosicao.AlterarPosicao(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            tempPosicao.AlterarPosicao(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(tempPosicao) && VerificarMovimento(tempPosicao)) {
                tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }

            return tempMatriz;
        }
    }
}
