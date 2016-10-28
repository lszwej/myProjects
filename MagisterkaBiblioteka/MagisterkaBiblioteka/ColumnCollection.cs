using System;
using System.Collections.Generic;
using System.Linq;

namespace MagisterkaBiblioteka
{
    public class ColumnCollection
    {
        private List<Column> columns;
        private Table table;

        public ColumnCollection()
        {
            columns = new List<Column>();
        }

        public ColumnCollection(string tableName)
        {
            if (!string.IsNullOrWhiteSpace(tableName))
                table = new Table(tableName);
            columns = new List<Column>();
        }

        public ColumnCollection(ColumnCollection collection)
        {
            if (collection != null)
            {
                columns = collection.columns;
                table = collection.table;
            }
        }

        public ColumnCollection(List<Column> columns, string tableName = "")
        {
            if (columns != null)
            {
                this.columns = columns;
                table = new Table(tableName);
            }
        }

        public void AddColumn(Column newColumn)
        {
            if (newColumn != null && !columns.Contains(newColumn))
                columns.Add(newColumn);
        }

        public List<Column> Columns
        {
            get { return columns; }
        }

        public string TableName
        {
            get { return table.TableName; }
            set { table = new Table(value); }
        }

        public int Count
        {
            get { return columns.Count; }
        }

        public Column this[string name]
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(name))
                    return columns.Where(elem => elem.ColumnName.Equals(name)).FirstOrDefault();
                else
                    throw new ArgumentException("Column name is null or empty!");
            }
        }

        public Column this[int index]
        {
            get
            {
                if (index >= 0 && index < columns.Count)
                    return columns[index];
                else
                    throw new IndexOutOfRangeException("Index is out of range!");
            }
        }
    }
}