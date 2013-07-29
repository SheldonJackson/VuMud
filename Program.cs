using System;
using VuMud.Controllers;
using VuMud.Creature;
using VuMud.World;

namespace VuMud {
    class Program {
        static void Main(string[] args) {
            
            PlayerCharacter pc = new PlayerCharacter();
            var characterCreationController = new CharacterCreationController();
            pc = characterCreationController.CreateCharacter();
            // TODO - This will need to be rewritten or taken out, right now it's just here to prove that character creation works
            Console.WriteLine("Here is your character's info!");
            Console.WriteLine(pc.Name);
            Console.WriteLine(pc.Description);
            Console.WriteLine();

            Console.WriteLine("Get ready for an adventure!!");
            Console.WriteLine();
            Map worldMap = new Map();
            MoveController mc = new MoveController(pc, worldMap);
            pc.Location = worldMap.WorldMapRooms[0, 0];
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
