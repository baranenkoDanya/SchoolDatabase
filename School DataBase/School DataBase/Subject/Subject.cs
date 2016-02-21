using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace School_DataBase
{
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
            subjectTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
        }

        private void Subject_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.Subject' table. You can move, or remove it, as needed.
            this.subjectTableAdapter.Fill(this.schoolDataSet.Subject);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var add = new SubjectAdder();
            add.ShowDialog();
            subjectTableAdapter.Fill(schoolDataSet.Subject);
            schoolDataSet.AcceptChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                subjectTableAdapter.Delete1(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                subjectTableAdapter.Fill(schoolDataSet.Subject);
                schoolDataSet.AcceptChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\nOR THIS ELEMENT REFERENCES TO ANOTHER TABLE");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cl = new SchoolDataSet.SubjectDataTable();
            subjectTableAdapter.FillBy(cl, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            object[] row = cl.Rows[0].ItemArray;
            var edit = new SubjectAdder(Convert.ToInt32(row[0]), Convert.ToString(row[1]));
            edit.ShowDialog();
            subjectTableAdapter.Fill(schoolDataSet.Subject);
            schoolDataSet.AcceptChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    if (dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SteelBlue;
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.SteelBlue)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
        }
    }
}
