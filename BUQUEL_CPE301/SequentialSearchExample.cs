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
    public partial class SequentialSearchExample : Form
    {
        public SequentialSearchExample()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SequentialSearchExample_Load(object sender, EventArgs e)
        {
            // Create DataGridView columns
            dataGridView1.Columns.Add("ID", "Student ID");
            dataGridView1.Columns.Add("Name", "Student Name");
            dataGridView1.Columns.Add("Course", "Course");

            // Add sample data
            dataGridView1.Rows.Add("1001", "Juan Dela Cruz", "BSIT");
            dataGridView1.Rows.Add("1002", "Maria Santos", "BSCS");
            dataGridView1.Rows.Add("1003", "Pedro Reyes", "BSIS");
            dataGridView1.Rows.Add("1004", "Ana Garcia", "BSIT");
            dataGridView1.Rows.Add("1005", "Carlo Mendoza", "BSCS");

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
           
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
         
            dataGridView1.Height = dataGridView1.ColumnHeadersHeight
                                 + dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                                 + 2;

            dataGridView1.BackgroundColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            bool found = false;

            // Sequential Search
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // Ignore the empty new row
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string studentName =
                    dataGridView1.Rows[i].Cells["Name"].Value?.ToString() ?? "";

                if (studentName.Equals(searchValue,
                    StringComparison.OrdinalIgnoreCase))
                {
                    // Select the matching row
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;

                    // Move DataGridView to the matching record
                    dataGridView1.CurrentCell =
                        dataGridView1.Rows[i].Cells["Name"];

                    MessageBox.Show(
                        "Record found at row " + (i + 1),
                        "Sequential Search",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show(
                    "Record not found.",
                    "Sequential Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
