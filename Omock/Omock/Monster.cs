using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omock
{
    class Monster
    {
        private enum MonsterType { nine = 1, girl, dracula, zombie, tobi, end } // 포토샵 파일 보고 더 추가하기!
        private MonsterType type;
        private double hp;


        public Monster(int level)
        {

            hp = level * 50;

            switch (level)
            {
                case (int)MonsterType.nine:
                    type = MonsterType.nine;
                    break;
                case (int)MonsterType.girl:
                    type = MonsterType.girl;
                    break;
                case (int)MonsterType.dracula:
                    type = MonsterType.dracula;
                    break;
                case (int)MonsterType.zombie:
                    type = MonsterType.zombie;
                    break;
                case (int)MonsterType.tobi:
                    type = MonsterType.tobi;
                    break;
                default:
                    type = MonsterType.end;
                    break;
            }
        }
    }
}
