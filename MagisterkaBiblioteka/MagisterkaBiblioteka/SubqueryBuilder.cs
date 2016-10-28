namespace MagisterkaBiblioteka
{
    public class SubqueryBuilder
    {
        private string queryText;

        public SubqueryBuilder()
        {
            queryText = "";
        }

        public string SubqueryText
        {
            get { return queryText; }
        }

        public void CreateSubquery(ColumnCollection columnsList, string tableName, WhereBuilder whBuilder)
        {
            if (columnsList != null && !string.IsNullOrWhiteSpace(tableName) && whBuilder != null)
            {
                string columns = DatabaseHelper.concatColumns(columnsList);
                string where = whBuilder.WhereText;
                if (where.Length > 0)
                    queryText = string.Format("SELECT {0} FROM {1}{2}", columns, tableName, where);
                else
                    queryText =  string.Format("SELECT {0} FROM {1}", columns, tableName);
            }
        }
    }
}