﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Object
{
    public class Shape
    {
        public string position { get; set; }
        public string Shapename { get; set; }
        public string Dimension { get; set; }
        public Shape()
        {
            this.position = "0 0";          
        }
            

    }
    /// <summary>
    /// Interface that implements by all factory class to draw respective shapes
    /// </summary>
    interface ICustomObject
    {
        void draw(PaintEventArgs e , string dimension , string position);
    }
    class Circle : ICustomObject
    {
        /// <summary>
        /// This is draw method for circle factory class
        /// </summary>
        /// <param name="e"></param>
        /// <param name="dimension"></param>
        /// <param name="position"></param>
        public void draw(PaintEventArgs e, string dimension , string position)
        {
            string[] splitString = dimension.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string[] positionSplit = position.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            Pen red = new Pen(Color.Red , 1);
            System.Drawing.Rectangle circle = new System.Drawing.Rectangle(int.Parse(positionSplit[0]), int.Parse(positionSplit[1]), int.Parse(splitString[0]), int.Parse(splitString[0]));
            Graphics g = e.Graphics;
            g.DrawEllipse(red, circle);
        }
    }
    class Triangle : ICustomObject
    {
        /// <summary>
        /// This is draw method that draw triangle in triangle factory class
        /// </summary>
        /// <param name="e"></param>
        /// <param name="dimension"></param>
        /// <param name="position"></param>
        public void draw(PaintEventArgs e, string dimension, string position)
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
            
            Point point1 = new Point(100 , 100);
            Point point2 = new Point(100, 250);
            Point point3 = new Point(50 ,50);

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
        /// <summary>
        /// This is draw method that overrides the method of ICustomObject that draws rectangle.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="dimension"></param>
        /// <param name="position"></param>
        public void draw(PaintEventArgs e , string dimension , string position)
        {
           string[] splitString =  dimension.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
           string[] positionSplit = position.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            int[] dim = new int[2];
            for(int i = 0; i<2; i++)
            {
                dim[i] = int.Parse(splitString[i]);
            }
            Pen red = new Pen(Color.Red);
            Graphics g = e.Graphics;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(int.Parse(positionSplit[0]), int.Parse(positionSplit[1]) , dim[0], dim[1]);
            g.DrawRectangle(red, rectangle);
        }
    }
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
    /// <summary>
    /// This class get shape type in string and makes object dynamically as per string passed;
    /// </summary>
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
