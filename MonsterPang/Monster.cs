using System;

namespace MonsterPang
{
    class Monster
    {
        public enum MonsterType { goblin = 1, girl, dracula, zombie, kama, end }
        public MonsterType type;
        public double hp;
        public int hpPercent;

        public Monster(int level)
        {
            hp = Math.Log(level + 1) * 50;
            hpPercent = (int)(hp / (Math.Log(level + 1) * 50) * 50);

            switch (level)
            {
                case (int)MonsterType.goblin:
                    type = MonsterType.goblin;
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
                case (int)MonsterType.kama:
                    type = MonsterType.kama;
                    break;
                default:
                    type = MonsterType.end;
                    break;
            }
        }
    }
}
