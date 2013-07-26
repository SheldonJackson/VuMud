using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuMud.Controllers;
using VuMud.Creature;
using VuMud.Menus;
using VuMud.World;

namespace VuMud {
    class Program {
        static void Main(string[] args) {
            Map worldMap = new Map();
            PlayerCharacter pc = new PlayerCharacter();
            pc.Location = worldMap.WorldMapRooms[0, 0];
            MoveController mc = new MoveController(pc, worldMap);
            worldMap.DisplayMap();
            do
            {
                try {
                    mc.DisplayMenu();
                    mc.HandleResponse();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }
    }
}
