using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Łukasz_Szwej_Projekt
{
   
    public partial class Main_Form : Form
    {
        private Dictionary<string, string> tags_dict;
        
        public Main_Form()
        {
            InitializeComponent();
            tags_dict = new Dictionary<string, string>();
            fill_dict_grid();
        }

        private void fill_dict_grid()
        {
            tags_dict.Clear();
            res_gridview.Columns.Clear();
            for (int i = 0; i < tags_choose.Items.Count; ++i)
            {
                string name = tags_choose.Items[i].ToString();
                tags_dict.Add(name, "");
                res_gridview.Columns.Add("Column_" + name, name);
            }
            res_gridview.Rows.Add(1);
        }

        private void reset_but_Click(object sender, EventArgs e)
        {
            addr_txt.Text = "";
            desel_but.PerformClick();
            fill_dict_grid();
        }

        private void analy_but_Click(object sender, EventArgs e)
        {
            try
            {
                if (tags_choose.CheckedItems.Count == 0)
                    MessageBox.Show("Please check at least one element from CheckedListBox", "Nothing to analyze", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    string address = addr_txt.Text;
                    Analyzer_API analyzer = new Analyzer_API();
                    string source = analyzer.get_websitesrc(address);
                    
                    foreach (string elem in tags_choose.CheckedItems)
                    {
                        string value = analyzer.find_value(elem, source);
                        tags_dict[elem] = value;
                        res_gridview.Rows[0].Cells["Column_" + elem].Value = tags_dict[elem];
                    }
                    MessageBox.Show("The analysis ended.\r\nClose this dialog to see results.", "End of analysis", 
                        MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
            }

            catch (WebException ex) { MessageBox.Show(ex.Message, "Network error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

            catch (UriFormatException ex) { MessageBox.Show(ex.Message, "Bad URI error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

            catch (ArgumentException ex) { MessageBox.Show(ex.Message, "Bad argument error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

            catch (TimeoutException ex) { MessageBox.Show(ex.Message, "Timeout error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void desel_but_Click(object sender, EventArgs e)
        {
            foreach (int i in tags_choose.CheckedIndices)
                tags_choose.SetItemCheckState(i, CheckState.Unchecked);
        }

        private void sel_but_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tags_choose.Items.Count; ++i)
                tags_choose.SetItemCheckState(i, CheckState.Checked);
        }

        private void save_but_Click(object sender, EventArgs e)
        {
            if (save_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < res_gridview.Rows[0].Cells.Count; ++i)
                {
                    if (res_gridview.Rows[0].Cells[i].Value != null)
                        File.AppendAllText(save_dialog.FileName, res_gridview.Columns[i].Name + " => " + res_gridview.Rows[0].Cells[i].Value + Environment.NewLine);
                }
                File.AppendAllText(save_dialog.FileName, "Report created at: " + DateTime.Now + Environment.NewLine);
            }
        }
    }
}
