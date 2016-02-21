using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School_DataBase
{
    public partial class ThirdStat : Form
    {
        public ThirdStat()
        {
            try {
                InitializeComponent();
                SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
                connectstring.Open();
                string command = "SELECT StudyYear.EntryExitYear, ClassList.ClassName, COUNT(ClassList.Id_Class) AS Form_Amount FROM StudyYear, ClassList WHERE StudyYear.Id_StudyYear = ClassList.Id_StudyYear GROUP BY ClassList.ClassName, StudyYear.EntryExitYear;";
                SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
                DataTable dt = new DataTable();
                ida.Fill(dt);
                dataGridView1.DataSource = dt;
                connectstring.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
