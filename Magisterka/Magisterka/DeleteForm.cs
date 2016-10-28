using MagisterkaBiblioteka;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Magisterka
{
    public partial class DeleteForm : Form
    {
        private WhereBuilder whBuilder;
        private SubqueryBuilder sbBuilder;
        private List<object> values;
        private bool closedByX;

        public DeleteForm(ColumnCollection columns)
        {
            InitializeComponent();
            closedByX = true;
            whBuilder = new WhereBuilder();
            sbBuilder = new SubqueryBuilder();
            values = new List<object>();
            if (columns != null)
                columnCombo.Items.AddRange(columns.Columns.ToArray());
        }

        public WhereBuilder getWhBuilder()
        {
            return whBuilder;
        }

        public bool isClosedByX()
        {
            return closedByX;
        }

        private void addCondBut_Click(object sender, EventArgs e)
        {
            AssistantForm.addCondition(queryOperCombo, negateBox, columnCombo, compareOperCombo, whBuilder, sbBuilder, values);
        }

        private void executeBut_Click(object sender, EventArgs e)
        {
            closedByX = false;
            Close();
        }

        private void valueBut_Click(object sender, EventArgs e)
        {
            AssistantForm.addValue(valueText, values);
        }
    }
}
