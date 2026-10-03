using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BUQUEL_CPE301;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace BUQUEL_CPE301
{
    public partial class SaveAssessment : Form
    {
        String picturepath;
        String connectionString = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;

        public SaveAssessment()
        {
            connectionString = "Server=LAPTOP-9RU49MV3;Database=Assessmentdb;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
            InitializeComponent();
        }

        //global variable
        double Comlabfee = 2500;
        double Sapfee = 2000;
        double Ciscolabfee = 4500;
        double Exambookletfee = 450;



        private void clear_studentinfo_Click(object sender, EventArgs e)
        {
            //clear all textboxes under student information group box
            name.Clear();
            program.Items.Clear();
            studentnum.Clear();
            yrlvl.Items.Clear();
            scholar.Items.Clear();

        }
        private void clead_sched_Click(object sender, EventArgs e)
        {

            //clear all textboxes under schedule of course(s) group box
            course_code.Clear();
            course_code2.Clear();
            course_code3.Clear();
            course_code4.Clear();
            course_code5.Clear();
            course_code6.Clear();
            course_code7.Clear();
            Sec.Clear();
            Sec2.Clear();
            Sec3.Clear();
            Sec4.Clear();
            Sec5.Clear();
            Sec6.Clear();
            Sec7.Clear();
            desc.Clear();
            desc2.Clear();
            desc3.Clear();
            desc4.Clear();
            desc5.Clear();
            desc6.Clear();
            desc7.Clear();
            lec.Clear();
            lec2.Clear();
            lec3.Clear();
            lec4.Clear();
            lec5.Clear();
            lec6.Clear();
            lec7.Clear();
            lab.Clear();
            lab2.Clear();
            lab3.Clear();
            lab4.Clear();
            lab5.Clear();
            lab6.Clear();
            lab7.Clear();
            cred.Clear();
            cred2.Clear();
            cred3.Clear();
            cred4.Clear();
            cred5.Clear();
            cred6.Clear();
            cred7.Clear();
            time.Clear();
            time2.Clear();
            time3.Clear();
            time4.Clear();
            time5.Clear();
            time6.Clear();
            time7.Clear();
            day.Clear();
            day2.Clear();
            day3.Clear();
            day4.Clear();
            day5.Clear();
            day6.Clear();
            day7.Clear();
            room.Clear();
            room2.Clear();
            room3.Clear();
            room4.Clear();
            room5.Clear();
            room6.Clear();
            room7.Clear();
            total_cred.Clear();
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            connection.Open();
            sql = "SELECT * FROM AssessmentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
            dset = new DataSet();
            adaptersql.Fill(dset, "AssessmentTbl");
            connection.Close();

            //populate the program combo box with the following items: BSCS, BSEE, BSCpE, BSME, BSIT, BSIE
            program.Items.Add("BS Information Technology");
            program.Items.Add("BS Computer Engineering");
            program.Items.Add("BS Electrical Engineering");
            program.Items.Add("BS Computer Science");
            program.Items.Add("BS Mechanical Engineering");
            program.Items.Add("BS Industrial Engineering");

            //populate the year level combo box with the following items: 1st Year, 2nd Year, 3rd Year, 4th Year
            yrlvl.Items.Add("1st Year");
            yrlvl.Items.Add("2nd Year");
            yrlvl.Items.Add("3rd Year");
            yrlvl.Items.Add("4th Year");

            //scholar
            scholar.Items.Add("Academic Scholar");
            scholar.Items.Add("None");

            //mode of payment
            mode.Items.Add("Installment");

            //add installment to mode of payment combo box
            modeofpayment.Text = "Installment";

            //downpayment
            down.Text = "8000";


            //set school fees
            com_lab.Text = Comlabfee.ToString("C");
            sap.Text = Sapfee.ToString("C");
            cisco.Text = Ciscolabfee.ToString("C");
            exam.Text = Exambookletfee.ToString("C");

        }

        private void lec_TextChanged(object sender, EventArgs e)
        {
            if (lec.Text != "" && lab.Text != "")
            {
                double Templec = Convert.ToInt32(lec.Text);
                double Templab = Convert.ToInt32(lab.Text);
                double totalcred = Templec + Templab;

                cred.Text = totalcred.ToString();
            }
        }

        private void lab_TextChanged(object sender, EventArgs e)
        {

            if (lec.Text != "" && lab.Text != "")
            {
                double Templec = Convert.ToInt32(lec.Text);
                double Templab = Convert.ToInt32(lab.Text);
                double totalcred = Templec + Templab;

                cred.Text = totalcred.ToString();
            }
        }

        private void cred_TextChanged(object sender, EventArgs e)
        {
            if (cred.Text != "" && cred2.Text != "" && cred3.Text != "" && cred4.Text != "" && cred5.Text != "" && cred6.Text != "" && cred7.Text != "")
            {
                double Tempcred1 = Convert.ToInt32(cred.Text);
                double Tempcred2 = Convert.ToInt32(cred2.Text);
                double Tempcred3 = Convert.ToInt32(cred3.Text);
                double Tempcred4 = Convert.ToInt32(cred4.Text);
                double Tempcred5 = Convert.ToInt32(cred5.Text);
                double Tempcred6 = Convert.ToInt32(cred6.Text);
                double Tempcred7 = Convert.ToInt32(cred7.Text);
                double totalcred = Tempcred1 + Tempcred2 + Tempcred3 + Tempcred4 + Tempcred5 + Tempcred6 + Tempcred7;

                total_cred.Text = totalcred.ToString();
            }
        }

        private void lec2_TextChanged(object sender, EventArgs e)
        {
            if (lec2.Text != "" && lab2.Text != "")
            {
                double Templec = Convert.ToInt32(lec2.Text);
                double Templab = Convert.ToInt32(lab2.Text);
                double totalcred = Templec + Templab;

                cred2.Text = totalcred.ToString();
            }
        }

        private void lab2_TextChanged(object sender, EventArgs e)
        {

            if (lec2.Text != "" && lab2.Text != "")
            {
                double Templec = Convert.ToInt32(lec2.Text);
                double Templab = Convert.ToInt32(lab2.Text);
                double totalcred = Templec + Templab;

                cred2.Text = totalcred.ToString();
            }
        }

        private void cred2_TextChanged(object sender, EventArgs e)
        {
            if (cred.Text != "" && cred2.Text != "" && cred3.Text != "" && cred4.Text != "" && cred5.Text != "" && cred6.Text != "" && cred7.Text != "")
            {
                double Tempcred1 = Convert.ToInt32(cred.Text);
                double Tempcred2 = Convert.ToInt32(cred2.Text);
                double Tempcred3 = Convert.ToInt32(cred3.Text);
                double Tempcred4 = Convert.ToInt32(cred4.Text);
                double Tempcred5 = Convert.ToInt32(cred5.Text);
                double Tempcred6 = Convert.ToInt32(cred6.Text);
                double Tempcred7 = Convert.ToInt32(cred7.Text);
                double totalcred = Tempcred1 + Tempcred2 + Tempcred3 + Tempcred4 + Tempcred5 + Tempcred6 + Tempcred7;

                total_cred.Text = totalcred.ToString();
            }
        }

        private void lec3_TextChanged(object sender, EventArgs e)
        {
            if (lec3.Text != "" && lab3.Text != "")
            {
                double Templec = Convert.ToInt32(lec3.Text);
                double Templab = Convert.ToInt32(lab3.Text);
                double totalcred = Templec + Templab;

                cred3.Text = totalcred.ToString();
            }
        }

        private void lab3_TextChanged(object sender, EventArgs e)
        {
            if (lec3.Text != "" && lab3.Text != "")
            {
                double Templec = Convert.ToInt32(lec3.Text);
                double Templab = Convert.ToInt32(lab3.Text);
                double totalcred = Templec + Templab;

                cred3.Text = totalcred.ToString();
            }
        }

        private void lec4_TextChanged(object sender, EventArgs e)
        {
            if (lec4.Text != "" && lab4.Text != "")
            {
                double Templec = Convert.ToInt32(lec4.Text);
                double Templab = Convert.ToInt32(lab4.Text);
                double totalcred = Templec + Templab;

                cred4.Text = totalcred.ToString();
            }
        }

        private void lab4_TextChanged(object sender, EventArgs e)
        {

            if (lec4.Text != "" && lab4.Text != "")
            {
                double Templec = Convert.ToInt32(lec4.Text);
                double Templab = Convert.ToInt32(lab4.Text);
                double totalcred = Templec + Templab;

                cred4.Text = totalcred.ToString();
            }
        }

        private void lec5_TextChanged(object sender, EventArgs e)
        {

            if (lec5.Text != "" && lab5.Text != "")
            {
                double Templec = Convert.ToInt32(lec5.Text);
                double Templab = Convert.ToInt32(lab5.Text);
                double totalcred = Templec + Templab;

                cred5.Text = totalcred.ToString();
            }
        }

        private void lab5_TextChanged(object sender, EventArgs e)
        {
            if (lec5.Text != "" && lab5.Text != "")
            {
                double Templec = Convert.ToInt32(lec5.Text);
                double Templab = Convert.ToInt32(lab5.Text);
                double totalcred = Templec + Templab;

                cred5.Text = totalcred.ToString();
            }
        }

        private void lec6_TextChanged(object sender, EventArgs e)
        {
            if (lec6.Text != "" && lab6.Text != "")
            {
                double Templec = Convert.ToInt32(lec6.Text);
                double Templab = Convert.ToInt32(lab6.Text);
                double totalcred = Templec + Templab;

                cred6.Text = totalcred.ToString();
            }
        }

        private void lab6_TextChanged(object sender, EventArgs e)
        {
            if (lec6.Text != "" && lab6.Text != "")
            {
                double Templec = Convert.ToInt32(lec6.Text);
                double Templab = Convert.ToInt32(lab6.Text);
                double totalcred = Templec + Templab;

                cred6.Text = totalcred.ToString();
            }
        }

        private void lec7_TextChanged(object sender, EventArgs e)
        {
            if (lec7.Text != "" && lab7.Text != "")
            {
                double Templec = Convert.ToInt32(lec7.Text);
                double Templab = Convert.ToInt32(lab7.Text);
                double totalcred = Templec + Templab;

                cred7.Text = totalcred.ToString();
            }
        }

        private void lab7_TextChanged(object sender, EventArgs e)
        {
            if (lec7.Text != "" && lab7.Text != "")
            {
                double Templec = Convert.ToInt32(lec7.Text);
                double Templab = Convert.ToInt32(lab7.Text);
                double totalcred = Templec + Templab;

                cred7.Text = totalcred.ToString();
            }
        }

        private void cred3_TextChanged(object sender, EventArgs e)
        {
            if (cred.Text != "" && cred2.Text != "" && cred3.Text != "" && cred4.Text != "" && cred5.Text != "" && cred6.Text != "" && cred7.Text != "")
            {
                double Tempcred1 = Convert.ToInt32(cred.Text);
                double Tempcred2 = Convert.ToInt32(cred2.Text);
                double Tempcred3 = Convert.ToInt32(cred3.Text);
                double Tempcred4 = Convert.ToInt32(cred4.Text);
                double Tempcred5 = Convert.ToInt32(cred5.Text);
                double Tempcred6 = Convert.ToInt32(cred6.Text);
                double Tempcred7 = Convert.ToInt32(cred7.Text);
                double totalcred = Tempcred1 + Tempcred2 + Tempcred3 + Tempcred4 + Tempcred5 + Tempcred6 + Tempcred7;

                total_cred.Text = totalcred.ToString();
            }
        }

        private void cred4_TextChanged(object sender, EventArgs e)
        {
            if (cred.Text != "" && cred2.Text != "" && cred3.Text != "" && cred4.Text != "" && cred5.Text != "" && cred6.Text != "" && cred7.Text != "")
            {
                double Tempcred1 = Convert.ToInt32(cred.Text);
                double Tempcred2 = Convert.ToInt32(cred2.Text);
                double Tempcred3 = Convert.ToInt32(cred3.Text);
                double Tempcred4 = Convert.ToInt32(cred4.Text);
                double Tempcred5 = Convert.ToInt32(cred5.Text);
                double Tempcred6 = Convert.ToInt32(cred6.Text);
                double Tempcred7 = Convert.ToInt32(cred7.Text);
                double totalcred = Tempcred1 + Tempcred2 + Tempcred3 + Tempcred4 + Tempcred5 + Tempcred6 + Tempcred7;

                total_cred.Text = totalcred.ToString();
            }
        }

        private void cred5_TextChanged(object sender, EventArgs e)
        {
            if (cred.Text != "" && cred2.Text != "" && cred3.Text != "" && cred4.Text != "" && cred5.Text != "" && cred6.Text != "" && cred7.Text != "")
            {
                double Tempcred1 = Convert.ToInt32(cred.Text);
                double Tempcred2 = Convert.ToInt32(cred2.Text);
                double Tempcred3 = Convert.ToInt32(cred3.Text);
                double Tempcred4 = Convert.ToInt32(cred4.Text);
                double Tempcred5 = Convert.ToInt32(cred5.Text);
                double Tempcred6 = Convert.ToInt32(cred6.Text);
                double Tempcred7 = Convert.ToInt32(cred7.Text);
                double totalcred = Tempcred1 + Tempcred2 + Tempcred3 + Tempcred4 + Tempcred5 + Tempcred6 + Tempcred7;

                total_cred.Text = totalcred.ToString();
            }
        }

        private void cred6_TextChanged(object sender, EventArgs e)
        {
            if (cred.Text != "" && cred2.Text != "" && cred3.Text != "" && cred4.Text != "" && cred5.Text != "" && cred6.Text != "" && cred7.Text != "")
            {
                double Tempcred1 = Convert.ToInt32(cred.Text);
                double Tempcred2 = Convert.ToInt32(cred2.Text);
                double Tempcred3 = Convert.ToInt32(cred3.Text);
                double Tempcred4 = Convert.ToInt32(cred4.Text);
                double Tempcred5 = Convert.ToInt32(cred5.Text);
                double Tempcred6 = Convert.ToInt32(cred6.Text);
                double Tempcred7 = Convert.ToInt32(cred7.Text);
                double totalcred = Tempcred1 + Tempcred2 + Tempcred3 + Tempcred4 + Tempcred5 + Tempcred6 + Tempcred7;

                total_cred.Text = totalcred.ToString();
            }
        }

        private void cred7_TextChanged(object sender, EventArgs e)
        {
            if (cred.Text != "" && cred2.Text != "" && cred3.Text != "" && cred4.Text != "" && cred5.Text != "" && cred6.Text != "" && cred7.Text != "")
            {
                double Tempcred1 = Convert.ToInt32(cred.Text);
                double Tempcred2 = Convert.ToInt32(cred2.Text);
                double Tempcred3 = Convert.ToInt32(cred3.Text);
                double Tempcred4 = Convert.ToInt32(cred4.Text);
                double Tempcred5 = Convert.ToInt32(cred5.Text);
                double Tempcred6 = Convert.ToInt32(cred6.Text);
                double Tempcred7 = Convert.ToInt32(cred7.Text);
                double totalcred = Tempcred1 + Tempcred2 + Tempcred3 + Tempcred4 + Tempcred5 + Tempcred6 + Tempcred7;

                total_cred.Text = totalcred.ToString();
            }
        }

        private void compute_Click(object sender, EventArgs e)
        {

            //local variables
            double totalcred = Convert.ToInt32(total_cred.Text);
            double temp_lab1 = Convert.ToInt32(lab.Text);
            double temp_lab2 = Convert.ToInt32(lab2.Text);
            double temp_lab3 = Convert.ToInt32(lab3.Text);
            double temp_lab4 = Convert.ToInt32(lab4.Text);
            double temp_lab5 = Convert.ToInt32(lab5.Text);
            double temp_lab6 = Convert.ToInt32(lab6.Text);
            double temp_lab7 = Convert.ToInt32(lab7.Text);





            //total tuition
            double tuition_fee = totalcred * 1500;
            total_tuition.Text = tuition_fee.ToString("C");


            //comp lab fee
            double total_labunit = temp_lab1 + temp_lab2 + temp_lab3 + temp_lab4 + temp_lab5 + temp_lab6 + temp_lab7;
            Comlabfee = total_labunit * 2500;
            // total misc

            double totalMisc = Comlabfee + Sapfee + Ciscolabfee + Exambookletfee;
            total_misc.Text = totalMisc.ToString();
            other.Text = totalMisc.ToString();
            com_lab.Text = Comlabfee.ToString();

            //
            double tuition_fee_total = tuition_fee + totalMisc;
            total_tuitionandfee.Text = tuition_fee_total.ToString();

            double installment = (tuition_fee_total - 8000) / 3;
            first.Text = installment.ToString("C");
            second.Text = installment.ToString("C");
            third.Text = installment.ToString("C");

        }

        private void course_code2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void course_code7_TextChanged(object sender, EventArgs e)
        {

        }

        private void course_code6_TextChanged(object sender, EventArgs e)
        {

        }

        private void course_code5_TextChanged(object sender, EventArgs e)
        {

        }

        private void course_code4_TextChanged(object sender, EventArgs e)
        {

        }

        private void course_code3_TextChanged(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            connection.Open();

            sql = "INSERT INTO AssessmentTbl (student_no, student_name, student_program, date_enrolled, year_level, scholar, Total_cred_units, Total_tuition, Miscellaneous_Fees, Total_Oth_Fee) " +

                "VALUES('" + studentnum.Text + "', '" + name.Text + "','" + program.Text + "','" + date.Text + "', '" + yrlvl.Text + "', '" + scholar.Text + "', '" + total_cred.Text + "', '" + total_tuition.Text + "', '" + total_misc.Text + "', '" + other.Text + "') ";

            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.InsertCommand = command;
            command.ExecuteNonQuery();

            sql = "SELECT * FROM AssessmentTbl ";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "AssessmentTbl");


            course_code.Clear();
            course_code2.Clear();
            course_code3.Clear();
            course_code4.Clear();
            course_code5.Clear();
            course_code6.Clear();
            course_code7.Clear();
            Sec.Clear();
            Sec2.Clear();
            Sec3.Clear();
            Sec4.Clear();
            Sec5.Clear();
            Sec6.Clear();
            Sec7.Clear();
            desc.Clear();
            desc2.Clear();
            desc3.Clear();
            desc4.Clear();
            desc5.Clear();
            desc6.Clear();
            desc7.Clear();
            lec.Clear();
            lec2.Clear();
            lec3.Clear();
            lec4.Clear();
            lec5.Clear();
            lec6.Clear();
            lec7.Clear();
            lab.Clear();
            lab2.Clear();
            lab3.Clear();
            lab4.Clear();
            lab5.Clear();
            lab6.Clear();
            lab7.Clear();
            cred.Clear();
            cred2.Clear();
            cred3.Clear();
            cred4.Clear();
            cred5.Clear();
            cred6.Clear();
            cred7.Clear();
            time.Clear();
            time2.Clear();
            time3.Clear();
            time4.Clear();
            time5.Clear();
            time6.Clear();
            time7.Clear();
            day.Clear();
            day2.Clear();
            day3.Clear();
            day4.Clear();
            day5.Clear();
            day6.Clear();
            day7.Clear();
            room.Clear();
            room2.Clear();
            room3.Clear();
            room4.Clear();
            room5.Clear();
            room6.Clear();
            room7.Clear();
            total_cred.Clear();

            connection.Close();

            MessageBox.Show(" Data submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
}