using System;

namespace JogoDasDamas
{
    class White : Piece
    {
        public White(int linha, int coluna, Piece[,] tab) : base(linha, coluna, tab)
        {
            Color = ConsoleColor.White;
        }
        public override string ToString()
        {
            return "W";
        }
    }
}
