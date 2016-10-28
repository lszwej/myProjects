using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Magisterka
{
    public enum Engines { MySQL, Postgres, SQLServer };

    public interface IDataBaseWrapper : IDisposable
    {
        string Server { get; }
        string DataBaseName { get; }
        bool IntegratedSecurity { get; }
        string User { get; }
        string Password { get; }
        ConnectionState State { get; }
        DataTable CurrentTable { get; }
        object[] GetTablesNames();
        void SelectAll(string tableName);
        void ModifyRecords();
        void OpenConnection();
        void CloseConnection();
    }
}
