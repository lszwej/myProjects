namespace MagisterkaBiblioteka
{
    public class Column
    {
        private string name;
        private bool isAutoIncrement;
        private string tableName;

        public Column(Column col)
        {
            if (col != null)
            {
                name = col.name ?? "";
                tableName = col.tableName ?? "";
                isAutoIncrement = col.isAutoIncrement;
            }
        }

        public Column(string name, string tableName = "", bool isAutoIncrement = false)
        {
            this.tableName = tableName ?? "";
            this.name = name ?? "";
            this.isAutoIncrement = isAutoIncrement;
        }

        public string ColumnName
        {
            get { return name; }
        }

        public bool IsAutoIncrement
        {
            get { return isAutoIncrement; }
        }

        public string TableName
        {
            get { return tableName; }
            set { tableName = value ?? ""; }
        }

        public override string ToString()
        {
            return ColumnName;
        }
    }
}