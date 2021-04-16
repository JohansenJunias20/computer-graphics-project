using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
namespace UTS_PROJECT.Johansen
{
    class antenna
    {
        public Mesh left;
        public Mesh right;
        public Vector3 position;
        public antenna()
        {
            left = new Mesh();
            right = new Mesh();
        }
        public void Animate()
        {

            left._transform = Matrix4.Identity;

            left._transform *= Matrix4.CreateTranslation(Global.translate);

            left._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            left._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            left._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));


            right._transform = Matrix4.Identity;

            right._transform *= Matrix4.CreateTranslation(Global.translate);

            right._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            right._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            right._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));
        }
        public void setPosition(Vector3 p)
        {
            position = p;
            left._position = new Vector3(p.X-0.01f , p.Y, p.Z);
            right._position = new Vector3(p.X+0.01f, p.Y,p.Z);
            Console.WriteLine("antenna pos left: ");
            Console.WriteLine(left._position);
        }
        public void Translate(Vector3 vector3)
        {
            left._transform *= Matrix4.CreateTranslation(vector3);
            right._transform *= Matrix4.CreateTranslation(vector3);
        }
        public void Rotate(float degX, float degY, float degZ)
        {
            left._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            left._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            left._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

            right._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            right._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            right._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
        }
        public void create()
        {
            left.createBezier(
                new Vector3(left._position.X+0.01f,left._position.Y+0.05f,left._position.Z),
                new Vector3(left._position.X-0.15f,left._position.Y+0.15f,position.Z),
                new Vector3(left._position.X-0.2f,left._position.Y+0.1f,left._position.Z),
                0.001f
                );
            left.setupBezier();
            right.createBezier(
              new Vector3(right._position.X - 0.01f, left._position.Y + 0.05f, left._position.Z),
              new Vector3(right._position.X + 0.15f, left._position.Y + 0.15f, position.Z),
              new Vector3(right._position.X + 0.2f, left._position.Y + 0.1f, left._position.Z),
              0.001f
              );
            right.setupBezier();
            //right.createBezier();
            //left.setupBezier();
        }
        public void render()
        {
            left.renderBezier();
            right.renderBezier();
        }
        //private int Pascal(int index, int height)
        //{
        //    List<int> arr = getRow(height);
        //    return arr[index];


        //}
        //public static List<int> getRow(int rowIndex)
        //{
        //    List<int> currow = new List<int>();

        //    // 1st element of every row is 1
        //    currow.Add(1);

        //    // Check if the row that has to
        //    // be returned is the first row
        //    if (rowIndex == 0)
        //    {
        //        return currow;
        //    }
        //    // Generate the previous row
        //    List<int> prev = getRow(rowIndex - 1);

        //    for (int i = 1; i < prev.Count; i++)
        //    {

        //        // Generate the elements
        //        // of the current row
        //        // by the help of the
        //        // previous row
        //        int curr = prev[i - 1] + prev[i];
        //        currow.Add(curr);
        //    }
        //    currow.Add(1);

        //    // Return the row
        //    return currow;
        //}
        //Vector3 setBezierLeft(Vector3 cp1, Vector3 cp2, Vector3 pEnd, float t, int l)
        //{
        //    Vector3 p;
        //    float a1 = (float)Math.Pow((1 - t), 3);
        //    float a2 = (float)Math.Pow((1 - t), 2) * 3 * t;
        //    float a3 = 3 * t * t * (1 - t);
        //    float a4 = t * t * t;
        //    p.X = a1 * left._position.X + a2 * cp1.X + a3 * cp2.X + a4 * pEnd.X;
        //    p.Y = a1 * left._position.Y + a2 * cp1.Y + a3 * cp2.Y + a4 * pEnd.Y;
        //    p.Z = a1 * left._position.Z + a2 * cp1.Z + a3 * cp2.Z + a4 * pEnd.Z;
        //    return p;
        //}
        //Vector2 setBezierRight(Vector3 cp1,Vector3 cp2, Vector3 pEnd, float t, int l)
        //{
        //    Vector2 p;
        //    p.X = 0;
        //    p.Y = 0;


        //    for (int i = 0; i < l; i++)
        //    {
        //        Console.WriteLine(i);
        //        p.X += (float)Pascal(i, l - 1) * (float)Math.Pow((1 - t), (int)l - 1 - i) * (float)Math.Pow(t, i) * (float)_p[i].X;
        //        p.Y += (float)Pascal(i, l - 1) * (float)Math.Pow((1 - t), (int)l - 1 - i) * (float)Math.Pow(t, i) * (float)_p[i].Y;
        //    }
        //    return p;
        //}

    }
}
