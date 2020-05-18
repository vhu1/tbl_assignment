using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Object
{
    interface CustomObject
    {
        void draw(PaintEventArgs e);
    }
    class Circle : CustomObject
    {
        public void draw(PaintEventArgs e)
        {
            Pen red = new Pen(Color.Red);
            Rectangle circle = new Rectangle(20, 20, 220, 220);
            Graphics g = e.Graphics;
            g.DrawEllipse(red, circle);
        }
    }
    class Triangle : CustomObject
    {
        public void draw(PaintEventArgs e)
        {
            Pen red = new Pen(Color.Red);
            Graphics g = e.Graphics;
            g.DrawLine(red, 10, 10, 20, 10);
            g.DrawLine(red, 10, 10, 10, 50);
            g.DrawLine(red, 10, 50, 20, 10);
        }
    }

    class GetShapeFactory
    {
        public CustomObject getShape(String geomObj)
        {
            if(geomObj == null)
            {
                return null;
            }
            if(string.Equals(geomObj , "circle", StringComparison.OrdinalIgnoreCase))
            {
                return new Circle();
            }
            if(string.Equals(geomObj , "triangle", StringComparison.OrdinalIgnoreCase))
            {
                return new Triangle();
            }
            return null;
        }
    }
}
