﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuMud.Items {
    public interface IConsumable
    {
        bool CanConsume();
    }
}