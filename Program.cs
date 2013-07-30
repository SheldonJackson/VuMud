using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuMud.Controllers;
using Creatures;
using World;

namespace VuMud {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("(C)rud creatures or (S)tart new game.");
            var choice = Console.ReadLine();
            if (choice.ToUpper() == "C")
            {
                DoCreatureManage();
                Environment.Exit(0);
            }

            PlayerCharacter pc = new PlayerCharacter();
            var characterCreationController = new CharacterCreationController();
            pc = characterCreationController.CreateCharacter();
            pc.Stats = new Stats() {
                Strength = 20,
                Dexterity = 20,
                Constitution = 20,
                Intelligence = 20,
                Wisdom = 20,
                Charisma = 20,
                Health = 20,
                Mana = 20,
                Armor = 20,
                Damage = 20,
                AttackBonus = 20
            };
            // TODO - This will need to be rewritten or taken out, right now it's just here to prove that character creation works
            Console.WriteLine("Here is your character's info!");
            Console.WriteLine(pc.Name);
            Console.WriteLine(pc.Description);
            Console.WriteLine();
            Console.WriteLine("Get ready for an adventure!!");
            Console.WriteLine();
            Map worldMap = new Map();
            MoveController mc = new MoveController(pc, worldMap);
            pc.Location = worldMap.WorldMapRooms[0, 0];
            PlayerCharacter playerCharacter = new PlayerCharacter();
            playerCharacter.Location = worldMap.WorldMapRooms[0, 0];
            MoveController moveController = new MoveController(playerCharacter, worldMap);
            worldMap.DisplayMap();

            do {
                try {

                    moveController.DisplayMenu();
                    moveController.HandleResponse();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }

        static void DoCreatureManage()
        {
            var menu =
                string.Format(
                    "What would you like to do?{0} (C)reate a new creature.{0} (S)elect a creature's info.{0} (U)pdate a creature's info.{0} (D)elete a creature.{0} (I)mport creature from file.{0} (E)xport all creatures{0}",
                    Environment.NewLine);
            var quit = false;
            while (!quit)
            {
                Console.WriteLine(menu);
                var input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "C":
                        CreateCreature();

                        break;
                    case "S":
                        SelectCreature();

                        break;
                    case "U":
                        UpdateCreature();

                        break;
                    case "D":
                        DeleteCreature();

                        break;
                    case "I":
                        break;
                    case "E":
                        //ExportCreature();

                        break;
                    default:
                        quit = true;
                        break;
                }
            }
        }

        static void CreateCreature()
        {
            PlayerCharacter pc = new PlayerCharacter();
            var characterCreationController = new CharacterCreationController();
            pc = characterCreationController.CreateCharacter();
            pc.Stats = new Stats()
            {
                Strength = 20,
                Dexterity = 20,
                Constitution = 20,
                Intelligence = 20,
                Wisdom = 20,
                Charisma = 20,
                Health = 20,
                Mana = 20,
                Armor = 20,
                Damage = 20,
                AttackBonus = 20
            };
            // TODO - This will need to be rewritten or taken out, right now it's just here to prove that character creation works
            Console.WriteLine("Here is your character's info!");
            Console.WriteLine(pc.Name);
            Console.WriteLine(pc.Description);
            Console.WriteLine();

            using (
                var connection =
                    new SqlConnection("Server=VUHL-985LFV1;Database=VuMUD;User Id=vumud_user;Password=admin;"))
            {
                string commandText = "InsertCreature";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(
                        new SqlParameter[]
                        {
                            new SqlParameter("name", pc.Name),
                            new SqlParameter("description", pc.Description),
                            new SqlParameter("strength", pc.Stats.Strength),
                            new SqlParameter("dexterity", pc.Stats.Dexterity),
                            new SqlParameter("constitution", pc.Stats.Constitution),
                            new SqlParameter("intelligence", pc.Stats.Intelligence),
                            new SqlParameter("wisdom", pc.Stats.Wisdom),
                            new SqlParameter("charisma", pc.Stats.Charisma),
                            new SqlParameter("health", pc.Stats.Health),
                            new SqlParameter("mana", pc.Stats.Mana),
                            new SqlParameter("armor", pc.Stats.Armor),
                            new SqlParameter("damage", pc.Stats.Damage),
                            new SqlParameter("attackbonus", pc.Stats.AttackBonus)
                        }
                        );
                    connection.Open();
                    command.ExecuteScalar();
                }
            }
        }

        static void SelectCreature()
        {
            Console.Write("Provide a creature id to select: ");
            var creatureId = Convert.ToInt64(Console.ReadLine());
            using (
                var connection =
                    new SqlConnection("Server=VUHL-985LFV1;Database=VuMUD;User Id=vumud_user;Password=admin;"))
            {
                var commandText = "SelectCharacterInfo";
                using (var command = new SqlCommand(commandText, connection)) {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("creatureId", creatureId));
                    command.CommandType = CommandType.StoredProcedure;
                    var reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Console.WriteLine(reader["Name"]);
                    }
                    reader.Close();

                }
            }
        }

        static void UpdateCreature()
        {
            PlayerCharacter pc = new PlayerCharacter();
            pc.Stats = new Stats();
            Console.Write("What is the ID of the creatuer you would like to update? ");
            var creatureId = Convert.ToInt64(Console.ReadLine());
            using (
                var connection =
                    new SqlConnection("Server=VUHL-985LFV1;Database=VuMUD;User Id=vumud_user;Password=admin;"))
            {
                var commandText = "SelectCharacterInfo";
                using (var command = new SqlCommand(commandText, connection))
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("creatureId", creatureId));
                    command.CommandType = CommandType.StoredProcedure;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        pc.Stats.Strength = Convert.ToInt32(reader["Strength"]);
                        pc.Stats.Dexterity = Convert.ToInt32(reader["Dexterity"]);
                        pc.Stats.Constitution = Convert.ToInt32(reader["Constitution"]);
                        pc.Stats.Intelligence = Convert.ToInt32(reader["Intelligence"]);
                        pc.Stats.Wisdom = Convert.ToInt32(reader["Wisdom"]);
                        pc.Stats.Charisma = Convert.ToInt32(reader["Charisma"]);
                        pc.Stats.Armor = Convert.ToInt32(reader["Armor"]);
                        pc.Stats.Damage = Convert.ToInt32(reader["Damage"]);
                        pc.Stats.AttackBonus = Convert.ToInt32(reader["AttackBonus"]);
                        pc.Stats.Health = Convert.ToInt32(reader["Health"]);
                        pc.Stats.Mana = Convert.ToInt32(reader["Mana"]);
                        //Console.WriteLine(reader["Name"]);
                    }
                    reader.Close();
                }



                pc.Stats.Strength = 40;
                pc.Stats.Wisdom = 40;
                commandText = "UpdateCreatureStatistics";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(
                        new SqlParameter[]
                        {
                            new SqlParameter("creatureId", creatureId),
                            new SqlParameter("strength", pc.Stats.Strength),
                            new SqlParameter("dexterity", pc.Stats.Dexterity),
                            new SqlParameter("constitution", pc.Stats.Constitution),
                            new SqlParameter("intelligence", pc.Stats.Intelligence),
                            new SqlParameter("wisdom", pc.Stats.Wisdom),
                            new SqlParameter("charisma", pc.Stats.Charisma),
                            new SqlParameter("health", pc.Stats.Health),
                            new SqlParameter("mana", pc.Stats.Mana),
                            new SqlParameter("armor", pc.Stats.Armor),
                            new SqlParameter("damage", pc.Stats.Damage),
                            new SqlParameter("attackbonus", pc.Stats.AttackBonus)
                        }
                        );
                    command.ExecuteScalar();
                }
            }
        }

        static void DeleteCreature()
        {
            using (
                var connection =
                    new SqlConnection("Server=VUHL-985LFV1;Database=VuMUD;User Id=vumud_user;Password=admin;"))
            {
                connection.Open();
                Console.Write("Enter an id to delete: ");
                var creatureId = Convert.ToInt64(Console.ReadLine());
                var commandText = "DeleteCreature";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.Add(new SqlParameter("creatureId", creatureId));
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteScalar();
                }
            }
        }
    }
}
