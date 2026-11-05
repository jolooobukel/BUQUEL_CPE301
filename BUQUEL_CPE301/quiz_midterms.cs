using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BUQUEL_CPE301
{
    public partial class quiz_midterms : Form
    {
        String picturepath;
        String connectionString = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;

        double hmdfpay = 100;
        public quiz_midterms()
        {
            connectionString = "Data Source=C203-05; Initial Catalog=MidtermDb; user id=SA; password=B1Admin123@; TrustServerCertificate=True";
            connection = new SqlConnection(connectionString);

            InitializeComponent();
        }

        DataTable table = new DataTable();
        private void quiz_midterms_Load(object sender, EventArgs e)
        {
            connection.Open();
            sql = "SELECT * FROM quizTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            dset = new DataSet();
            adaptersql.Fill(dset, "quizTbl");
            table = dset.Tables["quizTbl"];
            dataGridView1.DataSource = table;
            connection.Close();
            
            hmdf.Text = "100.00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();

            sql = "INSERT INTO quizTbl (company, department, code, cutoff, name_, payperiod, basicpay, overtime, absence, honorarium, tardy, gross, deduction, netpay) " +

                "VALUES('" + company.Text + "', '" + department.Text + "','" + code.Text + "','" + cutoff.Text + "', '" + name.Text + "', '" + payperiod.Text + "', '" + basicpay.Text + "', '" + overtime.Text + "', '" + absence.Text + "', '" + honorarium.Text + "', '" + tardy.Text + "', '" + gross.Text + "', '" + deduction.Text + "', '" + netpay.Text + "') ";

            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.InsertCommand = command;
            command.ExecuteNonQuery();

            sql = "SELECT * FROM quizTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            dset = new DataSet();
            adaptersql.Fill(dset, "quizTbl");
            table = dset.Tables["quizTbl"];
            dataGridView1.DataSource = table;

            dataGridView1.Refresh();

            company.Clear();
            department.Clear();
            code.Clear();
            cutoff.Clear();
            name.Clear();
            payperiod.Clear();
            basicpay.Clear();
            overtime.Clear();
            absence.Clear();
            tardy.Clear();
            gross.Clear();
            deduction.Clear();
            //honorarium.Clear();
            sss.Clear();
            //hmdf.Clear();
            philhealth.Clear();

            dataGridView1.Refresh();
           

            connection.Close();
           
            MessageBox.Show(
                   "Record save.",
                   "thankyou",
                   MessageBoxButtons.OK);
            
        }

        private void basicpay_TextChanged(object sender, EventArgs e)
        {

        }

        private double ssscontrib, philcontrib;

        private void button1_Click(object sender, EventArgs e)
        {
           double rateperhour = Convert.ToInt32(rate.Text);
           double numhour = Convert.ToInt32(numhrs.Text);
           double overtimehours = Convert.ToInt32(overtimehrs.Text);
           double absenthours = Convert.ToInt32(absenthr.Text);
           double tardyhours = Convert.ToInt32(tardyhrs.Text);
           //double grossearnings = Convert.ToInt32(gross.Text);
           double honopay = Convert.ToInt32(honorarium.Text);
           //double ssscont = Convert.ToInt32(sss.Text);
           //double philcont = Convert.ToInt32(philhealth.Text);
           //double hmdfcont = Convert.ToInt32(hmdf.Text);

            double basicpays = rateperhour * numhour;
            basicpay.Text = basicpays.ToString("C");

            double overtimepay = rateperhour * overtimehours;
            overtime.Text = overtimepay.ToString("C");

            double absencepay = rateperhour * absenthours;
            absence.Text = absencepay.ToString("C");

            double tardypay = rateperhour * tardyhours;
            tardy.Text = tardypay.ToString("C");

            double grossearningpay = basicpays + overtimepay + honopay;
            gross.Text = grossearningpay.ToString("C");

            double deductionpay = absencepay + tardypay + ssscontrib + philcontrib + hmdfpay;
            deduction.Text = deductionpay.ToString("C");

            double Netpays = grossearningpay - deductionpay;
            netpay.Text = Netpays.ToString("C");

            if (grossearningpay > 0 && grossearningpay <= 20000)
            {
                ssscontrib = 125.75;
            }
            else if (grossearningpay > 20001 && grossearningpay <= 50000)
            {
                ssscontrib = 2200.50;
            }
            else if (grossearningpay > 50001 && grossearningpay <= 75008)
            {
                ssscontrib = 4800;
            }
            else
            {
                ssscontrib = 5800;
            }
            if (grossearningpay > 0 && grossearningpay <= 20000)
            {
                philcontrib = 125.75;
            }
            else if (grossearningpay > 20001 && grossearningpay <= 50000)
            {
                philcontrib = 2200.50;
            }
            else if (grossearningpay > 50001 && grossearningpay <= 75000)
            {
                philcontrib = 4800;
            }
            else
            {
                philcontrib = 5800;
            }
            sss.Text = ssscontrib.ToString("c");
            philhealth.Text = philcontrib.ToString("c");

        }

        private void overtime_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text.Trim();
            bool found = false;
            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string employeeCode =
                    dataGridView1.Rows[i].Cells["code"].Value?.ToString() ?? "";

                if (employeeCode.Equals(searchName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    string name =
                        dataGridView1.Rows[i].Cells["name_"].Value?.ToString() ?? "";

                    string gross =
                        dataGridView1.Rows[i].Cells["gross"].Value?.ToString() ?? "";

                    string deduction =
                        dataGridView1.Rows[i].Cells["deduction"].Value?.ToString() ?? "";

                    string netpay =
                        dataGridView1.Rows[i].Cells["netpay"].Value?.ToString() ?? "";

                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;   // scroll to the match
                    dataGridView1.Refresh();

                    MessageBox.Show(
                        "Employee Found\n\n" +
                        "Employee Name: " + name +
                        "\ngross income: " + gross +
                        "\ndeduction: " + deduction +
                        "\nnetpay: " + netpay);

                    //dataGridView1.ClearSelection();
                    //dataGridView1.Rows[i].Selected = true;

                    found = true;
                    //break;
                }
            }

            if (!found)
                MessageBox.Show("Product not found.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }       

        private void hmdf_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
