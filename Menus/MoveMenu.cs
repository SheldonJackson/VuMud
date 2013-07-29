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

        public void Display(string roomDescription)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}", roomDescription);
            Console.ResetColor();

            Console.WriteLine("Obvious Exits:{0}", Environment.NewLine);
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
