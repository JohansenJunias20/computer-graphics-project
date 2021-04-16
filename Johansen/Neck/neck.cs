using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTS_PROJECT.Johansen
{
    class neck
    {
        public Vector3 position;
        public Vector3 rotation = new Vector3(0f, 0f, 0f);

        public List<node> node = new List<node>() { 
            new node(),
            new node(),
            new node(),
            new node(),
            new node()
        };
        public Matrix4 transform = Matrix4.Identity;
        public Vector3 size = new Vector3(0.8f, 0.8f, 0.8f);
        //size total dari mouth (atas dan bawah)
        public int NodeCount = 5;

        public neck(int nodecount)
        {
            NodeCount = nodecount;
            //atas.createBoxVertices();
            //atas.setupObject();
            //bawah.createBoxVertices();
            //bawah.setupObject();
            //node temp;
            //temp = new node();
            //for (int i = 0; i < NodeCount; i++)
            //{
            //    node[i] = new node();
            //}
            //node = node.ConvertAll(item=> new node());
            //node.set
        }

        public Matrix4 getBothTransform()
        {
            return transform;
        }
        public void Translate(Vector3 t)
        {
            for (int i = 0; i < NodeCount; i++)
            {
                node[i].Translate(t);
            }
        }
        public void Rotate(float degX, float degY, float degZ)
        {
            //transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            //transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            //transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
            //Console.WriteLine("rotating mouth!");


            for (int i = 0; i < NodeCount; i++)
            {
                node[i].Rotate(degX, degY, degZ);
            }

        }
        public void Animate()
        {
            for (int i = 0; i < NodeCount; i++)
            {
                node[i].block._transform = Matrix4.Identity;

                node[i].block._transform *= Matrix4.CreateTranslation(Global.translate);

                node[i].block._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
                node[i].block._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
                node[i].block._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));



                node[i].fur._transform = Matrix4.Identity;

                node[i].fur._transform *= Matrix4.CreateTranslation(Global.translate);

                node[i].fur._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
                node[i].fur._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
                node[i].fur._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));
            }
           
        }
        //1
        public void setPostion(Vector3 pos)
        {
            Vector3 posisiAwal = new Vector3(pos.X, pos.Y, pos.Z - ( 0.5f * size.Z) );
            //Vector3 posisiAwal = new Vector3(pos.X,pos.Y, pos.Z + 0.1f/2f + size.Z/5f/2f);

            for (int i = 0; i < NodeCount; i++)
            {
                node[i].setPostion(posisiAwal);
                posisiAwal.Z += node[i].block.sizeBox.Z;
            }
        }
        //2
        public void setSize(Vector3 size)
        {
            Console.WriteLine(size);
            Vector3 sizeFur, sizeBlock;

            this.size = size;
            sizeBlock = new Vector3(size);
            sizeBlock.Z /= NodeCount;

            sizeFur = new Vector3(size);
            sizeFur.X = sizeBlock.X / 6f;
            sizeFur.Y = sizeBlock.Y / 2f;
            sizeFur.Z = sizeBlock.Z * 0.8f;
            Console.WriteLine("fursize: ");
            Console.WriteLine(sizeFur);
            Console.WriteLine("blocksize: ");
            Console.WriteLine(sizeBlock);
            for (int i = 0; i < NodeCount; i++)
            {
                node[i].setSize(sizeFur, sizeBlock);
            }

        }
        //3
        public void create()
        {
            for (int i = 0; i < NodeCount; i++)
            {
                node[i].create();
            }
        }
        //4
        public void render()
        {
            for (int i = 0; i < NodeCount; i++)
            {
                node[i].render();
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
