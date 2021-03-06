using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTS_PROJECT.Johansen
{
    class ears
    {
        public Vector3 position;
        public Mesh left;
        public Mesh right;
        public Matrix4 transform = Matrix4.Identity;
        //0
        public ears()
        {
        }
        public Matrix4 getBothTransform()
        {
            return transform;
        }
        public void Rotate(float degX, float degY, float degZ)
        {

            left._transform = left._transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            left._transform = left._transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            left._transform = left._transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

            right._transform = right._transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            right._transform = right._transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            right._transform = right._transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

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
            right.sizeBox = size;
        }
        //3
        public void create()
        {
            left.createBoxVertices();
            right.createBoxVertices();
            left.setupObject();
            right.setupObject();
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
