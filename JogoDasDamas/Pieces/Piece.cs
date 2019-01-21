using System;

namespace JogoDasDamas
{
    class Piece
    {
        public Position Pos { get; set; }
        public bool isLady { get; set; }
        public ConsoleColor Color { get; set; }
        public Piece[,] Tab { get; set; }
        public bool [,] Moves { get; set; }
        public bool canEat { get; set; }
        public bool ateNow { get; set; }

        public Piece(int linha, int coluna, Piece[,] tab)
        {
            Pos = new Position(linha, coluna);
            Tab = tab;
            isLady = false;
            ateNow = false;
            canEat = false;
        }

        public Piece()
        {

        }

        public bool isMyTurn(bool blackTurn)
        {
            if (blackTurn && Color == ConsoleColor.Black || !blackTurn && Color == ConsoleColor.White)
                return true;
            else
                return false;
        }

        public void possibleMoves()
        {
            Menu.isMove = true;
            //canEat = false;
            int movesTrue = 0; //movimentos possiveis
            int l = Pos.Linha;
            int c = Pos.Coluna;

            Moves = new bool[8, 8];

            if (Color == ConsoleColor.White || isLady) // SE
            {
                int i = l + 1; //linha
                int j = c + 1; //coluna
                bool isThereADifPiece = false ;
                if (isLady)
                {
                    int k = i;
                    int g = j;
                    while (true)
                    {
                        if (k < 0 || g < 0 || k > 7 || g > 7)
                            break;

                        if (Tab[k, g] != null && Tab[k,g].Color != Color)
                        {
                            isThereADifPiece = true;
                            break;
                        }
                        ++k;
                        ++g;
                    }
                }

                while (true)
                {
                    if (isLady && isThereADifPiece)
                        break;
                    if (i < 0 || j < 0 || i > 7 || j > 7)
                        break;

                    if (Tab[i, j] == null)
                    {
                        Moves[i, j] = true;
                        movesTrue++;
                        if (!isLady)
                            break;
                    }

                    if (Tab[i, j] != null && Tab[i, j].Color == Color)
                        break;

                    ++i;
                    ++j;
                    if (!isLady)
                        break;

                }
            }

            if (Color == ConsoleColor.White || isLady) // SW
            {
                int i = l + 1; //linha
                int j = c - 1; //coluna
                bool isThereADifPiece = false;
                if (isLady)
                {
                    int k = i;
                    int g = j;
                    while (true)
                    {
                        if (k < 0 || g < 0 || k > 7 || g > 7)
                            break;

                        if (Tab[k, g] != null && Tab[k, g].Color != Color)
                        {
                            isThereADifPiece = true;
                            break;
                        }
                        ++k;
                        ++g;
                    }
                }
                while (true)
                {
                    if (isLady && isThereADifPiece)
                        break;

                    if (i < 0 || j < 0 || i > 7 || j > 7)
                        break;

                    if (Tab[i, j] == null)
                    {
                        Moves[i, j] = true;
                        movesTrue++;
                        if(!isLady)
                            break;
                    }

                    if (Tab[i, j] != null && Tab[i, j].Color == Color)
                        break;

                    ++i;
                    --j;
                    if(!isLady)
                        break;
                }
            }

            if (Color == ConsoleColor.Black || isLady) // NE
            {
                int i = l - 1; //linha
                int j = c + 1; //coluna
                bool isThereADifPiece = false;
                if (isLady)
                {
                    int k = i;
                    int g = j;
                    while (true)
                    {
                        if (k < 0 || g < 0 || k > 7 || g > 7)
                            break;

                        if (Tab[k, g] != null && Tab[k, g].Color != Color)
                        {
                            isThereADifPiece = true;
                            break;
                        }
                        ++k;
                        ++g;
                    }
                }
                while (true)
                {
                    if (isLady && isThereADifPiece)
                        break;

                    if (i < 0 || j < 0 || i > 7 || j > 7)
                        break;

                    if (Tab[i, j] == null)
                    {
                        Moves[i, j] = true;
                        movesTrue++;
                        if (!isLady)
                            break;
                    }

                    if (Tab[i, j] != null && Tab[i, j].Color == Color)
                        break;

                    --i;
                    ++j;
                    if (!isLady)
                        break;
                }
            }

            if (Color == ConsoleColor.Black || isLady) // NW
            {
                int i = l - 1; //linha
                int j = c - 1; //coluna
                bool isThereADifPiece = false;
                if (isLady)
                {
                    int k = i;
                    int g = j;
                    while (true)
                    {
                        if (k < 0 || g < 0 || k > 7 || g > 7)
                            break;

                        if (Tab[k, g] != null && Tab[k, g].Color != Color)
                        {
                            isThereADifPiece = true;
                            break;
                        }
                        ++k;
                        ++g;
                    }
                }
                while (true)
                {
                    if (isLady && isThereADifPiece)
                        break;

                    if (i < 0 || j < 0 || i > 7 || j > 7)
                        break;

                    if (Tab[i, j] == null)
                    {
                        Moves[i, j] = true;
                        movesTrue++;
                        if (!isLady)
                            break;
                    }

                    if (Tab[i, j] != null && Tab[i, j].Color == Color)
                        break;

                    --i;
                    --j;
                    if (!isLady)
                        break;
                }
            }
            if (movesTrue == 0 && !canEat) //não há movimentos possiveis //cancela movimento
                Menu.isMove = false;
        }
    }
}
