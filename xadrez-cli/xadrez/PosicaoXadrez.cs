﻿using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez_cli.xadrez {
    class PosicaoXadrez {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha) {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ConverterPosicao() {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString() {
            return $"{Coluna}{Linha}";
        }
    }
}
