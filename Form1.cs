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
        int startx = 0;
        int starty = 0;
        List<Shape> drawShapeDime = new List<Shape>();
        string[] shape = null;
        string[] dimensions = null;
        GetShapeFactory g;
        public Form1()
        {
            g = new GetShapeFactory();
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
       
        }

        private void txtCmdbox_KeyPress(object sender, KeyPressEventArgs e)
        {
           Shape sp = new Shape();
            string[] lines = txtCmdBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                foreach (string st in lines)
                {
                    
                    if (st.Contains("Draw", StringComparison.OrdinalIgnoreCase))
                        foreach (string st1 in shapes)
                        {
                            
                            if (st.Contains(st1, StringComparison.OrdinalIgnoreCase))
                            {
                                sp.Shapename = st1;
                                
                                bool dimst = false;
                                string tempdim ="";
                               for(int i=0; i<st.Length; i++)
                                {
                                    if (st[i] == ')')
                                        dimst = false;
                                    if (dimst && st[i]!=',')
                                    {
                                        Debug.WriteLine(st[i]);
                                        tempdim = tempdim + st[i];
                                    }
                                    if(st[i] == ',' && st[i] == ' ')
                                    {
                                        tempdim = tempdim + ' ';
                                    }

                                    if (st[i] == '(')
                                        dimst = true;
                                    if(st[i]==')')
                                        dimst = false;
                                }
                                sp.Dimension = tempdim;
                                Debug.WriteLine(tempdim);
                                drawShapeDime.Add(sp);
                            }

                        }
                }
                pnlCanvas.Refresh();
            }
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (drawShapeDime.Count > 0)
            {
                foreach(Shape sp in drawShapeDime)
                {
                    g.getShape(sp.Shapename).draw(e, sp.Dimension);
                }
            }
            //if (shape != null && dimensions != null)
            //{
            //    g.getShape(shape).draw(e, dimensions);
            //    shape = null;
            //    dimensions = null;
            //}

        }
    }
}
