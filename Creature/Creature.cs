﻿using System;
using System.Collections.Generic;
using Items;
using World;

<<<<<<< HEAD
<<<<<<< HEAD
namespace Creatures {
    public class Creature : IDisposable{
=======
namespace VuMud.Creature {
    public class Creature : IDisposable {
>>>>>>> 62c808623e4ac13c51b8dcdce61d6b700de0024b
=======
namespace VuMud.Creature {
    public class Creature : IDisposable {
>>>>>>> 62c808623e4ac13c51b8dcdce61d6b700de0024b
        public string Name { get; set; }
        public Stats Stats { get; set; }
        public string Description { get; set; }
        public Room Location { get; set; }

        Enum Class { get; set; }

        private List<Item> Inventory;

        public Creature() {
            Inventory = new List<Item>();
        }

        public void Communicate(Creature creature) {
            //TODO: Stuff goes here
        }

        public void Move(Room room) {
            Location = room;
        }

        public void Attack(Creature creature) {
            //TODO: stuff goes here
        }

        public void AddItem(Item item) {
            Inventory.Add(item);
        }

        public void DropItem(Item item) {
            Location.Inventory.Add(item);
            this.Inventory.Remove(item);
        }

        public bool IsAlive() {
            if (Stats.Health > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        public void Die() {
            foreach (Item item in Inventory) {
                DropItem(item);
            }
        }

        public void Dispose() {
            //TODO: self destruct
        }
    }
}
