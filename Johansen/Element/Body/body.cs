using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTS_PROJECT.Johansen
{
    class body
    {
        public Mesh block = new Mesh();
        public Vector3 rotation = new Vector3(0f, 0f, 0f);
        public List<Mesh> fur = new List<Mesh>() {
            new Mesh(),
            new Mesh(),
            new Mesh()
        };
        public body()
        {

        }
        public void Rotate(float degX, float degY, float degZ)
        {
            //transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            //transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            //transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
            block._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            block._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            block._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
            for (int i = 0; i < 3; i++)
            {
                fur[i]._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
                fur[i]._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
                fur[i]._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
            }

        }
        //1
        public void setPostion(Vector3 pos)
        {
            //Vector3 posisiAwal = new Vector3(pos.X,pos.Y, pos.Z + 0.1f/2f + size.Z/5f/2f);
            Console.WriteLine("posisi body: ");
            block.setPosition(pos);
            Vector3 posisi = new Vector3(pos.X, pos.Y + block.sizeBox.Y/2f, pos.Z - 0.25f * block.sizeBox.Z);
            fur[0].setPosition(posisi);
            posisi = new Vector3(pos.X, pos.Y + block.sizeBox.Y / 2f,pos.Z);
            fur[1].setPosition(posisi);
            posisi = new Vector3(pos.X, pos.Y + block.sizeBox.Y / 2f,pos.Z+ 0.25f * block.sizeBox.Z);
            fur[2].setPosition(posisi);
        }
        public void Translate(Vector3 t)
        {
            block._transform *= Matrix4.CreateTranslation(t);
            for (int i = 0; i < fur.Count; i++)
            {
                fur[i]._transform *= Matrix4.CreateTranslation(t);
            }
        }
        public void Animate()
        {
            block._transform = Matrix4.Identity;

            block._transform *= Matrix4.CreateTranslation(Global.translate);

            block._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            block._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            block._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));


            fur[0]._transform = Matrix4.Identity;

            fur[0]._transform *= Matrix4.CreateTranslation(Global.translate);

            fur[0]._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            fur[0]._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            fur[0]._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));




            fur[1]._transform = Matrix4.Identity;

            fur[1]._transform *= Matrix4.CreateTranslation(Global.translate);

            fur[1]._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            fur[1]._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            fur[1]._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));




            fur[2]._transform = Matrix4.Identity;

            fur[2]._transform *= Matrix4.CreateTranslation(Global.translate);

            fur[2]._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            fur[2]._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            fur[2]._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));
        }
        public Vector3 size = new Vector3(0, 0, 0);
        //2
        public void setSize(Vector3 size)
        {
            Console.WriteLine("size  body: ");
            Console.WriteLine(size);
            Vector3 sizeFur, sizeBlock;

            this.size = size;
            sizeBlock = new Vector3(size);
            block.setSize(sizeBlock);

            sizeFur = new Vector3(size);
            sizeFur.X = sizeBlock.X / 8f;
            sizeFur.Y = sizeBlock.Y / 3f;
            sizeFur.Z = sizeBlock.Z / 6f;
            Console.WriteLine("size fur body: ");
            Console.WriteLine(sizeFur);
            for (int i = 0; i < 3; i++)
            {
                fur[i].setSize(sizeFur);
            }

        }
        //3
        public void create()
        {
            block.createBoxVertices();
            block.setupObject();
            for (int i = 0; i < 3; i++)
            {
                fur[i].createBoxVertices();
                fur[i].setupObject();
            }
        }
        //4
        public void render()
        {
            block.render();
            for (int i = 0; i < 3; i++)
            {
                fur[i].render();
            }
        }
        public void update()
        {
            //atas.updateBox();
            //bawah.updateBox();
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
