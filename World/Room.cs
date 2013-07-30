<<<<<<< HEAD
﻿namespace World {
=======
﻿using System.Collections.Generic;
using VuMud.Items;

namespace VuMud.World {
>>>>>>> 62c808623e4ac13c51b8dcdce61d6b700de0024b
    public class Room {
        public int X { get; set; }
        public int Y { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Exits { get; set; }

        public List<Item> Inventory;

        public Room(int x, int y, string title, string description, string[] exits = null)
        {
            X = x;
            Y = y;
            Title = title;
            Description = description;
            if(exits == null)
                Exits = new string[4] {"North", "South", "East", "West"};
            else
                Exits = exits;
        }
    }
}
