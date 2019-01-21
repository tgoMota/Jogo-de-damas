namespace JogoDasDamas
{
    class Position
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Position(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
    }
}
