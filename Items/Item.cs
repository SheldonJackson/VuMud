namespace VuMud.Items {
    public abstract class Item : IEquipable, IConsumable {
        public abstract string Description { get; set; }
        public abstract string Name { get; set; }

        public abstract bool CanConsume();
        public abstract bool CanEquip();
    }
}