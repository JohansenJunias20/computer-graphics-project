using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTS_PROJECT.Johansen
{
    class eyes
    {
        public Vector3 position;
        public Mesh left;
        public Mesh right;
        public Matrix4 transform = Matrix4.Identity;
        //0
        public eyes()
        {
        }
        public Matrix4 getBothTransform()
        {
            return transform;
        }
        public void Rotate(float degX, float degY, float degZ)
        {
            //Console.WriteLine(left._transform.ExtractTranslation());
            //transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            //transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            //transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

            left._transform = left._transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            left._transform = left._transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            left._transform = left._transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
            
            right._transform = right._transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            right._transform = right._transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            right._transform = right._transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

        }
        public void Animate()
        {

            left._transform = Matrix4.Identity;

            left._transform *= Matrix4.CreateTranslation(Global.translate);

            left._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            left._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            left._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));


            right._transform = Matrix4.Identity;

            right._transform *= Matrix4.CreateTranslation(-right._position.X, -right._position.Y, -right._position.Z);
            right._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(180));
            right._transform *= Matrix4.CreateTranslation(right._position.X, right._position.Y, right._position.Z);


            right._transform *= Matrix4.CreateTranslation(Global.translate);

            right._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            right._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            right._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));
        }
        //1
        public void setPostion(Vector3 pos)
        {
            position = pos;
            left.setPosition(new Vector3(position.X - 0.02f, position.Y, position.Z));
            right.setPosition(new Vector3(position.X + 0.02f, position.Y, position.Z));

            
        }
        public void Translate(Vector3 t)
        {
            left._transform *= Matrix4.CreateTranslation(t);
            right._transform *= Matrix4.CreateTranslation(t);
        }
        //2
        public void setBothSize(Vector3 size)
        {
            left.sizeBox = size;

            left.sisi = size.X;
            left.Ttinggi = size.Y;
            left.tinggi = size.Z;


            right.sizeBox = size;

            right.sisi = size.X;
            right.Ttinggi = size.Y;
            right.tinggi = size.Z;
        }
        //3
        public void create()
        {
            left.createTrianglePrism();
            right.createTrianglePrism();
            left.setupObject();
            right.setupObject();
            right._transform *= Matrix4.CreateTranslation(-right._position.X, -right._position.Y, -right._position.Z);
            right._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180));
            right._transform *= Matrix4.CreateTranslation(right._position.X, right._position.Y, right._position.Z);
        }
        //4
        public void render()
        {
            left.render();
            right.render();
        }
        public void update()
        {
            //left.updateBox();
            //right.updateBox();
        }
    }
}
