using System.Collections.Generic;
using VuMud.World;
using VuMud.Creature;

namespace VuMud.Controllers
{
    internal class RoomController : IController
    {
        private Creature.Creature playerCreature { get; set; }
        private Map map { get; set; }

        private MoveController moveController;
        private ViewController viewController;

        private Dictionary<string, IController> commandDictionary = new Dictionary<string, IController>() ;

        public RoomController(Creature.Creature player, Map worldMap)
        {
            playerCreature = player;
            map = worldMap;

            moveController = new MoveController(playerCreature, map);
            viewController = new ViewController(playerCreature, map);

            commandDictionary.Add("view", viewController);
            commandDictionary.Add("move", moveController);
        }

        public void HandleResponse(string action, string target)
        {
            IController controller;
            if(commandDictionary.TryGetValue(action, out controller))
            {
                controller.HandleResponse(action, target);
            }
        }
    }
}
