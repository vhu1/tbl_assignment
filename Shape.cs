﻿using System;
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
            string[] splitString = dimension.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            int a = int.Parse(splitString[0]);
            int b = int.Parse(splitString[1]);
            int c = int.Parse(splitString[2]);
            if(a == b && b ==c )
            {
                a = a + 50;
                b = b + 60;
                c = c + 70;
            }
            Pen red = new Pen(Color.Red);
            Graphics g = e.Graphics;
            
            Point point1 = new Point(a , b);
            Point point2 = new Point(b, c);
            Point point3 = new Point(a ,c);

            Point[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,

             };
            g.DrawPolygon(red, curvePoints);
            
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
