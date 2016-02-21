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
    public partial class FirstStat : Form
    {
        public FirstStat()
        {
            InitializeComponent();
            SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring.Open();
            string command = "SELECT StudyYear.EntryExitYear, COUNT(ClassList.Id_Class) AS Classes_Amount FROM StudyYear, ClassList WHERE StudyYear.Id_StudyYear = ClassList.Id_StudyYear GROUP BY StudyYear.EntryExitYear";
            SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
            DataTable dt = new DataTable();
            ida.Fill(dt);
            dataGridView1.DataSource = dt;
            connectstring.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
