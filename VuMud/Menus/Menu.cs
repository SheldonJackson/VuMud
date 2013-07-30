using System;
using System.Collections.Generic;

namespace VuMud.Menus {
    public class Menu {
        public static void Display(List<MenuItem> menuItems) {
            foreach (var menuItem in menuItems) {
                DisplayMenuItem(menuItem);
            }
        }

        public static void Display(MenuItem menuItem) {
            DisplayMenuItem(menuItem);
        }

        public static string GetResponse() {
            return Console.ReadLine();
        }

        private static void DisplayMenuItem(MenuItem menuItem) {
            Console.WriteLine("{0} - {1}", menuItem.Option, menuItem.DisplayString);
        }
    }
}
