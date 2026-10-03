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
    public partial class SequentialSearchExample_6 : Form
    {
        public SequentialSearchExample_6()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchCourse = txtSearch.Text.Trim();
            int count = 0;

            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string course =
                    dataGridView1.Rows[i].Cells["Course"].Value?.ToString() ?? "";

                if (course.Equals(searchCourse,
                    StringComparison.OrdinalIgnoreCase))
                {
                    dataGridView1.Rows[i].Selected = true;
                    count++;
                }
            }

            if (count > 0)
            {
                MessageBox.Show(
                    count + " matching record(s) found.");
            }
            else
            {
                MessageBox.Show("No matching records found.");
            }
        }

        private void SequentialSearchExample_6_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Course", "Course");
            dataGridView1.Rows.Add("1001", "John Buquel", "BSIT");
            dataGridView1.Rows.Add("1002", "David Monzon", "BSCS");
            dataGridView1.Rows.Add("1003", "Richard Rosales", "BSIT");
            dataGridView1.Rows.Add("1004", "Ernest SOlis", "BSIS");
            dataGridView1.Rows.Add("1005", "Karlo Legaspi", "BSIT");

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Height = dataGridView1.ColumnHeadersHeight
                                 + dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                                 + 2;

            dataGridView1.BackgroundColor = Color.White;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
