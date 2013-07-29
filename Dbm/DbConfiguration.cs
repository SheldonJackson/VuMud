using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuMud.Dbm {
    public class DbConfiguration {
        private string Server { get; set; }
        private string Database { get; set; }
        private string User { get; set; }
        private string Password { get; set; }

        public DbConfiguration(string server, string database, string user, string password)
        {
            Server = server;
            Database = database;
            User = user;
            Password = password;
        }

        public string GetDbConfigurationString()
        {
            return String.Format("SERVER={0};Database={1};User Id={2};Password={3}",
                Server,
                Database,
                User,
                Password
                );
        }
    }
}
