﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items {
    public class NonEquipable : IEquipable{
        public bool CanEquip()
        {
            return false;
        }
    }
}
