using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Vector2D
    {
        public const double PI = 3.14159265;

        public Vector2D( double x = 0, double y = 0 )
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Length
        {
            get
            {
                double xSquared = X * X,
                    ySquared = Y * Y;
                return Math.Sqrt(xSquared + ySquared);
            }
        }
        public double LengthSquared
        {
            get
            {
                double xSquared = X * X,
                    ySquared = Y * Y;
                return xSquared + ySquared;
            }
        }

        public static Vector2D operator +( Vector2D firstVector, Vector2D secondVector )
        {
            return new Vector2D
            {
                X = firstVector.X + secondVector.X,
                Y = firstVector.Y + secondVector.Y
            };
        }
        public static Vector2D operator -( Vector2D firstVector, Vector2D secondVector )
        {
            return new Vector2D
            {
                X = firstVector.X - secondVector.X,
                Y = firstVector.Y - secondVector.Y
            };
        }
        public static Vector2D operator *( Vector2D firstVector, double coefficient )
        {
            return new Vector2D
            {
                X = firstVector.X * coefficient,
                Y = firstVector.Y * coefficient
            };
        }
        public static Vector2D operator /( Vector2D firstVector, double coefficient )
        {
            return new Vector2D
            {
                X = firstVector.X / coefficient,
                Y = firstVector.Y / coefficient
            };
        }

        public void Normallize()
        {
            Vector2D vectorOut = this / Length;
            X = vectorOut.X;
            Y = vectorOut.Y;
        }

        public void Rotate( double angle, bool isInDegrees = false )
        {
            if(isInDegrees)
            {
                angle = angle * PI / 180.0;
            }
            double resultX = Y * Math.Sin(angle) + X * Math.Cos(angle);
            double resultY = Y * Math.Cos(angle) - X * Math.Sin(angle);
            X = resultX;
            Y = resultY;
        }

        public static double DotProduct( Vector2D a, Vector2D b )
        {
            return a.X * b.X
                   + a.Y * b.Y;
        }
        public static double CrossProductXY( Vector2D a, Vector2D b )
        {
            return a.X * b.Y - a.Y * b.X;
        }
        public static double TriangleArea( Vector2D a, Vector2D b )
        {
            Vector2D c = a - b;
            return CrossProductXY(b - a, c - a) / 2;
        }
        public static double TriangleArea( Vector2D a, Vector2D b, Vector2D c )
        {
            return CrossProductXY(b - a, c - a) / 2;
        }
        public static double GetAngle( Vector2D a, Vector2D b, bool inDegrees = false )
        {
            a.Normallize();
            b.Normallize();
            double cosAngle = DotProduct(a, b);
            double angle = Math.Acos(cosAngle);
            return inDegrees ? angle * 180.0 / PI : angle;
        }
        public static double GetProjectionLength( Vector2D a, Vector2D vectorBase )
        {
            double dpResult = DotProduct(a, vectorBase);
            return dpResult / vectorBase.Length;
        }
    }
}
