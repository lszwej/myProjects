using System.Collections.Generic;

namespace MagisterkaBiblioteka
{
    public class SortBuilder
    {
        string orderText;

        public SortBuilder()
        {
            orderText = "";
        }

        public string OrderText
        {
            get { return orderText;  }
        }

        public void OrderBy(Dictionary<Column, OrderByTypes> data)
        {
            if (data != null)
            {
                string columns = DatabaseHelper.concatOrderBy(data);
                orderText = string.Format(" SORT {0}{1}{2} ", "{", columns, "}");
            }
        }
    }
}