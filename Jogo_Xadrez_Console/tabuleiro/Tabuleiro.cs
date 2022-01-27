namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        //construtor de tabuleiro
        public Tabuleiro(int linhas, int colunas) 
        {
            this.linhas = linhas;
            this.colunas = colunas;

            pecas = new Peca[linhas, colunas];
        }
        
        //instancia uma peça em uma determinada posição
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        //sobrecarga do método
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        //verifica se existe peça na posição
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        //Coloca peça na posição
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
                throw new TabuleiroException("Já existe uma peça nessa posição");

            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        //Verifica se existe posição válida
        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }

            return true;
        }

        //Lança exeção
        public void validarPosicao(Posicao pos)
        {
            if(!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida");
            }
        }

    }
}
