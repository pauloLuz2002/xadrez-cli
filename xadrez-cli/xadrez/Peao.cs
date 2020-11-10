using tabuleiro;

namespace xadrez {
    class Peao : Peca {
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "P";
        }
        
        private bool VerificaInimigo(Posicao posicao) {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool VerificaEspacoVazio(Posicao posicao) {
            return Tabuleiro.Peca(posicao) == null;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] tempMatriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao tempPosicao = new Posicao(0, 0);

            if (Cor == Cor.Branca) {
                tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(tempPosicao) && VerificaEspacoVazio(tempPosicao)) {
                    tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                }

                tempPosicao.AlterarPosicao(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(tempPosicao) && VerificaEspacoVazio(tempPosicao) && Movimentos == 0) {
                    tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                }

                tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(tempPosicao) && VerificaInimigo(tempPosicao)) {
                    tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                }
 
                tempPosicao.AlterarPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(tempPosicao) && VerificaInimigo(tempPosicao)) {
                    tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                }
            } else {
                tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(tempPosicao) && VerificaEspacoVazio(tempPosicao)) {
                    tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                }

                tempPosicao.AlterarPosicao(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(tempPosicao) && VerificaEspacoVazio(tempPosicao) && Movimentos == 0) {
                    tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                }

                tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(tempPosicao) && VerificaInimigo(tempPosicao)) {
                    tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                }

                tempPosicao.AlterarPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(tempPosicao) && VerificaInimigo(tempPosicao)) {
                    tempMatriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                }
            }

            return tempMatriz;
        }
    }
}
