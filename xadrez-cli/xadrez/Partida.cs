using System.Collections.Generic;
using tabuleiro;
using xadrez_cli.xadrez;

namespace xadrez {
    class Partida {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor CorPecaJogador { get; private set; }
        public bool Terminada { get; private set; }
        public HashSet<Peca> PecasJogo { get; private set; }
        public HashSet<Peca> PecasCapturadas { get; private set; }

        public Partida() {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            CorPecaJogador = Cor.Branca;
            Terminada = false;
            PecasJogo = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        private void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarMovimento();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);

            if (pecaCapturada != null) {
                PecasCapturadas.Add(pecaCapturada);
            }
        }

        private void MudaCorPeca() {
            if (CorPecaJogador == Cor.Branca) {
                CorPecaJogador = Cor.Preta;
            } else {
                CorPecaJogador = Cor.Branca;
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaCorPeca();
        }

        public void ValidarPosicaoOrigem(Posicao posicao) {
            if (Tabuleiro.Peca(posicao) == null) {
                throw new TabuleiroException("Posição informada não apresenta peça...");
            }
            if (CorPecaJogador != Tabuleiro.Peca(posicao).Cor) {
                throw new TabuleiroException("Posição informada contém peça de outro jogador...");
            }
            if (!Tabuleiro.Peca(posicao).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não existe movimentos possíveis para peça informada...");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino) {
            if (!Tabuleiro.Peca(origem).VerificarDestino(destino)) {
                throw new TabuleiroException("Posição de destino inválida, pois não está listada nos movimentos possíveis.");
            }
        }

        public HashSet<Peca> ObterPecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in PecasCapturadas) {
                if (peca.Cor == cor) {
                    aux.Add(peca);
                }
            }
            return aux;
        }

        public HashSet<Peca> DistinguirPecasJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in PecasJogo) {
                if (peca.Cor == cor) {
                    aux.Add(peca);
                }
            }
            aux.ExceptWith(ObterPecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ConverterPosicao());
            PecasJogo.Add(peca);
        }

        private void ColocarPecas() {
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta));
        }
    }
}
