using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Object
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static int add(int a , int b)
        {
            return a + b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int b = add(2, 5);
            label1.Text = ""+b;
        }
    }
}
