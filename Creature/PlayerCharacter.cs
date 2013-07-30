using Items;

namespace Creatures {
    public class PlayerCharacter :  Creature {

        public string Inspect(Item item) {
            return item.Description;
        }

        public string Inspect(Creature creature) {
            return creature.Description;
        }
    }
}
