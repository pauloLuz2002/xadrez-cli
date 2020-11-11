using tabuleiro;

namespace xadrez {
    class Peao : Peca {
        private Partida Partida;

        public Peao(Tabuleiro tabuleiro, Cor cor, Partida partida) : base(tabuleiro, cor) {
            Partida = partida;
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

                // en passant
                if (Posicao.Linha == 3) {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && VerificaInimigo(esquerda) && Tabuleiro.Peca(esquerda) == Partida.PecaEnPassant) {
                        tempMatriz[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && VerificaInimigo(direita) && Tabuleiro.Peca(direita) == Partida.PecaEnPassant) {
                        tempMatriz[direita.Linha - 1, direita.Coluna] = true;
                    }
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

                // en passant
                if (Posicao.Linha == 4) {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && VerificaInimigo(esquerda) && Tabuleiro.Peca(esquerda) == Partida.PecaEnPassant) {
                        tempMatriz[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && VerificaInimigo(direita) && Tabuleiro.Peca(direita) == Partida.PecaEnPassant) {
                        tempMatriz[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return tempMatriz;
        }
    }
}
