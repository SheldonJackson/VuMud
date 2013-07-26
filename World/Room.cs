namespace VuMud.World {
    public class Room {
        public int X { get; set; }
        public int Y { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Exits { get; set; }

        public Room(int x, int y, string title, string description, string[] exits = null)
        {
            X = x;
            Y = y;
            Title = title;
            Description = description;
            if(exits == null)
                Exits = new string[4] {"North", "South", "East", "West"};
            else
                Exits = exits;
        }
    }
}
