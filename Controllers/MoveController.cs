using System;
using System.Collections.Generic;
using System.Linq;
using VuMud.Creature;
using VuMud.Menus;
using VuMud.World;

namespace VuMud.Controllers {
    public class MoveController : IController {
        public Creature.Creature PlayerCreature { get; set; }
        public MoveMenu MoveMenu { get; set; }
        public Map Map { get; set; }

        public MoveController(Creature.Creature character, Map map)
        {
            PlayerCreature = character;
            MoveMenu = new MoveMenu();
            Map = map;
        }

        public void DisplayMenu()
        {
            //check for exits
            //Room room = Character.CurrentRoom;
            //build options
            var menuItems = new List<MenuItem>()
            {
                new MenuItem("North", "N"),
                new MenuItem("South", "S"),
                new MenuItem("East", "E"),
                new MenuItem("West", "W")
            };
            MoveMenu.Display(menuItems);
        }

        public void HandleResponse()
        {
            Room curRoom = PlayerCreature.Location;
            Console.WriteLine("{0}, {1}", PlayerCreature.Location.X, PlayerCreature.Location.Y);

            var response = MoveMenu.GetRepsonse();
            switch (response.ToUpper())
            {
                case "N":
                    if(curRoom.Exits.Contains("North"))
                        PlayerCreature.Move(Map.WorldMapRooms[curRoom.X, curRoom.Y - 1]);
                    break;
                case "S":
                    if (curRoom.Exits.Contains("South"))
                        PlayerCreature.Move(Map.WorldMapRooms[curRoom.X, curRoom.Y + 1]);
                    break;
                case "E":
                    if (curRoom.Exits.Contains("East"))
                        PlayerCreature.Move(Map.WorldMapRooms[curRoom.X + 1, curRoom.Y]);
                    break;
                case "W":
                    if (curRoom.Exits.Contains("West"))
                        PlayerCreature.Move(Map.WorldMapRooms[curRoom.X - 1, curRoom.Y]);
                    break;
                default:
                    break;
            }
            Console.WriteLine("{0}, {1}", PlayerCreature.Location.X, PlayerCreature.Location.Y);
        }
    }
}
