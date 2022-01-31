using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor){}

        public override string ToString()
        {
            return "B";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);

            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // acima a esquerda
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);

            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;

                pos.definirValores(pos.linha - 1, pos.coluna - 1);
            }

            // abaixo a esquerda
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);

            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;

                pos.definirValores(pos.linha + 1, pos.coluna - 1);
            }


            // acima a direita
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);

            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;

                pos.definirValores(pos.linha - 1, pos.coluna + 1);
            }

            // abaixo a direita
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);

            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;

                pos.definirValores(pos.linha + 1, pos.coluna + 1);
            }


            return mat;
        }
    }
}
