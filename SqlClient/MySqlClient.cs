using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace IOT_SERVER
{
    public class MySqlClient

    {
        private const string CONNECTION_OK = "OK";

        private MySqlConnection Connection;

        private MySqlDataAdapter adapter;        

        private MySqlCommand command;

        private string SERVER;

        private string DATABASE;

        private string UID;

        private string PASSWORD;

        public string CurrentTable { get; set; }

        public MySqlClient(string source, string databaseName, string userId, string password)
        {

            this.SERVER = source;

            this.DATABASE = databaseName;

            this.UID = userId;

            this.PASSWORD = password;            

        }

        public string Initiliase()
        {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

            builder.Server = this.SERVER;

            builder.Database = this.DATABASE;

            builder.Password = this.PASSWORD;

            builder.UserID = this.UID;

            Connection = new MySqlConnection(builder.ToString());

            adapter = new MySqlDataAdapter(null, Connection);

            command = new MySqlCommand();

            command.Connection = Connection;

            try
            {
                Connection.Open();
            }
            catch (MySqlException ex)
            {

                return ex.Message;

            }

            Connection.Close();

            return Codes.OK;

        }

        public DataSet GetData()
        {

            DataSet ds = new DataSet();

            string connector = string.Format("USE {0}; SELECT * FROM {1};", this.DATABASE, this.CurrentTable);           

            if (!(Connection.State == ConnectionState.Open)) return null;

            command.CommandText = connector;

            adapter.SelectCommand = command;

            adapter.Fill(ds, this.CurrentTable);            

            return ds;
        }

        public int InsertNew(string ip, int port, bool active, int key)
        {
            Connection.Open();

            command.CommandText = string.Format("INSERT INTO {0} (IP, PORT, ACTIVE, LASTMSG, `KEY`) VALUES('{1}',{2},{3},\"N/A\",{4} );", this.CurrentTable, ip, port, active, key);

            int affected = command.ExecuteNonQuery();

            Connection.Close();

            return affected;
        }

        public int DeleteByKey(int key)
        {

         Connection.Open();

            command.CommandText = string.Format("DELETE FROM {0}.{1} WHERE `KEY` = {2};", this.DATABASE, this.CurrentTable, key);

            command.ExecuteNonQuery();

          Connection.Close();

            return 1;
        }

        public int EditActive(int key, bool state) {

            Connection.Open();

            string active = (state) ? "1" : "0";

            command.CommandText = string.Format("UPDATE {0}.{1} SET `ACTIVE`= '{2}' WHERE  `KEY`= {3} LIMIT 1;", this.DATABASE, this.CurrentTable, active, key);

            command.ExecuteNonQuery();

            Connection.Close();

            return 1;

        }

        public int Edit(int key, string message)
        {

            Connection.Open();

            command.CommandText = string.Format("UPDATE {0}.{1} SET `LASTMSG`= '{2}' WHERE  `KEY`= {3} LIMIT 1;", this.DATABASE, this.CurrentTable, message, key);

            command.ExecuteNonQuery();

            Connection.Close();

            return 1;
        }

        public void Close() {

            Connection.Close();

        }

        public  class Codes
        {
            public const string OK = CONNECTION_OK;

        }

    }
}