using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualObjectProjectR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row=0,col=0,bomb = 0;
            if (!int.TryParse(textBox1.Text, out row) || !int.TryParse(textBox2.Text, out col) || !int.TryParse(textBox3.Text, out bomb))
            {
                MessageBox.Show("pls insert number", "pls :/", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
               
            

            if (row * col <= bomb || row <= 0|| col <= 0 || bomb <=0)
            {
                MessageBox.Show("Please check the varibles " , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                Form2 form2 = new Form2(row,col,bomb,this);
                form2.Show();
                this.Visible = false;
            }
            
        }
    }
}


