using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUQUEL_CPE301
{
    public partial class SequentialSearchExample_7 : Form
    {
        DataTable table = new DataTable();
        public SequentialSearchExample_7()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string target = txtSearch.Text.Trim();
            bool found = false;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string name = table.Rows[i]["Name"].ToString();

                if (name.Equals(target, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "Student found at record " + (i + 1));

                    found = true;
                    break;
                }
            }

            if (!found)
                MessageBox.Show("Student not found.");
        }

        private void SequentialSearchExample_7_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Course");

            table.Rows.Add("1001", "Juan Cruz", "BSIT");
            table.Rows.Add("1002", "Maria Santos", "BSCS");
            table.Rows.Add("1003", "Pedro Reyes", "BSIS");
            table.Rows.Add("1004", "Ana Garcia", "BSIT");

            dataGridView1.DataSource = table;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Height = dataGridView1.ColumnHeadersHeight
                                 + dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                                 + 2;

            dataGridView1.BackgroundColor = Color.White;
        }
    }
}
