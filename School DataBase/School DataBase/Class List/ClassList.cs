using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School_DataBase
{
    public partial class ClassList : Form
    {
        public ClassList()
        {
            InitializeComponent();
            classListTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            studyYearTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            StartUp();
            dataGridView1.ForeColor = Color.Black;
        }

        private void StartUp()
        {
            SqlConnection connectstring1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring1.Open();
            string command1 = "SELECT DISTINCT StudyYear.EntryExitYear AS 'Study Year', CONCAT(ClassList.ClassName, Class.ClassLetter) AS CName, Class.Id_Set, ClassList.Id_Class FROM ClassList, Class, StudyYear WHERE ClassList.Id_StudyYear=StudyYear.Id_StudyYear AND ClassList.Id_Set=Class.Id_Set AND ClassList.ClassName <= 11 GROUP BY Class.Id_Set, EntryExitYear, CONCAT(ClassList.ClassName, Class.ClassLetter), ClassList.Id_Class;";
            SqlDataAdapter ida1 = new SqlDataAdapter(command1, connectstring1);
            DataTable da = new DataTable();
            ida1.Fill(da);
            dataGridView1.DataSource = da;
            connectstring1.Close();
        }

        private void ClassList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.ClassList' table. You can move, or remove it, as needed.
            classListTableAdapter.Fill(schoolDataSet.ClassList);

        }

        private void RefreshTable()
        {
            SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring.Open();
            string command = "SELECT DISTINCT StudyYear.EntryExitYear, CONCAT(ClassList.ClassName, Class.ClassLetter) AS CName, Class.Id_Set, ClassList.Id_Class FROM ClassList, Class, StudyYear WHERE ClassList.Id_StudyYear=StudyYear.Id_StudyYear AND ClassList.Id_Set=Class.Id_Set GROUP BY Class.Id_Set, EntryExitYear, CONCAT(ClassList.ClassName, Class.ClassLetter), ClassList.Id_Class;";
            SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
            DataTable dt = new DataTable();
            ida.Fill(dt);
            dataGridView1.DataSource = dt;
            connectstring.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassListAdd clad = new ClassListAdd();
            clad.ShowDialog();
            classListTableAdapter.Fill(schoolDataSet.ClassList);
            schoolDataSet.AcceptChanges();
            RefreshTable();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clt = new SchoolDataSet.ClassListDataTable();
            classListTableAdapter.FillBy(clt, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value));
            object[] row = clt.Rows[0].ItemArray;
            var edit = new ClassListAdd(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), Convert.ToInt32(row[2]), Convert.ToByte(row[3]));
            edit.ShowDialog();
            classListTableAdapter.Fill(schoolDataSet.ClassList);
            schoolDataSet.AcceptChanges();
            RefreshTable();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            classListTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value));
            classListTableAdapter.Fill(schoolDataSet.ClassList);
            schoolDataSet.AcceptChanges();
            RefreshTable();
        }
                        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] split = textBox1.Text.Split(new Char[] {' ', '.'}); // splited input in case if there is a need to find diff. info
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    if (split.Length != 0)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[1].Value != null)
                        {
                            if (split.Length == 1)
                            {
                                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(split[0]) || dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(split[0]))
                                {
                                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SteelBlue;
                                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                                }
                            }
                            else if(split.Length == 2)
                            {
                                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(split[0]) || dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(split[1]) && dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(split[1]) || dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(split[0]))
                                {
                                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SteelBlue;
                                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Try to write it in another way!");
                                break;
                            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                connectstring.Open();
                if (textEntYear1.Text == "")
                    textEntYear1.Text = "2000";
                if (textEntYear2.Text == "")
                    textEntYear2.Text = "2020";
                if (textCName1.Text == "")
                    textCName1.Text = "1";
                if (textCName2.Text == "")
                    textCName2.Text = "11";
                string command = "SELECT DISTINCT ClassList.Id_Class, StudyYear.EntryExitYear, CONCAT(ClassList.ClassName, Class.ClassLetter) AS CName FROM ClassList, Class, StudyYear WHERE ClassList.Id_StudyYear=StudyYear.Id_StudyYear AND ClassList.Id_Set=Class.Id_Set AND SUBSTRING(StudyYear.EntryExitYear,1,4) BETWEEN '" + textEntYear1.Text + "' AND '" + textEntYear2.Text + "' AND ClassList.ClassName BETWEEN '" + textCName1.Text + "' AND '" + textCName2.Text + "'GROUP BY Id_Class, EntryExitYear, CONCAT(ClassList.ClassName, Class.ClassLetter);";
                SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                DataTable dt = new DataTable();
                ida.Fill(dt);
                dataGridView1.DataSource = dt;
                connectstring.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring.Open();
            string command = "SELECT DISTINCT StudyYear.EntryExitYear AS 'Study Year', CONCAT(ClassList.ClassName, Class.ClassLetter) AS CName, Class.Id_Set, ClassList.Id_Class FROM ClassList, Class, StudyYear WHERE ClassList.Id_StudyYear=StudyYear.Id_StudyYear AND ClassList.Id_Set=Class.Id_Set GROUP BY Class.Id_Set, EntryExitYear, CONCAT(ClassList.ClassName, Class.ClassLetter), ClassList.Id_Class;";
            SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
            DataTable dt = new DataTable();
            ida.Fill(dt);
            dataGridView1.DataSource = dt;
            connectstring.Close();
            textBox1.Clear();
            textCName1.Clear();
            textCName2.Clear();
            textEntYear1.Clear();
            textEntYear2.Clear();
        }

        private void updateClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int thisisClassNumber=100;
            string maxYear = studyYearTableAdapter.MaxYear().ToString();
            UpdateSY();
            foreach (DataGridViewRow dt in dataGridView1.Rows)
            {
                if (dt.Cells[0].Value != null)
                {
                    if (dt.Cells[0].Value.ToString() == maxYear)
                    {
                        if (dt.Cells[1].Value.ToString().Length == 1)
                        {
                            thisisClassNumber = Convert.ToInt32(dt.Cells[1].Value.ToString());
                        }
                        else if (dt.Cells[1].Value.ToString().Length == 2)
                        {
                            if (Int32.TryParse(dt.Cells[1].Value.ToString(), out thisisClassNumber))
                            { }
                            else
                            {
                                char[] A_S = new char[dt.Cells[1].Value.ToString().Length];
                                for (int i = 0; i < A_S.Length; i++)
                                {
                                    A_S[i] = dt.Cells[1].Value.ToString()[i];
                                }
                                thisisClassNumber = Convert.ToInt32(A_S[0].ToString());
                            }
                        }
                        else if (dt.Cells[1].Value.ToString().Length == 3)
                        {
                            char[] A_S = new char[dt.Cells[1].Value.ToString().Length];
                            for (int i = 0; i < A_S.Length; i++)
                            {
                                A_S[i] = dt.Cells[1].Value.ToString()[i];
                            }
                            thisisClassNumber = Convert.ToInt32(A_S[0].ToString() + A_S[1].ToString());
                        }
                        SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                        connectstring.Open();
                        string command = "INSERT INTO ClassList (Id_Class, Id_StudyYear, Id_Set, ClassName) VALUES (" + (int)(classListTableAdapter.MaxId() + 1) + ", " + (int)studyYearTableAdapter.MaxId() + ", " + (int)dt.Cells[2].Value + ", " + (int)(thisisClassNumber + 1) + ");";
                        SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                        DataTable dtt = new DataTable();
                        ida.Fill(dtt);
                        connectstring.Close();
                        schoolDataSet.AcceptChanges();
                    }
                }
            }
            StartUp();    
        }

        // adding new study year
        private void UpdateSY()
        {
            SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring.Open();
            string command = "INSERT INTO StudyYear (Id_StudyYear, EntryExitYear) VALUES (" + (int)(studyYearTableAdapter.MaxId() + 1) + ", '" + Convert.ToInt32(DateTime.Now.Year) + "-" + (Convert.ToInt32(DateTime.Now.Year + 1)) + "'); ";
            SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
            DataTable dt = new DataTable();            
            ida.Fill(dt);
            connectstring.Close();
            schoolDataSet.AcceptChanges();
        }
    }
}
