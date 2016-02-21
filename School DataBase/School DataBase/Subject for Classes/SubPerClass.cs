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

namespace School_DataBase
{
    public partial class SubPerClass : Form
    {
        public SubPerClass()
        {
            InitializeComponent();
            subjectsByClassTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            comboBox1.SelectedIndex = 0;

            SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring.Open();
            string command = "SELECT DISTINCT Subject.SubjectName, SubjectsByClass.SubjectHours, SubjectsByClass.Id_Class AS Class FROM Subject, SubjectsByClass WHERE SubjectsByClass.Id_Subject = Subject.Id_Subject AND SubjectsByClass.Id_Class ='" + comboBox1.SelectedItem.ToString() + "' ORDER BY Subject.SubjectName asc, SubjectsByClass.SubjectHours asc, SubjectsByClass.Id_Class asc;";
            SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
            DataTable dt = new DataTable();
            ida.Fill(dt);
            dataGridView1.DataSource = dt;
            connectstring.Close();

            SqlConnection connectstring1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring1.Open();
            string command1 = "SELECT DISTINCT Subject.SubjectName, SubjectsByClass.Id_Subject, SubjectsByClass.SubjectHours, SubjectsByClass.Id_Class, SubjectsByClass.Id_SubjectsByClass FROM Subject, SubjectsByClass WHERE SubjectsByClass.Id_Subject = Subject.Id_Subject AND SubjectsByClass.Id_Class ='" + comboBox1.SelectedItem.ToString() + "';";
            SqlDataAdapter ida1 = new SqlDataAdapter(command1, connectstring1);
            DataTable dt1 = new DataTable();
            ida1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            connectstring1.Close();
        }

        private void SubPerClass_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.SubjectsByClass' table. You can move, or remove it, as needed.

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring.Open();
            string command = "SELECT DISTINCT Subject.SubjectName, SubjectsByClass.SubjectHours, SubjectsByClass.Id_Class AS Class FROM Subject, SubjectsByClass WHERE SubjectsByClass.Id_Subject = Subject.Id_Subject AND SubjectsByClass.Id_Class ='" + comboBox1.SelectedItem.ToString() + "' ORDER BY Subject.SubjectName asc, SubjectsByClass.SubjectHours asc, SubjectsByClass.Id_Class asc;";
            SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
            DataTable dt = new DataTable();
            ida.Fill(dt);
            dataGridView1.DataSource = dt;
            connectstring.Close();

            SqlConnection connectstring1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring1.Open();
            string command1 = "SELECT DISTINCT Subject.SubjectName, SubjectsByClass.Id_Subject, SubjectsByClass.SubjectHours, SubjectsByClass.Id_Class, SubjectsByClass.Id_SubjectsByClass FROM Subject, SubjectsByClass WHERE SubjectsByClass.Id_Subject = Subject.Id_Subject AND SubjectsByClass.Id_Class ='" + comboBox1.SelectedItem.ToString() + "' ORDER BY Subject.SubjectName asc, SubjectsByClass.SubjectHours asc, SubjectsByClass.Id_Class asc;";
            SqlDataAdapter ida1 = new SqlDataAdapter(command1, connectstring1);
            DataTable dt1 = new DataTable();
            ida1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            connectstring1.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                comboBox1.Enabled = false;
                SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                connectstring.Open();
                string command = "SELECT DISTINCT Subject.SubjectName, SubjectsByClass.SubjectHours, SubjectsByClass.Id_Class AS Class FROM Subject, SubjectsByClass WHERE SubjectsByClass.Id_Subject = Subject.Id_Subject ORDER BY Subject.SubjectName asc, SubjectsByClass.SubjectHours asc, SubjectsByClass.Id_Class asc;";
                SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                DataTable dt = new DataTable();
                ida.Fill(dt);
                dataGridView1.DataSource = dt;
                connectstring.Close();

                SqlConnection connectstring1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                connectstring1.Open();
                string command1 = "SELECT DISTINCT Subject.SubjectName, SubjectsByClass.Id_Subject, SubjectsByClass.SubjectHours, SubjectsByClass.Id_Class, SubjectsByClass.Id_SubjectsByClass FROM Subject, SubjectsByClass WHERE SubjectsByClass.Id_Subject = Subject.Id_Subject ORDER BY Subject.SubjectName asc, SubjectsByClass.SubjectHours asc, SubjectsByClass.Id_Class asc;";
                SqlDataAdapter ida1 = new SqlDataAdapter(command1, connectstring1);
                DataTable dt1 = new DataTable();
                ida1.Fill(dt1);
                dataGridView2.DataSource = dt1;
                connectstring1.Close();
            }
            else
            {
                comboBox1.Enabled = true;
                SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                connectstring.Open();
                string command = "SELECT DISTINCT Subject.SubjectName, SubjectsByClass.SubjectHours, SubjectsByClass.Id_Class AS Class FROM Subject, SubjectsByClass WHERE SubjectsByClass.Id_Subject = Subject.Id_Subject AND SubjectsByClass.Id_Class ='" + comboBox1.SelectedItem.ToString() + "' ORDER BY Subject.SubjectName asc, SubjectsByClass.SubjectHours asc, SubjectsByClass.Id_Class asc;";
                SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                DataTable dt = new DataTable();
                ida.Fill(dt);
                dataGridView1.DataSource = dt;
                connectstring.Close();

                SqlConnection connectstring1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                connectstring1.Open();
                string command1 = "SELECT DISTINCT Subject.SubjectName, SubjectsByClass.Id_Subject, SubjectsByClass.SubjectHours, SubjectsByClass.Id_Class, SubjectsByClass.Id_SubjectsByClass FROM Subject, SubjectsByClass WHERE SubjectsByClass.Id_Subject = Subject.Id_Subject AND SubjectsByClass.Id_Class ='" + comboBox1.SelectedItem.ToString() + "' ORDER BY Subject.SubjectName asc, SubjectsByClass.SubjectHours asc, SubjectsByClass.Id_Class asc;";
                SqlDataAdapter ida1 = new SqlDataAdapter(command1, connectstring1);
                DataTable dt1 = new DataTable();
                ida1.Fill(dt1);
                dataGridView2.DataSource = dt1;
                connectstring1.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SPClAdd sp = new SPClAdd();
            sp.ShowDialog();
            subjectsByClassTableAdapter.Fill(schoolDataSet.SubjectsByClass);
            schoolDataSet.AcceptChanges();
            checkBox1.Checked = false;
            checkBox1.Checked = true;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.Rows[i].Index;
                    dataGridView2.Refresh();
                    dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];
                    dataGridView2.Rows[i].Selected = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                SPClAdd sp = new SPClAdd(Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[4].Value), Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[3].Value), Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[1].Value), Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[2].Value));
                sp.ShowDialog();
                subjectsByClassTableAdapter.Fill(schoolDataSet.SubjectsByClass);
                schoolDataSet.AcceptChanges();
                dataGridView1.Refresh();
                dataGridView2.Refresh();
                checkBox1.Checked = false;
                checkBox1.Checked = true;
            }
            catch
            {
                MessageBox.Show("Ooops...please, try again");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                subjectsByClassTableAdapter.Delete1(Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[4].Value));
                subjectsByClassTableAdapter.Fill(schoolDataSet.SubjectsByClass);
                schoolDataSet.AcceptChanges();
                dataGridView1.Refresh();
                dataGridView2.Refresh();
                checkBox1.Checked = false;
                checkBox1.Checked = true;
            }
            catch
            {
                MessageBox.Show("Ooops...please, try again");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                    textBox1.Text = "0";
                else if (textBox2.Text == "")
                    textBox2.Text = "200";
                else if (textBox3.Text == "")
                    textBox3.Text = "1";
                else if (textBox4.Text == "")
                    textBox4.Text = "11";
                if (checkBox1.Checked)
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT DISTINCT Subject.SubjectName, SubjectsByClass.SubjectHours, SubjectsByClass.Id_Class AS Class FROM Subject, SubjectsByClass WHERE SubjectsByClass.Id_Subject = Subject.Id_Subject AND SubjectsByClass.SubjectHours BETWEEN '" + textBox1.Text + "' AND '" + textBox2.Text + "' AND SubjectsByClass.Id_Class BETWEEN '" + textBox3.Text + "' AND '" + textBox4.Text + "'ORDER BY Subject.SubjectName asc, SubjectsByClass.SubjectHours asc, SubjectsByClass.Id_Class asc;";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT DISTINCT Subject.SubjectName, SubjectsByClass.SubjectHours, SubjectsByClass.Id_Class AS Class FROM Subject, SubjectsByClass WHERE SubjectsByClass.Id_Subject = Subject.Id_Subject AND SubjectsByClass.SubjectHours BETWEEN '" + textBox1.Text + "' AND '" + textBox2.Text + "' AND SubjectsByClass.Id_Class BETWEEN '" + textBox3.Text + "' AND '" + textBox4.Text + "' AND SubjectsByClass.Id_Class ='" + comboBox1.SelectedItem.ToString() + "' ORDER BY Subject.SubjectName asc, SubjectsByClass.SubjectHours asc, SubjectsByClass.Id_Class asc;";
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
    }
}
