using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MagisterkaBiblioteka;

namespace Magisterka
{
    public partial class MainForm : Form
    {
        internal static IDatabaseWrapper wrapper;
        internal static TableCollection tables;

        public MainForm()
        {
            InitializeComponent();
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("Show all records", showAllRecordsToolStripMenuItem_Click);
            menu.MenuItems.Add("Show selected records", showSelectedRecordsToolStripMenuItem_Click);
            menu.MenuItems.Add("Insert records", insertRecordToolStripMenuItem_Click);
            menu.MenuItems.Add("Update records", updateRecordsToolStripMenuItem_Click);
            menu.MenuItems.Add("Delete records", deleteRecordsToolStripMenuItem_Click);
            menu.MenuItems.Add("Type metalanguage query", typeMetaLanguageToolStripMenuItem_Click);
            tablesList.ContextMenu = menu;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to exit?", "Exit application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                e.Cancel = true;
        }

        private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectForm form = new ConnectForm();
                form.ShowDialog();
                mainGridView.DataSource = null;
                tablesList.Items.Clear();
                if (wrapper != null)
                {
                    tables = wrapper.GetTables();
                    tablesList.Items.AddRange(tables.Tables.ToArray());
                    tablesList.Visible = true;
                    mainGridView.Visible = true;
                    saveBut.Visible = true;
                    cancelBut.Visible = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has catched!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showAllRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tablesList.SelectedItem != null)
                {
                    string tableName = tablesList.SelectedItem.ToString();
                    wrapper.Select(tableName);
                    mainGridView.DataSource = wrapper.CurrentTable;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has catched!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showSelectedRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tablesList.SelectedItem != null)
                {
                    string tableName = tablesList.SelectedItem.ToString();
                    ColumnCollection columns = wrapper.GetColumns(tableName);
                    SelectForm form = new SelectForm(columns);
                    form.ShowDialog();
                    if (!form.isClosedByX())
                    {
                        ColumnCollection selectedColumns = form.getSelectedColumns();
                        decimal limit = form.getLimit();
                        WhereBuilder whBuilder = form.getWhereBuilder();
                        SortBuilder srBuilder = form.getSortBuilder();
                        JoinBuilder jnBuilder = form.getJoinBuilder();
                        wrapper.Select(tableName, selectedColumns, whBuilder, jnBuilder, srBuilder, limit);
                        mainGridView.DataSource = wrapper.CurrentTable;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has catched!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tablesList.SelectedItem != null)
                {
                    string tableName = tablesList.SelectedItem.ToString();
                    ColumnCollection columns = wrapper.GetColumns(tableName);
                    InsertForm form = new InsertForm(columns);
                    form.ShowDialog();
                    Dictionary<Column, object> data = form.getData();
                    wrapper.Insert(tableName, data);
                    mainGridView.DataSource = wrapper.CurrentTable; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has catched!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tablesList.SelectedItem != null)
                {
                    string tableName = tablesList.SelectedItem.ToString() ?? "";
                    ColumnCollection columns = wrapper.GetColumns(tableName);
                    UpdateForm form = new UpdateForm(columns);
                    form.ShowDialog();
                    Dictionary<Column, object> data = form.getData();
                    if (data.Count > 0)
                    {
                        WhereBuilder whBuilder = form.getWhBuilder();
                        wrapper.Update(tableName, data, whBuilder);
                        mainGridView.DataSource = wrapper.CurrentTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has catched!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tablesList.SelectedItem != null)
                {
                    string tableName = tablesList.SelectedItem.ToString() ?? "";
                    ColumnCollection columns = wrapper.GetColumns(tableName);
                    DeleteForm form = new DeleteForm(columns);
                    form.ShowDialog();
                    if (!form.isClosedByX())
                    {
                        WhereBuilder whBuilder = form.getWhBuilder();
                        wrapper.Delete(tableName, whBuilder);
                        mainGridView.DataSource = wrapper.CurrentTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has catched!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void typeMetaLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MetaLanguageForm form = new MetaLanguageForm();
                form.ShowDialog();
                string metaQuery = form.getMetaLanguageQuery();
                if (metaQuery.Length > 0)
                {
                    wrapper.ExecuteMetaLanguage(metaQuery);
                    mainGridView.DataSource = wrapper.CurrentTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has catched!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveBut_Click(object sender, EventArgs e)
        {
            try
            {
                wrapper.ModifyRecords();
                mainGridView.DataSource = wrapper.CurrentTable;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has catched!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            try
            {
                showAllRecordsToolStripMenuItem_Click(sender, e);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has catched!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wrapper != null)
            {
                wrapper.CloseConnection();
                mainGridView.DataSource = null;
                tablesList.DataSource = null;
                tablesList.Visible = false;
                mainGridView.Visible = false;
                saveBut.Visible = false;
                cancelBut.Visible = false;
            }
        }
    }
}