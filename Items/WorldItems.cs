using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuMud.Creature;

namespace VuMud.Items {
    public class WorldItems
    {
        public List<Item> Items = new List<Item>();

        public WorldItems()
        {
            Items.Add(new Potion(10, Stats.Health, "Recovers 10 Health", "Minor Health Potion"));
            Items.Add(new Potion(10, Stats.Mana, "Recovers 10 Mana", "Minor Mana Potion"));
            Items.Add(new Weapon(2, Stats.AttackBonus, "Basic Starting Sword.", "Iron Sword", 5));
            Items.Add(new Weapon(1, Stats.AttackBonus, "Basic Starting Dagger.", "Iron Dagger", 1));
            Items.Add(new Weapon(2, Stats.AttackBonus, "Basic Stargin Axe.", "Iron Axe", 4));
            Items.Add(new Armor(1, Stats.Armor, "It's a hat.", "Leather Cap", 1));
            Items.Add(new Armor(2, Stats.Charisma, "Not that shiny, but looks nice.", "Bronze Charm", 1));
            Items.Add(new Armor(1, Stats.Armor, "Welcome to the 80's!", "Leather Shoulder Pads", 2));
            Items.Add(new Armor(1, Stats.Armor, "Basic Gauntlets of the Poor", "Leather Gauntlets", 1));
            Items.Add(new Armor(4, Stats.Armor, "Provides Basic coverage for your squishy bits.", "Leather Tunic", 5));
            Items.Add(new Armor(1, Stats.Armor, "Don't be saggin', bro.", "Leather Belt", 1));
            Items.Add(new Armor(2, Stats.Armor, "Better than Chaps!", "Leather Pants", 3));
            Items.Add(new Armor(2, Stats.Armor, "Keep yo feet clean!", "Leather Boots", 2));
            Items.Add(new Armor(2, Stats.Constitution, "Bling!", "Iron Ring", 1));
            Items.Add(new Armor(1, Stats.Intelligence, "Bling!", "Opal Ring", 1));
        }

        public Item GenerateRandomWorldItem()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, Items.Count());

            return Items[randomNumber];
        }

    }
}
