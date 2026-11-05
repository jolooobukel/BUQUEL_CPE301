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
    public partial class sentinel : Form
    {
        public sentinel()
        {
            InitializeComponent();
        }

        private void sentinel_Load(object sender, EventArgs e)
        {
            DataTable students = new DataTable();
            students.Columns.Add("ID", typeof(int));
            students.Columns.Add("Name", typeof(string));

            students.Rows.Add(101, "Ana");
            students.Rows.Add(102, "Ben");
            students.Rows.Add(103, "Cara");
            students.Rows.Add(104, "Dina");

            dataGridView1.DataSource = students;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Height = dataGridView1.ColumnHeadersHeight
                                 + dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                                 + 2;

            dataGridView1.BackgroundColor = Color.White;
        }

        private int SentinelSearch(DataTable table, string key)
        {
            var names = table.AsEnumerable()
                .Select(r => r["Name"].ToString())
                .ToList(); // copy; do not edit DataSource

            int originalCount = names.Count;
            names.Add(key); // temporary sentinel
            int i = 0;
            while (!string.Equals(names[i], key,
                    StringComparison.OrdinalIgnoreCase)) i++;

            return i < originalCount ? i : -1;
        }

        private void RunSearch(Func<DataTable, string, int> search)
        {
            var table = (DataTable)dataGridView1.DataSource;
            int index = search(table, txtSearch.Text.Trim());
            dataGridView1.ClearSelection();
            if (index >= 0)
            {
                dataGridView1.Rows[index].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = index;
            }
            MessageBox.Show(index < 0 ? "Not found" : "Found!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RunSearch(SentinelSearch);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunSearch(SequentialSearch);
        }
        private int SequentialSearch(DataTable table, string key)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (string.Equals(table.Rows[i]["Name"].ToString(), key,
                        StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }
    }
}