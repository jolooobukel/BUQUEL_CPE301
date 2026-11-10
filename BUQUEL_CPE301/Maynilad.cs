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


namespace BUQUEL_CPE301
{
    public partial class Maynilad : Form
    {
        String picturepath;
        String connectionString = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;

        DataTable table = new DataTable();
        public Maynilad()
        {
            connectionString = "Data Source=C203-05; Initial Catalog=WaterBillDB; user id=SA; password=B1Admin123@; TrustServerCertificate=True";
            connection = new SqlConnection(connectionString);

            InitializeComponent();
          
        }

        private void Maynilad_Load(object sender, EventArgs e)
        {
            connection.Open();
            sql = "SELECT * FROM customerInfoTbl c " +
                  "INNER JOIN meterTbl m ON c.soa_number = m.soa_number " +
                  "INNER JOIN paymentTbl p ON c.soa_number = p.soa_number";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
            dset = new DataSet();
            adaptersql.Fill(dset, "waterbillall");
            dataGridView1.DataSource = dset.Tables["waterbillall"];
            connection.Close();

        }
     
        private void MSC_TextChanged(object sender, EventArgs e)
        {

        }
        private double rate = 23.52, msc = 1.53;
        private void button1_Click(object sender, EventArgs e)
        {
            double cons = Convert.ToDouble(Present.Text) - Convert.ToDouble(Previous.Text);
            double basic = Math.Round(rate * cons, 2);
            double env = Math.Round(basic * 0.20, 2);
            double before = basic + env + msc;
            double tax = Math.Round(before * 0.025, 2);
            double total = before + tax;

            Consumption.Text = cons.ToString();
            Basic.Text = basic.ToString("n");
            Env.Text = env.ToString("n");
            MSC.Text = msc.ToString("n");
            Beforetax.Text = before.ToString("n");
            GovTax.Text = tax.ToString("n");
            Total.Text = total.ToString("n");
            Current.Text = total.ToString("n");

            Mayniladreceipt receipt = new Mayniladreceipt(new string[] {
                textBox1.Text,        
                textBox2.Text,        
                Contract.Text,       
                AccountName.Text,     
                Address.Text,         
                TIN.Text,             
                RateClass.Text,     
                Business.Text,      
                MeterNo.Text,       
                MRU.Text,            
                Seq.Text,             
                ReadingDate.Text,   
                Present.Text,         
                Previous.Text,        
                Consumption.Text,     
                BillingPeriod.Text,   
                Current.Text,         
                Basic.Text,           
                Env.Text,             
                MSC.Text,             
                Beforetax.Text,       
                GovTax.Text,         
                Total.Text,           
                DueDate.Text          
            });
            receipt.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();

            sql = "INSERT INTO customerInfoTbl (soa_number, statement_account, contract_account_no, account_name, service_address, tin, rate_class, business_area) " +

                  "VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + Contract.Text + "', '" + AccountName.Text + "', '" + Address.Text + "', '" + TIN.Text + "', '" + RateClass.Text + "', '" + Business.Text + "') ";

            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.InsertCommand = command;
            command.ExecuteNonQuery();

            sql = "INSERT INTO meterTbl (soa_number, meter_no, mru_no, seq_no, reading_date, present_reading, previous_reading, consumption) " +

                  "VALUES('" + textBox1.Text + "', '" + MeterNo.Text + "', '" + MRU.Text + "', '" + Seq.Text + "', '" + ReadingDate.Text + "', '" + Present.Text + "', '" + Previous.Text + "', '" + Consumption.Text + "') ";

            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.InsertCommand = command;
            command.ExecuteNonQuery();

            sql = "INSERT INTO paymentTbl (soa_number, billing_period, current_charges, basic_charge, environmental_charge, maintenance_charge, total_before_tax, government_taxes, total_amount_due, payment_due_date) " +

                  "VALUES('" + textBox1.Text + "', '" + BillingPeriod.Text + "', '" + Current.Text + "', '" + Basic.Text + "', '" + Env.Text + "', '" + MSC.Text + "', '" + Beforetax.Text + "', '" + GovTax.Text + "', '" + Total.Text + "', '" + DueDate.Text + "') ";

            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.InsertCommand = command;
            command.ExecuteNonQuery();

            sql = "SELECT * FROM waterbillview ";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "waterbillview");
            dataGridView1.DataSource = dset.Tables["waterbillview"];

            //textBox1.Clear();
            //textBox2.Clear();
            //Contract.Clear();
            //AccountName.Clear();
            //Address.Clear();
            //TIN.Clear();
            //RateClass.Clear();
            //Business.Clear();
            //MeterNo.Clear();
            //MRU.Clear();
            //Seq.Clear();
            //ReadingDate.Clear();
            //Present.Clear();
            //Previous.Clear();
            //Consumption.Clear();
            //BillingPeriod.Clear();
            //Current.Clear();
            //Basic.Clear();
            //Env.Clear();
            //MSC.Clear();
            //Beforetax.Clear();
            //GovTax.Clear();
            //Total.Clear();
            //DueDate.Clear();

            connection.Close();
        }
    }
}
