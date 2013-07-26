using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuMud.Menus;

namespace VuMud {
    class Program {
        static void Main(string[] args) {
            IMenu roomMenu = new RoomMenu();
            roomMenu.Display();


        }
    }
}
