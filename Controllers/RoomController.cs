using System.Linq;
using VuMud.Menus;
using VuMud.World;

namespace VuMud.Controllers {
    class RoomController : IController {
        public Creature.Creature PlayerCreature { get; set; }
        public RoomMenu RoomMenu { get; set; }
        public Map Map { get; set; }

        public RoomController (Creature.Creature character, Map world)
        {
            RoomMenu = new RoomMenu();
            PlayerCreature = character;
            Map = Map;
        }

        public void DisplayMenu()
        {
            throw new System.NotImplementedException();
        }

        public void HandleResponse()
        {
            Room room = PlayerCreature.Location;

            var response = RoomMenu.GetRepsonse();
            switch (response.ToUpper())
            {
                case "L":
                    RoomMenu.Display(room);

                    break;
                case "E":
                    var menuItems = (from exit in room.Exits where exit != null select new MenuItem(exit, exit.Substring(0, 1))).ToList();
                    RoomMenu.Display(menuItems);

                    break;
                default:
                    break;
            }
        }
    }
}
