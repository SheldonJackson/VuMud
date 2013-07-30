namespace Items {
    public class Weapon : Item
    {
        public WeaponSlots Slot { get; set; }

        public IConsumable Consumable;
        public IEquipable Equipable;

        public Weapon(int bonus, Stats.Stats stat, string desc, string name, int weight)
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
