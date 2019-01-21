using System;
using System.Threading;

namespace JogoDasDamas
{
    class GameBoard
    {
        public Piece[,] Pieces { get; set; }
        public int remainingW { get; set; }
        public int remainingB { get; set; }
        public bool[,] requiredMoves { get; set; }
        public bool thereIsARequiredMoveW { get; set; }
        public bool thereIsARequiredMoveB { get; set; }
        public bool blackTurn { get; set; } //indica se a vez é das brancas(false)/pretas(true)

        public GameBoard()
        {
            Pieces = new Piece[8, 8];
            remainingB = 12; //12 peças pretas
            remainingW = 12; //12 peças brancas
            thereIsARequiredMoveW = false;
            thereIsARequiredMoveB = false;
        }

        public void initializeBoard()
        {
            Console.Clear();
            Menu.title();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                              Initializing Game Board.");
            Console.WriteLine("                                         37% ");
            Console.WriteLine();
            Console.WriteLine();
            Menu.version();
            Thread.Sleep(800);
            Console.Clear();

            Menu.title();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                              Initializing Game Board..");
            Console.WriteLine("                                         74% ");
            Console.WriteLine();
            Console.WriteLine();
            Menu.version();
            Thread.Sleep(800);
            Console.Clear();

            Menu.title();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                              Initializing Game Board...");
            Console.WriteLine("                                         100% ");
            Console.WriteLine();
            Console.WriteLine();
            Menu.version();
            Thread.Sleep(800);
            Console.Clear();

            Menu.positionX = 28; //extremo inicial X do tabuleiro (cursor)
            Menu.positionY = 10; //extremo inicial Y do tabuleiro (cursor)
            Menu.Round = 1;

            int w = 0, b = 0;
            for(int i = 0; i < 8; ++i)
            {
                for(int j = 0; j < 8; ++j)
                {
                    if(i < 3) // White Pieces
                    {
                        if(w % 2 != 0)
                            Pieces[i, j] = new White(i, j, Pieces);
                        ++w;
                    }
                    if(i > 4) // Black Pieces
                    {
                        if(b % 2 != 0)
                            Pieces[i, j] = new Black(i, j, Pieces);
                        ++b;
                    }
                }
                --w;
                --b;
            }
        }

        public void printBoard()
        {
            int k = 9; //coluna do cursor
            Console.SetCursorPosition(25, k);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   A  B  C  D  E  F  G  H  ");
            for (int i = 0; i < 8; ++i)
            {
                ++k;
                Console.SetCursorPosition(25, k);
                Console.Write(i + 1 + " ");
                Console.ResetColor();
                for (int j = 0; j < 8; ++j)
                {   
                    if(Menu.isMove && Menu.PieceMoving.Moves[i,j] && !Menu.PieceMoving.canEat && Menu.showPossibleMoves|| requiredMoves[i,j] && Menu.showPossibleMoves)
                    {
                        if (!Menu.PieceMoving.canEat && Menu.PieceMoving.Moves[i, j])
                            Console.BackgroundColor = ConsoleColor.Blue;
                        if (requiredMoves[i,j])
                            Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        if ((i + j) % 2 == 0)
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        else
                            Console.BackgroundColor = ConsoleColor.DarkGray;

                        if (Menu.isMove && Menu.PieceMoving.Pos.Linha == i && Menu.PieceMoving.Pos.Coluna == j)
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }

                    if (Pieces[i, j] != null)
                    {
                        if (!Pieces[i, j].isLady)
                            Console.ForegroundColor = Pieces[i, j].Color;
                        else
                            Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.Write(" " + Pieces[i, j].ToString() + " ");
                    }
                    else
                        Console.Write("   ");

                }
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public void movePiece()
        {
            int posj = (Menu.positionX - 28) / 3; //0 - 7 i
            int posi = Menu.positionY - 10; // 0 - 7 j
            int posAntigai = Menu.PieceMoving.Pos.Linha;
            int posAntigaj = Menu.PieceMoving.Pos.Coluna;

            if (Menu.PieceMoving.Moves[posi, posj] && !Menu.PieceMoving.canEat && Menu.everEat || Menu.PieceMoving.Moves[posi, posj] && !Menu.everEat || requiredMoves[posi, posj] && Math.Abs(posi - posAntigai) == Math.Abs(posj - posAntigaj))
            {
                Menu.PieceMoving.Pos.Linha = posi;
                Menu.PieceMoving.Pos.Coluna = posj;

                Pieces[posi, posj] = Menu.PieceMoving;
                Pieces[posAntigai, posAntigaj] = null;
                Pieces[posi, posj].ateNow = false;

                if (Math.Abs(posi - posAntigai) == 2 && Math.Abs(posj - posAntigaj) == 2 && !Pieces[posi,posj].isLady)
                {
                    int removei = (posi + posAntigai) / 2; //posição i,j da peça inimiga a ser destruida
                    int removej = (posj + posAntigaj) / 2;

                    if (Pieces[removei, removej].Color == ConsoleColor.Black)
                        remainingB--;
                    else
                        remainingW--;

                    Pieces[removei, removej] = null;
                    Pieces[posi, posj].ateNow = true;
                    Pieces[posi, posj].canEat = false;
                    Console.Beep();
                }
                else //se for dama e for movimento obrigatorio
                {
                    if(Pieces[posi,posj].isLady && requiredMoves[posi, posj] && Math.Abs(posi - posAntigai) == Math.Abs(posj - posAntigaj))
                    { //procurando a peça a ser destruida //todos os sentidos NW NE SW SE
                        int deltaI = posi - posAntigai;
                        int deltaJ = posj - posAntigaj;

                        if(deltaI < 0 && deltaJ < 0) //NW
                        {
                            int l = posAntigai - 1;
                            int c = posAntigaj - 1;
                            while (true)
                            {
                                if (Pieces[l, c] != null && Pieces[l, c].Color != Pieces[posi, posj].Color)//encontrou a peça
                                {
                                    if (Pieces[l, c].Color == ConsoleColor.Black)
                                        remainingB--;
                                    else
                                        remainingW--;
                                    Pieces[l, c] = null;//destruindo a peça
                                    break;
                                }
                                --l;
                                --c;
                            }
                        }

                        if(deltaI < 0 && deltaJ > 0) // NE
                        {
                            int l = posAntigai - 1;
                            int c = posAntigaj + 1;
                            while (true)
                            {
                                if (Pieces[l, c] != null && Pieces[l, c].Color != Pieces[posi, posj].Color)//encontrou a peça
                                {
                                    if (Pieces[l, c].Color == ConsoleColor.Black)
                                        remainingB--;
                                    else
                                        remainingW--;

                                    Pieces[l, c] = null;//destruindo a peça
                                    break;
                                }
                                --l;
                                ++c;
                            }
                        }

                        if(deltaI > 0 && deltaJ < 0) //SW
                        {
                            int l = posAntigai + 1;
                            int c = posAntigaj - 1;
                            while (true)
                            {
                                if (Pieces[l, c] != null && Pieces[l, c].Color != Pieces[posi, posj].Color)//encontrou a peça
                                {
                                    if (Pieces[l, c].Color == ConsoleColor.Black)
                                        remainingB--;
                                    else
                                        remainingW--;
                                    Pieces[l, c] = null;//destruindo a peça
                                    break;
                                }
                                ++l;
                                --c;
                            }
                        }

                        if(deltaI > 0 && deltaJ > 0) //SE
                        {
                            int l = posAntigai + 1;
                            int c = posAntigaj + 1;
                            while (true)
                            {
                                if (Pieces[l, c] != null && Pieces[l, c].Color != Pieces[posi, posj].Color)//encontrou a peça
                                {
                                    if (Pieces[l, c].Color == ConsoleColor.Black)
                                        remainingB--;
                                    else
                                        remainingW--;
                                    Pieces[l, c] = null; //destruindo a peça
                                    break;
                                }
                                ++l;
                                ++c;
                            }
                        }

                        Pieces[posi, posj].ateNow = true;
                        Pieces[posi, posj].canEat = false;
                        Console.Beep();
                    }
                }
                Menu.isMove = false;
                checkRequiredMoves();
                if (!Pieces[posi, posj].canEat || Pieces[posi, posj].canEat && !Pieces[posi, posj].ateNow)
                    Menu.Round++;
            }
            else
            {
                Menu.isMove = false;
            }
            Menu.counter = 1;
            if (Menu.PieceMoving.Color == ConsoleColor.Black && Menu.PieceMoving.Pos.Linha == 0)
                Menu.PieceMoving.isLady = true;
            if(Menu.PieceMoving.Color == ConsoleColor.White && Menu.PieceMoving.Pos.Linha == 7)
                Menu.PieceMoving.isLady = true; //transformando em dama
        }   


        public void remainingPieces()
        {
            Console.SetCursorPosition(55, 12);
            Console.WriteLine("--------------------");
            Console.SetCursorPosition(55, 13);
            Console.Write("|    Black: ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" " + remainingB + " ");
            if (remainingB < 10)
                Console.Write(" ");
            Console.ResetColor();
            Console.WriteLine("   |");
            Console.SetCursorPosition(55, 14);
            Console.Write("|    White: ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" " + remainingW + " ");
            if(remainingW < 10)
                Console.Write(" ");
            Console.ResetColor();
            Console.WriteLine("   |");
            Console.SetCursorPosition(55, 15);
            Console.WriteLine("--------------------");
        }

        public void showRoundNumber()
        {
            int nRound;
            if (Menu.Round % 2 == 0)
                nRound = Menu.Round / 2;
            else
                nRound = (Menu.Round / 2) + 1;

            Console.SetCursorPosition(9, 12);
            Console.WriteLine("-------------");
            Console.SetCursorPosition(9, 13);
            Console.Write("| ROUND:");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" " + nRound + " ");
            Console.ResetColor();
            Console.WriteLine(" |");
            Console.SetCursorPosition(9, 14);
            Console.WriteLine("-------------");
            Console.SetCursorPosition(7, 16);

            if (blackTurn)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("BLACK PLAYS! ");
            }
            else
            {
                Console.Write("WHITE PLAYS! ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("  ");
            }
            Console.ResetColor();
        }

        public void isThereAWinner()
        {
            if (remainingB == 0 || remainingW == 0)
            {
                Console.SetCursorPosition(28, 22);
                Console.WriteLine("WINNER WINNER CHICKEN DINNER!");
                Console.SetCursorPosition(28, 23);

                if (remainingB == 0)
                    Console.WriteLine("    The Blacks wins");

                if (remainingW == 0)
                    Console.WriteLine("    The Whites wins");

                Console.SetCursorPosition(28, 25);
                Console.WriteLine("Pressione alguma tecla para voltar ao menu...");
                Console.ReadLine();
                Menu.Display();
            }
        }

        public void checkRequiredMoves()
        {
            int movesTrueW = 0;
            int movesTrueB = 0;

            requiredMoves = new bool[8, 8];

            for (int l = 0; l < 8; ++l)
            {
                for (int c = 0; c < 8; ++c)
                {
                    if (Pieces[l, c] != null)
                        Pieces[l, c].canEat = false;

                    if (!Menu.eatBack)
                    {
                        if (Pieces[l, c] != null && Pieces[l, c].Color == ConsoleColor.White && !blackTurn || Pieces[l,c] != null && Pieces[l,c].isLady && Pieces[l,c].isMyTurn(blackTurn)) // SE
                        {
                            int i = l + 1; //linha
                            int j = c + 1; //coluna
                            int piecesFounds = 0;

                            while (true)
                            {
                                if (i < 0 || j < 0 || i > 7 || j > 7)
                                    break;

                                if (Pieces[i, j] == null && !Pieces[l,c].isLady)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color == Pieces[l, c].Color)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color != Pieces[l, c].Color)
                                {
                                    int a = i + 1;
                                    int b = j + 1;
                                    if (piecesFounds > 0)
                                        break;
                                    ++piecesFounds;

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] == null)
                                    {
                                        requiredMoves[a, b] = true; //movimento obrigatório
                                        movesTrueW++;
                                        Pieces[l, c].canEat = true;
                                        if (!Pieces[l, c].isLady)
                                            break;
                                    }

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] != null)
                                        break;
                                }
                                ++i;
                                ++j;

                            }
                        }

                        if (Pieces[l, c] != null && Pieces[l, c].Color == ConsoleColor.White && !blackTurn || Pieces[l, c] != null && Pieces[l, c].isLady && Pieces[l, c].isMyTurn(blackTurn)) // SW
                        {
                            int i = l + 1; //linha
                            int j = c - 1; //coluna
                            int piecesFounds = 0;
                            while (true)
                            {
                                if (i < 0 || j < 0 || i > 7 || j > 7)
                                    break;

                                if (Pieces[i, j] == null && !Pieces[l,c].isLady)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color == Pieces[l, c].Color)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color != Pieces[l, c].Color)
                                {
                                    int a = i + 1;
                                    int b = j - 1;
                                    if (piecesFounds > 0)
                                        break;
                                    ++piecesFounds;

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] == null && piecesFounds == 1)
                                    {
                                        requiredMoves[a, b] = true; //movimento obrigatório
                                        movesTrueW++;
                                        Pieces[l, c].canEat = true;
                                        if (!Pieces[l, c].isLady)
                                            break;
                                    }

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] != null)
                                        break;
                                }
                                ++i;
                                --j;
                            }
                        }

                        if (Pieces[l, c] != null && Pieces[l, c].Color == ConsoleColor.Black && blackTurn || Pieces[l, c] != null && Pieces[l, c].isLady && Pieces[l, c].isMyTurn(blackTurn)) // NE
                        {
                            int i = l - 1; //linha
                            int j = c + 1; //coluna
                            int piecesFounds = 0;
                            while (true)
                            {
                                if (i < 0 || j < 0 || i > 7 || j > 7)
                                    break;

                                if (Pieces[i, j] == null && !Pieces[l,c].isLady)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color == Pieces[l, c].Color)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color != Pieces[l, c].Color)
                                {
                                    int a = i - 1;
                                    int b = j + 1;
                                    if (piecesFounds > 0)
                                        break;
                                    piecesFounds++;

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] == null)
                                    {
                                        requiredMoves[a, b] = true; //movimento obrigatório
                                        movesTrueB++;
                                        Pieces[l, c].canEat = true;
                                        if (!Pieces[l, c].isLady)
                                            break;
                                    }

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] != null)
                                        break;
                                }
                                --i;
                                ++j;
                            }
                        }

                        if (Pieces[l, c] != null && Pieces[l, c].Color == ConsoleColor.Black && blackTurn || Pieces[l, c] != null && Pieces[l, c].isLady && Pieces[l, c].isMyTurn(blackTurn)) // NW
                        {
                            int i = l - 1; //linha
                            int j = c - 1; //coluna
                            int piecesFounds = 0;

                            while (true)
                            {
                                if (i < 0 || j < 0 || i > 7 || j > 7)
                                    break;

                                if (Pieces[i, j] == null && !Pieces[l,c].isLady)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color == Pieces[l, c].Color)
                                    break;
                                if (Pieces[i, j] != null && Pieces[i, j].Color != Pieces[l, c].Color)
                                {
                                    int a = i - 1;
                                    int b = j - 1;
                                    if (piecesFounds > 0)
                                        break;
                                    ++piecesFounds;

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] == null)
                                    {
                                        requiredMoves[a, b] = true; //movimento obrigatório
                                        movesTrueB++;
                                        Pieces[l, c].canEat = true;
                                        if (!Pieces[l, c].isLady)
                                            break;
                                    }
                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] != null)
                                        break;
                                }
                                --i;
                                --j;
                            }
                        }
                    }

                    else //eatBack ativado
                    {
                        if (Pieces[l, c] != null && Pieces[l,c].isMyTurn(blackTurn)) // SE
                        {
                            int i = l + 1; //linha
                            int j = c + 1; //coluna
                            int piecesFounds = 0;

                            while (true)
                            {
                                if (i < 0 || j < 0 || i > 7 || j > 7)
                                    break;

                                if (Pieces[i, j] == null && !Pieces[l,c].isLady)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color == Pieces[l, c].Color)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color != Pieces[l, c].Color)
                                {
                                    int a = i + 1;
                                    int b = j + 1;
                                    if (piecesFounds > 0)
                                        break;
                                    ++piecesFounds;

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] == null)
                                    {
                                        requiredMoves[a, b] = true; //movimento obrigatório
                                        if (Pieces[l, c].Color == ConsoleColor.Black)
                                            movesTrueB++;
                                        else
                                            movesTrueW++;
                                        Pieces[l, c].canEat = true;
                                        if (!Pieces[l, c].isLady)
                                            break;
                                    }

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] != null)
                                        break;
                                }
                                ++i;
                                ++j;

                            }
                        }

                        if (Pieces[l, c] != null && Pieces[l, c].isMyTurn(blackTurn)) // SW
                        {
                            int i = l + 1; //linha
                            int j = c - 1; //coluna
                            int piecesFounds = 0;
                            while (true)
                            {
                                if (i < 0 || j < 0 || i > 7 || j > 7)
                                    break;

                                if (Pieces[i, j] == null && !Pieces[l, c].isLady)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color == Pieces[l, c].Color)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color != Pieces[l, c].Color)
                                {
                                    int a = i + 1;
                                    int b = j - 1;
                                    if (piecesFounds > 0)
                                        break;
                                    ++piecesFounds;

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] == null)
                                    {
                                        requiredMoves[a, b] = true; //movimento obrigatório
                                        if (Pieces[l, c].Color == ConsoleColor.Black)
                                            movesTrueB++;
                                        else
                                            movesTrueW++;
                                        Pieces[l, c].canEat = true;
                                        if (!Pieces[l, c].isLady)
                                            break;
                                    }

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] != null)
                                        break;
                                }
                                ++i;
                                --j;
                            }
                        }

                        if (Pieces[l, c] != null && Pieces[l, c].isMyTurn(blackTurn)) // NE
                        {
                            int i = l - 1; //linha
                            int j = c + 1; //coluna
                            int piecesFounds = 0;
                            while (true)
                            {
                                if (i < 0 || j < 0 || i > 7 || j > 7)
                                    break;

                                if (Pieces[i, j] == null && !Pieces[l, c].isLady)
                                    break;

                                if (Pieces[i,j] != null && Pieces[i, j].Color == Pieces[l, c].Color)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color != Pieces[l, c].Color)
                                {
                                    int a = i - 1;
                                    int b = j + 1;
                                    if (piecesFounds > 0)
                                        break;
                                    ++piecesFounds;

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] == null)
                                    {
                                        requiredMoves[a, b] = true; //movimento obrigatório
                                        if (Pieces[l, c].Color == ConsoleColor.Black)
                                            movesTrueB++;
                                        else
                                            movesTrueW++;
                                        Pieces[l, c].canEat = true;
                                        if (!Pieces[l, c].isLady)
                                            break;
                                    }

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] != null)
                                        break;
                                }
                                --i;
                                ++j;
                            }
                        }

                        if (Pieces[l, c] != null && Pieces[l, c].isMyTurn(blackTurn)) // NW
                        {
                            int i = l - 1; //linha
                            int j = c - 1; //coluna
                            int piecesFounds = 0;

                            while (true)
                            {
                                if (i < 0 || j < 0 || i > 7 || j > 7)
                                    break;

                                if (Pieces[i, j] == null && !Pieces[l, c].isLady)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color == Pieces[l, c].Color)
                                    break;

                                if (Pieces[i, j] != null && Pieces[i, j].Color != Pieces[l, c].Color)
                                {
                                    int a = i - 1;
                                    int b = j - 1;
                                    if (piecesFounds > 0)
                                        break;
                                    ++piecesFounds;

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] == null)
                                    {
                                        requiredMoves[a, b] = true; //movimento obrigatório
                                        if (Pieces[l, c].Color == ConsoleColor.Black)
                                            movesTrueB++;
                                        else
                                            movesTrueW++;
                                            
                                        Pieces[l, c].canEat = true;
                                        if (!Pieces[l, c].isLady)
                                            break;
                                    }

                                    if (a < 8 && b < 8 && a >= 0 && b >= 0 && Pieces[a, b] != null)
                                        break;
                                }
                                --i;
                                --j;

                            }
                        }
                    }
                }
            }
            thereIsARequiredMoveW = movesTrueW > 0;
            thereIsARequiredMoveB = movesTrueB > 0;
        }
    
    }
}
