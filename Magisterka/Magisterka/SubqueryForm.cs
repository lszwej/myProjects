using MagisterkaBiblioteka;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Magisterka
{
    public partial class SubqueryForm : Form
    {
        private WhereBuilder whBuilder;
        private SubqueryBuilder sbBuilder;
        private ColumnCollection selectedColumns;
        private List<object> values;

        public SubqueryForm()
        {
            InitializeComponent();
            whBuilder = new WhereBuilder();
            sbBuilder = new SubqueryBuilder();
            selectedColumns = new ColumnCollection();
            values = new List<object>();
            tableCombo.Items.AddRange(MainForm.tables.Tables.ToArray());
        }

        public SubqueryBuilder getSubqueryBuilder()
        {
            return sbBuilder;
        }

        private void selectAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            AssistantForm.checkColumns(selectAllCheck, columnsCheckBox);
        }

        private void tableCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableCombo.SelectedItem != null)
            {
                columnsCheckBox.Items.Clear();
                columnCombo.Items.Clear();
                ColumnCollection columns = MainForm.wrapper.GetColumns(tableCombo.SelectedItem.ToString());
                Column[] cols = columns.Columns.ToArray(); 
                columnsCheckBox.Items.AddRange(cols);
                columnCombo.Items.AddRange(cols);
            }
        }

        private void valueBut_Click(object sender, EventArgs e)
        {
            AssistantForm.addValue(valueText, values);
        }

        private void addCondBut_Click(object sender, EventArgs e)
        {
            AssistantForm.addCondition(queryOperCombo, negateBox, columnCombo, compareOperCombo, whBuilder, sbBuilder, values);
        }

        private void generQueryBut_Click(object sender, EventArgs e)
        {
            foreach (var elem in columnsCheckBox.CheckedItems)
                selectedColumns.AddColumn(new Column(elem.ToString()));
            string table = tableCombo.SelectedItem.ToString();
            sbBuilder.CreateSubquery(selectedColumns, table, whBuilder);
            Close();
        }
    }
}