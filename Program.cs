using System;
using VuMud.Controllers;
using VuMud.Creature;
using VuMud.World;

namespace VuMud {
    class Program {
        static void Main(string[] args) {
            Map worldMap = new Map();
            PlayerCharacter playerCharacter = new PlayerCharacter();
            playerCharacter.Location = worldMap.WorldMapRooms[0, 0];
            MoveController moveController = new MoveController(playerCharacter, worldMap);
            worldMap.DisplayMap();
            do
            {
                try {

                    moveController.DisplayMenu();
                    moveController.HandleResponse();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }
    }
}
