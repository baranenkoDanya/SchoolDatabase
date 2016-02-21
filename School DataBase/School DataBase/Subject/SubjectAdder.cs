using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_DataBase
{
    public partial class SubjectAdder : Form
    {
        private readonly int Id_Subject;

        private bool edit;

        public SubjectAdder()
        {
            InitializeComponent();
            subjectTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            edit = false;
            Id_Subject = (int)subjectTableAdapter.MaxId() + 1;
        }

        public SubjectAdder(int id, string subj): this()
        {
            subjectTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            edit = true;
            Id_Subject = id;
            textBox1.Text = subj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (edit)
                { 
                    subjectTableAdapter.UpdateQuery(textBox1.Text, Id_Subject);
                }
                else
                {
                    subjectTableAdapter.Insert(Id_Subject, textBox1.Text);
                }
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
