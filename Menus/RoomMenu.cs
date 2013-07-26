using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuMud.Menus {
    public class RoomMenu : IMenu{
        public void Display()
        {
            Console.WriteLine("You are in a room.");
            Console.WriteLine("You have died.");
        }

        public string GetRepsonse()
        {
            throw new NotImplementedException();
        }
    }
}
