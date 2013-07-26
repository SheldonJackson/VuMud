using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuMud.Creature;

namespace VuMud.Items {
    public class Armor : Item
    {
        public int Bonus { get; set; }
        public Stats AffectedStat { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ArmorSlots Slot { get; set; }

        public IConsumable Consumable;
        public IEquipable Equipable;

        public Armor(int bonus, Stats stat, string desc, string name)
        {
            Bonus = bonus;
            AffectedStat = stat;
            Description = desc;
            Name = name;

            Consumable = new NonConsumable();
            Equipable = new Equipable();
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
