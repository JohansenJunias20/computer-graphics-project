using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace UTS_PROJECT.Johansen
{
    class left
    {
        public Mesh innerBone, outerBone, furInner, furOuter;
        bool isInnerUp = true;
        bool isOuterUp = true;
        public left()
        {
            innerBone = new Mesh();
            outerBone = new Mesh();
            furInner = new Mesh();
            furOuter = new Mesh();

        }
        public void Translate(Vector3 t)
        {
            innerBone._transform *= Matrix4.CreateTranslation(t);
            outerBone._transform *= Matrix4.CreateTranslation(t);
            furInner._transform *= Matrix4.CreateTranslation(t);
            furOuter._transform *= Matrix4.CreateTranslation(t);
        }
        public Vector3 innerRotation = new Vector3(0f,0f,0f);
        public Vector3 outerRotation =  new Vector3(0f,0f,0f);
        public void Animate()
        {
            if(innerRotation.Z <= -30f)
            {
                isInnerUp = false;
                isOuterUp = true;
            }
            if(innerRotation.Z >= 30f)
            {
                isInnerUp = true;
                isOuterUp = false;
            }

            if(outerRotation.Z >= 30f)
            {
            }

            if(outerRotation.Z <= -30f)
            {
            }
            innerRotation.Z += isInnerUp ? -0.06f : 0.06f;
            outerRotation.Z += isOuterUp ? -0.007f : 0.007f;

            //reset transformasi pada innerbone (kembali pada kamera depan)
            innerBone._transform = Matrix4.Identity;
            //translate ke titik 0,0,0 dengan offset x - size X dari innerbone karena dititik itu lah dijadikan sebagai titik rotate poros (sendi atas)
            innerBone._transform *= Matrix4.CreateTranslation(new Vector3(-innerBone._position.X - innerBone.sizeBox.X / 2f, -innerBone._position.Y, -innerBone._position.Z));
            //rotate innerBone di Z sebanyak innerRotation.Z
            innerBone._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(innerRotation.Z));
            //kembalikan lokasi seperti semula (masih pada kamera depan)
            innerBone._transform *= Matrix4.CreateTranslation(new Vector3(innerBone._position.X + innerBone.sizeBox.X / 2f, innerBone._position.Y, innerBone._position.Z));

            innerBone._transform *= Matrix4.CreateTranslation(Global.translate);
            //putar sesuai angle
            innerBone._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            innerBone._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            innerBone._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));

         

            //reset transformasi furinner
            furInner._transform = Matrix4.Identity;
            //translate ke 0,0,0
            furInner._transform *= Matrix4.CreateTranslation(new Vector3(-furInner._position.X, -furInner._position.Y, -furInner._position.Z));
            //rotate X 90f karena pada awalnya trapesium ini posisi tidur (maka harus diberdirikan)
            furInner._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));

            furInner._transform *= Matrix4.CreateTranslation(new Vector3(furInner._position.X, furInner._position.Y, furInner._position.Z));


            furInner._transform *= Matrix4.CreateTranslation(new Vector3(-furInner._position.X - innerBone.sizeBox.X / 2f, -furInner._position.Y, -furInner._position.Z));
            furInner._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(innerRotation.Z));
            furInner._transform *= Matrix4.CreateTranslation(new Vector3(furInner._position.X + innerBone.sizeBox.X / 2f, furInner._position.Y, furInner._position.Z));


            furInner._transform *= Matrix4.CreateTranslation(Global.translate);
            furInner._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            furInner._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            furInner._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));

            //reset transformasi pada outerbone
            outerBone._transform = Matrix4.Identity;
            //sendi yang terdapat pada ujung innerbone yang ada di dekat badan
            Vector3 sendiAtasInnerBone = new Vector3(innerBone._position.X + innerBone.sizeBox.X / 2f, innerBone._position.Y, innerBone._position.Z);

            //mencari titik ujung sendi lainnya innerbone (bukan yang didekan badan)
            float x = sendiAtasInnerBone.X - innerBone.sizeBox.X * (float)Math.Cos(MathHelper.DegreesToRadians(innerRotation.Z));
            float y = sendiAtasInnerBone.Y - innerBone.sizeBox.X * (float)Math.Sin(MathHelper.DegreesToRadians(innerRotation.Z));


            outerBone.setPosition(new Vector3(x - outerBone.sizeBox.X/2f, y, innerBone._position.Z));
            outerBone.createBoxVertices();
            outerBone.setupObject();
            outerBone._transform *= Matrix4.CreateTranslation(-outerBone._position.X - outerBone.sizeBox.X / 2f, -outerBone._position.Y, -outerBone._position.Z);
            outerBone._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(outerRotation.Z));
            outerBone._transform *= Matrix4.CreateTranslation(outerBone._position.X + outerBone.sizeBox.X / 2f, outerBone._position.Y, outerBone._position.Z);

            outerBone._transform *= Matrix4.CreateTranslation(Global.translate);
            outerBone._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            outerBone._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            outerBone._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));

            furOuter._transform = Matrix4.Identity;

            furOuter.setPosition(new Vector3(outerBone._position.X, outerBone._position.Y,outerBone._position.Z + furOuter.sisi/2f));
            furOuter.createTrianglePrism();
            furOuter.setupObject();

            furOuter._transform *= Matrix4.CreateTranslation(new Vector3(-furOuter._position.X, -furOuter._position.Y, -furOuter._position.Z));
            furOuter._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            furOuter._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f));
            furOuter._transform *= Matrix4.CreateTranslation(new Vector3(furOuter._position));

            furOuter._transform *= Matrix4.CreateTranslation(new Vector3(-furOuter._position.X - outerBone.sizeBox.X / 2f, -furOuter._position.Y, -furOuter._position.Z));
            furOuter._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(outerRotation.Z));
            furOuter._transform *= Matrix4.CreateTranslation(new Vector3(furOuter._position.X + outerBone.sizeBox.X / 2f, furOuter._position.Y, furOuter._position.Z ));

            furOuter._transform *= Matrix4.CreateTranslation(Global.translate);
            furOuter._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            furOuter._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            furOuter._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));





            //float x = innerBone._position.X + 



        }
        
        public void Rotate(float degX, float degY, float degZ)
        {
            furOuter._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            furOuter._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            furOuter._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

            furInner._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            furInner._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            furInner._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

            innerBone._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            innerBone._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            innerBone._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

            outerBone._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            outerBone._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            outerBone._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
        }
        //TP = Triangle Prism
        public void create( )
        {
            //furOuter.createTrianglePrism();
            //furOuter.setupObject();

            furInner.createTrianglePrism();
            furInner.setupObject();

            furInner._transform *= Matrix4.CreateTranslation(new Vector3(-furInner._position.X, -furInner._position.Y, -furInner._position.Z));
            furInner._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            //furInner._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(45f));
            furInner._transform *= Matrix4.CreateTranslation(new Vector3(furInner._position));
            Console.WriteLine("furiner pos:");
            Console.WriteLine(furInner._position);

            //furInner._transform.ClearTranslation();
            furOuter.createTrianglePrism();
            furOuter.setupObject();

            furOuter._transform *= Matrix4.CreateTranslation(new Vector3(-furOuter._position.X, -furOuter._position.Y, -furOuter._position.Z));
            furOuter._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            furOuter._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f));
            furOuter._transform *= Matrix4.CreateTranslation(new Vector3(furOuter._position));


            innerBone.createBoxVertices();
            innerBone.setupObject();

            outerBone.createBoxVertices();
            outerBone.setupObject();
        }
        public Vector3 position = new Vector3(0, 0, 0);
        //anchor points ada di ujung wing yang nempel di body
        public void setPosition(Vector3 pos)
        {
            position = pos;
            innerBone.setPosition(new Vector3(pos.X - innerBone.sizeBox.X / 2f, pos.Y, pos.Z));
            outerBone.setPosition(new Vector3(innerBone._position.X-outerBone.sizeBox.X/2f - innerBone.sizeBox.X/2f,pos.Y,pos.Z));

            furInner.setPosition(new Vector3(innerBone._position.X, innerBone._position.Y, innerBone._position.Z+furInner.sisi/2f));
            furOuter.setPosition(new Vector3(outerBone._position.X, outerBone._position.Y, outerBone._position.Z+ furOuter.sisi/2f));
            //furInner.setPosition(new Vector3(0f,0f,0f));
            //Console.WriteLine("fur inner position: ")
        }

        public void render()
        {
            furOuter.render();
            furInner.render();

            innerBone.render();
            outerBone.render();
        }
    }
}
