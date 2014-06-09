using System;
using System.Collections;

namespace Omock
{
    class Board
    {
        public int boardSize = 6;
        public Stone[,] board;
        public Random random = new Random(DateTime.Now.Millisecond);

        public Board()
        {

        }

        public void Make()
        {
            board = new Stone[boardSize, boardSize];// 바둑판을 그림
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    board[row, col] = new Stone(col, row, random);// row, col 자리 바꿈  그랠라고!
                }
            }
        }

        public Stone[,] ShowBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (board[i, j] == null)
                        Console.Write("_ ");
                    else
                    {
                        switch (board[i, j].type)
                        {
                            case 1:
                                Console.Write("1 ");
                                break;
                            case 2:
                                Console.Write("2 ");
                                break;
                            case 3:
                                Console.Write("3 ");
                                break;
                            case 4:
                                Console.Write("4 ");
                                break;
                            case 5:
                                Console.Write("5 ");
                                break;
                            case 6:
                                Console.Write("6 ");
                                break;
                            default:
                                Console.Write("* ");
                                break;
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return board;
        }

        public bool IsMovable()
        {
            int type = 0;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = boardSize - 1; j >= 0; j--)
                {
                    type = board[j, i].type;
                }
            }
            return true;
        }

        public bool IsLinear(Stone stone)
        {
            if ((Score(stone.y, stone.x)[0] >= 2) || (Score(stone.y, stone.x)[1] >= 2))
                return true;
            else
                return false;
        }

        public int Check(ref int score, int y, int x, int changeY, int changeX)
        {
            if ((GetBoardData(y + changeY, x + changeX) != null) && (board[y, x].type != board[y + changeY, x + changeX].type))
                return 0;
            else if ((GetBoardData(y + changeY, x + changeX) != null) && (board[y, x].type == board[y + changeY, x + changeX].type))
            {
                score = score + 1;
                Check(ref score, y + changeY, x + changeX, changeY, changeX);
                return score;
            }
            return score;
        }

        public int[] Score(int y, int x)
        {
            int[] score = new int[2];
            Check(ref score[0], y, x, 0, 1);
            Check(ref score[0], y, x, 0, -1);
            Check(ref score[1], y, x, 1, 0);
            Check(ref score[1], y, x, -1, 0);
            return score;
        }

        public void Delete()
        {
            int[,] scores = new int[6, 6];
            int maxRow = 0;
            int maxCol = boardSize - 1;
            int maxScore = scores[maxCol, maxRow];
            int maxType = board[maxCol, maxRow].type;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = boardSize - 1; j >= 0; j--)
                {
                    if ((Score(j, i)[0] >= 2) || (Score(j, i)[1] >= 2))
                    {
                        if ((Score(j, i)[0] >= 2) && (Score(j, i)[1] >= 2))
                        {
                            scores[j, i] = Score(j, i)[0] + Score(j, i)[1] + 1;
                        }
                        else
                        {
                            if (Score(j, i)[0] > Score(j, i)[1])
                            {
                                scores[j, i] = Score(j, i)[0] + 1;
                            }
                            else
                            {
                                scores[j, i] = Score(j, i)[1] + 1;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = boardSize - 1; j >= 0; j--)
                {
                    if (scores[j, i] > maxScore)
                    {
                        maxScore = scores[j, i];
                        maxRow = i;
                        maxCol = j;
                        maxType = board[j, i].type;
                    }
                }
            }

            if ((Score(maxCol, maxRow)[0] >= 2) || (Score(maxCol, maxRow)[1] >= 2))
            {
                Console.WriteLine("Delete Start");
                if ((Score(maxCol, maxRow)[0] >= 2) && (Score(maxCol, maxRow)[1] >= 2))
                {               
                    DelStone(maxCol, maxRow, 0, 1, maxType);
                    DelStone(maxCol, maxRow, 0, -1, maxType);
                    DelStone(maxCol, maxRow, 1, 0, maxType);
                    DelStone(maxCol, maxRow, -1, 0, maxType);
                    board[maxCol, maxRow].type = 0;
                }
                else
                {
                    if (Score(maxCol, maxRow)[0] >= 2)
                    {                       
                        DelStone(maxCol, maxRow, 0, 1, maxType);
                        DelStone(maxCol, maxRow, 0, -1, maxType);
                        board[maxCol, maxRow].type = 0;
                    }
                    else
                    {
                        DelStone(maxCol, maxRow, 1, 0, maxType);
                        DelStone(maxCol, maxRow, -1, 0, maxType);
                        board[maxCol, maxRow].type = 0;
                    }
                }
            }
            ShowBoard();
        }

        public void DelStone(int y, int x, int changeY, int changeX, int type)
        {
            while ((GetBoardData(y + changeY, x + changeX) != null) && (type == board[y + changeY, x + changeX].type))
            {
                board[y + changeY, x + changeX].type = 0;
                y = y + changeY;
                x = x + changeX;
                ShowBoard();
            }
        }

        public Stone GetBoardData(int y, int x) // exception check
        {
            if (((y >= boardSize) || (y < 0)) || ((x >= boardSize) || (x < 0)))
                return null;
            return board[y, x];
        }
    }

 
}
