using System;
using System.Windows.Forms;

namespace School_DataBase
{
    public partial class Report1 : Form
    {
        public Report1()
        {
            InitializeComponent();
            ClassTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            label2.Text = DateTime.Now.ToString();
        }

        private void Report1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'SchoolDataSet.Class' table. You can move, or remove it, as needed.
            this.ClassTableAdapter.Fill(this.SchoolDataSet.Class);

            this.reportViewer1.RefreshReport();
        }
    }
}
