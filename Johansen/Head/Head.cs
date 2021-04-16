using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTS_PROJECT.Johansen
{
    struct HeadProps
    {
        public Vector3 pos;
        public Vector3 size;
    }
    class Head
    {
        public Vector3 rotation = new Vector3(0f, 0f, 0f);

        public Vector3 position;
        public Matrix4 transform;
        public eyes eyes;
        public ears ears;
        public mouth mouth;
        public Mesh kepala;
        public antenna antenna;
        public Vector3 size = new Vector3(0.05f, 0.05f, 0.05f);
        //0 --> urutan panggilan
        public Head()
        {
            eyes = new eyes();
            ears = new ears();
            //mouth = new mouth();
            kepala = new Mesh();
            mouth = new mouth();
            transform = Matrix4.Identity;
            kepala._transform = Matrix4.Identity;

            ears.transform = Matrix4.Identity;
            ears.left = new Mesh();
            ears.right = new Mesh();
            ears.left._transform = Matrix4.Identity;
            ears.right._transform = Matrix4.Identity;


            eyes.transform = Matrix4.Identity;
            eyes.left = new Mesh();
            eyes.right = new Mesh();
            eyes.left._transform = Matrix4.Identity;
            eyes.right._transform = Matrix4.Identity;

            mouth.atas._transform = Matrix4.Identity;

            antenna = new antenna();
            antenna.left._transform = Matrix4.Identity;
            antenna.right._transform = Matrix4.Identity;
        }
        public void Animate()
        {
            mouth.Animate();
            eyes.Animate();
            antenna.Animate();
        }
        public HeadProps getHeadProperty()
        {
            HeadProps hp;
            hp.pos = position;
            hp.size = size;
            return hp;
        }
        //2
        public void setPosition(Vector3 pos)
        {
            position = pos;

            kepala.setPosition(position);
            eyes.setPostion(new Vector3(position.X,position.Y+kepala.sizeBox.Y/4f,position.Z - kepala.sizeBox.Z/2f));
            mouth.setPostion(new Vector3(position.X,position.Y-kepala.sizeBox.Y/4f, position.Z - mouth.atas.sizeBox.Z / 2f - kepala.sizeBox.Z / 2f));
            ears.setPostion(new Vector3(position.X, position.Y + kepala.sizeBox.Y / 2f, position.Z));
            antenna.setPosition(new Vector3(pos.X, pos.Y + size.Y / 2f, pos.Z));

        }
        //1
        public void setSize(Vector3 _size)
        {
            size = _size;
            kepala.setSize(size);
            eyes.setBothSize(new Vector3(0.01f,0.01f,0.01f));
            mouth.setOverallSize(new Vector3(_size.X*0.9f, _size.Y/2f, 0.08f));
            ears.setBothSize(new Vector3(0.01f, 0.03f, 0.04f));
        }
        //3
        public void create()
        {
            eyes.create();
            kepala.createBoxVertices();
            kepala.setupObject();
            mouth.create();
            ears.create();

            antenna.create();
        }
        //4
        public void render()
        {
            eyes.render();
            kepala.render();
            mouth.render();
            ears.render();
            antenna.render();
        }
        public void Translate(Vector3 t)
        {
            eyes.Translate(t);
            kepala._transform = kepala._transform * Matrix4.CreateTranslation(t);
            mouth.atas._transform *= Matrix4.CreateTranslation(t);
            mouth.bawah._transform *= Matrix4.CreateTranslation(t);
            ears.Translate(t);
            antenna.Translate(t);
        }
        public void update()
        {
            //eyes.update();
            //kepala.updateBox();
        }
        public void setTemptoTransform()
        {

        }
        public void Rotate(float degX, float degY, float degZ)
        {
            //eyes.Rotate(degX, degY, degZ);
            transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
            //eyes.transform = transform;
            eyes.Rotate(degX, degY, degZ);
            mouth.Rotate(degX, degY, degZ);
            ears.Rotate(degX, degY, degZ);
            antenna.Rotate(degX, degY, degZ);
            //mouth.atas._transform = transform;
            //mouth.bawah._transform = transform;

            //mouth.transform = transform;
            //eyes.Rotate(degX, degY, degZ);
            //mouth.Rotate(degX, degY, degZ);
            kepala._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            kepala._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            kepala._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
        }
    }
}
