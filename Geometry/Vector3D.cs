using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Vector3D
    {
        public const double PI = 3.14159265;

        public Vector3D( double x = 0, double y = 0, double z = 0 )
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Length
        {
            get
            {
                double xSquared = X * X,
                    ySquared = Y * Y,
                    zSquared = Z * Z;
                return Math.Sqrt(xSquared + ySquared + zSquared);
            }
        }
        public double LengthSquared
        {
            get
            {
                double xSquared = X * X,
                    ySquared = Y * Y,
                    zSquared = Z * Z;
                return xSquared + ySquared + zSquared;
            }
        }

        public static Vector3D operator +( Vector3D firstVector, Vector3D secondVector )
        {
            return new Vector3D
            {
                X = firstVector.X + secondVector.X,
                Y = firstVector.Y + secondVector.Y,
                Z = firstVector.Z + secondVector.Z
            };
        }
        public static Vector3D operator -( Vector3D firstVector, Vector3D secondVector )
        {
            return new Vector3D
            {
                X = firstVector.X - secondVector.X,
                Y = firstVector.Y - secondVector.Y,
                Z = firstVector.Z - secondVector.Z
            };
        }
        public static Vector3D operator *( Vector3D firstVector, double coefficient )
        {
            return new Vector3D
            {
                X = firstVector.X * coefficient,
                Y = firstVector.Y * coefficient,
                Z = firstVector.Z * coefficient
            };
        }
        public static Vector3D operator /( Vector3D firstVector, double coefficient )
        {
            return new Vector3D
            {
                X = firstVector.X / coefficient,
                Y = firstVector.Y / coefficient,
                Z = firstVector.Z / coefficient
            };
        }

        public void Normallize()
        {
            Vector3D vectorOut = this / Length;
            X = vectorOut.X;
            Y = vectorOut.Y;
            Z = vectorOut.Z;
        }

        public void RotateInXZ( double angle, bool isInDegrees = false )
        {
            if(isInDegrees)
            {
                angle = angle * PI / 180.0;
            }
            double resultX = Z * Math.Sin(angle) + X * Math.Cos(angle);
            double resultZ = Z * Math.Cos(angle) - X * Math.Sin(angle);
            X = resultX;
            Z = resultZ;
        }
        public void RotateInXY( double angle, bool isInDegrees = false )
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
        public void RotateInYZ( double angle, bool isInDegrees = false )
        {
            if(isInDegrees)
            {
                angle = angle * PI / 180.0;
            }
            double resultY = Z * Math.Sin(angle) + Y * Math.Cos(angle);
            double resultZ = Z * Math.Cos(angle) - Y * Math.Sin(angle);
            Y = resultY;
            Z = resultZ;
        }

        public void RotateAroundXAxis( double angleInDegrees )
        {
            RotateInYZ(angleInDegrees);
        }
        public void RotateAroundYAxis( double angleInDegrees )
        {
            RotateInXZ(angleInDegrees);
        }
        public void RotateAroundZAxis( double angleInDegrees )
        {
            RotateInXY(angleInDegrees);
        }

        public static double DotProduct( Vector3D a, Vector3D b )
        {
            return a.X * b.X
                + a.Y * b.Y
                + a.Z * b.Z;
        }
        public static double CrossProductXY( Vector3D a, Vector3D b )
        {
            return a.X * b.Y - a.Y * b.X;
        }
        public static double CrossProductXZ( Vector3D a, Vector3D b )
        {
            return a.X * b.Z - a.Z * b.X;
        }
        public static double CrossProductYZ( Vector3D a, Vector3D b )
        {
            return a.Y * b.Z - a.Z * b.Y;
        }
        public static Vector3D CrossProduct( Vector3D a, Vector3D b )
        {
            return new Vector3D
            {
                X = a.Y * b.Z - b.Y * a.Z,
                Y = a.Z * b.X - b.Z * a.X,
                Z = a.X * b.Y - b.X * a.Y
            };
        }
        public static double TriangleArea( Vector3D a, Vector3D b, Vector3D c )
        {
            return CrossProduct(b - a, c - a).Length / 2;
        }
        public static double GetAngle( Vector3D a, Vector3D b, bool inDegrees = false )
        {
            a.Normallize();
            b.Normallize();
            double cosAngle = DotProduct(a, b);
            double angle = Math.Acos(cosAngle);
            return inDegrees ? angle * 180.0 / PI : angle;
        }
        public static double GetProjectionLength( Vector3D a, Vector3D vectorBase)
        {
            double dpResult = DotProduct(a,vectorBase);
            return dpResult / vectorBase.Length;
        }
    }
}
