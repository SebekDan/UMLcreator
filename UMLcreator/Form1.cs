using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLcreator
{
    public partial class Form1 : Form
    {
        public static string fileinput = string.Empty;
        public static string fileoutput = string.Empty;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileinput = FileSelecter.filepath();
            textBox1.Text = fileinput;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileoutput = FileSelecter.filepath();
            textBox2.Text = fileoutput;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Algorithm.CreateVariables(fileinput, fileoutput);
            Algorithm.CreateMethods(fileinput, fileoutput);
        }
    }
}
