using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuMud.Dbm;

namespace VuMud.Items.DataAccess {
    public class ItemDao
    {
        private readonly SqlExecute _dbm;

        public ItemDao()
        {
            _dbm = new SqlExecute();
            _dbm.SetConfiguration("localhost","VuMud","vu_mud","tester");
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

            const string procedure = "InsertWeapon";
            _dbm.Insert(procedure, parameters);
        }

        public void DeleteWeapon(Weapon weapon)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("itemId", weapon.ItemId)
            };

            const string procedure = "RemoveWeaponByItemId";
            _dbm.Delete(procedure, parameters);
        }

        public List<IDataRecord> SelectWeaponById(Weapon weapon)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("Id", weapon.WeaponId)
            };

            const string procedure = "RetrieveWeaponById";
            return _dbm.Select(procedure, parameters);
        }

        public List<IDataRecord> SelectAllWeapons()
        {
            return _dbm.Select("RetrieveAllWeapons", new SqlParameter[0]);
        } 

        private long SelectAffectedStatId(Stats stat)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("Stat", stat.ToString())
            };
            const string procedure = "SELECT Id FROM AffectedStats WHERE Stat = @Stat";
            var result = _dbm.Select(procedure, parameters);

            return Convert.ToInt64(result[0]);
        }

        private long SelectSlotId(WeaponSlots slot)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("Slot", slot)
            };
            const string procedure = "SELECT Id FROM Slots WHERE Slot = @Slot";
            var result = _dbm.Select(procedure, parameters);

            return Convert.ToInt64(result[0]);
        }
    }
}
