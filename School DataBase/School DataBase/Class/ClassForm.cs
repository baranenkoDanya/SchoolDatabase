using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;

namespace School_DataBase
{
    public partial class ClassForm : Form
    {
        public ClassForm()
        {
            InitializeComponent();
            classTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            classListTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            menuStrip1.BackColor = Color.SteelBlue;
            //string checker = "01.09." + DateTime.Now.Year + " 00:00:00";
            //if (DateTime.Now.ToString() == checker)
            //{
            //    UpdateClass();
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.Class' table. You can move, or remove it, as needed.
            classTableAdapter.Fill(this.schoolDataSet.Class);
            bindingNavigator1.BindingSource = classBindingSource;
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var add = new ClassAdder();
            add.ShowDialog();
            classTableAdapter.Fill(schoolDataSet.Class);
            schoolDataSet.AcceptChanges();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                classTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                classTableAdapter.Fill(schoolDataSet.Class);
                schoolDataSet.AcceptChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\nOR THIS ELEMENT REFERENCES TO ANOTHER TABLE");
            }
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var cl = new SchoolDataSet.ClassDataTable();
            classTableAdapter.FillBy(cl, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            object[] row = cl.Rows[0].ItemArray;
            var edit = new ClassAdder(Convert.ToInt32(row[0]), Convert.ToChar(row[1]), Convert.ToDateTime(row[2]));
            edit.ShowDialog();
            classTableAdapter.Fill(schoolDataSet.Class);
            schoolDataSet.AcceptChanges();
                
        }

        private void studyYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudyYear sty = new StudyYear();
            sty.ShowDialog();
        }

        private void classListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassList cllist = new ClassList();
            cllist.ShowDialog();
        }

        // sort
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (!checkBox3.Checked && !checkBox4.Checked)
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class ORDER BY ClassLetter asc, EntryYear asc;";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (checkBox3.Checked && !checkBox4.Checked)
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class ORDER BY ClassLetter desc, EntryYear asc;";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (!checkBox3.Checked && checkBox4.Checked)
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class ORDER BY ClassLetter asc, EntryYear desc;";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (checkBox3.Checked && checkBox4.Checked)
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class ORDER BY ClassLetter desc, EntryYear desc;";
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

        // search
        private void button2_Click(object sender, EventArgs e)
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
                    if (dataGridView1.Rows[i].Cells[1].Value != null && dataGridView1.Rows[i].Cells[2].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(textBox1.Text) || dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(textBox1.Text))
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
        
        // filter
        private void button3_Click(object sender, EventArgs e)
        {
            try {
                if (textBox2.Text != "" && sinBox.Text == "" && tillBox.Text == "")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class WHERE ClassLetter LIKE '" + textBox2.Text + "';";
                    if (textBox2.Text == "0")
                    {
                        command = "SELECT * FROM Class WHERE ClassLetter LIKE '';";
                    }
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (textBox2.Text != "" && sinBox.Text != "" && tillBox.Text == "")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class WHERE ClassLetter LIKE '" + textBox2.Text + "' AND YEAR(EntryYear) >= " + sinBox.Text + ";";
                    if (textBox2.Text == "0")
                    {
                        command = "SELECT * FROM Class WHERE ClassLetter LIKE '' AND YEAR(EntryYear) >= " + sinBox.Text + ";";
                    }
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (textBox2.Text != "" && sinBox.Text != "" && tillBox.Text != "")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class WHERE ClassLetter LIKE '" + textBox2.Text + "' AND YEAR(EntryYear) BETWEEN '" + sinBox.Text + "' AND '" + tillBox.Text + "';";
                    if (textBox2.Text == "0")
                    {
                        command = "SELECT * FROM Class WHERE ClassLetter LIKE '' AND YEAR(EntryYear) BETWEEN '" + sinBox.Text + "' AND '" + tillBox.Text + "';";
                    }
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (textBox2.Text != "" && sinBox.Text == "" && tillBox.Text != "")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class WHERE ClassLetter LIKE '" + textBox2.Text + "' AND YEAR(EntryYear) <= " + tillBox.Text + ";";
                    if (textBox2.Text == "0")
                    {
                        command = "SELECT * FROM Class WHERE ClassLetter LIKE '' AND YEAR(EntryYear) <= " + tillBox.Text + ";";
                    }
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (textBox2.Text == "" && sinBox.Text == "" && tillBox.Text == "")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (textBox2.Text == "" && sinBox.Text != "" && tillBox.Text == "")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class WHERE YEAR(EntryYear) >= " + sinBox.Text + ";";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (textBox2.Text == "" && sinBox.Text == "" && tillBox.Text != "")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class WHERE YEAR(EntryYear) <= " + tillBox.Text + ";";
                    SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                    DataTable dt = new DataTable();
                    ida.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connectstring.Close();
                }
                else if (textBox2.Text == "" && sinBox.Text != "" && tillBox.Text != "")
                {
                    SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                    connectstring.Open();
                    string command = "SELECT * FROM Class WHERE YEAR(EntryYear) BETWEEN '" + sinBox.Text + "' AND '" + tillBox.Text + "';";
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

        private void makeAQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeQuery make = new MakeQuery();
            make.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FirstStat first = new FirstStat();
            first.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SecondStat sec = new SecondStat();
            sec.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ThirdStat three = new ThirdStat();
            three.ShowDialog();
        }

        private void classSetsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report1 rep = new Report1();
            rep.ShowDialog();
        }

        private void studyYearsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report2 rep = new Report2();
            rep.ShowDialog();
        }

        // show table
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                connectstring.Open();
                string command = "SELECT * FROM Class ORDER BY Id_Set asc;";               
                SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                DataTable dt = new DataTable();
                ida.Fill(dt);
                dataGridView1.DataSource = dt;
                connectstring.Close();
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                textBox1.Clear();
                textBox2.Clear();
                tillBox.Clear();
                sinBox.Clear(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subject sb = new Subject();
            sb.ShowDialog();
        }

        private void subjectForClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubPerClass sb = new SubPerClass();
            sb.ShowDialog();
        }        
        
    }
}
