using System.Text;
using System.Collections.Generic;

namespace MagisterkaBiblioteka
{
    public class WhereBuilder
    {
        private StringBuilder whereText;

        public WhereBuilder()
        {
            whereText = new StringBuilder("");
        }

        public string WhereText
        {
            get { return whereText.ToString(); }
        }

        public void GreaterCond(QueryOperators queryOper, Column column, SubqueryBuilder sbBuilder, bool negation = false)
        {
            if (column != null && sbBuilder != null)
            { 
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} > ({2})", negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} > ({3})", queryOper, negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
            }
        }

        public void GreaterCond(QueryOperators queryOper, Column column, object value, bool negation = false)
        {
            if (column != null && value != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} >= {2}", negation ? "NOT": "", column.ColumnName, value);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} >= {3}", queryOper, negation ? "NOT" : "", column.ColumnName, value);
            }
        }

        public void GreaterEqualsCond(QueryOperators queryOper, Column column, SubqueryBuilder sbBuilder, bool negation = false)
        {
            if (column != null && sbBuilder != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} >= ({2})", negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} >= ({3})", queryOper, negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
            }
        }

        public void GreaterEqualsCond(QueryOperators queryOper, Column column, object value, bool negation = false)
        {
            if (column != null && value != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} >= {2}", negation ? "NOT" : "", column.ColumnName, value);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} >= {3}", queryOper, negation ? "NOT" : "", column.ColumnName, value);
            }
        }

        public void LesserCond(QueryOperators queryOper, Column column, SubqueryBuilder sbBuilder, bool negation = false)
        {
            if (column != null && sbBuilder != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} < ({2})", negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} < ({3})", queryOper, negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
            }
        }

        public void LesserCond(QueryOperators queryOper, Column column, object value, bool negation = false)
        {
            if (column != null && value != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} < {2}", negation ? "NOT" : "", column.ColumnName, value);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} < {3}", queryOper, negation ? "NOT" : "", column.ColumnName, value);
            }
        }

        public void LesserEqualsCond(QueryOperators queryOper, Column column, SubqueryBuilder sbBuilder, bool negation = false)
        {
            if (column != null && sbBuilder != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} <= ({2})", negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} <= ({3})", queryOper, negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
            }
        }

        public void LesserEqualsCond(QueryOperators queryOper, Column column, object value, bool negation = false)
        {
            if (column != null && value != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} <= {2}", negation ? "NOT" : "", column.ColumnName, value);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} <= {3}", queryOper, negation ? "NOT" : "", column.ColumnName, value);
            }
        }

        public void EqualsCond(QueryOperators queryOper, Column column, SubqueryBuilder sbBuilder, bool negation = false)
        {
            if (column != null && sbBuilder != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} = ({2})", negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} = ({3})", queryOper, negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
            }
        }

        public void EqualsCond(QueryOperators queryOper, Column column, object value, bool negation = false)
        {
            if (column != null && value != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} = {2}", negation ? "NOT" : "", column.ColumnName, value);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} = {3}", queryOper , negation ? "NOT" : "", column.ColumnName, value);
            }
        }

        public void NotEqualsCond(QueryOperators queryOper, Column column, SubqueryBuilder sbBuilder, bool negation = false)
        {
            if (column != null && sbBuilder != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} <> ({2})", negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} <> ({3})", queryOper, negation ? "NOT" : "", column.ColumnName, sbBuilder.SubqueryText);
            }
        }

        public void NotEqualsCond(QueryOperators queryOper, Column column, object value, bool negation = false)
        {
            if (column != null && value != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} <> {2}", negation ? "NOT" : "", column.ColumnName, value);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} <> {3}", queryOper, negation ? "NOT" : "", column.ColumnName, value);
            }
        }

        public void IsNullCond(QueryOperators queryOper, Column column, bool negation = false)
        {
            if (column != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} IS NULL", negation ? "NOT" : "", column.ColumnName);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} IS NULL", queryOper, negation ? "NOT" : "", column.ColumnName);
            }
        }

        public void IsNotNullCond(QueryOperators queryOper, Column column, bool negation = false)
        {
            if (column != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} IS NOT NULL", negation ? "NOT" : "", column.ColumnName);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} IS NOT NULL", queryOper, negation ? "NOT" : "", column.ColumnName);
            }
        }

        public void LikeCond(QueryOperators queryOper, Column column, object value, bool negation = false)
        {
            if (column != null && value != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} LIKE {2}", negation ? "NOT" : "", column.ColumnName, value);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} LIKE {3}", queryOper, negation ? "NOT" : "", column.ColumnName, value);
            }
        }

        public void BetweenCond(QueryOperators queryOper, Column column, object value, object value2, bool negation = false)
        {
            if (column != null && value != null && value2 != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} BETWEEN {2} AND {3}", negation ? "NOT" : "", column.ColumnName, value, value2);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} BETWEEN {3} AND {4}", queryOper, negation ? "NOT" : "", column.ColumnName, value, value2);
            }
        }

        public void ExistsCond(QueryOperators queryOper, SubqueryBuilder sbBuilder, bool negation = false)
        {
            if (sbBuilder != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} EXISTS({1})", negation ? "NOT" : "", sbBuilder.SubqueryText);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} EXISTS({2})", queryOper, negation ? "NOT" : "", sbBuilder.SubqueryText);
            }
        }

        public void InCond(QueryOperators queryOper, Column column, SubqueryBuilder sbBuilder, bool negation = false)
        {
            if (column != null && sbBuilder != null)
            {
                if (whereText.Length == 0)
                    whereText.AppendFormat(" WHERE {0} {1} IN({2})", column.ColumnName, negation ? "NOT" : "", sbBuilder.SubqueryText);
                else if (queryOper != QueryOperators.WHERE)
                    whereText.AppendFormat(" {0} {1} {2} IN({3})", queryOper, column.ColumnName, negation ? "NOT" : "", sbBuilder.SubqueryText);
            }
        }

        public void InCond(QueryOperators queryOper, Column column, List<object> values, bool negation = false)
        {
            if (column != null && values != null)
            {
                if (whereText.Length == 0)
                {
                    string inParams = DatabaseHelper.concatValues(values);
                    whereText.AppendFormat(" WHERE {0} {1} IN ({2})", negation ? "NOT" : "", column.ColumnName, inParams);
                }
                else if (queryOper != QueryOperators.WHERE)
                {
                    string inParams = DatabaseHelper.concatValues(values);
                    whereText.AppendFormat(" {0} {1} {2} IN ({3})", queryOper, negation ? "NOT" : "", column.ColumnName, inParams);
                }
            }
        }
    }
}