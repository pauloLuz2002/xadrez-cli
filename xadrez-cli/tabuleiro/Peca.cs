namespace tabuleiro {
    class Peca {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int Movimentos { get; set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Posicao posicao, Tabuleiro tabuleiro, Cor cor) {
            Posicao = posicao;
            Tabuleiro = tabuleiro;
            Cor = cor;
            Movimentos = 0;
        }
    }
}
