using System;
using System.Windows.Forms;

namespace BUQUEL_CPE301
{
    public partial class Mayniladreceipt : Form
    {
        public Mayniladreceipt(string[] d)
        {
            InitializeComponent();
            AutoScroll = true;                          // the receipt is taller than the screen
            StartPosition = FormStartPosition.CenterScreen;

            soaLbl.Text = d[0];
            monthLbl.Text = d[1];
         

            contractLbl.Text = d[2];
            accountLbl.Text = d[3];
            serviceLbl.Text = d[4];
            tinLbl.Text = d[5];
            rateLbl.Text = d[6];
            businessLbl.Text = d[7];

            meterLbl.Text = d[8];
            mruLbl.Text = d[9];
            seqLbl.Text = d[10];
            readingLbl.Text = d[11];
            presentLbl.Text = d[12];
            previousLbl.Text = d[13];
            consumptionLbl.Text = d[14];

            // "01/24/2024 TO 02/23/2024" is split into start and end
            string[] period = d[15].Split(new string[] { " TO " }, StringSplitOptions.None);
            billstartLbl.Text = period[0];
            billendLbl.Text = period.Length > 1 ? period[1] : "";

            currentLbl.Text = d[16];
            basicLbl.Text = d[17];
            environmentalLbl.Text = d[18];
            mscLbl.Text = d[19];
            beforetaxLbl.Text = d[20];
            governmentLbl.Text = d[21];
            totalLbl.Text = "PHP " + d[22];
            duedateLbl.Text = d[23];
        }

        // these two are already hooked up in your designer, so they must exist
        private void lab7_print_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void monthLbl_Click(object sender, EventArgs e)
        {

        }
    }
}