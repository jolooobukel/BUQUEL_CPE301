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
    public partial class SequentialSearchExample_5 : Form
    {
        public SequentialSearchExample_5()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();
            bool found = false;

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                if (dataGridView1.Rows[row].IsNewRow)
                    continue;

                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    string value =
                        dataGridView1.Rows[row].Cells[col].Value?.ToString() ?? "";

                    if (value.Equals(searchValue,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridView1.ClearSelection();

                        dataGridView1.Rows[row].Selected = true;
                        dataGridView1.CurrentCell =
                            dataGridView1.Rows[row].Cells[col];

                        MessageBox.Show(
                            "Record found at row " + (row + 1));

                        found = true;
                        break;
                    }
                }

           
                if (found)
                    break;
            }

            if (!found)
                MessageBox.Show("Record not found.");
     
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SequentialSearchExample_5_Load(object sender, EventArgs e)
        {

            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Course", "Course");
            dataGridView1.Columns.Add("Year", "Year");

            dataGridView1.Rows.Add("1001", "John Buquel", "BSIT", "1");
            dataGridView1.Rows.Add("1002", "David Monzon", "BSCS", "2");
            dataGridView1.Rows.Add("1003", "Richard Rosales", "BSIT", "3");
            dataGridView1.Rows.Add("1003", "Ernest Solis", "BSCPE", "4");

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
