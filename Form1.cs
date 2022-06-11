using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace XML_CRUD
{
    public partial class Form1 : Form
    {
        XmlSerializer xs;
        List<StudentClass> ls;
        public Form1()
        {
            InitializeComponent();
            ls = new List<StudentClass>();
            xs = new XmlSerializer(typeof(List<StudentClass>));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("E:\\Student.xml", FileMode.Create, FileAccess.Write);
            StudentClass sc = new StudentClass();
            sc.Name = textBox1.Text;
            sc.Class = int.Parse(textBox2.Text);
            sc.sub = textBox3.Text;
            ls.Add(sc);
            xs.Serialize(fs, ls);
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("E:\\Student.xml", FileMode.Open, FileAccess.Read);
            ls = (List<StudentClass>)xs.Deserialize(fs);
            dataGridView1.DataSource = ls;
            fs.Close();
        }
    }
}
