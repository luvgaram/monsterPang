using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterPang
{
    class Stage
    {
        public Board board;
        public Monster monster;
        public int level;

        public Stage(int level)
        {
            board = new Board();
            monster = new Monster(level);
            this.level = level;
        }

        public void DeleteContinuously()
        {          
            while (true)
            {
                int num = board.Deletable();
                if (num > 0)
                {
                    Damage(num);
                    board.Sort();
                }
                else
                {
                    return;
                }
            }
             
        }

        public bool IsSwitchable(int row1, int col1, int row2, int col2)
        {
            return board.Switchable(row1, col1, row2, col2);
        }

        public void Swap(int row1, int col1, int row2, int col2)
        {
            board.Swap(row1, col1, row2, col2); 
        }

        public bool IsMovable()
        {
            return board.IsMovable();
        }



        /*
        public void Play()
        {
            while (monster.hp > 0)
            {
                while (board.Deletable() > 0)
                {
                    Damage(board.Deletable());
                    board.Sort();
                }

                if (board.IsMovable() == false)
                {
                    board.Refresh();
                    continue;
                }
                else
                {
                    Console.WriteLine("입력받습니다. row col 순서대로 입력해주세요.");
                    int row1;
                    int col1;
                    int row2;
                    int col2;
                    do
                    {
                        row1 = ReadInteger();
                        col1 = ReadInteger();
                        row2 = ReadInteger();
                        col2 = ReadInteger();
                    } while (!board.Switchable(row1, col1, row2, col2)); //Switchable() 다혜가 구현하기
                    board.Swap(row1, col1, row2, col2); //Swap(..) 다혜가 구현하기
                    continue;
                }
            }
        }
         */

        public void Damage(int num)
        {
            monster.hp = monster.hp - num;
            monster.hpPercent = (int)(monster.hp / (Math.Log(level + 1) * 50) * 10);
        }
       
        public int ReadInteger()
        {
            Console.Write("값을 입력하세요 : ");
            return int.Parse(Console.ReadLine());
        }
    }
}
