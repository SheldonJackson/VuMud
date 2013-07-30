<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using VuMud.Dbm;

namespace VuMud.Items.DataAccess {
    public class ItemDao
    {
        private SqlExecute dbm;

        public ItemDao()
        {
            SqlExecute dbm = new SqlExecute();
            dbm.SetConfiguration("localhost","VuMud","vu_mud","tester");
        }

        public void InsertWeapon(Weapon weapon)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("name", weapon.Name),
                new SqlParameter("description", weapon.Description),
                new SqlParameter("weight", weapon.Weight),
                new SqlParameter("cost", weapon.Price),
                new SqlParameter("affectedStatId", SelectAffectedStatId(weapon.AffectedStat)),
                new SqlParameter("bonus", weapon.Bonus),
                new SqlParameter("slotId", SelectSlotId(weapon.Slot))
            };

            string procedure = "InsertWeapon";
            dbm.Insert(procedure, parameters);
        }

        public void DeleteWeapon(Weapon weapon)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("itemId", weapon.ItemId)
            };

            string procedure = "RemoveWeaponByItemId";
            dbm.Delete(procedure, parameters);
        }

        public List<IDataRecord> SelectWeaponById(Weapon weapon)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("Id", weapon.WeaponId)
            };

            string procedure = "RetrieveWeaponById";
            return dbm.Select(procedure, parameters);
        }

        public List<IDataRecord> SelectAllWeapons()
        {
            return dbm.Select("RetrieveAllWeapons", new SqlParameter[0]);
        } 

        private long SelectAffectedStatId(Stats stat)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("Stat", stat.ToString())
            };
            String procedure = "SELECT Id FROM AffectedStats WHERE Stat = @Stat";
            var result = dbm.Select(procedure, parameters);

            return Convert.ToInt64(result[0]);
        }

        private long SelectSlotId(WeaponSlots slot)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("Slot", slot)
            };
            String procedure = "SELECT Id FROM Slots WHERE Slot = @Slot";
            var result = dbm.Select(procedure, parameters);

            return Convert.ToInt64(result[0]);
=======
﻿using System.Collections.Generic;
using System.Data.SqlClient;

namespace VuMud.Items.DataAccess {
<<<<<<< HEAD
    public class ItemDao {
        public SqlConnection Connection;

        public ItemDao() {
            Connection = new SqlConnection("Server=localhost;Database=VuMud;User Id=vehical_admin;Password=tester;");
        }

        public SqlDataReader RetrieveItem(int itemId) {
            using (Connection) {

=======
    public class ItemDao
    {
        public SqlConnection Connection;

        public ItemDao()
        {
            Connection = new SqlConnection("Server=localhost;Database=VuMud;User Id=vehical_admin;Password=tester;");
        }

        public SqlDataReader RetrieveItem(int itemId)
        {
            using (Connection)
            {
                
>>>>>>> origin/master
            }
>>>>>>> Rebase
        }
    }
}
