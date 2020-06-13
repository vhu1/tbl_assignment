using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Graphics_Object
{
    public partial class Form1 : Form
    {
        string[] shapes = { "circle", "rectangle", "triangle" };
        List<Shape> drawShapeList = new List<Shape>();
        GetShapeFactory shapeFactory;
        public Form1()
        {
            shapeFactory = new GetShapeFactory();
            InitializeComponent();
        }
        private void clearDrawingArea()
        {
            this.drawShapeList = new List<Shape>();
            this.txtCmdBox.Text = "";
        }

        private string prepareParams(string st , Shape sp)
        {
            bool dimst = false;
            string tempdim = "";
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] == ')')
                    dimst = false;
                if (st[i] == ',' || st[i] == ' ')
                {
                    tempdim = tempdim + ' ';
                }
                if (dimst && st[i] != ',')
                {
                    tempdim = tempdim + st[i];
                }

                if (st[i] == '(')
                    dimst = true;
                if (st[i] == ')')
                    dimst = false;
            }
            return tempdim;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void txtCmdbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Shape sp = new Shape();
            string[] lines = txtCmdBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                foreach (string st in lines)
                {
                    if (st.Contains("clear"))
                    {
                        clearDrawingArea();
                    }
                    if(st.Contains("Draw" , StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (string st1 in this.shapes)
                        {
                            if (st.Contains(st1, StringComparison.OrdinalIgnoreCase))
                            {
                                sp.Shapename = st1;
                                string tempdim = prepareParams(st, sp);
                                sp.Dimension = tempdim;
                                drawShapeList.Add(sp);
                            }
                        }
                    }
                    if(st.Contains("moveto" , StringComparison.OrdinalIgnoreCase))
                    {
                        sp.position = prepareParams(st, sp);
                    }
                }
                pnlCanvas.Refresh();
            }
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (drawShapeList.Count > 0)
            {
                foreach(Shape sp in drawShapeList)
                {
                    shapeFactory.getShape(sp.Shapename).draw(e, sp.Dimension , sp.position);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
            fr.Bounds = Screen.PrimaryScreen.Bounds;
            this.Hide();
        }

        
    }
}
