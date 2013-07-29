using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuMud.Creature;

namespace VuMud.Items {
    public class Potion : Item
    {
        public int Bonus { get; set; }
        public Stats AffectedStat { get; set; }
        public override string Description { get; set; }
        public override string Name { get; set; }

        public IConsumable Consumable;
        public IEquipable Equipable;

        public Potion(int bonus, Stats stat, string desc, string name)
        {
            Bonus = bonus;
            AffectedStat = stat;
            Description = desc;
            Name = name;

            Consumable = new Consumable();
            Equipable = new NonEquipable();
        }

        public override bool CanConsume()
        {
            return Consumable.CanConsume();
        }

        public override bool CanEquip()
        {
            return Equipable.CanEquip();
        }

    }
}
