using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School_DataBase
{
    public partial class StudyYear : Form
    {
        private int Id;

        public StudyYear()
        {
            InitializeComponent();
            studyYearTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
        }

        private void Subject_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.StudyYear' table. You can move, or remove it, as needed.
            this.studyYearTableAdapter.Fill(this.schoolDataSet.StudyYear);
            //textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter years!");
                }
                else
                {
                    Id = Convert.ToInt32(studyYearTableAdapter.MaxId()) + 1;
                    studyYearTableAdapter.Insert(Id, textBox1.Text);
                    studyYearTableAdapter.Fill(schoolDataSet.StudyYear);
                    schoolDataSet.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studyYearTableAdapter.UpdateQuery(textBox1.Text, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            studyYearTableAdapter.Fill(schoolDataSet.StudyYear);
            schoolDataSet.AcceptChanges();
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                studyYearTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                studyYearTableAdapter.Fill(schoolDataSet.StudyYear);
                schoolDataSet.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\nOR this element may be in reference with another table");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && textBox3.Text == "")
                { 
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM StudyYear WHERE SUBSTRING(EntryExitYear,1,4)>=" + textBox2.Text + " ;";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (textBox2.Text=="" && textBox3.Text!="")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM StudyYear WHERE SUBSTRING(EntryExitYear,1,4)<=" + textBox3.Text + " ;";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (textBox2.Text != "" && textBox3.Text != "")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM StudyYear WHERE SUBSTRING(EntryExitYear,1,4) BETWEEN '" + textBox2.Text + "' AND '" + textBox3.Text + "' ;";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (textBox2.Text == "" && textBox3.Text == "")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM StudyYear;";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
         }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring.Open();
            string command = "SELECT * FROM StudyYear;";
            SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
            DataTable dt = new DataTable();
            ida.Fill(dt);
            dataGridView1.DataSource = dt;
            connectstring.Close();
        }
    }
}
