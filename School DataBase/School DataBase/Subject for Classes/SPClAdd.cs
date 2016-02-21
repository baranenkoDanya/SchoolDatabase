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
    public partial class SPClAdd : Form
    {
        private readonly int Id_Sbc;

        private bool edit;

        public SPClAdd()
        {
            InitializeComponent();
            subjectsByClassTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            subjectTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";

            subjectTableAdapter.Fill(schoolDataSet.Subject);
            subjectsByClassTableAdapter.Fill(schoolDataSet.SubjectsByClass);
            edit = false;
            Id_Sbc = (int)subjectsByClassTableAdapter.MaxId() + 1;
        }

        public SPClAdd(int idSbc, int clas, int idSbj, int subHours):this()
        {
            comboBox1.SelectedValue = idSbj;
            listBox1.SelectedIndex = clas - 1;
            textBox1.Text = subHours.ToString();
            Id_Sbc = idSbc;
            edit = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (edit)
            {

                subjectsByClassTableAdapter.Update1(Convert.ToInt32(listBox1.SelectedItem), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(textBox1.Text), Id_Sbc);
            }
            else
            {
                subjectsByClassTableAdapter.Insert(Id_Sbc, Convert.ToInt32(listBox1.SelectedItem), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(textBox1.Text));
            }
            Close();
        }
    }
}
