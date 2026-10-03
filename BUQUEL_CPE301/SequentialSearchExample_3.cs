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
    public partial class SequentialSearchExample_3 : Form
    {
        public SequentialSearchExample_3()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text.Trim();
            bool found = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string employeeName =
                    dataGridView1.Rows[i].Cells["EmployeeName"].Value?.ToString() ?? "";

                if (employeeName.Equals(searchName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    string id =
                        dataGridView1.Rows[i].Cells["EmployeeID"].Value?.ToString() ?? "";

                    string department =
                        dataGridView1.Rows[i].Cells["Department"].Value?.ToString() ?? "";

                    string position =
                        dataGridView1.Rows[i].Cells["Position"].Value?.ToString() ?? "";

                    MessageBox.Show(
                        "Employee Found\n\n" +
                        "ID: " + id +
                        "\nName: " + employeeName +
                        "\nDepartment: " + department +
                        "\nPosition: " + position);

                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;

                    found = true;
                    break;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void SequentialSearchExample_3_Load(object sender, EventArgs e)
        {


            dataGridView1.Columns.Add("EmployeeID", "EmployeeID");
            dataGridView1.Columns.Add("EmployeeName", "EmployeeName");
            dataGridView1.Columns.Add("Department", "Department");
            dataGridView1.Columns.Add("Position", "Position");

            dataGridView1.Rows.Add("E001", "John Lord Buquel", "IT", "Programmer");
            dataGridView1.Rows.Add("E002", "David Monzon", "HR", "HR Officer");
            dataGridView1.Rows.Add("E003", "Richard Rosales", "Accounting", "Accountant");
            dataGridView1.Rows.Add("E004", "Ernest Solis", "IT", "System Analyst");

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