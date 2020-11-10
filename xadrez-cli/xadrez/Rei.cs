using tabuleiro;

namespace xadrez {
    class Rei : Peca {
        private Partida Partida;

        public Rei(Tabuleiro tabuleiro, Cor cor, Partida partida) : base(tabuleiro, cor) {
            Partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        private bool TestarTorreRoque(Posicao posicao) {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca != null && peca is Torre && peca.Cor == Cor && peca.Movimentos == 0;
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

            // roque
            if (Movimentos == 0 && !Partida.Xeque) {
                // roque pequeno
                Posicao pt1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TestarTorreRoque(pt1)) {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null) {
                        tempMatriz[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // roque grande
                Posicao pt2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TestarTorreRoque(pt2)) {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null) {
                        tempMatriz[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return tempMatriz;
        }
    }
}
