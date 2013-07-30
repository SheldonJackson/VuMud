using System;
using System.Collections;
using System.Configuration;
using System.Linq;

namespace VuMud.World
{
    public class Map
    {
        public Room[,] WorldMapRooms = new Room[20, 10];
        public string mapString { get; set; }
        public RoomTitles[,] WorldMapRoomTitles = new RoomTitles[10, 20]
        {
            {RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Cave,   RoomTitles.Cave,   RoomTitles.Cave,   RoomTitles.Cave},
            {RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Cave,   RoomTitles.Cave,   RoomTitles.Cave,   RoomTitles.Cave},
            {RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Cave,   RoomTitles.Cave,   RoomTitles.Cave,   RoomTitles.Cave},
            {RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.ForestClearing, RoomTitles.ForestClearing, RoomTitles.ForestClearing, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Cave,   RoomTitles.Cave,   RoomTitles.Cave,   RoomTitles.Cave},
            {RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.ForestClearing, RoomTitles.ForestClearing, RoomTitles.ForestClearing, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains},
            {RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.ForestClearing, RoomTitles.ForestClearing, RoomTitles.ForestClearing, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains},
            {RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Woods,  RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains},
            {RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains},
            {RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains},
            {RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Plains,         RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Woods, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains, RoomTitles.Plains},
        }; // This is the default map, new maps can be passed in by dat file like so GenerateRoomTitlesFromFile("../../World/map1.dat");

        public Map()
        {
            GenerateRoomTitlesFromFile("../../World/map1.dat"); // if generating custom map from file this must come before generateMap();
            WorldMapRooms = generateMap();
            GenerateMapDrawing();
        }

        private Room[,] generateMap()
        {
            Room[,] rooms = new Room[20, 10];
            for (var i = 0; i < 20; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    string[] exits = new string[4] { "North", "South", "East", "West" };
                    if (i == 0)
                    {
                        exits[3] = null;
                    }
                    else if (i == 19)
                    {
                        exits[2] = null;
                    }

                    if (j == 0)
                    {
                        exits[0] = null;
                    }
                    else if (j == 9)
                    {
                        exits[1] = null;
                    }
                    rooms[i, j] = new Room(i, j, string.Format("{0}", WorldMapRoomTitles[j, i]),
                            generateRoomDescription(WorldMapRoomTitles[j, i]), exits);
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
            else if (roomTitle == RoomTitles.Woods)
            {
                description = string.Format("Trees surround you.  You are shielded from the sun as the tall timbers form a canopy above your head.{0}", Environment.NewLine);
            }

            return description;
        }

        public void GenerateMapDrawing()
        {
            string map;
            map = "+ - - - - - - - - - - - - - - - - - - - - +\n";
            for (int i = 0; i < 10; i++)
            {
                map += "|";
                for (int j = 0; j < 20; j++)
                {
                    switch (WorldMapRoomTitles[i, j])
                    {
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
            map += "+ - - - - - - - - - - - - - - - - - - - - +\n";
            mapString = map;
        }

        public void GenerateMapDrawing(int x, int y)
        {
            string map;
            map = "+ - - - - - - - - - - - - - - - - - - - - +\n";
            for (int i = 0; i < 10; i++)
            {
                map += "|";
                for (int j = 0; j < 20; j++)
                {
                    if ((x == j) && (y == i))
                    {
                        map += " @";
                        continue;
                    }
                    switch (WorldMapRoomTitles[i, j])
                    {
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
            map += "+ - - - - - - - - - - - - - - - - - - - - +\n";
            mapString = map;
        }

        public void DisplayMap()
        {
            foreach (char tile in mapString)
            {
                switch (tile)
                {
                    case 'c':
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case 'w':
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 'f':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 'p':
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 'd':
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
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

        public Room FetchRoom(int x, int y)
        {
            return WorldMapRooms[x, y];
        }

        public void GenerateRoomTitlesFromFile(string filename)
        {
            string text = System.IO.File.ReadAllText(filename);

            int rowCount = 0;
            int colCount = 0;
            foreach (char symbol in text)
            {
                switch (symbol)
                {
                    case 'c':
                        WorldMapRoomTitles[rowCount, colCount] = RoomTitles.Cave;
                        break;
                    case 'p':
                        WorldMapRoomTitles[rowCount, colCount] = RoomTitles.Plains;
                        break;
                    case 'f':
                        WorldMapRoomTitles[rowCount, colCount] = RoomTitles.ForestClearing;
                        break;
                    case 'd':
                        WorldMapRoomTitles[rowCount, colCount] = RoomTitles.Dungeon;
                        break;
                    case 'w':
                        WorldMapRoomTitles[rowCount, colCount] = RoomTitles.Woods;
                        break;
                    default:
                        colCount--;
                        break;
                }
                colCount++;
                if (colCount >= 20)
                {
                    colCount = 0;
                    rowCount++;
                    if (rowCount == 10)
                        return;
                }
            }
        }
    }
}
