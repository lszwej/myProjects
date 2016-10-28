using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MagisterkaBiblioteka;

namespace Magisterka
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
            engineCombo.SelectedIndex = 0;
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void connectBut_Click(object sender, EventArgs e)
        {
            try
            {
                string server = serverText.Text;
                string database = databaseText.Text;
                bool security = authCheck.Checked;
                string user = userText.Text;
                string password = passText.Text;

                if (!string.IsNullOrWhiteSpace(server) && !string.IsNullOrWhiteSpace(database))
                {
                    Engines engine = (Engines) Enum.Parse(typeof(Engines), engineCombo.SelectedItem.ToString());
                    switch (engine)
                    {
                        case Engines.MYSQL:
                            MySqlConnectionStringBuilder mySqlBuilder = new MySqlConnectionStringBuilder();
                            mySqlBuilder.Server = server;
                            mySqlBuilder.Database = database;
                            mySqlBuilder.IntegratedSecurity = security;
                            mySqlBuilder.UserID = user;
                            mySqlBuilder.Password = password;
                            MainForm.wrapper = new MySqlWrapper(mySqlBuilder);
                            break;
                        case Engines.SQLSERVER:
                            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                            sqlBuilder.DataSource = server;
                            sqlBuilder.InitialCatalog = database;
                            sqlBuilder.IntegratedSecurity = security;
                            sqlBuilder.UserID = user;
                            sqlBuilder.Password = password;
                            MainForm.wrapper = new SqlServerWrapper(sqlBuilder);
                            break;
                    }
                    Close();
                }
                else
                    MessageBox.Show("Please enter a server address or name and database!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has catched!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}