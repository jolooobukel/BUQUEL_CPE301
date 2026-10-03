using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace BUQUEL_CPE301
{
    public partial class Employeesave : Form
    {
        String picturepath;
        String connectionString = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;

        private void SetupPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            textBox.TextAlign = HorizontalAlignment.Center;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void SetupComboPlaceholder(ComboBox comboBox, string placeholder)
        {
            comboBox.Text = placeholder;
            comboBox.ForeColor = Color.Gray;

            comboBox.Enter += (s, e) =>
            {
                if (comboBox.Text == placeholder)
                {
                    comboBox.Text = "";
                    comboBox.ForeColor = Color.Black;
                }
            };

            comboBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(comboBox.Text))
                {
                    comboBox.Text = placeholder;
                    comboBox.ForeColor = Color.Gray;
                }
            };
        }

        public Employeesave()
        {
            connectionString = "Server=LAPTOP-9RU49MV3;Database=DSALDB;Integrated Security=True;";
            connection = new SqlConnection(connectionString);

            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Employeesave_Load(object sender, EventArgs e)
        {
            connection.Open();
            sql = "SELECT * FROM dsaltbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
            dset = new DataSet();
            adaptersql.Fill(dset, "dsaltbl");
            connection.Close();

            comboBox1.Items.AddRange(new object[] { "Mr.", "Mrs." });
            comboBox2.Items.AddRange(new object[] { "Director", "Manager", "Supervisor", "Team Lead", "Intern" });
            comboBox3.Items.AddRange(new object[] { "Marketing", "Sales", "Operations", "Customer Service", "Accounting" });
            comboBox4.Items.AddRange(new object[] { "Single", "Married" });

            SetupPlaceholder(textbox2, "First name");
            SetupPlaceholder(textbox3, "Middle name");
            SetupPlaceholder(textbox4, "Surname");
            SetupPlaceholder(textbox5, "suffix");
            SetupPlaceholder(textbox6, "House No./Street/Subdivision");
            SetupPlaceholder(textBox7, "Barangay");
            SetupPlaceholder(textBox8, "City/Municipality");
            SetupPlaceholder(textBox9, "Province/region");
            SetupPlaceholder(textBox10, "Zip");
            SetupPlaceholder(textBox11, "mm/dd/yyyy");
            SetupPlaceholder(textBox13, "Email address");
            SetupPlaceholder(textBox14, "Telephone/Mobile No.");
            SetupComboPlaceholder(comboBox1  , "Select...");
            SetupComboPlaceholder(comboBox2, "Select...");
            SetupComboPlaceholder(comboBox3, "Select...");
            SetupComboPlaceholder(comboBox4, "Select...");

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
          
            connection.Open();

            sql = "INSERT INTO dsaltbl (employee_id, salutation, first_name, middle_name, last_name, suffix, House_no, Barangay, city, province, zip, birthday , nationality, email_address, phone_number, job_title, department, status_ , photo_path) " +
                  
                "VALUES('" + Idtxtbox.Text + "', '" + comboBox1.Text + "','" + textbox2.Text + "','" + textbox3.Text + "', '" + textbox4.Text + "', '" + textbox5.Text + "', '" + textbox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox12.Text + "', '" + textBox13.Text + "', '" + textBox14.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "', '" + comboBox4.Text + "', '" + textBox15.Text + "') ";
           
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.InsertCommand = command;
            command.ExecuteNonQuery();

            sql = "SELECT * FROM dsaltbl ";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "dsaltbl");

            pictureBox1.Image = Image.FromFile("C:\\Users\\jiel\\Downloads\\profile.png");

            Idtxtbox.Clear();
            textbox2.Clear();
            textbox3.Clear();
            textbox4.Clear();
            textbox5.Clear();
            textbox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            //textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            connection.Close();
        }

        private void surnametxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File | *.gif; *.jpg; *.png; *.bmp";
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            picturepath = openFileDialog1.FileName;
            textBox15.Text = picturepath;
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void viewbtn_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            Employeedata viewForm = new Employeedata();
            viewForm.Show();
        }
    }
}
