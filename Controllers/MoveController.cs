using System.Collections.Generic;
using VuMud.Creature;
using VuMud.Menus;

namespace VuMud.Controllers {
    public class MoveController : IController {
        public Creature.Creature PlayerCreature { get; set; }
        public MoveMenu MoveMenu { get; set; }

        public MoveController(Creature.Creature character)
        {
            PlayerCreature = character;
            MoveMenu = new MoveMenu();
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
            var response = MoveMenu.GetRepsonse();
            switch (response.ToUpper())
            {
                case "N":
                    //Character.Move("North");
                    break;
                case "S":
                    break;
                case "E":
                    break;
                case "W":
                    break;
                default:
                    break;
            }
        }
    }
}
