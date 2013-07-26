using System.Collections.Generic;

namespace VuMud.World {
    public class Room {
        public int X { get; set; }
        public int Y { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Exits { get; set; }

        public List<Creature.Creature> Inhabitants { get; set; }
        public List<Items.Item> Contents { get; set; }

        public Room(int x, int y, string title, string description, string[] exits)
        {
            X = x;
            Y = y;
            Title = title;
            Description = description;
            Exits = exits;
        }

        public void AddInhabitant(Creature.Creature creature)
        {
            Inhabitants.Add(creature);
        }

        public void AddItem(Items.Item item)
        {
            Contents.Add(item);
        }
    }
}
