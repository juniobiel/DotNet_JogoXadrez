using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);

            return p == null || p.cor != cor;
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);


            if(cor == Cor.Branca)
            {
                // acima
                pos.definirValores(posicao.linha - 1, posicao.coluna);

                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // acima na primeira jogada, mexe 2 casas
                pos.definirValores(posicao.linha - 2, posicao.coluna);

                if (tab.posicaoValida(pos) && podeMover(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // captura se houver inimigo na diagonal esquerda
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);

                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // captura se houver inimigo na diagonal direita
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);

                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // #jogadaespecial en passant
                if(posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);

                    if(tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);

                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }

            }
            else
            {
                // abaixo
                pos.definirValores(posicao.linha + 1, posicao.coluna);

                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // abaixo na primeira jogada, mexe 2 casas
                pos.definirValores(posicao.linha + 2, posicao.coluna);

                if (tab.posicaoValida(pos) && podeMover(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // captura se houver inimigo na diagonal esquerda
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);

                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // captura se houver inimigo na diagonal direita
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);

                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // #jogadaespecial en passant
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);

                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha + 1 , esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);

                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha + 1, direita.coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
