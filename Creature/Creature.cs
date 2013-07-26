using System;
using System.Collections.Generic;
using VuMud.Items;
using VuMud.World;

namespace VuMud.Creature {
    public class Creature : IDisposable{
        public string Name { get; set; }
        public Stats Stats { get; set; }
        public string Description { get; set; }
        public Room Location { get; set; } // Once Trey pushes his changes up

        Enum Class { get; set; }
        List<Item> Invtentory { get; set; }

        public void Communicate(Creature creature) {
            //TODO: Stuff goes here
        }

        public void Move(Room room) {
            Location = room;
        }

        public void Attack(Creature creature) {
            //TODO: stuff goes here
        }

        public void DropItem(Item item) {
            //TODO: stuff goes here
        }

        public void Die() {
            foreach (var item in Invtentory) {
                DropItem(item);
            }
        }

        public void Dispose() {
            throw new NotImplementedException();
        }
    }
}
