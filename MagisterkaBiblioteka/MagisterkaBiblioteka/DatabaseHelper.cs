using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MagisterkaBiblioteka
{
    internal struct DatabaseHelper
    {
        internal static TableCollection getTablesNames(SqlConnection connection, string database = "")
        {
            List<string> tablesList = connection.GetSchema("Tables").AsEnumerable().Select(x => x["TABLE_NAME"].ToString()).ToList();
            TableCollection tables = new TableCollection(tablesList, database);
            return tables;
        }

        internal static TableCollection getTablesNames(MySqlConnection connection, string database = "")
        {
            List<string> tablesList = connection.GetSchema("Tables").AsEnumerable().Select(x => x["TABLE_NAME"].ToString()).ToList();
            TableCollection tables = new TableCollection(tablesList, database);
            return tables;
        }

        internal static string concatOrderBy(Dictionary<Column, OrderByTypes> data)
        {
            StringBuilder builder = new StringBuilder("");
            foreach (KeyValuePair<Column, OrderByTypes> value in data)
                builder.Append(value.Key + " " + value.Value + ",");
            builder.Replace(",", "", builder.Length - 1, 1);
            return builder.ToString();
        }

        internal static string concatUpdate(Dictionary<Column, object> data)
        {
            StringBuilder builder = new StringBuilder("");
            foreach (KeyValuePair<Column, object> value in data)
                builder.Append(value.Key + " = " + value.Value + ",");
            builder.Replace(",", "", builder.Length - 1, 1);
            return builder.ToString();
        }

        internal static string concatColumns(ColumnCollection columns)
        {
            StringBuilder builder = new StringBuilder("");
            foreach (Column column in columns.Columns)
                builder.Append(column.ColumnName + ",");
            builder.Replace(",", "", builder.Length - 1, 1);
            return builder.ToString();
        }

        internal static string concatValues(List<object> values)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string value in values)
                builder.Append(value + ",");
            builder.Replace(",", "", builder.Length - 1, 1);
            return builder.ToString();
        }

        internal static string findTable(string metaQuery)
        {
            const string PATTERN = @"(for|from)\s+(\s*|\[)([a-z0-9]+)";
            string tableName = "";
            Regex regex = new Regex(PATTERN, RegexOptions.IgnoreCase);
            Match match = regex.Match(metaQuery);
            if (match.Success)
                tableName = match.Groups[3].Value;
            return tableName;
        }
    }
}