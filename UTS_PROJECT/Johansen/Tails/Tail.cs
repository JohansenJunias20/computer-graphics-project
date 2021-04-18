using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTS_PROJECT.Johansen.Tails
{
    class Tail
    {
        public List<Tails.Node> node;
        public Matrix4 transform = Matrix4.Identity;
        public Vector3 size = new Vector3(0.8f, 0.8f, 0.8f);
        public Vector3 position;
        public Tail()
        {
            node = new List<Node>()
            {
                new Node(),
                new Node(),
                new Node(),
                new Node(),
                new Node(),
                new Node(),
                new Node(),
                new Node(),
                new Node(),
                new Node(),
                new Node(),
                new Node(),
            };
        }
        public Matrix4 getBothTransform()
        {
            return transform;
        }

        //List<Vector3> bezierLinePos = new List<Vector3>();
        //void setPositionToBezier(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
        //{
        //    List<Vector3> newPos = new List<Vector3>();
        //    Vector3 p;
        //    float a1, a2, a3, a4;
        //    for (float t = 0.0f; t <= 1.0f; t += 0.01f)
        //    {

        //        a1 = (float)Math.Pow((1 - t), 3);
        //        a2 = (float)Math.Pow((1 - t), 2) * 3 * t;
        //        a3 = 3 * t * t * (1 - t);
        //        a4 = t * t * t;
        //        p.X = a1 * p1.X + a2 * p2.X + a3 * p3.X + a4 * p4.X;
        //        p.Y = a1 * p1.Y + a2 * p2.Y + a3 * p3.Y + a4 * p4.Y;
        //        p.Z = a1 * p1.Z + a2 * p2.Z + a3 * p3.Z + a4 * p4.Z;
        //        newPos.Add(p);

        //    }
        //    bezierLinePos = newPos;

        //    for (int i = 0; i < node.Count; i++)
        //    {
        //        node[i].setPostion(posisiAwal);
        //        posisiAwal.Z += node[i].block.sizeBox.Z;
        //    }
        //}
        public void Translate(Vector3 t)
        {
            for (int i = 0; i < node.Count; i++)
            {
                node[i].Translate(t);
            }
            //create();
        }
        Vector3 posisiAwalNode;
        public void Rotate(float degX, float degY, float degZ)
        {
            //transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            //transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            //transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
            //Console.WriteLine("rotating mouth!");


            for (int i = 0; i < node.Count; i++)
            {
                node[i].Rotate(degX, degY, degZ);
            }

        }
        float radius = 2f;
        Vector3 poros;
        float maxDegree = 30f;
        float startDegree = 0f;
        //1
        public void setPostion(Vector3 pos)
        {
            startDegree = 0f;
            //Vector3 posisiAwal = new Vector3(pos.X, pos.Y, pos.Z - (0.5f * size.Z));
            ////Vector3 posisiAwal = new Vector3(pos.X,pos.Y, pos.Z + 0.1f/2f + size.Z/5f/2f);
            //Vector3 p1 = posisiAwal;
            //Vector3 p4 = new Vector3(position.X, 0f, 0f);
            ////for (float t = 0.0f; t <= 1.0f; t += 0.01f)
            ////{

            ////    a1 = (float)Math.Pow((1 - t), 3);
            ////    a2 = (float)Math.Pow((1 - t), 2) * 3 * t;
            ////    a3 = 3 * t * t * (1 - t);
            ////    a4 = t * t * t;
            ////    p.X = a1 * p1.X + a2 * p2.X + a3 * p3.X + a4 * p4.X;
            ////    p.Y = a1 * p1.Y + a2 * p2.Y + a3 * p3.Y + a4 * p4.Y;
            ////    p.Z = a1 * p1.Z + a2 * p2.Z + a3 * p3.Z + a4 * p4.Z;
            ////    newPos.Add(p);

            ////}
            //for (int i = 0; i < node.Count; i++)
            //{
            //    node[i].setPostion(posisiAwal);
            //    posisiAwal.Z += node[i].block.sizeBox.Z;
            //}
            //posisiAwalNode = posisiAwal;
            position = pos;
            Vector3 posisiAwal = new Vector3(pos.X, pos.Y, pos.Z - (0.5f * size.Z) - node[0].block.sizeBox.Z / 2f);
            //poros untuk memutarkan ekornya
            poros = new Vector3(0f, radius, posisiAwal.Z - node[0].block.sizeBox.Z / 2f);
            //offset degree adalah berapa derajat setiap node terhadap porosnya (total degree putar / banyaknya node)
            //startDegree akan ditambahkan offset setiap loopnya agar mendapatkan degree node berikutnya
            float offsetDegree = (maxDegree - startDegree) / node.Count;
            float y, z;
            for (int i = 0; i < node.Count; i++)
            {
                //menentukan y dan x tiap node menggunakan trigonometri
                y = poros.Y -(float)Math.Cos(MathHelper.DegreesToRadians( startDegree)) * radius;
                z = poros.Z +(float)Math.Sin(MathHelper.DegreesToRadians( startDegree)) * radius;
                //ngeset startdegree karena akan dipakai di function Animate untuk mengukur angleNode
                node[i].startDegree = startDegree;
                node[i].setPostion(new Vector3(posisiAwal.X, y, z));

                startDegree += offsetDegree;
            }
        }
        //2
        public void setSize(Vector3 size)
        {
            
            Vector3 sizeFur, sizeBlock;

            this.size = size;
            sizeBlock = new Vector3(size);
            sizeBlock.Z /= node.Count;

            sizeFur = new Vector3(size);
            sizeFur.X = sizeBlock.X / 6f;
            sizeFur.Y = sizeBlock.Y / 2f;
            sizeFur.Z = sizeBlock.Z * 0.8f;
            for (int i = 0; i < node.Count; i++)
            {
                node[i].setSize(sizeFur, sizeBlock);
            }

        }
        //3
        public void create()
        {
            for (int i = 0; i < node.Count; i++)
            {
                node[i].create();
            }
        }
        //4
        public void render()
        {
            for (int i = 0; i < node.Count; i++)
            {
                node[i].render();
            }
        }
        //membuka mulut sebanyak... derajat

        bool isUp = true;
        public void Animate()
        {
            if(radius >= 3f)
            {
                isUp = true;
            }
            if(radius <= 2f)
            {
                isUp = false;
            }

            radius += isUp ? -0.001f : 0.001f;
            maxDegree += isUp ? 0.01f : -0.01f;
            //setSize(new Vector3(0.08f, 0.08f, 0.08f * 12f));
            setPostion(new Vector3(0f, 0f, 0 + 0.05f + 0.4f + 0.08f * 12f * 0.5f + 0.08f * 5f));
            create();
            float angleNode;
            for (int i = 0; i < node.Count; i++)
            {
                angleNode = 180f - node[i].startDegree - 90f;

                node[i].block._transform *= Matrix4.CreateTranslation(-node[i].block._position.X, -node[i].block._position.Y, -node[i].block._position.Z);
                node[i].block._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angleNode));
                node[i].block._transform *= Matrix4.CreateTranslation(node[i].block._position.X, node[i].block._position.Y, node[i].block._position.Z);

                node[i].fur._transform *= Matrix4.CreateTranslation(-node[i].fur._position.X, -node[i].fur._position.Y, -node[i].fur._position.Z);
                node[i].fur._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angleNode));
                node[i].fur._transform *= Matrix4.CreateTranslation(node[i].fur._position.X, node[i].fur._position.Y, node[i].fur._position.Z);
                node[i].Translate(Global.translate);
                node[i].Rotate(Global.angle.X, Global.angle.Y, Global.angle.Z);
            }

        }
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
