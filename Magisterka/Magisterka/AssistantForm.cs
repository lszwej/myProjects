using MagisterkaBiblioteka;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Magisterka
{
    internal struct AssistantForm
    {
        internal static void checkColumns(CheckBox selecAllCheck, CheckedListBox columnsCheckBox)
        {
            if (selecAllCheck.Checked)
            {
                for (int i = 0; i < columnsCheckBox.Items.Count; ++i)
                    columnsCheckBox.SetItemCheckState(i, CheckState.Checked);
            }
            else
            {
                for (int i = 0; i < columnsCheckBox.Items.Count; ++i)
                    columnsCheckBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
       
        internal static void addValue(TextBox valueText, List<object> values)
        {
            string value = valueText.Text;
            if (value != null)
                values.Add(value);
            valueText.Clear();
        }
      
        internal static void addCondition(ComboBox queryOperCombo, CheckBox negateBox, ComboBox columnCombo, ComboBox compareOperCombo, WhereBuilder whBuilder, SubqueryBuilder sbBuilder, List<object> values)
        {
            string oper = queryOperCombo.SelectedItem.ToString();
            bool negation = negateBox.Checked;
            QueryOperators queryOper = (QueryOperators)Enum.Parse(typeof(QueryOperators), oper);
            Column column = new Column(columnCombo.SelectedItem.ToString());
            string compareOper = compareOperCombo.SelectedItem.ToString();
            switch (compareOper)
            {
                case ">":
                    if (sbBuilder.SubqueryText.Length == 0)
                        whBuilder.GreaterCond(queryOper, column, values[0], negation);
                    else
                        whBuilder.GreaterCond(queryOper, column, sbBuilder, negation);
                    break;
                case ">=":
                    if (sbBuilder.SubqueryText.Length == 0)
                        whBuilder.GreaterEqualsCond(queryOper, column, values[0], negation);
                    else
                        whBuilder.GreaterEqualsCond(queryOper, column, sbBuilder, negation);
                    break;
                case "<":
                    if (sbBuilder.SubqueryText.Length == 0)
                        whBuilder.LesserCond(queryOper, column, values[0], negation);
                    else
                        whBuilder.LesserCond(queryOper, column, sbBuilder, negation);
                    break;
                case "<=":
                    if (sbBuilder.SubqueryText.Length == 0)
                        whBuilder.LesserEqualsCond(queryOper, column, values[0], negation);
                    else
                        whBuilder.LesserEqualsCond(queryOper, column, sbBuilder, negation);
                    break;
                case "=":
                    if (sbBuilder.SubqueryText.Length == 0)
                        whBuilder.EqualsCond(queryOper, column, values[0], negation);
                    else
                        whBuilder.EqualsCond(queryOper, column, sbBuilder, negation);
                    break;
                case "<>":
                    if (sbBuilder.SubqueryText.Length == 0)
                        whBuilder.NotEqualsCond(queryOper, column, values[0], negation);
                    else
                        whBuilder.NotEqualsCond(queryOper, column, sbBuilder, negation);
                    break;
                case "IS NULL":
                    whBuilder.IsNullCond(queryOper, column, negation);
                    break;
                case "IS NOT NULL":
                    whBuilder.IsNotNullCond(queryOper, column, negation);
                    break;
                case "LIKE":
                    whBuilder.LikeCond(queryOper, column, values[0], negation);
                    break;
                case "BETWEEN":
                    whBuilder.BetweenCond(queryOper, column, values[0], values[1], negation);
                    break;
                case "EXISTS":
                    if (sbBuilder.SubqueryText.Length > 0)
                        whBuilder.ExistsCond(queryOper, sbBuilder, negation);
                    break;
                case "IN":
                    if (sbBuilder.SubqueryText.Length == 0)
                        whBuilder.InCond(queryOper, column, values, negation);
                    else
                        whBuilder.InCond(queryOper, column, sbBuilder, negation);
                    break;
            }
        }
    }
}