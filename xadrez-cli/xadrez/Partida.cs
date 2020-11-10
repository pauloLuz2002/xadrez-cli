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
        public bool Xeque { get; private set; }

        public Partida() {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            CorPecaJogador = Cor.Branca;
            Terminada = false;
            Xeque = false;
            PecasJogo = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        private Peca ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarMovimento();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);

            if (pecaCapturada != null) {
                PecasCapturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }

        private void MudaCorPeca() {
            if (CorPecaJogador == Cor.Branca) {
                CorPecaJogador = Cor.Preta;
            } else {
                CorPecaJogador = Cor.Branca;
            }
        }

        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca peca = Tabuleiro.RetirarPeca(destino);
            peca.DecrementarMovimento();
            if (pecaCapturada != null) {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(peca, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (ValidaPosicaoXeque(CorPecaJogador)) {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Não é possível colocar-se em posição de xeque!");
            }

            if (ValidaPosicaoXeque(IdentificarCorAdversaria(CorPecaJogador))) {
                Xeque = true;
            } else {
                Xeque = false;
            }

            if (ValidaXequeMate(IdentificarCorAdversaria(CorPecaJogador))) {
                Terminada = true;
            } else {
                Turno++;
                MudaCorPeca();
            }
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
            if (!Tabuleiro.Peca(origem).ObterMovimentosPossiveis(destino)) {
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

        public HashSet<Peca> ObterPecasJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in PecasJogo) {
                if (peca.Cor == cor) {
                    aux.Add(peca);
                }
            }
            aux.ExceptWith(ObterPecasCapturadas(cor));
            return aux;
        }

        private Cor IdentificarCorAdversaria(Cor cor) {
            if (cor == Cor.Branca) {
                return Cor.Preta;
            }
            return Cor.Branca;
        }

        private Peca IdentificarRei(Cor cor) {
            foreach (Peca peca in ObterPecasJogo(cor)) {
                if (peca is Rei) {
                    return peca;
                }
            }
            return null;
        }

        public bool ValidaPosicaoXeque(Cor cor) {
            Peca r = IdentificarRei(cor);
            if (r == null) {
                throw new TabuleiroException($"Rei da cor {cor} não está no tabuleiro...");
            }
            foreach (Peca peca in ObterPecasJogo(IdentificarCorAdversaria(cor))) {
                bool[,] tempMat = peca.MovimentosPossiveis();
                if (tempMat[r.Posicao.Linha, r.Posicao.Coluna]) {
                    return true;
                }
            }
            return false;
        }

        public bool ValidaXequeMate(Cor cor) {
            if (!ValidaPosicaoXeque(cor)) {
                return false;
            }
            foreach (Peca peca in ObterPecasJogo(cor)) {
                bool[,] tempMat = peca.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++) {
                    for (int j = 0; j < Tabuleiro.Colunas; j++) {
                        if (tempMat[i, j]) {
                            Posicao origem = peca.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool xeque = ValidaPosicaoXeque(cor);
                            DesfazerMovimento(origem, destino, pecaCapturada);
                            if (!xeque) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ConverterPosicao());
            PecasJogo.Add(peca);
        }

        private void ColocarPecas() {
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('h', 7, new Torre(Tabuleiro, Cor.Branca));

            ColocarNovaPeca('a', 8, new Rei(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('b', 8, new Torre(Tabuleiro, Cor.Preta));
        }
    }
}
