using System;
using System.Windows.Forms;

namespace School_DataBase
{
    public partial class Report2 : Form
    {
        public Report2()
        {
            InitializeComponent();
            StudyYearTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            label2.Text = DateTime.Now.ToString();
        }

        private void Report2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'SchoolDataSet.StudyYear' table. You can move, or remove it, as needed.
            this.StudyYearTableAdapter.Fill(this.SchoolDataSet.StudyYear);

            this.reportViewer1.RefreshReport();
        }
    }
}
