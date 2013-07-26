using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuMud.Items {
    public class NonConsumable : IConsumable {
        public bool CanConsume()
        {
            return false;
        }
    }
}
