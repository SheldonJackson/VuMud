﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Testing out Merging
namespace VuMud.Items {
    public abstract class Item : IEquipable, IConsumable
    {
        public abstract bool CanConsume();
        public abstract bool CanEquip();
    }
}