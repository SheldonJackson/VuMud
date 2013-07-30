using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuMud.Controllers;
using VuMud.Creature;
using VuMud.World;

namespace VuMud {
    class ProgramTest {
        private static void Main(string[] args)
        {
            PlayerCharacter player = new PlayerCharacter();
            var characterCreationController = new CharacterCreationController();
            player = characterCreationController.CreateCharacter();

            Map worldMap = new Map();
            RoomController mainController = new RoomController(player, worldMap);

            
            do
            {
                Console.WriteLine("'view map' 'move n/s/e/w'");
                Console.Write("Command: ");
                string input = Console.ReadLine();

                input = input.ToLower();
                string[] inputs = input.Split(' ');

                try {
                    mainController.HandleResponse(inputs[0], inputs[1]);

                }
                catch (Exception e) {
                    Console.WriteLine("Please only enter 1 or 2 word commands please.");
                    Console.WriteLine(e);
                }
            } while (true);
        }
    }
}
