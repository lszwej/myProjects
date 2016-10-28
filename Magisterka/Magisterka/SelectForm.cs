using MagisterkaBiblioteka;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Magisterka
{
    public partial class SelectForm : Form
    {
        private readonly ColumnCollection baseColumns;
        private ColumnCollection selectedColumns;
        private Column parentColumn;
        private Column joinedColumn;
        private Dictionary<Column, OrderByTypes> sortedColumns;
        private WhereBuilder whBuilder;
        private SubqueryBuilder sbBuilder;
        private SortBuilder srBuilder;
        private JoinBuilder jnBuilder;
        private List<object> values;
        private decimal limit;
        private bool closedByX;

        public SelectForm(ColumnCollection columns)
        {
            InitializeComponent();
            limit = 0;
            closedByX = true;
            whBuilder = new WhereBuilder();
            jnBuilder = new JoinBuilder();
            sbBuilder = new SubqueryBuilder();
            srBuilder = new SortBuilder();
            values = new List<object>();
            if (columns != null && MainForm.tables != null && MainForm.wrapper != null)
            {
                baseColumns = columns;
                addBaseColumns();
                baseColBox.Items.AddRange(baseColumns.Columns.ToArray());
                tableCombo.Items.AddRange(MainForm.tables.Tables.ToArray());
                selectedColumns = new ColumnCollection(baseColumns.TableName);
                parentColumn = new Column(baseColumns.TableName);
                sortedColumns = new Dictionary<Column, OrderByTypes>();
            }
        }

        public decimal getLimit()
        {
            return limit;
        }

        public bool isClosedByX()
        {
            return closedByX;
        }

        public ColumnCollection getSelectedColumns()
        {
            return selectedColumns;
        }

        public WhereBuilder getWhereBuilder()
        {
            return whBuilder;
        }

        public JoinBuilder getJoinBuilder()
        {
            return jnBuilder;
        }

        public SortBuilder getSortBuilder()
        {
            return srBuilder;
        }

        private void addBaseColumns()
        {
            foreach (Column col in baseColumns.Columns)
            {
                string column = baseColumns.TableName + "." + col.ColumnName;
                columnsCheckBox.Items.Add(column);
                columnCombo.Items.Add(column);
                columnSortCombo.Items.Add(column);
            }
        }

        private void selectAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            AssistantForm.checkColumns(selectAllCheck, columnsCheckBox);
        }

        private void executeBut_Click(object sender, EventArgs e)
        {
            limit = limitText.Value;
            foreach (var elem in columnsCheckBox.CheckedItems)
                selectedColumns.AddColumn(new Column(elem.ToString()));
            if (sortedColumns.Count > 0)
                srBuilder.OrderBy(sortedColumns);
            closedByX = false;
            Close();
        }

        private void addCondBut_Click(object sender, EventArgs e)
        {
            AssistantForm.addCondition(queryOperCombo, negateBox, columnCombo, compareOperCombo, whBuilder, sbBuilder, values);
        }

        private void valueBut_Click(object sender, EventArgs e)
        {
            AssistantForm.addValue(valueText, values);
        }

        private void tableCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tableName = tableCombo.SelectedItem.ToString();
            joinColBox.Items.Clear();
            columnsCheckBox.Items.Clear();
            columnCombo.Items.Clear();
            columnSortCombo.Items.Clear();
            addBaseColumns();
            ColumnCollection cols = MainForm.wrapper.GetColumns(tableName);
            foreach (Column col in cols.Columns)
            {
                string table = tableName + "." + col.ColumnName;
                joinColBox.Items.Add(table);
                columnsCheckBox.Items.Add(table);
                columnCombo.Items.Add(table);
                columnSortCombo.Items.Add(table);
            }
        }

        private void addColumnsBut_Click(object sender, EventArgs e)
        {
            object elem = baseColBox.SelectedItem;
            object elem2 = joinColBox.SelectedItem;
            if (elem != null && elem2 != null && tableCombo.SelectedItem != null)
            {
                parentColumn = new Column(elem.ToString(), baseColumns.TableName);
                string col = elem2.ToString().Split('.').GetValue(1).ToString();
                string tableName = tableCombo.SelectedItem.ToString();
                joinedColumn = new Column(col, tableName);
            }
        }

        private void addJoinBut_Click(object sender, EventArgs e)
        {
            string tableName = tableCombo.SelectedItem.ToString();
            string joinType = joinCombo.SelectedItem.ToString();
            switch (joinType)
            {
                case "INNER JOIN":
                    jnBuilder.InnerJoin(parentColumn, joinedColumn);
                    break;
                case "LEFT JOIN":
                    jnBuilder.LeftJoin(parentColumn, joinedColumn);
                    break;
                case "RIGHT JOIN":
                    jnBuilder.RightJoin(parentColumn, joinedColumn);
                    break;
            }
        }

        private void subqueryBut_Click(object sender, EventArgs e)
        {
            SubqueryForm form = new SubqueryForm();
            form.ShowDialog();
            sbBuilder = form.getSubqueryBuilder();
        }

        private void addColSortBut_Click(object sender, EventArgs e)
        {
            string tempColumn = columnSortCombo.SelectedItem.ToString();
            string column = tempColumn.Split('.').GetValue(1).ToString();
            sortedColumns[new Column(column)] = dscRadio.Checked ? OrderByTypes.DESC : OrderByTypes.ASC;
        }
    }
}