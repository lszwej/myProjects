using System;
using System.Text;
using System.Windows.Forms;

namespace Magisterka
{
    public partial class MetaLanguageForm : Form
    {
        private string metaQuery;

        public MetaLanguageForm()
        {
            InitializeComponent();
            metaQuery = "";
        }

        public string getMetaLanguageQuery()
        {
            return metaQuery;
        }

        private void clearBut_Click(object sender, EventArgs e)
        {
            metaQueryTextBox.Lines = new string[] { "" };
        }

        private void metaQueryBut_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder("");
            foreach (string line in metaQueryTextBox.Lines)
                builder.Append(line);
            metaQuery = builder.ToString();
            Close();
        }
    }
}
