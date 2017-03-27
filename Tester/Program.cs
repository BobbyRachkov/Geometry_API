using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry;

namespace Tester
{
    class Program
    {
        static void Main( string[] args )
        {
            Vector3D vector1=new Vector3D(0,3,3);
            Vector3D vector2=new Vector3D(0,0,3);
            Vector3D vector3 = new Vector3D(4, 0, 0);
            Console.WriteLine(Vector3D.TriangleArea(vector1,vector2,vector3));
        }
    }
}
