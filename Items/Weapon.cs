﻿using VuMud.Creature;

namespace VuMud.Items {
    public class Weapon : Item
    {
        public long WeaponId { get; Set; }
        public WeaponSlots Slot { get; set; }

        public IConsumable Consumable;
        public IEquipable Equipable;

        public Weapon(int bonus, Stats stat, string desc, string name, int weight)
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