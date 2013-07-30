using Creatures;
using VuMud.Menus;

namespace VuMud.Controllers {
    public class CharacterCreationController {
        public PlayerCharacter PlayerCharacter { get; set; }

        public PlayerCharacter CreateCharacter() {
            PlayerCharacter = new PlayerCharacter();
            PlayerCharacter.Name = GetNameFromUser();
            PlayerCharacter.Description = GetDescriptionFromUser();
            return PlayerCharacter;
        }

        private string GetNameFromUser() {
            MenuItem menuItem = new MenuItem("", "Please enter your character's name");
            Menu.Display(menuItem);
            return Menu.GetResponse();
        }

        private string GetDescriptionFromUser() {
            MenuItem menuItem = new MenuItem("", "Enter a custom description for your character");
            Menu.Display(menuItem);
            return Menu.GetResponse();
        }
    }
}
