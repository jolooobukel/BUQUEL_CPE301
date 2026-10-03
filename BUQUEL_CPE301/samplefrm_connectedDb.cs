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
    public partial class samplefrm_connectedDb : Form
    {
        String picturepath;
        String connectionString = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;

        public samplefrm_connectedDb()
        {
            connectionString = "Server=LAPTOP-9RU49MV3;Database=sampledb;Integrated Security=True;";
            connection = new SqlConnection(connectionString);

            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            sql = "SELECT * FROM studentTbl WHERE student_no = '" + student_numTxtbox.Text + "' ";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            datagrid_display.DataSource = dset.Tables[0];

            student_nameTxtbox.Text = dset.Tables[0].Rows[0][1].ToString();
            student_departmentTxtbox.Text = dset.Tables[0].Rows[0][2].ToString();
            picturpathTxtbox.Text = dset.Tables[0].Rows[0][3].ToString();
            pictureBox1.Image = Image.FromFile(picturpathTxtbox.Text);

            connection.Close();

            connection.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            sql = "DELETE FROM studentTbl WHERE student_no = '" + student_numTxtbox.Text + "'";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.DeleteCommand = command;
            command.ExecuteNonQuery();

            sql = "SELECT * FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            datagrid_display.DataSource = dset.Tables[0];

            connection.Close();

            student_numTxtbox.Clear();
            student_nameTxtbox.Clear();
            student_departmentTxtbox.Clear();
            student_numTxtbox.Focus();

            picturpathTxtbox.Text = "C:\\Users\\jiel\\Downloads\\profile.png";
            pictureBox1.Image = Image.FromFile(picturpathTxtbox.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            student_numTxtbox.Clear();
            student_nameTxtbox.Clear();
            student_departmentTxtbox.Clear();
            student_numTxtbox.Focus();

            picturpathTxtbox.Text = "C:\\Users\\jiel\\Downloads\\profile.png";
            pictureBox1.Image = Image.FromFile(picturpathTxtbox.Text);

            connection.Open();
            sql = "SELECT * FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            datagrid_display.DataSource = dset.Tables[0];
            connection.Close();
        }

        private void samplefrm_connectedDb_Load(object sender, EventArgs e)
        {
            connection.Open();
            sql = "SELECT * FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");
            datagrid_display.DataSource = dset.Tables[0];
            connection.Close();

        }

        private void student_nameTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File | *.gif; *.jpg; *.png; *.bmp";
            openFileDialog1.ShowDialog(); 
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            picturepath = openFileDialog1.FileName;
            picturpathTxtbox.Text = picturepath;

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //code to open the connection between ca and ns sqt

            connection.Open();

            //mssql query to insert or save data from GUI interface to the student table located inside the database
            sql = "INSERT INTO studentTbl (student_no, student_name, student_department, picturepath) VALUES('" + student_numTxtbox.Text +
            "','" + student_nameTxtbox.Text + "','"+ student_departmentTxtbox.Text + "', '"+ picturpathTxtbox. Text + "') ";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            //codes for mediating the language or world of C# and MSSQL
            adaptersql = new SqlDataAdapter();
            adaptersql.InsertCommand = command;
            command.ExecuteNonQuery();

            //essql query to display the contents of student table located inside the database
            sql = "SELECT * FROM studentTbl ";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            //codes for mediating the language or world of C# and MSSQL
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            //codes for mirroring the contents of the database inside the MSSQL going to C# or Visual Studio
            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            //codes for displaying the contents of student table to the inside of data grid vien
            datagrid_display.DataSource = dset.Tables[0];

            //clearing of text boxes after saving the data to the database
            pictureBox1.Image = Image.FromFile("C:\\Users\\jiel\\Downloads\\profile.png");

            student_numTxtbox.Clear();
            student_nameTxtbox.Clear();
            student_departmentTxtbox.Clear();
            picturpathTxtbox.Clear();

            connection.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            connection.Open();
            sql = "UPDATE studentTbl SET student_name = '" + student_nameTxtbox.Text + "', student_department = '" + student_departmentTxtbox.Text + "', " +
            "picturepath = '" + picturpathTxtbox.Text + "' WHERE student_no = '" + student_numTxtbox.Text + " ";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.UpdateCommand = command;
            command.ExecuteNonQuery();

            sql = "SELECT *FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            datagrid_display.DataSource = dset.Tables[0];

            connection.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            student_numTxtbox.Clear();
            student_nameTxtbox.Clear();
            student_departmentTxtbox.Clear();
            student_numTxtbox.Focus();

            picturpathTxtbox.Text = "C:\\Users\\jiel\\Downloads\\profile.png";
            pictureBox1.Image = Image.FromFile(picturpathTxtbox.Text);

            connection.Open();
            sql = "SELECT * FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            datagrid_display.DataSource = dset.Tables[0];
            connection.Close();
        }
    }
}
