using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTS_PROJECT.Johansen
{
    class Element
    {
        //Mesh egg;
        public Vector3 radius;
        public Vector3 rotation;
        public Vector3 position;
        public Mesh node;
        //public List<Mesh> bulge = new List<Mesh>();
        Vector3 size = new Vector3();
        public Element()
        {
            node = new Mesh();
            node._transform = Matrix4.Identity;
            //for (int i = 0; i <50; i++)
            //{
            //    bulge.Add(new Mesh());
            //}
            //egg = new Mesh();
            //egg._transform = Matrix4.Identity;
            //for (int i = 0; i < bulge.Count; i++)
            //{
            //    bulge[i] = new Mesh();
            //    bulge[i]._transform = Matrix4.Identity;
            //}
        }
        public void Translate(Vector3 t)
        {
            node._transform *= Matrix4.CreateTranslation(t);
            node._transform *= Matrix4.CreateTranslation(t);
        }
        public void setRadius(Vector3 radius)
        {
            this.radius = radius;
            node.radius = radius;
            //radius = new Vector3(sizeEgg.X/2f, sizeEgg.Y/2f, sizeEgg.Z/2f);
            //egg.sizeBox = sizeEgg;
            //egg.radius = new Vector3(sizeEgg.X / 2f, sizeEgg.Y / 2f, sizeEgg.Z/2f);
            //for (int i = 0; i < bulge.Count; i++)
            //{
            //    bulge[i].setSize(sizeBulg);
            //    bulge[i].radius = new Vector3(sizeBulg.X / 2f, sizeBulg.Y / 2f, sizeBulg.Z / 2f); ;
            //}
        }
        public void create()
        {

            node.createBall();
            node.setupObject();


            //left._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(45f));
            //right._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(45f));
            //egg.createBall();
            //egg.setupObject();

            //for (int i = 0; i < bulge.Count; i++)
            //{
            //    bulge[i].createBall();
            //    bulge[i].setupObject();
            //}
        }
        float scale = 0F;
        bool goingBigger = true;
        public void Animate()
        {
            if (scale >= 0.3f)
            {
                goingBigger = false;
            }

            if (scale <= 0f)
            {
                goingBigger = true;
            }

            scale += goingBigger ? 0.000033f : -0.000033f;
            node._transform = Matrix4.Identity;
            node._transform *= Matrix4.CreateTranslation(-node._position.X, -node._position.Y, -node._position.Z);
            node._transform *= Matrix4.CreateScale(scale);
            node._transform *= Matrix4.CreateTranslation(node._position.X, node._position.Y, node._position.Z);
            node._transform *= Matrix4.CreateTranslation(Global.translate);
            node._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            node._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            node._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));

        }
        public void setPosition(Vector3 center)    
        {

            position = center;
            node._position = new Vector3(center.X , center.Y, center.Z);
            Console.WriteLine("position element left:");
            Console.WriteLine(node._position);


            //int i = 0;
            ////for (int degY = 0; degY <= 360; degY+=90)
            ////{

            ////}
            //position = center;
            //egg._position = center;

            //float _radiusX = radius.X;
            //float _radiusY = radius.Y;
            //float _radiusZ = radius.Z;
            //float _pi = 3.141519f;
            //for (float u = -_pi; u <= _pi; u += _pi / 2)
            //{
            //    for (float v = -_pi / 2; v < _pi / 2; v += _pi /2)
            //    {
            //        bulge[i]._position.X = center.X + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u);
            //        bulge[i]._position.Y = center.Y + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u);
            //        bulge[i]._position.Z = center.Z + _radiusZ * (float)Math.Sin(v);
            //        i++;
            //        Console.WriteLine($"posisioning bulge {i}");
            //    }
            //}



            //for (int degY = 0; degY < 360; degY +=45)
            //{
            //for (int degZ = 0; degZ < 360; degZ += 45)
            //    {
            //        bulge[i]._position.X = radius.X * (float) Math.Cos(MathHelper.DegreesToRadians(degZ))  + center.X;
            //        bulge[i]._position.Y = radius.Y * (float) Math.Sin(MathHelper.DegreesToRadians(degZ)) + center.Y;
            //        bulge[i]._position.Z = radius.Z * (float) Math.Sin(MathHelper.DegreesToRadians(degZ)) + center.Z;
            //        i++;
            //    }
            //}
        }
        public void clearRotationView()
        {
            //right._transform.ClearRotation();
            //var temp = left._transform.ExtractRotation();
            //left._transform *= Matrix4.CreateRotationX(-temp.X);
            //left._transform *= Matrix4.CreateRotationX(-temp.Y);
            //left._transform *= Matrix4.CreateRotationX(-temp.Z);
            //left._transform = left._transform.Inverted();
            //left._transform = left._transform.ClearRotation();
        }
        
        //public void Animate()
        //{
        //    //Console.WriteLine(left._transform.ExtractTranslation());
        //    //Console.WriteLine(right._transform.ExtractTranslation());
        //    //right._transform *= Matrix4.CreateTranslation(new Vector3(0f, 0f, -right._position.Z + radius.Z));
        //    //right._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X+=0.05f));
        //    //right._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y-0.05f));
        //    //right._transform *= Matrix4.CreateTranslation(new Vector3(0f, 0f, right._position.Z - radius.Z));

        //    //right._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X));
        //    //right._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y));
        //    //right._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotation.Z));
        //    rotation.X += 0.05f;
        //    rotation.Y += 0.05f;
        //    //left._transform *= Matrix4.CreateTranslation(new Vector3(0f, 0f, -left._position.Z + radius.Z));
        //    //left._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X));
        //    //left._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y));
        //    //left._transform *= Matrix4.CreateTranslation(new Vector3(0f, 0f, left._position.Z - radius.Z));
        //    //left._transform *= Matrix4.CreateTranslation(new Vector3(0f, 0f, -0.5f));

        //    //right._transform *= Matrix4.CreateTranslation(new Vector3(0f, 0f, -0.5f));
        //    //right._transform *= Matrix4.CreateTranslation(new Vector3(-right._position.X + radius.X, -right._position.Y, -right._position.Z));
        //    ////right._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.05f));
        //    //right._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.05f));
        //    //right._transform *= Matrix4.CreateTranslation(new Vector3(right._position.X - radius.X, right._position.Y, right._position.Z));

        //}
        public void Rotate(float degX, float degY, float degZ)
        {
            rotation = new Vector3(degX, degY, degZ);
            node._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            node._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            node._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
            //Console.WriteLine(left._transform.ExtractRotation());
            //egg._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            //egg._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            //egg._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

            //for (int i = 0; i < bulge.Count; i++)
            //{
            //    //bulge[i]._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            //    bulge[i]._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            //    //bulge[i]._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
            //}
        }
        float index = 0;
        public void render()
        {
            node.renderBezier();
            //right.renderBezier();
            //egg.renderBezier();

            //for (int i = 0; i < bulge.Count; i++)
            //{

            //    bulge[i].renderBezier();
            //}
        }
    }
}
