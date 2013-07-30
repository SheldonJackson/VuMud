using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using VuMud.Controllers;
using VuMud.Creature;
using VuMud.Dbm;
using VuMud.World;

namespace VuMud {
    class Program {
        static void Main(string[] args) {
            var pc = new PlayerCharacter();

            var characterCreationController = new CharacterCreationController();
            pc = characterCreationController.CreateCharacter();
            // TODO - This will need to be rewritten or taken out, right now it's just here to prove that character creation works
            Console.WriteLine("Here is your character's info!");
            Console.WriteLine(pc.Name);
            Console.WriteLine(pc.Description);
            Console.WriteLine();

            Console.WriteLine("Get ready for an adventure!!");
            Console.WriteLine();
            var worldMap = new Map();
            var mc = new MoveController(pc, worldMap);
            pc.Location = worldMap.WorldMapRooms[0, 0];
            var playerCharacter = new PlayerCharacter();
            playerCharacter.Location = worldMap.WorldMapRooms[0, 0];
            var moveController = new MoveController(playerCharacter, worldMap);
            worldMap.DisplayMap();

            do {
                try {

                    moveController.DisplayMenu();
                    moveController.HandleResponse();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            } while (true);

        }
    }
}
