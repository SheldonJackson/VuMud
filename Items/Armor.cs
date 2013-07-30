using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuMud.Creature;

namespace VuMud.Items {
    public class Armor : Item
    {
        public long ArmorId { get; set; }
        public ArmorSlots Slot { get; set; }

        public IConsumable Consumable;
        public IEquipable Equipable;

        public Armor(int bonus, Stats stat, string desc, string name, int weight)
        {
            Bonus = bonus;
            AffectedStat = stat;
            Description = desc;
            Name = name;
            Weight = weight;

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
