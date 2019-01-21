using System;

namespace JogoDasDamas
{
    class Black : Piece
    {
        public const char indicativo = (char)7;
        public Black(int linha, int coluna, Piece[,] tab) : base(linha, coluna, tab)
        {
            Color = ConsoleColor.Black;
        }
        public override string ToString()
        {   
                return "B";
        }
    }
}
