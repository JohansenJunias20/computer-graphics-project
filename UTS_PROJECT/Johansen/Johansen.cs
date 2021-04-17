using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using System.Drawing.Imaging;
using System.Drawing;
using OpenTK.Mathematics;
using UTS_PROJECT.Johansen;
using UTS_PROJECT.Johansen.Feets;

namespace UTS_PROJECT
{
    class JohansenProps
    {
        //Mesh wing;
        public Head head;
        public neck neck;
        public body body;
        public wings wings;
        public front feetsFront;
        public Back feetsBack;
        public Johansen.Tails.Tail tail;
        public Element element;
        //feets.bac
        public JohansenProps()
        {
        }

        public void Load()
        {
            GL.ClearColor(0.1f, 0.5f, 0.3f, 1f);
            //GL.Enable(EnableCap.LIG)
            //face = new Mesh();
            //face.createBoxVertices();
            //face.setupObject();
            //wing = new Mesh();
            //wing.createTrapezoidPrism(new OpenTK.Mathematics.Vector3(0f, 0f, 0f), 1f, 0.3f, 0.6f, 0.2f);
            //wing.setupObject();



            neck = new neck(5);
            neck.setSize(new Vector3(0.08f, 0.08f, 0.08f * 5f));

            // 0 adalah titik awal z kemudian di minus 0.08f*5 karena panjang Z total dari nect kemudian di x setengah karena posisi z harus ditengah2
            // 0.1f*0.5f adalah jarak setengah dari kepala
            neck.setPostion(new Vector3(0f, 0f, 0 + 0.05f + 0.08f * 5f * 0.5f));
            neck.create();
            for (int i = 0; i < 5; i++)
            {
                neck.node[i].fur.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\fur\shader.vert", 
                    @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\fur\shader.frag");
            }

            tail = new Johansen.Tails.Tail();

            tail.setSize(new Vector3(0.08f, 0.08f, 0.08f * 12f));
            tail.setPostion(new Vector3(0f, 0f, 0 + 0.05f + 0.4f + 0.08f * 12f * 0.5f + 0.08f * 5f));
            tail.create();
            for (int i = 0; i < 12; i++)
            {
                tail.node[i].fur.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\fur\shader.vert",
                    @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\fur\shader.frag");
            }


            body = new body();
            Vector3 np = new Vector3(neck.position);
            body.setSize(new Vector3(0.15f, 0.15f, 0.4f));
            body.setPostion(new Vector3(np.X,np.Y, np.Z+neck.size.Z/2f + body.size.Z));
          


            body.fur[0].setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\fur\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\fur\shader.frag"); 
            body.fur[1].setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\fur\shader.vert",
                 @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\fur\shader.frag");
            body.fur[2].setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\fur\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\fur\shader.frag");
            body.block.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\Body\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\Body\shader.frag");
            body.create();

          


            feetsFront = new Johansen.Feets.front();
            feetsFront.left.arm.setSize(new Vector3(0.06f,0.17f,0.05f));
            feetsFront.left.forearm.setSize(new Vector3(0.05f,0.15f,0.045f));
            feetsFront.left.palm.setSize(new Vector3(0.06f,0.1f,0.03f));
            feetsFront.right.arm.setSize(new Vector3(0.06f, 0.17f, 0.05f));
            feetsFront.right.forearm.setSize(new Vector3(0.05f, 0.15f, 0.045f));
            feetsFront.right.palm.setSize(new Vector3(0.06f, 0.1f, 0.03f));
            feetsFront.setPosition(new Vector3(body.block._position.X, body.block._position.Y - body.block.sizeBox.Y / 2f + feetsFront.left.arm.sizeBox.Z,
                body.block._position.Z - body.block.sizeBox.Z / 2f+feetsFront.left.arm.sizeBox.Z/2f+0.04f));
            feetsFront.left.arm.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\arm\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\arm\shader.frag");
            feetsFront.left.forearm.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\forearm\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\forearm\shader.frag");
            feetsFront.right.arm.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\arm\shader.vert",
               @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\arm\shader.frag");
            feetsFront.right.forearm.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\forearm\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\forearm\shader.frag");
            feetsFront.create();

            feetsBack = new Back();
            feetsBack.left.arm.setSize(new Vector3(0.07f, 0.2f,0.07f));
            feetsBack.left.forearm.setSize(new Vector3(0.075f, 0.2f,0.06f));
            feetsBack.left.palm.setSize(new Vector3(0.06f,0.12f,0.04f));

            feetsBack.right.arm.setSize(new Vector3(0.07f, 0.2f, 0.07f));
            feetsBack.right.forearm.setSize(new Vector3(0.075f, 0.2f, 0.06f));
            feetsBack.right.palm.setSize(new Vector3(0.06f, 0.12f, 0.04f));

            feetsBack.setPosition(new Vector3(body.block._position.X, body.block._position.Y - body.block.sizeBox.Y / 4f + feetsBack.left.arm.sizeBox.Z,
                body.block._position.Z + body.block.sizeBox.Z / 2f - feetsBack.left.arm.sizeBox.Z / 2f - 0.04f));
            feetsBack.left.arm.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\arm\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\arm\shader.frag");
            feetsBack.left.forearm.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\forearm\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\forearm\shader.frag");
            feetsBack.right.arm.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\arm\shader.vert",
               @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\arm\shader.frag");
            feetsBack.right.forearm.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\forearm\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\feets\forearm\shader.frag");
            feetsBack.create();


            wings = new wings();
            wings.left.innerBone.setSize(new Vector3(0.4f,0.05f,0.05f));
            wings.left.outerBone.setSize(new Vector3(0.4f,0.025f,0.025f));
            wings.left.innerBone.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\wings\bone\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\wings\bone\shader.frag");
            wings.left.outerBone.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\wings\bone\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\wings\bone\shader.frag");
            wings.left.furInner.setTPsize(0.01f,0.4f,wings.left.innerBone.sizeBox.X);
            wings.left.furOuter.setTPsize(0.01f, 0.4f,wings.left.innerBone.sizeBox.X);

            wings.right.innerBone.setSize(new Vector3(0.4f, 0.05f, 0.05f));
            wings.right.outerBone.setSize(new Vector3(0.4f, 0.025f, 0.025f));
            wings.right.innerBone.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\wings\bone\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\wings\bone\shader.frag");
            wings.right.outerBone.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\wings\bone\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\wings\bone\shader.frag");
            wings.right.furInner.setTPsize(0.01f, 0.4f, wings.right.innerBone.sizeBox.X);
            wings.right.furOuter.setTPsize(0.01f, 0.4f, wings.right.innerBone.sizeBox.X);
            wings.setPosition(new Vector3(body.block._position.X, body.block._position.Y+body.block.sizeBox.Y/2f - wings.left.innerBone.sizeBox.Y/2f, body.block._position.Z - body.block.sizeBox.Z / 4f));
            wings.create();


            head = new Head();
            head.setSize(new Vector3(0.1f, 0.1f, 0.1f));
            head.setPosition(new OpenTK.Mathematics.Vector3(0f, 0f, 0f));
            head.create();
            head.eyes.left.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\default\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\eyes\shader.frag");
            head.eyes.right.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\eyes\shader.vert",
                 @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\eyes\shader.frag");
            //head.mouth.atas.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\mouth\shader.vert",
            //    @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\mouth\shader.frag");
            head.mouth.bawah.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\mouth\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\mouth\shader.frag");

            head.ears.left.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\ears\shader.vert",
                @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\ears\shader.frag");
            head.ears.right.setShaderPath(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\ears\shader.vert",
               @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Johansen\Shaders\ears\shader.frag");

            //float speed = 1.5f;


            element = new Element();
            element.node.radius = new Vector3(0.02f, 0.02f,0.02f);
            element.setRadius(new Vector3(0.3f,0.3f,0.3f));
            element.setPosition(new Vector3( head.kepala._position.X,head.kepala._position.Y,head.kepala._position.Z - head.kepala.sizeBox.Z - head.mouth.size.Z));
            element.create();

            Translate(Global.translate);
            head.Rotate(Global.angle.X, Global.angle.Y, Global.angle.Z);
            neck.Rotate(Global.angle.X, Global.angle.Y, Global.angle.Z);
            body.Rotate(Global.angle.X, Global.angle.Y, Global.angle.Z);
            tail.Rotate(Global.angle.X, Global.angle.Y, Global.angle.Z);


        }
        public void Translate(Vector3 t)
        {
            head.Translate(t);
            neck.Translate(t);
            body.Translate(t);
            tail.Translate(t);
        }
        bool translated = false;
        public void render()
        {
            //head.Rotate(0f, 90f, 0f);
            //GL.DepthMask(true);
            //wing.render();

            //head.Rotate(-0.01f, -0.01f, 0f);
            //neck.Rotate(-0.01f, -0.01f, 0f);
            //body.Rotate(-0.01f, -0.01f, 0f);
            //wings.Rotate(-0.01f, -0.01f, 0f);
            //feetsFront.Rotate(-0.01f, -0.01f, 0f);
            //feetsBack.Rotate(-0.01f, -0.01f, 0f);
            //tail.Rotate(-0.01f, -0.01f, 0f);
            //element.Rotate(-0.01f, -0.01f, 0f);
            //element.Rotate(-0.01f, -0.01f, 0f);
            //head.kepala.setPosition(new Vector3(0f, 0f, 0f));
            //head.eyes.setPostion(new Vector3(0f, 0f, positionZeyes));
            //positionZeyes -= 0.00001f;
            //element.Rotate(30f, 0f, 12f);
            //element.clearRotationView();
            //body.clearRotationView();
            //element.Animate();
            //element.Rotate(90f, 45f, 0f);
            //feetsFront.left.RotateArm(0.01f);


            head.render();
            neck.render();
            body.render();
            wings.render();
            feetsFront.render();
            feetsBack.render();
            tail.render();
            element.render();


        }

        public void update()
        {

            feetsBack.left.Animate();
            feetsBack.right.Animate();
            feetsFront.left.Animate();
            feetsFront.right.Animate();
            wings.right.Animate();
            //element.Animate();
            wings.left.Animate();
            head.Animate();
            element.Animate();
            tail.Animate();
            body.Animate();
            neck.Animate();
            //head.Rotate(-0.05f, 0f, 0f);
            //neck.Rotate(-0.05f, 0f, 0f);
            //body.Rotate(-0.05f, 0f, 0f);
            //wings.Rotate(-0.05f, 0f, 0f);
            //feetsFront.Rotate(-0.05f, 0f, 0f);
            //feetsBack.Rotate(-0.05f, 0f, 0f);
            //tail.Rotate(-0.05f, 0f, 0f);
            //head.setTemptoTransform();
            //head.mouth.openAt(-45f);
            //head.mouth.bawah._transform *= Matrix4.CreateTranslation(new Vector3(0f, 0.001f, 0f));
            //head.saveTransformtoTemp();
            //head.eyes
            //head.eyes.Rotate(0.1f, 0.0f, 0.0f);

            //head.Rotate(0.01f, 0.0f, 0f);
            //head.update();
            //Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fov), AspectRatio, 0.01f, 100f);
        }
    }
}
