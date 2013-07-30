namespace Items {
    public abstract class Item : IEquipable, IConsumable {
        public long ItemId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public Stats.Stats AffectedStat { get; set; }
        public int Bonus { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }

        public abstract bool CanConsume();
        public abstract bool CanEquip();
    }
}