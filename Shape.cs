using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Object
{
    interface ICustomObject
    {
        void draw(PaintEventArgs e , string dimension);
    }
    class Circle : ICustomObject
    {
        public void draw(PaintEventArgs e, string dimension)
        {
            string[] splitString = dimension.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            
            Pen red = new Pen(Color.Red , 3);
            System.Drawing.Rectangle circle = new System.Drawing.Rectangle(20, 20, int.Parse(splitString[0]), int.Parse(splitString[0]));
            Graphics g = e.Graphics;
            g.DrawEllipse(red, circle);
        }
    }
    class Triangle : ICustomObject
    {
        public void draw(PaintEventArgs e, string dimension)
        {
            Pen red = new Pen(Color.Red);
            Graphics g = e.Graphics;
            g.DrawLine(red, 10, 10, 200, 100);
            g.DrawLine(red, 10, 10, 100, 500);
            g.DrawLine(red, 100, 500, 200, 100);
        }
    }

    class Rectangle : ICustomObject
    {
        public void draw(PaintEventArgs e , string dimension)
        {
           string[] splitString =  dimension.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            int[] dim = new int[2];
            for(int i = 0; i<2; i++)
            {
                dim[i] = int.Parse(splitString[i]);
            }
            Pen red = new Pen(Color.Red);
            Graphics g = e.Graphics;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(10, 10, dim[0], dim[1]);
            g.DrawRectangle(red, rectangle);
        }
    }

    class GetShapeFactory
    {
        public ICustomObject getShape(String geomObj)
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
            if(string.Equals(geomObj , "rectangle", StringComparison.OrdinalIgnoreCase))
            {
                return new Rectangle();
            }
            return null;
        }
    }
}
