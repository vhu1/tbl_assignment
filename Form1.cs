using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
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
        private void Form1_Load(object sender, EventArgs e )
        {

            string[] passedInArgs = Environment.GetCommandLineArgs();
            if(passedInArgs.Length < 2)
            {
                MessageBox.Show("Please pass and valid argument to load shapes");
                this.Close();
                return;
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            string[] passedInArgs = Environment.GetCommandLineArgs();
            if (passedInArgs.Contains("run"))
            {

                GetShapeFactory g = new GetShapeFactory();
                g.getShape(passedInArgs[2]).draw(e);

            }
            else
            {
                MessageBox.Show("Please pass and valid argument to load shapes");
                this.Close();
            }
        }
    }
}
