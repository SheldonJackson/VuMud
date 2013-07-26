using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuMud.Menus {
    public class MoveMenu : IMenu {
        public void Display(List<MenuItem> menuItems )
        {
            foreach (var menuItem in menuItems)
            {
                Console.WriteLine("{0} - {1}", menuItem.Option, menuItem.DisplayString);
            }
        }

        public void Display()
        {
            
        }

        public string GetRepsonse()
        {
            return Console.ReadLine();
        }

    }
}
