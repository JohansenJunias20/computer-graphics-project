using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTS_PROJECT.Johansen.Tails
{
    class Node
    {
        public Vector3 position;
        public Mesh block;
        public Mesh fur;
        public Node()
        {
            block = new Mesh();
            fur = new Mesh();
        }
        public void Rotate(float degX, float degY, float degZ)
        {
            //Console.WriteLine(left._transform.ExtractTranslation());
            fur._transform = fur._transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            fur._transform = fur._transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            fur._transform = fur._transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));


            block._transform = block._transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            block._transform = block._transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            block._transform = block._transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

        }
        //1
        public void setPostion(Vector3 pos)
        {
            position = pos;
            block.setPosition(pos);
            fur.setPosition(new Vector3(pos.X, pos.Y + block.sizeBox.Y / 2f, pos.Z));



        }
        public float startDegree;
        public void Translate(Vector3 t)
        {
            block._transform *= Matrix4.CreateTranslation(t);
            fur._transform *= Matrix4.CreateTranslation(t);
        }
        //2
        public void setSize(Vector3 FurSize, Vector3 BlockSize)
        {
            fur.setSize(FurSize);
            block.setSize(BlockSize);
        }
        //3
        public void create()
        {
            fur.createBoxVertices();
            fur.setupObject();
            block.createBoxVertices();
            block.setupObject();
        }
        //4
        public void render()
        {
            fur.render();
            block.render();
        }
        public void update()
        {
            //left.updateBox();
            //right.updateBox();
        }
    }
}
