using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuMud.Menus {
    public class MenuItem {
        public string DisplayString { get; set; }
        public string Option { get; set; }

        public MenuItem(string displayString, string option)
        {
            DisplayString = displayString;
            Option = option;
        }
    }
}
