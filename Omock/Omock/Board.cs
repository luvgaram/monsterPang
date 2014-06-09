using System;
using System.Collections;

namespace Omock
{
    class Board
    {
        static public int boardSize = 6;
        static public Stone[,] board;
        static public Random random = new Random(DateTime.Now.Millisecond);

        static public void Make()
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

        static public Stone[,] ShowBoard()
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

        static public bool IsMovable()
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

        static public bool IsLinear(Stone stone)
        {
            if ((Score(stone.y, stone.x)[0] >= 2) || (Score(stone.y, stone.x)[1] >= 2))
                return true;
            else
                return false;
        }

        static public int Check(ref int score, int y, int x, int changeY, int changeX)
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

        static public int[] Score(int y, int x)
        {
            int[] score = new int[2];
            Check(ref score[0], y, x, 0, 1);
            Check(ref score[0], y, x, 0, -1);
            Check(ref score[1], y, x, 1, 0);
            Check(ref score[1], y, x, -1, 0);
            return score;
        }

        static public void Delete()
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

        static public void DelStone(int y, int x, int changeY, int changeX, int type)
        {
            while ((GetBoardData(y + changeY, x + changeX) != null) && (type == board[y + changeY, x + changeX].type))
            {
                board[y + changeY, x + changeX].type = 0;
                y = y + changeY;
                x = x + changeX;
                ShowBoard();
            }
        }
        /*
        static public int GetLocation(ref int turn)
        {
            int x, y;
            int curScore = 0;

            if (turn % 2 + 1 == BLACK)
                Console.WriteLine("검은 돌○의 차례입니다.");
            else if (turn % 2 + 1 == WHITE)
                Console.WriteLine("흰 돌■의 차례입니다.");
            Console.Write("돌을 놓을 곳의 [x] 좌표를 입력해주세요: "); 
            x = int.Parse(Console.ReadLine()) - 1;
            Console.Write("돌을 놓을 곳의 [y] 좌표를 입력해주세요: ");
            y = int.Parse(Console.ReadLine()) - 1;
            if (y > boardSize - 1 || x > boardSize - 1 || board[y, x] != null) // 빈 칸인지 체크
                Console.WriteLine("다시 입력해 주세요.");
            else if (turn % 2 + 1 == BLACK && board[y, x] == null)
            {
                board[y, x] = new Stone(1, x, y);
                curScore = Score(y, x);
                if (curScore == -1)
                {
                    board[y, x] = null;
                    GetLocation(ref turn);
                }
                turn++;
                return curScore;
            }
            else if (turn % 2 + 1 == WHITE && board[y, x] == null)
            {
                board[y, x] = new Stone(2, x, y);
                curScore = Score(y, x);
                if (curScore == -1)
                {
                    board[y, x] = null;
                    GetLocation(ref turn);
                }
                turn++;
                return curScore;
            }
            return 0;
        }

        static public int Score(int y, int x)
        {
            int[] sc = new int[4];

            Check(ref sc[0], y, x, 0, 1);
            Check(ref sc[0], y, x, 0, -1);
            Check(ref sc[1], y, x, 1, 0);
            Check(ref sc[1], y, x, -1, 0);
            Check(ref sc[2], y, x, 1, -1);
            Check(ref sc[2], y, x, -1, 1);
            Check(ref sc[3], y, x, 1, 1);
            Check(ref sc[3], y, x, -1, -1);

            int largestScore = sc[0];
            int secondScore = 0;
            for (int element = 1; element < sc.Length; element++ )
            {
                if (sc[element] >= largestScore)
                {              
                    secondScore = largestScore;
                    largestScore = sc[element];
                }
            }
            if ((largestScore == 2) && (secondScore == 2))
                return -1;
            return largestScore;
        }
        
        static public int Check(ref int score, int y, int x, int changeY, int changeX)
        {
            if ((GetBoardData(y + changeY, x + changeX) != null) && (board[y, x].color != board[y + changeY, x + changeX].color))
                return 0;
            else if ((GetBoardData(y + changeY, x + changeX) != null) && (board[y, x].color == board[y + changeY, x + changeX].color))
            {
                score = score + 1;
                Check(ref score, y + changeY, x + changeX, changeY, changeX);               
                return score;
            } 
            return score;
        }

        static public bool IsFull() // 보드판이 다 찼는지 확인
        {
            int isFull = 0;
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    if (GetBoardData(y, x) != null)
                    {
                        isFull++;
                    }
                }
            }
            if (isFull == boardSize * boardSize)
                return true;
            else
                return false;
        }
        */

        static public Stone GetBoardData(int y, int x) // exception check
        {
            if (((y >= boardSize) || (y < 0)) || ((x >= boardSize) || (x < 0)))
                return null;
            return board[y, x];
        }
    }

 
}
