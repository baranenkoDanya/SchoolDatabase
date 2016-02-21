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
    public partial class ClassListAdd : Form
    {
        private readonly int Id_Class;

        private bool edit;

        public ClassListAdd()
        {
            InitializeComponent();

            classListTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            classTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            studyYearTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";

            studyYearTableAdapter.Fill(schoolDataSet.StudyYear);
            classTableAdapter.Fill(schoolDataSet.Class);
            edit = false;
            Id_Class = (int) classListTableAdapter.MaxId() + 1;                       
        }

        public ClassListAdd(int id, int id_study, int id_set, byte ClassNumber) : this()
        {
            classListTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            classTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            studyYearTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";

            studyYearTableAdapter.Fill(schoolDataSet.StudyYear);
            classTableAdapter.Fill(schoolDataSet.Class);

            edit = true;
            Id_Class = id;
            stYearBox.SelectedValue = id_study;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = true;
                if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) == id_set)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[i].Index;
                    dataGridView1.Refresh();
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                    dataGridView1.Rows[i].Selected = true;
                    break;
                }
                else
                    dataGridView1.Rows[i].Selected = false;
            }
            comboBox1.Text = ClassNumber.ToString();
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (edit)
            {

                classListTableAdapter.UpdateQuery(Convert.ToInt32(stYearBox.SelectedValue), Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value), Convert.ToByte(comboBox1.Text), Id_Class);
            }
            else
            {
                classListTableAdapter.Insert(Id_Class, Convert.ToInt32(stYearBox.SelectedValue), Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value), Convert.ToByte(comboBox1.Text));
            }
            Close();
        }
    }
}
