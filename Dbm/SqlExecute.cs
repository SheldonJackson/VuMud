using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VuMud.Dbm {
    public class SqlExecute
    {
        private string Configuration { get; set; }

        public void SetConfiguration(string server, string database, string user, string password)
        {
            var dbConfiguration = new DbConfiguration(server, database, user, password);
            Configuration = dbConfiguration.GetDbConfigurationString();
        }

        public long Insert(string procedure, SqlParameter[] parameters) {
            return ExecuteNonQuery(procedure, parameters);
        }

        public long Update(string procedure, SqlParameter[] parameters) {
            return ExecuteNonQuery(procedure, parameters);
        }

        public long Delete(string procedure, SqlParameter[] parameters) {
            return ExecuteNonQuery(procedure, parameters);
        }

        public List<IDataRecord> Select(string procedure, SqlParameter[] parameters)
        {
            var resultSet = new List<IDataRecord>();
            using (
                var connection = new SqlConnection(Configuration)
                )
            {
                using (var command = new SqlCommand(procedure, connection))
                {
                    command.Parameters.AddRange(parameters);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    resultSet = (from IDataRecord r in reader select r).ToList();
                }
            }
            return resultSet;
        }

        private long ExecuteNonQuery(string procedure, SqlParameter[] parameters) {
            long id;
            using (
                var connection = new SqlConnection(Configuration)
            ) {
                using (var command = new SqlCommand(procedure, connection)) {
                    command.Parameters.AddRange(parameters);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    id = Convert.ToInt64(command.ExecuteScalar());
                }
            }
            return id;
        }

    }
}
