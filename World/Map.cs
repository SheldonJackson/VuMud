using System;
using System.Configuration;

namespace VuMud.World {
    public class Map {
        public Room[,] WorldMapRooms = new Room[20, 10];
        public string mapString { get; set; }
        public RoomTitles[,] WorldMapRoomTitles = new RoomTitles[10, 20]
        {
            {RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave},
            {RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave},
            {RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave},
            {RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave},
            {RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave},
            {RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave},
            {RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave},
            {RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave},
            {RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave},
            {RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave,RoomTitles.Cave},
        };

        public Map()
        {
            WorldMapRooms = generateMap();
            GenerateMapDrawing();
        }

        private Room[,] generateMap()
        {
            Room[,] rooms = new Room[20, 10];
            for (var i = 0; i < 20; i++)
            {
                for(var j = 0; j < 10; j++)
                {
                    string[] exits = new string[]{"North", "South", "East", "West"};
                    rooms[i, j] = new Room(i, j, string.Format("{0}", WorldMapRoomTitles[j, i]), generateRoomDescription(WorldMapRoomTitles[j,i]), exits);
                }
            }
            return rooms;
        }

        private string generateRoomDescription(RoomTitles roomTitle)
        {
            string description = "";
            if (roomTitle == RoomTitles.Cave)
            {
                description = string.Format("You are in a cave.  It is pitch dark.  You are likely to be eaten by a Grue.{0}", Environment.NewLine);
            }
            else if (roomTitle == RoomTitles.Dungeon)
            {
                description = string.Format("You are in a dungeon.  The walls are made of stone and cold to the touch.{0}", Environment.NewLine);
            }
            else if (roomTitle == RoomTitles.ForestClearing)
            {
                description = string.Format("The woods open up into a small clearing.  The sun beats down on your face now that you are out in the open{0}", Environment.NewLine);
            }
            else if (roomTitle == RoomTitles.Plains)
            {
                description = string.Format("You are standing in the middle of a field.  The wind is blowing.  Hard.{0}", Environment.NewLine);
            }
            else if (roomTitle == RoomTitles.Woods) {
                description = string.Format("Trees surround you.  You can hear the wildlife of the woods all around you.{0}", Environment.NewLine);
            }

            return description;
        }

        public void GenerateMapDrawing()
        {
            string map;
            map = "+--------------------+\n";
            for (int i = 0; i < 10; i++)
            {
                map += "|";
                for (int j = 0; j < 20; j++)
                {
                    switch (WorldMapRoomTitles[i, j])
                    {
                        case RoomTitles.Cave:
                            map += "c";
                            break;
                        case RoomTitles.Dungeon:
                            map += "d";
                            break;
                        case RoomTitles.ForestClearing:
                            map += "f";
                            break;
                        case RoomTitles.Woods:
                            map += "w";
                            break;
                        case RoomTitles.Plains:
                            map += "p";
                            break;
                    }
                }
                map += "|\n";
            }
            map += "+--------------------+";
            mapString = map;
        }

        public void GenerateMapDrawing(int x, int y)
        {
            string map;
            map = "+ - - - - - - - - - - - - - - - - - - - - +\n";
            for (int i = 0; i < 10; i++) {
                map += "|";
                for (int j = 0; j < 20; j++) {
                    if ((x == j) && (y == i))
                    {
                        map += " @";
                        continue;
                    }
                    switch (WorldMapRoomTitles[i, j]) {
                        case RoomTitles.Cave:
                            map += " c";
                            break;
                        case RoomTitles.Dungeon:
                            map += " d";
                            break;
                        case RoomTitles.ForestClearing:
                            map += " f";
                            break;
                        case RoomTitles.Woods:
                            map += " w";
                            break;
                        case RoomTitles.Plains:
                            map += " p";
                            break;
                    }
                }
                map += " |\n";
            }
            map += "+ - - - - - - - - - - - - - - - - - - - - +";
            mapString = map;
        }

        public void DisplayMap()
        {
            foreach (char tile in mapString) {
                switch (tile) {
                    case 'c':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case '+':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case '-':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case '|':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case '@':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }
                Console.Write(tile);
                Console.ResetColor();
            }
   
        }
    }
}
