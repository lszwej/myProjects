using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Magisterka
{
    internal class SqlWrapper: IDataBaseWrapper
    {
        private string server;
        private string name;
        private bool security;
        private string user;
        private string password;
        private SqlConnection connection;
        private SqlDataAdapter adapter;
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

        public SqlWrapper(SqlConnectionStringBuilder builder)
        {
            if (builder != null)
            {
                server = builder.InitialCatalog;
                name = builder.DataSource;
                security = builder.IntegratedSecurity;
                user = builder.UserID;
                password = builder.Password;
                connection = new SqlConnection(builder.ConnectionString);
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
            string query = string.Concat("select * from ", tableName, ";");
            adapter = new SqlDataAdapter(query, connection);
            SqlCommandBuilder comBuilder = new SqlCommandBuilder(adapter);
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