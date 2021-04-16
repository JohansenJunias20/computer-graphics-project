using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTS_PROJECT.Johansen.Feets
{
    class front
    {
        public Vector3 position;
        public Feets.Fronts.left left;
        public Feets.Fronts.right right;
        //Steve.feets.front.right right;
        public front()
        {
            left = new Fronts.left();
            right = new Fronts.right();
        }
        public void Rotate(float degX,float degY, float degZ)
        {
            left.Rotate(degX, degY, degZ);
            right.Rotate(degX, degY, degZ);
        }
        public void Translate(Vector3 t)
        {
            left.palm._transform *= Matrix4.CreateTranslation(t);
            left.arm._transform *= Matrix4.CreateTranslation(t);
            left.forearm._transform *= Matrix4.CreateTranslation(t);
            right.palm._transform *= Matrix4.CreateTranslation(t);
            right.arm._transform *= Matrix4.CreateTranslation(t);
            right.forearm._transform *= Matrix4.CreateTranslation(t);
        }
        public void setPosition(Vector3 pos)
        {
            position = pos;
            //0.15f, 0.15f, 0.4f
            //arm.setPosition(new Vector3(0f-0.15f/2f-arm.sizeBox.X/2f,0f-0.15f/2f+arm.sizeBox.Y/2f,));
            //0.15f/2f adalah ukuran size body di * setengah
            left.setPosition(new Vector3(pos.X - 0.15f/2f,pos.Y,pos.Z));
            right.setPosition(new Vector3(pos.X + 0.15f / 2, pos.Y, pos.Z));
            //arm.setPosition(new Vector3(pos.X, pos.Y - arm.sizeBox.Y / 2f, pos.Z));

            //furInner.setPosition(new Vector3(0f,0f,0f));
            //Console.WriteLine("fur inner position: ")
        }
        public void render()
        {
            left.render();
            right.render();
        }
        public void create()
        {
            left.create();
            right.create();
        }
    }
}
