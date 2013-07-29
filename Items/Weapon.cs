using VuMud.Creature;

namespace VuMud.Items {
    public class Weapon : Item
    {
        public int Bonus { get; set; }
        public Stats AffectedStat { get; set; }
        public override string Description { get; set; }
        public override string Name { get; set; }
        public WeaponSlots Slot { get; set; }

        public IConsumable Consumable;
        public IEquipable Equipable;

        public Weapon(int bonus, Stats stat, string desc, string name)
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
