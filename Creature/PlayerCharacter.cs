using System;
using VuMud.Items;

namespace VuMud.Creature {
    public class PlayerCharacter : Creature {

        public string Inspect(Item item) {
            return item.Description;
        }

        public string Inspect(Creature creature) {
            return creature.Description;
        }

        public string FormatCharacterInfo() {
            string formattedString = "";

            return formattedString;
        }

        private string _formatStats() {
            return string.Format(
                "Combat Stats: {0}" +
                "    Health: {1}{0}" +
                "    Mana: {2}{0}" +
                "    Armor: {3}{0}" +
                "    Attack Bonus: {4}{0}" +
                "    Damage: {5}{0}{0}",
                Environment.NewLine,
                Stats.Health,
                Stats.Mana,
                Stats.Armor,
                Stats.AttackBonus,
                Stats.Damage
            );
        }
    }
}
