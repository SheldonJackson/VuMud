using System.Collections.Generic;
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
        }
    }
}
