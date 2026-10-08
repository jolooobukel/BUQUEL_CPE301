using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BUQUEL_CPE301
{
    public partial class Employeedata : Form
    {
        String picturepath;
        String connectionString = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;


        public Employeedata()
        {
            //connectionString = "Server=LAPTOP-9RU49MV3;Database=DSALDB;Integrated Security=True;";
            connectionString = "Data Source=C203-05; Initial Catalog=DSALDB; user id=SA; password=B1Admin123@; TrustServerCertificate=True";
            connection = new SqlConnection(connectionString);


            InitializeComponent();
        }

        private void LoadData()
        {
            connection.Open();
            sql = "SELECT * FROM dsaltbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            dset = new DataSet();
            adaptersql.Fill(dset, "dsaltbl");
            table = dset.Tables["dsaltbl"];
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void Employeedata_Load(object sender, EventArgs e)
        {

            LoadData();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        DataTable table = new DataTable();

        private void button6_Click(object sender, EventArgs e)
        {
            //example 7
            string target = txtSearch.Text.Trim();
            bool found = false;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string name = table.Rows[i]["employee_id"].ToString();

                if (name.Equals(target, StringComparison.OrdinalIgnoreCase))
                {
                    dataGridView1.Rows[i].Selected = true;                      // NEW
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;          // NEW
                    dataGridView1.Refresh();

                    MessageBox.Show(
                        "Student found at record " + (i + 1));

                    found = true;
                    //break;
                }
            }

            if (!found)
                MessageBox.Show("Student not found.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //example 5
            string searchValue = txtSearch.Text.Trim();
            bool found = false;
            dataGridView1.ClearSelection();

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
                        //dataGridView1.ClearSelection();

                        dataGridView1.Rows[row].Selected = true;
                        //dataGridView1.CurrentCell =
                        //dataGridView1.Rows[row].Cells[col];

                        dataGridView1.FirstDisplayedScrollingRowIndex = row;    // NEW
                        dataGridView1.Refresh();

                        MessageBox.Show(
                            "Record found at row " + (row + 1));

                        found = true;
                        //break;
                    }
                }


                if (found) ;
                    //break;
            }

            if (!found)
                MessageBox.Show("Record not found.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //example 6

            string searchCourse = txtSearch.Text.Trim();
            int count = 0;

            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string course =
                    dataGridView1.Rows[i].Cells["province"].Value?.ToString() ?? "";

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

        private void button3_Click(object sender, EventArgs e)
        {
            //example 2
            string searchName = txtSearch.Text.Trim();
            bool found = false;
            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string employeeName =
                    dataGridView1.Rows[i].Cells["middle_name"].Value?.ToString() ?? "";

                if (employeeName.Equals(searchName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    string id =
                        dataGridView1.Rows[i].Cells["employee_id"].Value?.ToString() ?? "";

                    string first =
                        dataGridView1.Rows[i].Cells["first_name"].Value?.ToString() ?? "";

                    string middle =
                        dataGridView1.Rows[i].Cells["middle_name"].Value?.ToString() ?? "";

                    string last =
                        dataGridView1.Rows[i].Cells["last_name"].Value?.ToString() ?? "";

                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;   // scroll to the match
                    dataGridView1.Refresh();

                    MessageBox.Show(
                        "Employee Found\n\n" +
                        "ID: " + id +
                        "\nfirst: " + first +
                        "\nmiddle: " + middle +
                        "\nlast: " + last);

                    //dataGridView1.ClearSelection();
                    //dataGridView1.Rows[i].Selected = true;

                    found = true;
                    //break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // exampple 3
            
            string searchName = txtSearch.Text.Trim();
            bool found = false;
            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string lastName =
                    dataGridView1.Rows[i].Cells["last_name"].Value?.ToString() ?? "";

                if (lastName.Equals(searchName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    string id =
                        dataGridView1.Rows[i].Cells["employee_id"].Value?.ToString() ?? "";

                    string Barangay =
                        dataGridView1.Rows[i].Cells["Barangay"].Value?.ToString() ?? "";

                    string city =
                        dataGridView1.Rows[i].Cells["city"].Value?.ToString() ?? "";

                    string province =
                        dataGridView1.Rows[i].Cells["province"].Value?.ToString() ?? "";

                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;   // scroll to the match
                    dataGridView1.Refresh();

                    MessageBox.Show(
                        "Employee Found\n\n" +
                        "last_name: " + lastName +
                        "ID: " + id +
                        "\nBarangay: " + Barangay +
                        "\ncity: " + city +
                        "\nprovince: " + province);

                    //dataGridView1.ClearSelection();
                    //dataGridView1.Rows[i].Selected = true;

                    found = true;
                    //break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //example 1
            string searchValue = txtSearch.Text.Trim();

            bool found = false;
            dataGridView1.ClearSelection();

            // Sequential Search
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // Ignore the empty new row
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string studentName =
                    dataGridView1.Rows[i].Cells["first_name"].Value?.ToString() ?? "";

                if (studentName.Equals(searchValue,
                    StringComparison.OrdinalIgnoreCase))
                {
                    // Select the matching row
                    //dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;

                    // Move DataGridView to the matching record
                    //dataGridView1.CurrentCell =
                    //dataGridView1.Rows[i].Cells["first_name"];

                    dataGridView1.FirstDisplayedScrollingRowIndex = i;          // NEW
                    dataGridView1.Refresh();

                    MessageBox.Show(
                        "Record found at row " + (i + 1),
                        "Sequential Search",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    found = true;
                    //break;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Employeeupdate updateForm = new Employeeupdate(dataGridView1.Rows[e.RowIndex]);

            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();   // refresh the grid after updating
            }
        }
    }
}
