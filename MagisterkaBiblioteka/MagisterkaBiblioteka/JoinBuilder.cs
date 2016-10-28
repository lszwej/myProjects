using System.Text;

namespace MagisterkaBiblioteka
{
    public class JoinBuilder
    {
        private StringBuilder joinText;

        public JoinBuilder()
        {
            joinText = new StringBuilder("");
        }

        public string JoinText
        {
            get { return joinText.ToString(); }
        }

        public void InnerJoin(Column parentColumn, Column joinedColumn)
        {
            if (isNotNull(parentColumn, joinedColumn))
            {
                string joinCondition = addJoinCondition(parentColumn, joinedColumn);
                joinText.AppendFormat(" IJ {0} ON {1}", joinedColumn.TableName, joinCondition);
            }
        }

        public void LeftJoin(Column parentColumn, Column joinedColumn)
        {
            if (isNotNull(parentColumn, joinedColumn))
            {
                string joinCondition = addJoinCondition(parentColumn, joinedColumn);
                joinText.AppendFormat(" LJ {0} ON {1}", joinedColumn.TableName, joinCondition);
            }
        }

        public void RightJoin(Column parentColumn, Column joinedColumn)
        {
            if (isNotNull(parentColumn, joinedColumn))
            {
                string joinCondition = addJoinCondition(parentColumn, joinedColumn);
                joinText.AppendFormat(" RJ {0} ON {1}", joinedColumn.TableName, joinCondition);
            }
        }

        private string addJoinCondition(Column parentColumn, Column joinedColumn)
        {
            string join = "";
            if (isNotNull(parentColumn, joinedColumn))
                join = string.Format("{0}.{1} = {2}.{3}", parentColumn.TableName, parentColumn.ColumnName, joinedColumn.TableName, joinedColumn.ColumnName);
            return join;
        }

        private bool isNotNull(Column first, Column second)
        {
            return first != null && second != null;
        }
    }
}