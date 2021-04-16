using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace UTS_PROJECT.Johansen.feets.backs
{
    class right
    {
        public Mesh arm, forearm, palm;
        public right()
        {
            arm = new Mesh();
            forearm = new Mesh();
            palm = new Mesh();
        }
        float armDeg = 0f;
        float forearmDeg = 0f;
        float palmDeg = 0f;
        bool goFront = false;
        public void Animate()
        {
            if (armDeg <= -45f)
            {
                goFront = true;
            }

            if (armDeg >= -40f)
            {
                goFront = false;
            }
            //arm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-rotation.X));
            //arm._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(-rotation.Y));
            //arm._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-rotation.Z));
            //arm._shader.SetMatrix4("transform", arm._transform);
            armDeg += goFront ? 0.005f : -0.005f;
            forearmDeg += goFront ? 0.008f : -0.008f;
            palmDeg += goFront ? 0.008f : -0.008f;

            arm._transform = Matrix4.Identity;
            //Rotating ARM first
            arm._transform *= Matrix4.CreateTranslation(new Vector3(-arm._position.X, -arm._position.Y - arm.sizeBox.Y / 2f + arm.sizeBox.Z / 2f, -arm._position.Z));

            arm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(armDeg));

            arm._transform *= Matrix4.CreateTranslation(new Vector3(arm._position.X, arm._position.Y + arm.sizeBox.Y / 2f - arm.sizeBox.Z / 2f, arm._position.Z));

            arm._transform *= Matrix4.CreateTranslation(Global.translate);
            arm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            arm._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            arm._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));

            //r adalah jarak antara sendi atas dengan sendi bawah (bukan seluruhnya melainkan r mulai dari sendi atas sampai sendi bawah)
            // - arm.sizeBox.Z karena untuk ngepas kan posisi dengan sendinya.
            // yang dicari adalah letak sendi, bukan ujung lengan, tidak di bagi 2f karena 1 untuk sendi
            float r = arm.sizeBox.Y - arm.sizeBox.Z;


            //initial pos adalah titik sendi atas arm.
            Vector3 initialPos = new Vector3(arm._position.X, arm._position.Y + arm.sizeBox.Y / 2f - arm.sizeBox.Z / 2f, arm._position.Z);
            //float 
            //z = x
            //y = y

            //mencari posisi titik sendi bawah arm.
            float z = initialPos.Z - (r * (float)Math.Sin(MathHelper.DegreesToRadians(armDeg)));
            float y = initialPos.Y - (r * (float)Math.Cos(MathHelper.DegreesToRadians(-armDeg)));

            //set posisi forearm menjadi posisi titik sendi bawah arm dengan offset y yaitu setengah dari size foream arm y

            var temp = forearm._transform;
            forearm.setPosition(new Vector3(initialPos.X, y - forearm.sizeBox.Y / 2f + forearm.sizeBox.Z / 2f, z));
            //forearm.setPosition(new Vector3(arm._position.X,y-forearm.sizeBox.Y/2f,z));
            forearm.createBoxVertices();
            forearm.setupObject();
            forearm._transform = Matrix4.Identity;

            //forearm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-forearmDeg));

            forearm._transform *= Matrix4.CreateTranslation(-forearm._position.X, -forearm._position.Y - forearm.sizeBox.Y / 2f + forearm.sizeBox.Z / 2f, -forearm._position.Z);
            forearm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(forearmDeg));
            forearm._transform *= Matrix4.CreateTranslation(forearm._position.X, forearm._position.Y + forearm.sizeBox.Y / 2f - forearm.sizeBox.Z / 2f, forearm._position.Z);

            forearm._transform *= Matrix4.CreateTranslation(Global.translate);
            forearm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            forearm._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            forearm._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));

            r = forearm.sizeBox.Y;
            initialPos = new Vector3(forearm._position.X, forearm._position.Y + forearm.sizeBox.Y / 2f - forearm.sizeBox.Z / 2f, forearm._position.Z);
            z = initialPos.Z - (r * (float)Math.Sin(MathHelper.DegreesToRadians(forearmDeg)));
            y = initialPos.Y - (r * (float)Math.Cos(MathHelper.DegreesToRadians(-forearmDeg)));

            palm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-Global.angle.X));
            palm._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(-Global.angle.Y));
            palm._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-Global.angle.Z));

            palm.setPosition(new Vector3(initialPos.X, y - palm.sizeBox.Y / 2f + palm.sizeBox.Z / 2f, z));

            palm.createBoxVertices();
            palm.setupObject();

            palm._transform *= Matrix4.CreateTranslation(new Vector3(-palm._position.X, -palm._position.Y - palm.sizeBox.Y / 2f + palm.sizeBox.Z / 2f, -palm._position.Z));
            palm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(palmDeg));
            palm._transform *= Matrix4.CreateTranslation(new Vector3(palm._position.X, palm._position.Y + palm.sizeBox.Y / 2f - palm.sizeBox.Z / 2f, palm._position.Z));


            palm._transform *= Matrix4.CreateTranslation(Global.translate);
            palm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Global.angle.X));
            palm._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Global.angle.Y));
            palm._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Global.angle.Z));
        }
        public void RotateArm(float degX)
        {
            armDeg = degX;
            //Rotating ARM first
            arm._transform *= Matrix4.CreateTranslation(new Vector3(-arm._position.X, -arm._position.Y - arm.sizeBox.Y / 2f + arm.sizeBox.Z / 2f, -arm._position.Z));

            arm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));

            arm._transform *= Matrix4.CreateTranslation(new Vector3(arm._position.X, arm._position.Y + arm.sizeBox.Y / 2f - arm.sizeBox.Z / 2f, arm._position.Z));

            //r adalah jarak antara sendi atas dengan sendi bawah (bukan seluruhnya melainkan r mulai dari sendi atas sampai sendi bawah)
            // - arm.sizeBox.Z karena untuk ngepas kan posisi dengan sendinya.
            // yang dicari adalah letak sendi, bukan ujung lengan, tidak di bagi 2f karena 1 untuk sendi
            float r = arm.sizeBox.Y - arm.sizeBox.Z;


            //initial pos adalah titik sendi atas arm.
            Vector3 initialPos = new Vector3(arm._position.X, arm._position.Y + arm.sizeBox.Y / 2f - arm.sizeBox.Z / 2f, arm._position.Z);
            //float 
            //z = x
            //y = y

            //mencari posisi titik sendi bawah arm.
            float z = initialPos.Z - (r * (float)Math.Sin(MathHelper.DegreesToRadians(degX)));
            float y = initialPos.Y - (r * (float)Math.Cos(MathHelper.DegreesToRadians(-degX)));

            //set posisi forearm menjadi posisi titik sendi bawah arm dengan offset y yaitu setengah dari size foream arm y
            forearm.setPosition(new Vector3(initialPos.X, y - forearm.sizeBox.Y / 2f + forearm.sizeBox.Z / 2f, z));
            //forearm.setPosition(new Vector3(arm._position.X,y-forearm.sizeBox.Y/2f,z));
            forearm.createBoxVertices();
            forearm.setupObject();

            r = forearm.sizeBox.Y;
            initialPos = new Vector3(forearm._position.X, arm._position.Y + forearm.sizeBox.Y / 2f - palm.sizeBox.Z / 2f, forearm._position.Z);
            z = initialPos.Z - (r * (float)Math.Sin(MathHelper.DegreesToRadians(forearmDeg)));
            y = initialPos.Y - (r * (float)Math.Cos(MathHelper.DegreesToRadians(forearmDeg)));


            palm.setPosition(new Vector3(initialPos.X, y - palm.sizeBox.Y / 2f, z));
            palm.createBoxVertices();
            palm.setupObject();

            //forearm.setPosition(new Vector3(arm));

        }

        public void RotateForeArm(float degX)
        {
            forearmDeg = degX;

            forearm._transform *= Matrix4.CreateTranslation(new Vector3(-forearm._position.X, -forearm._position.Y - forearm.sizeBox.Y / 2f + forearm.sizeBox.X / 2f, -forearm._position.Z));
            Console.WriteLine("sendi forem arm pos: ");
            Console.WriteLine(new Vector3(forearm._position.X, forearm._position.Y + forearm.sizeBox.Z / 2f, forearm._position.Z));
            forearm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));

            forearm._transform *= Matrix4.CreateTranslation(new Vector3(forearm._position.X, forearm._position.Y + forearm.sizeBox.Y / 2f - forearm.sizeBox.X / 2f, forearm._position.Z));

            Vector3 initialPos;
            float r;
            float z, y;
            r = forearm.sizeBox.Y - forearm.sizeBox.Z;
            initialPos = new Vector3(forearm._position.X, forearm._position.Y + forearm.sizeBox.Z / 2f, forearm._position.Z);
            Console.WriteLine("sendi forearm bawah pos: ");
            Console.WriteLine(new Vector3(forearm._position.X, forearm._position.Y - forearm.sizeBox.Y / 2f, forearm._position.Z));
            //Console.WriteLine(initialPos);
            z = initialPos.Z - (r * (float)Math.Sin(MathHelper.DegreesToRadians(forearmDeg)));
            y = initialPos.Y - (r * (float)Math.Cos(MathHelper.DegreesToRadians(-forearmDeg)));
            Console.WriteLine("Sendi bawah forearm setelah di rotate: ");
            Console.WriteLine(new Vector3(initialPos.X, y, z));
            //Console.WriteLine("Radius y");

            //Console.WriteLine((r * (float)Math.Cos(MathHelper.DegreesToRadians(forearmDeg))));
            palm.setPosition(new Vector3(initialPos.X, y - palm.sizeBox.Z / 2f, z));
            palm.createBoxVertices();
            palm.setupObject();
        }
        public void Rotate(float degX, float degY, float degZ)
        {
            Console.WriteLine("Before Rotate: ");
            Console.WriteLine(arm._transform.ExtractRotation());
            arm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            arm._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            arm._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));


            forearm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            forearm._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            forearm._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));

            palm._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degX));
            palm._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degY));
            palm._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degZ));
        }
        //TP = Triangle Prism
        public void create()
        {
            //furOuter.createTrianglePrism();
            //furOuter.setupObject();

            arm.createBoxVertices();
            arm.setupObject();

            forearm.createBoxVertices();
            forearm.setupObject();

            palm.createBoxVertices();
            palm.setupObject();
        }
        public Vector3 position = new Vector3(0, 0, 0);
        //anchor points ada di ujung kaki yang nempel di body
        public void setPosition(Vector3 pos)
        {
            position = pos;
            //0.15f, 0.15f, 0.4f
            //arm.setPosition(new Vector3(0f-0.15f/2f-arm.sizeBox.X/2f,0f-0.15f/2f+arm.sizeBox.Y/2f,));
            arm.setPosition(new Vector3(pos.X, pos.Y - arm.sizeBox.Y / 2f, pos.Z));

            forearm.setPosition(new Vector3(arm._position.X, arm._position.Y - arm.sizeBox.Y / 2f - forearm.sizeBox.Y / 2f + arm.sizeBox.Z / 2f + forearm.sizeBox.Z / 4f, pos.Z));

            palm.setPosition(new Vector3(forearm._position.X, forearm._position.Y - forearm.sizeBox.Y / 2f - palm.sizeBox.Y / 2f, forearm._position.Z));
            //furInner.setPosition(new Vector3(0f,0f,0f));
            //Console.WriteLine("fur inner position: ")
        }

        public void render()
        {
            arm.render();
            forearm.render();
            palm.render();
        }
    }
}
