using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School_DataBase
{
    public partial class SecondStat : Form
    {
        public SecondStat()
        {
            InitializeComponent();
            SqlConnection connectstring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True");
            connectstring.Open();
            string command = "SELECT EntryYear, COUNT(Id_Set) AS Set_Id FROM Class GROUP BY EntryYear";
            SqlDataAdapter ida = new SqlDataAdapter(command, connectstring);
            DataTable dt = new DataTable();
            ida.Fill(dt);
            dataGridView1.DataSource = dt;
            connectstring.Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
