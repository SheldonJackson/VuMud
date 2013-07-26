using VuMud.Items;

namespace VuMud.Creature {
    public class PlayerCharacter : Creature {

        public string Inspect(Item item)
        {
            return "Hello world";
        }

        public string Inspect(Creature creature) {
            return creature.Description;
        }
    }
}
