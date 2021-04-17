using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;
using UTS_PROJECT.Justin;

namespace UTS_PROJECT
{
    class JustinProps
    {
        public Mesh cannon_1;
        public Mesh duri, duri1;
        public Mesh duri2, duri3;
        public Mesh duri4, duri5;
        public Mesh tongkat;
        public Mesh tali;

        public JustinProps()
        {


        }
        public void load()
        {
            cannon_1 = new Mesh();
            duri = new Mesh();
            duri1 = new Mesh();
            duri2 = new Mesh();
            duri3 = new Mesh();
            duri4 = new Mesh();
            duri5 = new Mesh();
            tongkat = new Mesh();
            tali = new Mesh();

            tongkat.setPosition(new Vector3(0, 0, 0));
            cannon_1.setPosition(new Vector3(0.0f, 0f, 0.0f));
            tongkat.setSize(new Vector3(1.5f, 0.06f, 0.06f));
            tali.setPositionBezier(new Vector3(cannon_1._position.X + 0.0f, cannon_1._position.Y + -0.1f, cannon_1._position.Z + 0.0f));

            cannon_1.radius = new Vector3(0.05f, 0.05f, 0.05f);
            duri.setPosition(new Vector3(cannon_1._position.X + 0.0f, cannon_1._position.Y + cannon_1.radius.X/2f, cannon_1._position.Z + 0.0f));
            duri1.setPosition(new Vector3(cannon_1._position.X + -cannon_1.radius.X/2f, cannon_1._position.Y + 0.0f, cannon_1._position.Z + 0.0f));
            duri2.setPosition(new Vector3(cannon_1._position.X + cannon_1.radius.X/2f, cannon_1._position.Y + 0.0f, cannon_1._position.Z + 0.0f));
            duri3.setPosition(new Vector3(cannon_1._position.X + 0.0f, cannon_1._position.Y + -cannon_1.radius.X/2f, cannon_1._position.Z + 0.0f));
            duri4.setPosition(new Vector3(cannon_1._position.X + 0.0f, cannon_1._position.Y + 0.0f, cannon_1._position.Z + cannon_1.radius.X/2f));
            duri5.setPosition(new Vector3(cannon_1._position.X + 0.0f, cannon_1._position.Y + 0.0f, cannon_1._position.Z - cannon_1.radius.X/2f));

            duri.setShaderPath("C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.vert", "C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.frag");
            duri1.setShaderPath("C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.vert", "C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.frag");
            duri2.setShaderPath("C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.vert", "C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.frag");
            duri3.setShaderPath("C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.vert", "C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.frag");
            duri4.setShaderPath("C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.vert", "C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.frag");
            duri5.setShaderPath("C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.vert", "C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader1.frag");
            tongkat.setShaderPath("C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader2.vert", "C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader2.frag");
            tali.setShaderPath("C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader2.vert", "C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader2.frag");

            duri.createKerucut();
            duri1.createKerucut();
            duri2.createKerucut();
            duri3.createKerucut();
            duri4.createKerucut();
            duri5.createKerucut();
            tongkat.createBoxVertices();
            cannon_1.createBall();
            tali.createBezier(new Vector3(tali._position.X + 0.0f, tali._position.Y + 0.5f, tali._position.Z),
                new Vector3(tali._position.X + 0.5f, tali._position.Y + 0.5f, tali._position.Z),
                new Vector3(tali._position.X + 0.5f, tali._position.Y + 0.7f, tali._position.Z), 0.04f);

            duri.setupObject();
            duri1.setupObject();
            duri2.setupObject();
            duri3.setupObject();
            duri4.setupObject();
            duri5.setupObject();
            cannon_1.setupObject();
            tongkat.setupObject();
            tali.setupBezier();

            duri1._transform *= Matrix4.CreateTranslation(new Vector3(-duri1._position.X, -duri1._position.Y, -duri1._position.Z));
            duri1._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90));
            duri1._transform *= Matrix4.CreateTranslation(new Vector3(duri1._position.X, duri1._position.Y, duri1._position.Z));

            duri2._transform *= Matrix4.CreateTranslation(new Vector3(-duri2._position.X, -duri2._position.Y, -duri2._position.Z));
            duri2._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(270));
            duri2._transform *= Matrix4.CreateTranslation(new Vector3(duri2._position.X, duri2._position.Y, duri2._position.Z)); 

            duri3._transform *= Matrix4.CreateTranslation(new Vector3(-duri3._position.X, -duri3._position.Y, -duri3._position.Z));
            duri3._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180));
            duri3._transform *= Matrix4.CreateTranslation(new Vector3(duri3._position.X, duri3._position.Y, duri3._position.Z));

            duri4._transform *= Matrix4.CreateTranslation(new Vector3(-duri4._position.X, -duri4._position.Y, -duri4._position.Z));
            duri4._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90));
            duri4._transform *= Matrix4.CreateTranslation(new Vector3(duri4._position.X, duri4._position.Y, duri4._position.Z));

            duri5._transform *= Matrix4.CreateTranslation(new Vector3(-duri5._position.X, -duri5._position.Y, -duri5._position.Z));
            duri5._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(270));
            duri5._transform *= Matrix4.CreateTranslation(new Vector3(duri5._position.X, duri5._position.Y, duri5._position.Z));

            //cannon_1._transform *= Matrix4.CreateTranslation(new Vector3(-cannon_1._position.X, -cannon_1._position.Y, -cannon_1._position.Z));
            //cannon_1._transform *= Matrix4.CreateScale(new Vector3(0.25f, 0.25f, 0.25f));
            //cannon_1._transform *= Matrix4.CreateTranslation(new Vector3(cannon_1._position.X, cannon_1._position.Y, cannon_1._position.Z));

            duri._transform *= Matrix4.CreateTranslation(new Vector3(-duri._position.X, -duri._position.Y + 0.15f, -duri._position.Z));
            duri._transform *= Matrix4.CreateScale(new Vector3(0.25f, 0.25f, 0.25f));
            duri._transform *= Matrix4.CreateTranslation(new Vector3(duri._position.X, duri._position.Y - 0.15f, duri._position.Z));

            duri1._transform *= Matrix4.CreateTranslation(new Vector3(-duri1._position.X - 0.15f, -duri1._position.Y, -duri1._position.Z));
            duri1._transform *= Matrix4.CreateScale(new Vector3(0.25f, 0.25f, 0.25f));
            duri1._transform *= Matrix4.CreateTranslation(new Vector3(duri1._position.X + 0.15f, duri1._position.Y, duri1._position.Z));

            duri2._transform *= Matrix4.CreateTranslation(new Vector3(-duri2._position.X + 0.15f, -duri2._position.Y, -duri2._position.Z));
            duri2._transform *= Matrix4.CreateScale(new Vector3(0.25f, 0.25f, 0.25f));
            duri2._transform *= Matrix4.CreateTranslation(new Vector3(duri2._position.X - 0.15f, duri2._position.Y, duri2._position.Z));

            duri3._transform *= Matrix4.CreateTranslation(new Vector3(-duri3._position.X, -duri3._position.Y - 0.15f, -duri3._position.Z));
            duri3._transform *= Matrix4.CreateScale(new Vector3(0.25f, 0.25f, 0.25f));
            duri3._transform *= Matrix4.CreateTranslation(new Vector3(duri3._position.X, duri3._position.Y + 0.15f, duri3._position.Z));

            duri4._transform *= Matrix4.CreateTranslation(new Vector3(-duri4._position.X, -duri4._position.Y, -duri4._position.Z + 0.15f));
            duri4._transform *= Matrix4.CreateScale(new Vector3(0.25f, 0.25f, 0.25f));
            duri4._transform *= Matrix4.CreateTranslation(new Vector3(duri4._position.X, duri4._position.Y, duri4._position.Z - 0.15f));

            duri5._transform *= Matrix4.CreateTranslation(new Vector3(-duri5._position.X, -duri5._position.Y, -duri5._position.Z - 0.15f));
            duri5._transform *= Matrix4.CreateScale(new Vector3(0.25f, 0.25f, 0.25f));
            duri5._transform *= Matrix4.CreateTranslation(new Vector3(duri5._position.X, duri5._position.Y, duri5._position.Z + 0.15f));

            tongkat._transform *= Matrix4.CreateScale(new Vector3(0.25f, 0.25f, 0.25f));
            tali._transform *= Matrix4.CreateScale(new Vector3(0.25f, 0.25f, 0.25f));

        }

        public void render()
        {
            cannon_1._transform *= Matrix4.CreateTranslation(new Vector3(-cannon_1._position.X, -cannon_1._position.Y, -cannon_1._position.Z));
            cannon_1._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.3f));
            cannon_1._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.3f));
            cannon_1._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.3f));
            cannon_1._transform *= Matrix4.CreateTranslation(new Vector3(cannon_1._position.X, cannon_1._position.Y, cannon_1._position.Z));

            duri._transform *= Matrix4.CreateTranslation(new Vector3(-duri._position.X, -duri._position.Y + 0.15f, -duri._position.Z));
            duri._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.3f));
            duri._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.3f));
            duri._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.3f));
            duri._transform *= Matrix4.CreateTranslation(new Vector3(duri._position.X, duri._position.Y - 0.15f, duri._position.Z));

            duri1._transform *= Matrix4.CreateTranslation(new Vector3(-duri1._position.X - 0.15f, -duri1._position.Y, -duri1._position.Z));
            duri1._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.3f));
            duri1._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.3f));
            duri1._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.3f));
            duri1._transform *= Matrix4.CreateTranslation(new Vector3(duri1._position.X + 0.15f, duri1._position.Y, duri1._position.Z));

            duri2._transform *= Matrix4.CreateTranslation(new Vector3(-duri2._position.X + 0.15f, -duri2._position.Y, -duri2._position.Z));
            duri2._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.3f));
            duri2._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.3f));
            duri2._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.3f));
            duri2._transform *= Matrix4.CreateTranslation(new Vector3(duri2._position.X - 0.15f, duri2._position.Y, duri2._position.Z));

            duri3._transform *= Matrix4.CreateTranslation(new Vector3(-duri3._position.X, -duri3._position.Y - 0.15f, -duri3._position.Z));
            duri3._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.3f));
            duri3._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.3f));
            duri3._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.3f));
            duri3._transform *= Matrix4.CreateTranslation(new Vector3(duri3._position.X, duri3._position.Y + 0.15f, duri3._position.Z));

            duri4._transform *= Matrix4.CreateTranslation(new Vector3(-duri4._position.X, -duri4._position.Y, -duri4._position.Z + 0.15f));
            duri4._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.3f));
            duri4._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.3f));
            duri4._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.3f));
            duri4._transform *= Matrix4.CreateTranslation(new Vector3(duri4._position.X, duri4._position.Y, duri4._position.Z - 0.15f));

            duri5._transform *= Matrix4.CreateTranslation(new Vector3(-duri5._position.X, -duri5._position.Y, -duri5._position.Z - 0.15f));
            duri5._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.3f));
            duri5._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.3f));
            duri5._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.3f));
            duri5._transform *= Matrix4.CreateTranslation(new Vector3(duri5._position.X, duri5._position.Y, duri5._position.Z + 0.15f));

            duri.renderBezier();
            duri1.renderBezier();
            duri2.renderBezier();
            duri3.renderBezier();
            duri4.renderBezier();
            duri5.renderBezier();
            cannon_1.renderBezier();
            tongkat.render();
            tali.renderBezier();
            
        }

    }

}
