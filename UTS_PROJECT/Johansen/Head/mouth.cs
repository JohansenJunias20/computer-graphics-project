using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTS_PROJECT.Johansen
{
    class mouth
    {
        public Vector3 position;
        public Mesh atas;
        public Mesh bawah;
        public Matrix4 transform = Matrix4.Identity;
        public Vector3 Headpos;
        //size total dari mouth (atas dan bawah)
        public Vector3 size;
        public mouth()
        {
            //atas.createBoxVertices();
            //atas.setupObject();
            //bawah.createBoxVertices();
            //bawah.setupObject();
            atas = new Mesh();
            bawah = new Mesh();
        }

        public Matrix4 getBothTransform()
        {
            return transform;
        }
        public void Rotate(float degX, float degY, float degZ)
        {
            //transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            //transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            //transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
            atas._transform = atas._transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            atas._transform = atas._transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            atas._transform = atas._transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

            bawah._transform = bawah._transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            bawah._transform = bawah._transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            bawah._transform = bawah._transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

        }
        //1
        public void setPostion(Vector3 pos)
        {
            position = pos;
            bawah.setPosition(new Vector3(position.X , position.Y-size.Y/4f, position.Z));
            atas.setPosition(new Vector3(position.X , position.Y+size.Y/4f, position.Z));

        }
        //2
        public void setOverallSize(Vector3 size)
        {
            this.size = size;
            atas.sizeBox = new Vector3(size.X,size.Y/2f,size.Z);
            bawah.sizeBox = new Vector3(size.X,size.Y/2f,size.Z);
        }
        //3
        public void create()
        {
            atas.createBoxVertices();
            atas.setupObject();
            bawah.createBoxVertices();
            bawah.setupObject();
        }
        //4
        public void render()
        {
            atas.render();
            bawah.render();
        }
        public void update()
        {
            atas.updateBox();
            bawah.updateBox();
        }
        bool opening = true;
        float openDeg = 0f;
        public void Animate()
        {
            if (openDeg <= -45f)
            {
                opening = false;
            }

            if (openDeg >= 0f)
            {
                opening = true;
            }

            openDeg += opening ? -0.01f : 0.01f;

            bawah._transform = Matrix4.Identity;

            bawah._transform *= Matrix4.CreateTranslation(-bawah._position.X,-bawah._position.Y-bawah.sizeBox.Y/2f,-bawah._position.Z -  bawah.sizeBox.Z/2f);
            bawah._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(openDeg));
            bawah._transform *= Matrix4.CreateTranslation(bawah._position.X, bawah._position.Y + bawah.sizeBox.Y/2f,bawah._position.Z + bawah.sizeBox.Z/2f);

            bawah._transform *= Matrix4.CreateTranslation(Global.translate);
            bawah._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            bawah._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            bawah._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));



            atas._transform = Matrix4.Identity;

            atas._transform *= Matrix4.CreateTranslation(Global.translate);

            atas._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            atas._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            atas._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));
        }
        //membuka mulut sebanyak... derajat
        public void openAt(float degress)
        {
            //atas._transform = atas._transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degress));
            //atas._transform = transform * Matrix4.CreateTranslation(atas._position.X,atas._position.Y-atas.sizeBox.Y/2f,atas._position.Z+atas.sizeBox.Z/2f);

            //bawah._transform = bawah._transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degress));


            //bawah._transform = bawah._transform * Matrix4.CreateTranslation(bawah._position.X, bawah._position.Y- bawah.sizeBox.Y/2f, bawah._position.Z+ bawah.sizeBox.Z/2f);
            //bawah._transform = transform * Matrix4.CreateTranslation();
        }
    }
}
