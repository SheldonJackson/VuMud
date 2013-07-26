using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuMud.Creature {
    public class Stats {

        public int Strength { get; protected set; }
        public int Dexterity { get; protected set; }
        public int Constitution { get; protected set; }
        public int Intelligence { get; protected set; }
        public int Wisdom { get; protected set; }
        public int Charisma { get; protected set; }

        public int Health { get; protected set; }
        public int Mana { get; protected set; }

        public int Armor { get; protected set; }
        public int Damage { get; protected set; }
        public int AttackBonus { get; protected set; }

    }
}
