using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver
{
    public partial class Form1 : Form
    {
        DataGridView GetDataGridView1 = new DataGridView();

        public Form1()
        {
            InitializeComponent();

            string[] dirs = Directory.GetDirectories(@"C:\");

            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
        }
        
        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InsertNewRowtoDGV()
        {
            string[] dirs = Directory.GetDirectories(@"C\:");

            foreach (var dir in dirs)
            {

                dataGridView1.Columns[0].HeaderText = "buzi";
                //string[] row = new string[] { dir };
                //dataGridView1.Rows.Add(row);
                this.dataGridView1.Rows.Add("anyad");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
