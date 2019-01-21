using System;

namespace JogoDasDamas
{
    class Menu
    {
        public static int option { get; set; }
        public static int positionX { get; set; } // posicao X do cursor
        public static int positionY { get; set; }// posicao Y do cursor
        public static int Round { get; set; } //numero da rodada
        public static bool isMove { get; set; } //indica se há uma peça em movimento
        public static Piece PieceMoving { get; set; } //peca em movimento
        public static int counter { get; set; }
        public static bool eatBack { get; set; } //indica se está ativada a opcao de comer para trás
        public static bool showPossibleMoves { get; set; } //indica se está ativada a opcao de mostrar os possiveis movimentos
        public static bool everEat { get; set; } //indica se está ativada a opcao de sempre comer quando possivel


        public static void title()
        {
            Console.WriteLine(@"    ______________________________________________________________________");
            Console.WriteLine(@"        _______       ___      .___  ___.      ___           _______.");
            Console.WriteLine(@"       |       \     /   \     |   \/   |     /   \         /       |");
            Console.WriteLine(@"       |  .--.  |   /  ^  \    |  \  /  |    /  ^  \       |   (----`");
            Console.WriteLine(@"       |  |  |  |  /  /_\  \   |  |\/|  |   /  /_\  \       \   \   ");
            Console.WriteLine(@"       |  '--'  | /  _____  \  |  |  |  |  /  _____  \  .----)   |   ");
            Console.WriteLine(@"       |_______/ /__/     \__\ |__|  |__| /__/     \__\ |_______/   ");
            Console.WriteLine(@"    ______________________________________________________________________");
            Console.WriteLine();
        }

        public static void instructions()
        {
            Console.Clear();
            title();
        }

        public static void credits()
        {
            Console.Clear();
            title();
            Console.WriteLine();
            Console.WriteLine("                                Thiago Mota Carvalho");
            Console.WriteLine("                     Graduando em Ciência da Computação - UFU ");
            Console.WriteLine("                                        2019");
            Console.WriteLine("                     email: tgomota1@gmail.com");
            version();
            Console.WriteLine();
            Console.WriteLine("                      Pressione alguma tecla para voltar ao menu...");
            Console.ReadKey();
        }

        public static void settings()
        {
            int optionS = 1;
            Console.CursorVisible = false;
            var tecla = ConsoleKey.LeftArrow;

            while (true)
            {
                Console.Clear();
                title();
                if (optionS == 1)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.Write("-> Backwards captures: ");
                    if (eatBack)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 11);
                    Console.Write("Required captures: ");
                    if (everEat)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.SetCursorPosition(35, 12);
                    Console.ResetColor();
                    Console.Write("Checkers need to stop a house after the capture: ");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("ON");
                    Console.SetCursorPosition(35, 13);
                    Console.ResetColor();
                    Console.Write("Show the possible moves: ");
                    if (showPossibleMoves)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 14);
                    Console.ResetColor();
                    Console.WriteLine("Exit settings");
                }

                if (optionS == 2)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.Write("Backwards captures: ");
                    if (eatBack)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 11);
                    Console.Write("-> Required captures: ");
                    if (everEat)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.SetCursorPosition(35, 12);
                    Console.ResetColor();
                    Console.Write("Checkers need to stop a house after the capture: ");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("ON");
                    Console.SetCursorPosition(35, 13);
                    Console.ResetColor();
                    Console.Write("Show the possible moves: ");
                    if (showPossibleMoves)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 14);
                    Console.ResetColor();
                    Console.WriteLine("Exit settings");
                }

                if (optionS == 3)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.Write("Backwards captures: ");
                    if (eatBack)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 11);
                    Console.Write("Required captures: ");
                    if (everEat)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.SetCursorPosition(35, 12);
                    Console.ResetColor();
                    Console.Write("-> Checkers need to stop a house after the capture: ");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("ON");
                    Console.SetCursorPosition(35, 13);
                    Console.ResetColor();
                    Console.Write("Show the possible moves: ");
                    if (showPossibleMoves)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 14);
                    Console.ResetColor();
                    Console.WriteLine("Exit settings");
                }

                if (optionS == 4)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.Write("Backwards captures: ");
                    if (eatBack)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 11);
                    Console.Write("Required captures: ");
                    if (everEat)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.SetCursorPosition(35, 12);
                    Console.ResetColor();
                    Console.Write("Checkers need to stop a house after the capture: ");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("ON");
                    Console.SetCursorPosition(35, 13);
                    Console.ResetColor();
                    Console.Write("-> Show the possible moves: ");
                    if (showPossibleMoves)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 14);
                    Console.ResetColor();
                    Console.WriteLine("Exit settings");
                }

                if (optionS == 5)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.Write("Backwards captures: ");
                    if (eatBack)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 11);
                    Console.Write("Required captures: ");
                    if (everEat)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.SetCursorPosition(35, 12);
                    Console.ResetColor();
                    Console.Write("Checkers need to stop a house after the capture: ");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("ON");
                    Console.SetCursorPosition(35, 13);
                    Console.ResetColor();
                    Console.Write("Show the possible moves: ");
                    if (showPossibleMoves)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ON");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OFF");
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(35, 14);
                    Console.ResetColor();
                    Console.WriteLine("-> Exit settings");
                }

                Console.WriteLine();
                version();

                tecla = Console.ReadKey().Key;
                if (tecla == ConsoleKey.DownArrow)
                    ++optionS;
                if (tecla == ConsoleKey.UpArrow)
                    --optionS;
                if (optionS < 1)
                    optionS = 5;
                if (optionS > 5)
                    optionS = 1;

                if(tecla == ConsoleKey.Enter)
                {
                    if (optionS == 1)
                        eatBack = !eatBack;
                    if (optionS == 2)
                        everEat = !everEat;
                    // if(optionS == 3)
                    if (optionS == 4)
                        showPossibleMoves = !showPossibleMoves;
                    if (optionS == 5)
                        Display();
                }
                if (tecla == ConsoleKey.Escape)
                    Display();
            }
        }

        public static void play()
        {
            GameBoard Tab = new GameBoard();
            Tab.initializeBoard();

            while (true)
            {
                int posj = (positionX - 28) / 3; //0 - 7 i
                int posi = positionY - 10; // 0 - 7 j

                Tab.blackTurn = Round % 2 == 0;
                Tab.checkRequiredMoves();
                title();
                Tab.printBoard();
                version();
                Tab.remainingPieces();
                Tab.showRoundNumber();

                //linha comeca no (28,10) //termina no (49,10)
                //coluna comeca no (28,10) //termina no (28,17)
                //extremos: (28,10), (49,10), (28,17), (49,17)
                Console.SetCursorPosition(positionX, positionY);
                Console.CursorVisible = true;

                var tecla = ConsoleKey.LeftArrow; //inicializando tecla com um valor qualquer //var necessita de inicialização
                tecla = Console.ReadKey().Key;

                if(tecla == ConsoleKey.Escape) //voltar ao menu //ESC
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(15, 22);
                    Console.WriteLine("           Do you wanna return to the menu?");
                    Console.SetCursorPosition(15, 23);
                    Console.WriteLine("                           ->YES");
                    Console.SetCursorPosition(15, 24);
                    Console.WriteLine("                           NO");
                    int optionE = 1;
                    tecla = Console.ReadKey().Key;
                    while (true)
                    {
                        Console.Clear();
                        title();
                        Tab.printBoard();
                        version();
                        Tab.remainingPieces();
                        Tab.showRoundNumber();
                        if(tecla == ConsoleKey.UpArrow)
                        {
                            optionE = 1;
                            Console.SetCursorPosition(15, 22);
                            Console.WriteLine("           Do you wanna return to the menu?");
                            Console.SetCursorPosition(15, 23);
                            Console.WriteLine("                           ->YES");
                            Console.SetCursorPosition(15, 24);
                            Console.WriteLine("                           NO");

                        }
                        if (tecla == ConsoleKey.DownArrow)
                        {
                            optionE = 2;
                            Console.SetCursorPosition(15, 22);
                            Console.WriteLine("           Do you wanna return to the menu?");
                            Console.SetCursorPosition(15, 23);
                            Console.WriteLine("                           YES");
                            Console.SetCursorPosition(15, 24);
                            Console.WriteLine("                           ->NO");
                        }

                        if (tecla == ConsoleKey.Enter)
                        {
                            if (optionE == 1)
                            {
                                Console.Clear();
                                Display();
                            }
                            else
                                break; //continua o jogo
                        }
                        tecla = Console.ReadKey().Key;
                    }
                    Console.CursorVisible = true;
                }

                if (isMove || tecla == ConsoleKey.Enter && Tab.Pieces[posi,posj] != null && Tab.blackTurn && Tab.Pieces[posi, posj].Color == ConsoleColor.Black || tecla == ConsoleKey.Enter && Tab.Pieces[posi, posj] != null && !Tab.blackTurn && Tab.Pieces[posi, posj].Color == ConsoleColor.White) 
                {
                        if (!isMove)
                        {
                            if (Tab.thereIsARequiredMoveB && Tab.Pieces[posi,posj].canEat || Tab.thereIsARequiredMoveW && Tab.Pieces[posi, posj].canEat || !Tab.thereIsARequiredMoveB && Tab.blackTurn || !Tab.thereIsARequiredMoveW && !Tab.blackTurn)
                            {
                                Tab.Pieces[posi, posj].Tab = Tab.Pieces;
                                PieceMoving = Tab.Pieces[posi, posj];
                                PieceMoving.possibleMoves();
                                counter = 1;
                            }
                        }
                        if (isMove && tecla == ConsoleKey.Enter && counter > 1)
                            Tab.movePiece();

                        ++counter;
                }
                
                Console.CursorVisible = false;    

                //mover cursor no tabuleiro
                if (tecla == ConsoleKey.LeftArrow)
                    positionX = positionX - 3;
                if (tecla == ConsoleKey.RightArrow)
                    positionX = positionX + 3;
                if (tecla == ConsoleKey.DownArrow)
                    positionY++;
                if (tecla == ConsoleKey.UpArrow)
                    positionY--;

                //se o cursor sair do tabuleiro
                if (positionX < 28)
                    positionX = 49;
                if (positionX > 49)
                    positionX = 28;
                if (positionY < 10)
                    positionY = 17;
                if (positionY > 17)
                    positionY = 10;

                Tab.isThereAWinner();
                Console.Clear();

            }
        }

        public static void Display()
        {
            option = 1;

            while (true)
            {
                Console.Clear();
                title();
                if(option == 1)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("-> Play");
                    Console.SetCursorPosition(35, 11);
                    Console.WriteLine("Instructions");
                    Console.SetCursorPosition(35, 12);
                    Console.WriteLine("Credits");
                    Console.SetCursorPosition(35, 13);
                    Console.WriteLine("Settings");
                    Console.SetCursorPosition(35, 14);
                    Console.WriteLine("Exit");
                }

                if (option == 2)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("Play");
                    Console.SetCursorPosition(35, 11);
                    Console.WriteLine("-> Instructions");
                    Console.SetCursorPosition(35, 12);
                    Console.WriteLine("Credits");
                    Console.SetCursorPosition(35, 13);
                    Console.WriteLine("Settings");
                    Console.SetCursorPosition(35, 14);
                    Console.WriteLine("Exit");
                }

                if (option == 3)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("Play");
                    Console.SetCursorPosition(35, 11);
                    Console.WriteLine("Instructions");
                    Console.SetCursorPosition(35, 12);
                    Console.WriteLine("-> Credits");
                    Console.SetCursorPosition(35, 13);
                    Console.WriteLine("Settings");
                    Console.SetCursorPosition(35, 14);
                    Console.WriteLine("Exit");
                }

                if (option == 4)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("Play");
                    Console.SetCursorPosition(35, 11);
                    Console.WriteLine("Instructions");
                    Console.SetCursorPosition(35, 12);
                    Console.WriteLine("Credits");
                    Console.SetCursorPosition(35, 13);
                    Console.WriteLine("-> Settings");
                    Console.SetCursorPosition(35, 14);
                    Console.WriteLine("Exit");
                }

                if (option == 5)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("Play");
                    Console.SetCursorPosition(35, 11);
                    Console.WriteLine("Instructions");
                    Console.SetCursorPosition(35, 12);
                    Console.WriteLine("Credits");
                    Console.SetCursorPosition(35, 13);
                    Console.WriteLine("Settings");
                    Console.SetCursorPosition(35, 14);
                    Console.WriteLine("-> Exit");
                }
                version();

                Console.CursorVisible = false;
                var tecla = Console.ReadKey().Key;

                if (tecla == ConsoleKey.Enter)
                {
                    if (option == 1)
                        play();
                    if (option == 2)
                        instructions();
                    if (option == 3)
                        credits();
                    if (option == 4)
                        settings();
                    if (option == 5)
                        Environment.Exit(1);
                }

                if ((int)tecla == 87 || tecla == ConsoleKey.UpArrow)
                {
                    if (option == 1)
                        option = 5;
                    else
                        --option;
                }

                if ((int)tecla == 83 || tecla == ConsoleKey.DownArrow)
                {
                    if (option == 5)
                        option = 1;
                    else
                        ++option;
                }

            }
        }

        public static void version()
        {
            Console.WriteLine();
            Console.WriteLine("    ______________________________________________________________________");
            Console.WriteLine("                                                             Version: 1.0");
        }

    }
}