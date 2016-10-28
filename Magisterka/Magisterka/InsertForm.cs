using MagisterkaBiblioteka;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Magisterka
{
    public partial class InsertForm : Form
    {
        private Dictionary<Column, object> data;
        private const string READONLY = "(readonly)";

        public InsertForm(ColumnCollection columns)
        {
            InitializeComponent();
            data = new Dictionary<Column, object>();
            if (columns != null)
            {
                DataTable insertDataTable = new DataTable();
                foreach (Column col in columns.Columns)
                {
                    if (col.IsAutoIncrement)
                    {
                        insertDataTable.Columns.Add(col.ColumnName + READONLY);
                        insertDataTable.Columns[col.ColumnName + READONLY].ReadOnly = true;
                    }
                    else
                        insertDataTable.Columns.Add(col.ColumnName);
                }
                insertDataTable.Rows.Add();
                insertGridView.DataSource = insertDataTable;
            }
        }

        public Dictionary<Column, object> getData()
        {
            return data;
        }

        private void executeBut_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in insertGridView.Rows[0].Cells)
            {
                string header = cell.OwningColumn.HeaderText;
                if (!header.EndsWith(READONLY))
                {
                    Column column = new Column(header);
                    if (cell.Value != null && cell.Value.ToString().Length > 0)
                        data[column] = cell.Value;
                }
            }
            Close();
        }
    }
}