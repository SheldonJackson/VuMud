using VuMud.Creature;

namespace VuMud.Items {
    public class Potion : Item
    {
        public IConsumable Consumable;
        public IEquipable Equipable;

        public Potion(int bonus, Stats stat, string desc, string name)
        {
            Bonus = bonus;
            AffectedStat = stat;
            Description = desc;
            Name = name;
            Weight = 1;

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
