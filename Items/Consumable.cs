﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuMud.Items {
    public class Consumable : IConsumable{
        public bool CanConsume()
        {
            return true;
        }
    }
}