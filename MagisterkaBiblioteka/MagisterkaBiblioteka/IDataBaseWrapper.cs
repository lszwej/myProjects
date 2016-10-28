using System;
using System.Data;
using System.Collections.Generic;
using System.Security;

namespace MagisterkaBiblioteka
{
    public enum Engines { MYSQL, SQLSERVER };
    public enum OrderByTypes { ASC, DESC };
    public enum QueryOperators { WHERE, AND, OR };

    public interface IDatabaseWrapper : IDisposable
    {
        DataTable CurrentTable { get; }
        Engines DatabaseEngine { get; }
        TableCollection GetTables();
        ColumnCollection GetColumns(string tableName);
        void Select(string tableName);
        void Select(string tableName, ColumnCollection columns, WhereBuilder whBuilder, JoinBuilder jnBuilder, SortBuilder orBuilder, decimal limit = 0);
        void Insert(string tableName, Dictionary<Column, object> data);
        void Update(string tableName, Dictionary<Column, object> data, WhereBuilder whBuilder);
        void Delete(string tableName, WhereBuilder whBuilder);
        void ExecuteMetaLanguage(string metaQuery);
        void ModifyRecords();
        void OpenConnection();
        void CloseConnection();
    }
}