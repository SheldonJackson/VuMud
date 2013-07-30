using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuMud.Creature;
using VuMud.World;

namespace VuMud.Controllers {
    public class ViewController : IController
    {
        private Creature.Creature player;
        private Map worldMap;


        public ViewController(Creature.Creature playerCreature, Map map)
        {
            player = playerCreature;
            worldMap = map;
        }

        public void HandleResponse(string action, string target)
        {
            switch (action)
            {
                case "view":
                    HandleViewAction(target);
                    break;
                default:
                    break;
            }
        }

        protected void HandleViewAction(string target)
        {
            switch (target)
            {
                case "map":
                    worldMap.DisplayMap();
                    break;
                //case "room":
                //    Console.WriteLine(player.Location.Description());
            }
        }
    }
}
