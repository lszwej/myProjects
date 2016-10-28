using System;
using System.Collections.Generic;
using System.Linq;

namespace MagisterkaBiblioteka
{
    public class TableCollection
    {
        private List<Table> tables;
        private string database;

        public TableCollection(string database = "")
        {
            tables = new List<Table>();
            this.database = database ?? "";
        }

        public TableCollection(TableCollection collection)
        {
            if (collection != null)
            {
                tables = collection.tables;
                database = collection.database;
            }
        }

        public TableCollection(List<Table> tables, string database = "")
        {
            if (tables != null)
            {
                this.tables = tables;
                this.database = database;
            }
        }

        public TableCollection(List<string> tables, string database = "")
        {
            if (tables != null)
            {
                this.tables = new List<Table>();
                foreach (string table in tables)
                    this.tables.Add(new Table(table));
                this.database = database;
            }
        }

        public void AddTable(Table newTable)
        {
            if (newTable != null && !tables.Contains(newTable))
                tables.Add(newTable);
        }

        public List<Table> Tables
        {
            get { return tables; }
        }

        public string Database
        {
            get { return database; }
        }

        public int Count
        {
            get { return tables.Count; }
        }

        public Table this[string name]
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(name))
                    return tables.Where(elem => elem.TableName.Equals(name)).FirstOrDefault();
                else
                    throw new ArgumentException("Table name is null or empty!");
            }
        }

        public Table this[int index]
        {
            get
            {
                if (index >= 0 && index < tables.Count)
                    return tables[index];
                else
                    throw new IndexOutOfRangeException("Index is out of range!");
            }
        }
    }
}