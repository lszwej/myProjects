using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace MagisterkaBiblioteka
{
    public class MySqlWrapper : IDatabaseWrapper
    {
        private string database;
        private MagisterkaGrammar magGrammar;
        private MySqlConnection connection;
        private DataTable currentTable;
        private MySqlDataAdapter adapter;

        public DataTable CurrentTable
        {
            get { return currentTable; }
        }

        public Engines DatabaseEngine
        {
            get { return Engines.MYSQL; }
        }

        public MySqlWrapper(MySqlConnectionStringBuilder builder)
        {
            if (builder != null)
            {
                magGrammar = new MagisterkaGrammar();
                database = builder.Database;
                connection = new MySqlConnection(builder.ConnectionString);
                OpenConnection();
            }
        }

        public TableCollection GetTables()
        {
            TableCollection tables = DatabaseHelper.getTablesNames(connection, database);
            return tables;
        }

        public ColumnCollection GetColumns(string tableName)
        {
            ColumnCollection columns = new ColumnCollection(tableName);
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                string query = string.Format("DESCRIBE {0};", tableName);
                List<Column> columnsList = new List<Column>();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["FIELD"].ToString();
                        string dataType = reader["TYPE"].ToString();
                        string extra = reader["EXTRA"].ToString();
                        bool isIdentity = extra.Equals("auto_increment");
                        columns.AddColumn(new Column(name, tableName, isIdentity));
                    }
                }
            }
            return columns;
        }

        public void Select(string tableName)
        {
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                string metaQuery = string.Format("SELECT ALL FROM {0};", tableName);
                string sqlQuery = magGrammar.ParseMetaLanguage(metaQuery);
                adapter = new MySqlDataAdapter(sqlQuery, connection);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
                adapter.InsertCommand = builder.GetInsertCommand();
                adapter.DeleteCommand = builder.GetDeleteCommand();
                adapter.UpdateCommand = builder.GetUpdateCommand();
                currentTable = new DataTable(tableName);
                adapter.Fill(currentTable);
            }
        }

        public void Select(string tableName, ColumnCollection columnsList, WhereBuilder whBuilder, JoinBuilder jnBuilder, SortBuilder srBuilder, decimal limit = 0)
        {
            if (!string.IsNullOrWhiteSpace(tableName) && columnsList != null && whBuilder != null && srBuilder != null)
            {
                string columns = DatabaseHelper.concatColumns(columnsList);
                string where = whBuilder.WhereText;
                string join = jnBuilder.JoinText;
                string order = srBuilder.OrderText;
                string metaQuery = "";
                if (columnsList.Count == 0 && limit == 0)
                    metaQuery = string.Format("SELECT ALL FROM {0}{1}{2}{3};", tableName, join, where, order);
                else if (columnsList.Count == 0 && limit > 0)
                    metaQuery = string.Format("SELECT LIMIT {0} ALL FROM {1}{2}{3};", limit, tableName, join, where, order);
                else if (columnsList.Count > 0 && limit == 0)
                    metaQuery = string.Format("SELECT {0}{1}{2} FROM {3}{4}{5}{6};", "{", columns, "}", tableName, join, where , order);
                else if (columnsList.Count > 0 && limit > 0)
                    metaQuery = string.Format("SELECT LIMIT {0} {1}{2}{3} FROM {4}{5}{6}{7};", limit, "{", columns, "}", tableName, join, where, order);
                string sqlQuery = magGrammar.ParseMetaLanguage(metaQuery);
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    adapter = new MySqlDataAdapter(command);
                    currentTable = new DataTable(tableName);
                    adapter.Fill(currentTable);
               }
            }
        }

        public void Insert(string tableName, Dictionary<Column, object> data)
        {
            if (!string.IsNullOrWhiteSpace(tableName) && data != null)
            {
                string columns = DatabaseHelper.concatColumns(new ColumnCollection(data.Keys.ToList(), tableName));
                string values = DatabaseHelper.concatValues(data.Values.ToList());
                string metaQuery = string.Format("ADD FOR {0} ({1}) VALUES({2});", tableName, columns, values);
                string sqlQuery = magGrammar.ParseMetaLanguage(metaQuery);
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Select(tableName);
                }
            }
        }

        public void Update(string tableName, Dictionary<Column, object> data, WhereBuilder whBuilder)
        {
            if (!string.IsNullOrWhiteSpace(tableName) && data != null && whBuilder != null)
            {
                string where = whBuilder.WhereText;
                string update = DatabaseHelper.concatUpdate(data);
                string metaQuery = string.Format("MODIFY FOR {0} COLUMNS {1}{2};", tableName, update, where);
                string sqlQuery = magGrammar.ParseMetaLanguage(metaQuery);
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Select(tableName);
                }
            }
        }

        public void Delete(string tableName, WhereBuilder whBuilder)
        {
            if (!string.IsNullOrWhiteSpace(tableName) && whBuilder != null)
            {
                string where = whBuilder.WhereText;
                string metaQuery = string.Format("REMOVE FROM {0}{1};", tableName, where);
                string sqlQuery = magGrammar.ParseMetaLanguage(metaQuery);
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Select(tableName);
                }
            }
        }

        public void ExecuteMetaLanguage(string metaQuery)
        {
            string tableName = DatabaseHelper.findTable(metaQuery);
            string sqlQuery = magGrammar.ParseMetaLanguage(metaQuery);
            using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
            {
                if (sqlQuery.StartsWith("SELECT".ToLower()))
                {
                    adapter = new MySqlDataAdapter(command);
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                }
                else
                {
                    command.ExecuteNonQuery();
                    adapter = new MySqlDataAdapter(command);
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                }
            }
        }

        public void ModifyRecords()
        {
            adapter.Update(currentTable);
            Select(currentTable.TableName);
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