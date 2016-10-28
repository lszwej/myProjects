using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using System;

namespace Magisterka
{
    class MysqlWrapper : IDataBaseWrapper
    {
        private string name;
        private string server;
        private bool security;
        private string user;
        private string password;
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataTable table;

        public string Server
        {
            get { return server; }
        }

        public string DataBaseName
        {
            get { return name; }
        }

        public string User
        {
            get { return user; }
        }

        public string Password
        {
            get { return password; }
        }

        public ConnectionState State
        {
            get { return connection.State; }
        }

        public DataTable CurrentTable
        {
            get { return table; }
        }

        public bool IntegratedSecurity
        {
            get { return security; }
        }

        public MysqlWrapper(MySqlConnectionStringBuilder builder)
        {
            if (builder != null)
            {
                server = builder.Server;
                name = builder.Database;
                security = builder.IntegratedSecurity;
                user = builder.UserID;
                password = builder.Password;
                connection = new MySqlConnection(builder.ConnectionString);
                OpenConnection();
            }
        }

        public object[] GetTablesNames()
        {
            object[] tablesName = connection.GetSchema("Tables").AsEnumerable().Select(elem => elem["table_name"]).ToArray();
            return tablesName; 
        }

        public void SelectAll(string tableName)
        {
            string query = string.Concat("select * from ", tableName , ";");
            adapter = new MySqlDataAdapter(query, connection);
            MySqlCommandBuilder comBuilder = new MySqlCommandBuilder(adapter);
            adapter.DeleteCommand = comBuilder.GetDeleteCommand();
            adapter.InsertCommand = comBuilder.GetInsertCommand();
            adapter.UpdateCommand = comBuilder.GetUpdateCommand();
            table = new DataTable(tableName);
            adapter.Fill(table);
        }

        public void ModifyRecords()
        {
            adapter.Update(table);
            SelectAll(table.TableName);
        }

        public void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

        public void Dispose()
        {
            CloseConnection();
        }

    }
}
