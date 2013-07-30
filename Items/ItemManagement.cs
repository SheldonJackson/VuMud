using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VuMud.Items.DataAccess;

namespace VuMud.Items {
    public class ItemManagement
    {
        private ItemDao dao;
     
        public ItemManagement()
        {
            dao = new ItemDao();
        }

        public void InsertWeapon(Weapon weapon)
        {
            dao.InsertWeapon(weapon);
        }

        public void ExportWeaponItemsToCsv(string path)
        {
            var allWeapons = dao.SelectAllWeapons();
            using (var sr = new StreamWriter(path))
            {
                string line;
                foreach (IDataRecord record in allWeapons)
                {
                    line = string.Format("{0},{1},{2},{3},{4},{5},{6}\r\n", record["Name"], record["Description"],
                        record["Weight"], record["Cost"], record["Bonus"], record["Stat"], record["Slot"]);
                    sr.WriteLine(line);

                }
            }
        }
    }
}
