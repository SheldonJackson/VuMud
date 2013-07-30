using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using VuMud.Items.DataAccess;

namespace VuMud.Items {
    public class ItemManagement {
        private readonly ItemDao _dao;

        public ItemManagement() {
            _dao = new ItemDao();
        }

        public void InsertWeapon(Weapon weapon) {
            _dao.InsertWeapon(weapon);
        }

        public void ExportWeaponItemsToCsv(string path) {
            var allWeapons = _dao.SelectAllWeapons();
            using (var sr = new StreamWriter(path)) {
                foreach (var record in allWeapons) {
                    var line = string.Format("{0},{1},{2},{3},{4},{5},{6}\r\n", record["Name"], record["Description"],
                        record["Weight"], record["Cost"], record["Bonus"], record["Stat"], record["Slot"]);
                    sr.WriteLine(line);
                }
            }
        }

        public void ImportWeaponFromCsv(string filePath) {
            var weapons = new List<string>();
            var skipCount = 0;

            using (var textReader = new StreamReader(filePath)) {
                string line;
                do {
                    line = textReader.ReadLine();
                    if (line != null) {
                        weapons.Add(line);
                    }
                    skipCount++;
                } while (line != null && skipCount < 0);
            }

            foreach (var weapon in weapons) {
                var dataList = weapon.Split(',');
                
            }
        }
    }
}
