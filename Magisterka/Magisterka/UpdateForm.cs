using MagisterkaBiblioteka;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Magisterka
{
    public partial class UpdateForm : Form
    {
        private WhereBuilder whBuilder;
        private SubqueryBuilder sbBuilder;
        private Dictionary<Column, object> data;
        private List<object> values;

        public UpdateForm(ColumnCollection columns)
        {
            InitializeComponent();
            whBuilder = new WhereBuilder();
            sbBuilder = new SubqueryBuilder();
            data = new Dictionary<Column, object>();
            values = new List<object>();
            if (columns != null)
            {
                Column[] columnsArr = columns.Columns.ToArray();
                columnsCheckBox.Items.AddRange(columnsArr);
                columnCombo.Items.AddRange(columnsArr);
            }
        }

        public WhereBuilder getWhBuilder()
        {
            return whBuilder;
        }

        public Dictionary<Column, object> getData()
        {
            return data;
        }

        private void executeBut_Click(object sender, EventArgs e)
        {
            if (updateGridView.Rows.Count == 1)
            {
                foreach (DataGridViewCell cell in updateGridView.Rows[0].Cells)
                {
                    Column col = new Column(cell.OwningColumn.HeaderText);
                    data[col] = cell.Value;
                }
            }
            Close();
        }

        private void addCondBut_Click(object sender, EventArgs e)
        {
            AssistantForm.addCondition(queryOperCombo, negateBox, columnCombo, compareOperCombo, whBuilder, sbBuilder, values);
        }

        private void selectAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            AssistantForm.checkColumns(selectAllCheck, columnsCheckBox);
        }

        private void choiceBut_Click(object sender, EventArgs e)
        {
            updateGridView.DataSource = null;
            DataTable insertDataTable = new DataTable();
            foreach (var elem in columnsCheckBox.CheckedItems)
                insertDataTable.Columns.Add(elem.ToString());
            if (insertDataTable.Columns.Count > 0)
                insertDataTable.Rows.Add();
            updateGridView.DataSource = insertDataTable;
        }

        private void valueBut_Click(object sender, EventArgs e)
        {
            AssistantForm.addValue(valueText, values);
        }
    }
}