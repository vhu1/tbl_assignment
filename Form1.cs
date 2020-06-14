using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
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

        public static int graphic_sub_circle(int a , int b)
        {
            return a - b;
        }

        public static int graphic_add_circle(int a , int b)
        {
            return a + b;
        }

        public static string prepareParams(string st , Shape sp)
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
                    if (st.Contains("reset"))
                    {
                        clearDrawingArea();
                    }
                    if(st.Contains("moveto", StringComparison.OrdinalIgnoreCase))
                    {
                        string tempdim = prepareParams(st , sp);
                        string[] paramsSplit = tempdim.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                        if(paramsSplit.Length != 2)
                        {
                            MessageBox.Show($"Moveto should have only 2 instead {paramsSplit.Length} parameters passed");
                        }
                    }
                    if(st.Contains("Draw" , StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (string st1 in this.shapes)
                        {
                            string tempdim = prepareParams(st, sp);
                            if (st.Contains(st1, StringComparison.OrdinalIgnoreCase))
                            {
                                if(st1.Equals("Rectangle" , StringComparison.OrdinalIgnoreCase)){
                                    string[] paramsSplit = tempdim.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                                    if(paramsSplit.Length != 2){
                                        tempdim = "0";
                                        this.txtCmdBox.Text = "";
                                        MessageBox.Show($"Rectangle should have only 2 instead {paramsSplit.Length} parameters passed");
                                    }
                                }
                                if(st1.Equals("circle" , StringComparison.OrdinalIgnoreCase)){
                                    string[] paramsSplit = tempdim.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                                    if(paramsSplit.Length != 1){
                                      tempdim = "0";
                                      this.txtCmdBox.Text = "";
                                      MessageBox.Show($"Circle should have only 1 instead {paramsSplit.Length} parameters passed");
                                    }
                                }
                                if(st1.Equals("triangle" , StringComparison.OrdinalIgnoreCase)){
                                    string[] paramsSplit = tempdim.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                                    if(paramsSplit.Length != 3){
                                        tempdim = "0";
                                        this.txtCmdBox.Text = "";
                                        MessageBox.Show($"Triangle should have only 1 instead {paramsSplit.Length} parameters passed");
                                    }
                                }
                                
                                sp.Shapename = st1;
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

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
            fr.Bounds = Screen.PrimaryScreen.Bounds;
            this.Hide();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "c:\\";
            openFile.Filter = "Graphical Objects (.txt)|.txt";
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtCmdBox.Text = File.ReadAllText(openFile.FileName);
            }
        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Graphical Objects (.txt)|.txt";
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter sw = File.CreateText(saveDialog.FileName))
                {
                    sw.WriteLine(txtCmdBox.Text);

                }
            }
        }
    }
}
