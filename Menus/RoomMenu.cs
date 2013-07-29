using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuMud.Creature;
using VuMud.World;

namespace VuMud.Menus {
    public class RoomMenu : IMenu
    {
        protected PlayerCharacter PlayerCharacter { get; set; }
        protected Map WorldMap { get; set; }

        public void Display(List<MenuItem> menuItems) {
            foreach (var menuItem in menuItems) {
                Console.WriteLine("{0} - {1}", menuItem.Option, menuItem.DisplayString);
            }
        }

        public void Display(Room room)
        {
            Console.WriteLine("{0}", room.Description);
        }

        public string GetRepsonse()
        {
            throw new NotImplementedException();
        }

        public void Display()
        {
        }
    }
}
