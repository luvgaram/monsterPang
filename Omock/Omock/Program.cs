using System;
using System.Collections;

namespace Omock
{
    class Program
    {
        static void Main(string[] args)
        {
            // 바둑판을 만듦

            Board.Make();
            Board.ShowBoard();
            //Board.IsMovable();
            Board.Delete();
            /*
            if (Board.turn % 2 == 0 && score > 3)
                Console.WriteLine("검은 돌■의 승리입니다.");
            else if(Board.turn % 2 != 0 && score > 3)
                Console.WriteLine("흰 돌○의 승리입니다.");
            else
                Console.WriteLine("승자가 없습니다.");
            Console.ReadLine();
            */
        }
    }  
}
