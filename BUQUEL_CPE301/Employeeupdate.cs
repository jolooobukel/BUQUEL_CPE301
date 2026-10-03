using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BUQUEL_CPE301
{
    public partial class Employeeupdate : Form
    {
        String picturepath;
        String connectionString = null;
        SqlConnection connection;
        SqlCommand command;
        string sql = null;
        DataGridViewRow selectedRow;
        DataSet dset;
        SqlDataAdapter adaptersql;

        public Employeeupdate(DataGridViewRow row)
        {
            connectionString = "Server=LAPTOP-9RU49MV3;Database=DSALDB;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
            selectedRow = row;

            InitializeComponent();
        }

        private void Employeeupdate_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new object[] { "Mr.", "Mrs." });
            comboBox2.Items.AddRange(new object[] { "Director", "Manager", "Supervisor", "Team Lead", "Intern" });
            comboBox3.Items.AddRange(new object[] { "Marketing", "Sales", "Operations", "Customer Service", "Accounting" });
            comboBox4.Items.AddRange(new object[] { "Single", "Married" });

            FillFields();
        }

        // Puts the double-clicked row's data into the form
        private void FillFields()
        {
            Idtxtbox.Text = Cell("employee_id");
            Idtxtbox.ReadOnly = true;   // the ID identifies the record, so it can't be changed

            comboBox1.Text = Cell("salutation");
            textbox2.Text = Cell("first_name");
            textbox3.Text = Cell("middle_name");
            textbox4.Text = Cell("last_name");
            textbox5.Text = Cell("suffix");
            textbox6.Text = Cell("House_no");
            textBox7.Text = Cell("Barangay");
            textBox8.Text = Cell("city");
            textBox9.Text = Cell("province");
            textBox10.Text = Cell("zip");

            object bday = selectedRow.Cells["birthday"].Value;
            textBox11.Text = (bday is DateTime)
                ? ((DateTime)bday).ToString("MM/dd/yyyy")
                : (bday?.ToString() ?? "");

            textBox12.Text = Cell("nationality");
            textBox13.Text = Cell("email_address");
            textBox14.Text = Cell("phone_number");
            comboBox2.Text = Cell("job_title");
            comboBox3.Text = Cell("department");
            comboBox4.Text = Cell("status_");

            textBox15.Text = Cell("photo_path");
            if (File.Exists(textBox15.Text))
                pictureBox1.Image = Image.FromFile(textBox15.Text);
        }

        private string Cell(string column)
        {
            return (selectedRow.Cells[column].Value?.ToString() ?? "").Trim();
        }

        // Make sure your "Update" button's Click event points to this method
        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                sql = "UPDATE dsaltbl SET salutation = '" + comboBox1.Text + "', first_name = '" + textbox2.Text + "', " +
                      "middle_name = '" + textbox3.Text + "', last_name = '" + textbox4.Text + "', suffix = '" + textbox5.Text + "', " +
                      "House_no = '" + textbox6.Text + "', Barangay = '" + textBox7.Text + "', city = '" + textBox8.Text + "', " +
                      "province = '" + textBox9.Text + "', zip = '" + textBox10.Text + "', birthday = '" + textBox11.Text + "', " +
                      "nationality = '" + textBox12.Text + "', email_address = '" + textBox13.Text + "', phone_number = '" + textBox14.Text + "', " +
                      "job_title = '" + comboBox2.Text + "', department = '" + comboBox3.Text + "', status_ = '" + comboBox4.Text + "', " +
                      "photo_path = '" + textBox15.Text + "' WHERE employee_id = '" + Idtxtbox.Text + "'";

                command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;

                adaptersql = new SqlDataAdapter();
                adaptersql.UpdateCommand = command;
                command.ExecuteNonQuery();

                sql = "SELECT * FROM dsaltbl";
                command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;

                adaptersql = new SqlDataAdapter();
                adaptersql.SelectCommand = command;
                command.ExecuteNonQuery();

                dset = new DataSet();
                adaptersql.Fill(dset, "dsaltbl");

                MessageBox.Show("Record updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update failed");
                return;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            this.DialogResult = DialogResult.OK;   // tells Employeedata to reload its grid
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File | *.gif; *.jpg; *.png; *.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                picturepath = openFileDialog1.FileName;
                textBox15.Text = picturepath;
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}