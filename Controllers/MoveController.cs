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
            Room currRoom = PlayerCreature.Location;
            MoveMenu.Display(currRoom.Description);
            //build options
            var menuItems = (from exit in currRoom.Exits where exit != null select new MenuItem(exit, exit.Substring(0,1))).ToList();
            MoveMenu.Display(menuItems);
        }

        public void HandleResponse()
        {
            Room curRoom = PlayerCreature.Location;
<<<<<<< HEAD
            //Console.WriteLine("{0}, {1}", PlayerCreature.Location.X, PlayerCreature.Location.Y);
=======
>>>>>>> origin/Menus-and-Controllers

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
                case "SHOW MAP":
                    MoveMenu.DisplayMap(Map);
                    break;
                default:
                    break;
            }
<<<<<<< HEAD
            //Console.WriteLine("{0}, {1}", PlayerCreature.Location.X, PlayerCreature.Location.Y);
=======
>>>>>>> origin/Menus-and-Controllers
        }
    }
}
