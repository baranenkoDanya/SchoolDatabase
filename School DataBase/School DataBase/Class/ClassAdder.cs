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
    public partial class ClassAdder : Form
    {

        private readonly int Id_Set; // user's id

        private bool edit;

        public ClassAdder()
        {
            InitializeComponent();
            classTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            edit = false;
            Id_Set = (int)classTableAdapter.MaxId() + 1;           
        }               
        
        public ClassAdder(int id, char letter, DateTime entry): this()
        {
            classTableAdapter.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Danylo\Desktop\DataBase COURSACH\School DataBase\School DataBase\School1.mdf;Integrated Security=True";
            edit = true;
            Id_Set = id;
            ClassLetter.Text = letter.ToString();
            EntryYear.Value = entry;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                classTableAdapter.UpdateQuery(ClassLetter.Text, EntryYear.Text, Id_Set);
            }
            else
            {
                classTableAdapter.Insert(Id_Set, ClassLetter.Text, EntryYear.Text);
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
