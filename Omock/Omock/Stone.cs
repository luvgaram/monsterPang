using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omock
{
    class Stone
    {
        //enum StoneType {fire=1, water, earth,...}  
        // 수정
        public int type;
        int x;
        int y;

        public Stone(int x, int y, Random random)
        {
            type = random.Next(1, 7);
            this.x = x;
            this.y = y;
        }


        
    }
}
