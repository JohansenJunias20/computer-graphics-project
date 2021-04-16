using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTS_PROJECT.Johansen
{
    class wings
    {
        public left left;
        public right right;
        public Vector3 position;
        public Vector3 rotation = new Vector3(0f, 0f, 0f);

        public wings()
        {
            left = new left();
            right = new right();
            left.innerBone._transform = Matrix4.Identity;
            left.outerBone._transform = Matrix4.Identity;
            right.innerBone._transform = Matrix4.Identity;
            right.outerBone._transform = Matrix4.Identity;
        }
        //set position ada di tengah2 body yang ingin ditempel wings
        public void setPosition(Vector3 pos)
        {
            left.setPosition(new Vector3(pos.X - 0.15f/2f,pos.Y,pos.Z));
            right.setPosition(new Vector3(pos.X + 0.15f/2f,pos.Y,pos.Z));

        }
        public void Translate(Vector3 t)
        {
            left.Translate(t);
            right.Translate(t);
        }
        public Vector3 size;
        public void render()
        {
            left.render();
            right.render();
        }
        //sebelum create harus set 
        public void create()
        {
            left.create();
            right.create();
        }
        public void Rotate(float degX, float degY, float degZ)
        {
            left.Rotate(degX, degY, degZ);
            right.Rotate(degX, degY, degZ);
        }
    }
}
