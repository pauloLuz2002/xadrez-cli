using tabuleiro;
using xadrez_cli.xadrez;

namespace xadrez {
    class Partida {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor CorPecaJogador { get; private set; }
        public bool Terminada { get; private set; }

        public Partida() {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            CorPecaJogador = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }

        private void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarMovimento();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
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
            if (Tabuleiro.Peca(origem).VerificarDestino(destino)) {
                throw new TabuleiroException("Posição de destino inválida, pois não está listada nos movimentos possíveis.");
            }
        }

        private void ColocarPecas() {
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).ConverterPosicao());

            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).ConverterPosicao());
        }
    }
}
