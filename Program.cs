using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using VuMud.Controllers;
using VuMud.Creature;
using VuMud.Dbm;
using VuMud.World;

namespace VuMud {
    class Program {
        static void Main(string[] args)
        {

            SqlExecute dbm = new SqlExecute();
            dbm.SetConfiguration("VUHL-9CLYBS1\\CSHARPCLASS", "VehicleInventory", "Vehicles", "Password123!");

            var parameters = new SqlParameter[]
            {
                    new SqlParameter("name", "DBM TESTER"),
                    new SqlParameter("type", 2),
                    new SqlParameter("color","Yellow")
            };

            List<IDataRecord> resultSet = dbm.Select("SelectVehicles", parameters);
            foreach (IDataRecord result in resultSet)
            {
                Console.WriteLine(result["Name"]);
            }

            
            Console.ReadLine();


        }
    }
}
