using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using System.Drawing.Imaging;
using System.Drawing;
using OpenTK.Mathematics;

namespace UTS_PROJECT
{
    class Window : GameWindow
    {

        JohansenProps johansen;
        AlfonsProps alfons;
        JustinProps justin;
        float translateX = 0.01f;
        float maxTranslateX = 1f;
        float minTranslateX = -1f;
        float currentTranslate = 0f;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            johansen = new JohansenProps();
            alfons = new AlfonsProps();
            justin = new JustinProps();
        }

        protected override void OnLoad()
        {
            GL.ClearColor(0.1f, 0.5f, 0.3f, 1f);
            johansen.Load();
            alfons.load();
            justin.load();
            base.OnLoad();
        }
        void Translate(Vector3 t)
        {

        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            //head.Rotate(0f, 90f, 0f);

            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            justin.render();
            alfons.render();
            johansen.render();
            SwapBuffers();
            base.OnRenderFrame(args);
        }
        Vector3 offsetCannon = new Vector3(-0.55f, -0.2f, -0.25f);
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
        }
        float duriDeg = 0f;
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            johansen.update();
            Vector3 positionFeetDragon =  johansen.feetsFront.left.palm._position;
            positionFeetDragon.X -= justin.tongkat.sizeBox.X / 2f * 0.2f;
            justin.tongkat.setPosition(positionFeetDragon);
            justin.tongkat.createBoxVertices();
            justin.tongkat.setupObject();
            justin.tongkat._transform *= Matrix4.CreateTranslation(-positionFeetDragon.X, -positionFeetDragon.Y, -positionFeetDragon.Z);
            justin.tongkat._transform *= Matrix4.CreateScale(0.2f);
            justin.tongkat._transform *= Matrix4.CreateTranslation(positionFeetDragon);
            justin.tongkat._transform *= Matrix4.CreateTranslation(Johansen.Global.translate);

            justin.tongkat._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.X));
            justin.tongkat._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Y));
            justin.tongkat._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Z));


            #region temporary
            //justin.tongkat._transform = Matrix4.Identity;
            //justin.tongkat._transform *= Matrix4.CreateTranslation(-justin.tongkat._position.X, -justin.tongkat._position.Y, -justin.tongkat._position.Z);
            //justin.tongkat._transform *= Matrix4.CreateScale(0.2f);
            //justin.tongkat._transform *= Matrix4.CreateTranslation(justin.tongkat._position);
            //justin.tongkat._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90f));
            #endregion

            //0.0f, - 0.8f, 0.0f
            justin.cannon_1._transform = Matrix4.Identity;
            justin.cannon_1._transform *= Matrix4.CreateTranslation(offsetCannon);
            justin.cannon_1._transform *= Matrix4.CreateTranslation(positionFeetDragon);
            justin.cannon_1._transform *= Matrix4.CreateTranslation(Johansen.Global.translate);


            justin.cannon_1._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.X));
            justin.cannon_1._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Y));
            justin.cannon_1._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Z));


            #region tali reset transform
            //1. reset transform
            justin.tali._transform = Matrix4.Identity;
            justin.tali._transform *= Matrix4.CreateTranslation(new Vector3(-justin.tali._position.X, -justin.tali._position.Y, -justin.tali._position.Z));
            justin.tali._transform *= Matrix4.CreateScale(new Vector3(0.25f, 0.25f, 0.25f));
            justin.tali._transform *= Matrix4.CreateTranslation(justin.tali._position);
            justin.tali._transform *= Matrix4.CreateTranslation(positionFeetDragon);
            justin.tali._transform *= Matrix4.CreateTranslation(-0.15f, -0.05f, -0.5f);
            //justin.tali._transform *= Matrix4.CreateTranslation(positionFeetDragon);
            //justin.tali._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(180f));
            //justin.tali._transform *= Matrix4.CreateTranslation(Johansen.Global.translate);

            //2. Translate posisi tali ke positionfeetDragon
            //3. Translate (dicoba-coba)
            //justin.tali._transform *= Matrix4.CreateTranslation(offsetCannon);
            justin.tali._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.X));
            justin.tali._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Y));
            justin.tali._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Z));

            #endregion

            #region reseting transform
            justin.duri._transform = Matrix4.Identity;
            justin.duri1._transform = Matrix4.Identity;
            justin.duri2._transform = Matrix4.Identity;
            justin.duri3._transform = Matrix4.Identity;
            justin.duri4._transform = Matrix4.Identity;
            justin.duri5._transform = Matrix4.Identity;
            #endregion




            #region rotate each duri to its position

            justin.duri1._transform *= Matrix4.CreateTranslation(new Vector3(-justin.duri1._position.X, -justin.duri1._position.Y, -justin.duri1._position.Z));
            justin.duri1._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90));
            justin.duri1._transform *= Matrix4.CreateTranslation(new Vector3(justin.duri1._position.X, justin.duri1._position.Y, justin.duri1._position.Z));

            justin.duri2._transform *= Matrix4.CreateTranslation(new Vector3(-justin.duri2._position.X, -justin.duri2._position.Y, -justin.duri2._position.Z));
            justin.duri2._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(270));
            justin.duri2._transform *= Matrix4.CreateTranslation(new Vector3(justin.duri2._position.X, justin.duri2._position.Y, justin.duri2._position.Z));

            justin.duri3._transform *= Matrix4.CreateTranslation(new Vector3(-justin.duri3._position.X, -justin.duri3._position.Y, -justin.duri3._position.Z));
            justin.duri3._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180));
            justin.duri3._transform *= Matrix4.CreateTranslation(new Vector3(justin.duri3._position.X, justin.duri3._position.Y, justin.duri3._position.Z));

            justin.duri4._transform *= Matrix4.CreateTranslation(new Vector3(-justin.duri4._position.X, -justin.duri4._position.Y, -justin.duri4._position.Z));
            justin.duri4._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90));
            justin.duri4._transform *= Matrix4.CreateTranslation(new Vector3(justin.duri4._position.X, justin.duri4._position.Y, justin.duri4._position.Z));

            justin.duri5._transform *= Matrix4.CreateTranslation(new Vector3(-justin.duri5._position.X, -justin.duri5._position.Y, -justin.duri5._position.Z));
            justin.duri5._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(270));
            justin.duri5._transform *= Matrix4.CreateTranslation(new Vector3(justin.duri5._position.X, justin.duri5._position.Y, justin.duri5._position.Z));
            #endregion


            #region scaling Duri to 0.2f and rotate by axis cannon
            justin.duri._transform *= Matrix4.CreateTranslation(-justin.duri._position.X, -justin.duri._position.Y, -justin.duri._position.Z);
            justin.duri._transform *= Matrix4.CreateScale(0.25f);
            justin.duri._transform *= Matrix4.CreateTranslation(justin.duri._position.X, justin.duri._position.Y, justin.duri._position.Z);
            //setelah scale baru rotate (duri selanjutnya juga sama)
            justin.duri._transform *= Matrix4.CreateTranslation(-justin.duri._position.X, -justin.duri._position.Y + justin.cannon_1.radius.X/2f, -justin.duri._position.Z);
            justin.duri._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(duriDeg));
            justin.duri._transform *= Matrix4.CreateTranslation(justin.duri._position.X, justin.duri._position.Y - justin.cannon_1.radius.X / 2f, justin.duri._position.Z);


            justin.duri1._transform *= Matrix4.CreateTranslation(-justin.duri1._position.X, -justin.duri1._position.Y, -justin.duri1._position.Z);
            justin.duri1._transform *= Matrix4.CreateScale(0.25f);
            justin.duri1._transform *= Matrix4.CreateTranslation(justin.duri1._position.X, justin.duri1._position.Y, justin.duri1._position.Z);
            //setelah scale baru rotate (duri selanjutnya juga sama)
            justin.duri1._transform *= Matrix4.CreateTranslation(-justin.duri1._position.X - justin.cannon_1.radius.X / 2f, -justin.duri1._position.Y , -justin.duri1._position.Z);
            justin.duri1._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(duriDeg));
            justin.duri1._transform *= Matrix4.CreateTranslation(justin.duri1._position.X + justin.cannon_1.radius.X / 2f, justin.duri1._position.Y, justin.duri1._position.Z);


            justin.duri2._transform *= Matrix4.CreateTranslation(-justin.duri2._position.X, -justin.duri2._position.Y, justin.duri2._position.Z);
            justin.duri2._transform *= Matrix4.CreateScale(0.25f);
            justin.duri2._transform *= Matrix4.CreateTranslation(justin.duri2._position.X, justin.duri2._position.Y, justin.duri2._position.Z);
            //setelah scale baru rotate (duri selanjutnya juga sama)
            justin.duri2._transform *= Matrix4.CreateTranslation(-justin.duri2._position.X + justin.cannon_1.radius.X / 2f, -justin.duri2._position.Y  , -justin.duri2._position.Z);
            justin.duri2._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(duriDeg));
            justin.duri2._transform *= Matrix4.CreateTranslation(justin.duri2._position.X - justin.cannon_1.radius.X / 2f, justin.duri2._position.Y , justin.duri2._position.Z);


            justin.duri3._transform *= Matrix4.CreateTranslation(-justin.duri3._position.X, -justin.duri3._position.Y, -justin.duri3._position.Z);
            justin.duri3._transform *= Matrix4.CreateScale(0.25f);
            justin.duri3._transform *= Matrix4.CreateTranslation(justin.duri3._position.X, justin.duri3._position.Y, justin.duri3._position.Z);
            //setelah scale baru rotate (duri selanjutnya juga sama)
            justin.duri3._transform *= Matrix4.CreateTranslation(-justin.duri3._position.X, -justin.duri3._position.Y - justin.cannon_1.radius.X / 2f, -justin.duri3._position.Z);
            justin.duri3._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(duriDeg));
            justin.duri3._transform *= Matrix4.CreateTranslation(justin.duri._position.X, justin.duri3._position.Y + justin.cannon_1.radius.X / 2f, justin.duri3._position.Z);


            justin.duri4._transform *= Matrix4.CreateTranslation(-justin.duri4._position.X, -justin.duri4._position.Y, -justin.duri4._position.Z );
            justin.duri4._transform *= Matrix4.CreateScale(0.25f);
            justin.duri4._transform *= Matrix4.CreateTranslation(justin.duri4._position.X, justin.duri4._position.Y, justin.duri4._position.Z );
            //setelah scale baru rotate (duri selanjutnya juga sama)
            justin.duri4._transform *= Matrix4.CreateTranslation(-justin.duri4._position.X, -justin.duri4._position.Y, -justin.duri4._position.Z + justin.cannon_1.radius.X / 2f);
            justin.duri4._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(duriDeg));
            justin.duri4._transform *= Matrix4.CreateTranslation(justin.duri4._position.X, justin.duri4._position.Y , justin.duri4._position.Z - justin.cannon_1.radius.X / 2f);


            justin.duri5._transform *= Matrix4.CreateTranslation(-justin.duri5._position.X, -justin.duri5._position.Y, -justin.duri5._position.Z);
            justin.duri5._transform *= Matrix4.CreateScale(0.25f);
            justin.duri5._transform *= Matrix4.CreateTranslation(justin.duri5._position.X, justin.duri5._position.Y, justin.duri5._position.Z);
            //setelah scale baru rotate (duri selanjutnya juga sama)
            justin.duri5._transform *= Matrix4.CreateTranslation(-justin.duri5._position.X, -justin.duri5._position.Y, -justin.duri5._position.Z- justin.cannon_1.radius.X / 2f);
            justin.duri5._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(duriDeg));
            justin.duri5._transform *= Matrix4.CreateTranslation(justin.duri5._position.X, justin.duri5._position.Y, justin.duri5._position.Z + justin.cannon_1.radius.X / 2f);
            #endregion



            duriDeg += 0.1f;

            #region translate to cannon position with specific offset
            justin.duri._transform *= Matrix4.CreateTranslation(new Vector3(positionFeetDragon.X , positionFeetDragon.Y , positionFeetDragon.Z));
            justin.duri1._transform *= Matrix4.CreateTranslation(new Vector3(positionFeetDragon.X , positionFeetDragon.Y , positionFeetDragon.Z));
            justin.duri2._transform *= Matrix4.CreateTranslation(new Vector3(positionFeetDragon.X , positionFeetDragon.Y, positionFeetDragon.Z));
            justin.duri3._transform *= Matrix4.CreateTranslation(new Vector3(positionFeetDragon.X, positionFeetDragon.Y , positionFeetDragon.Z));
            justin.duri4._transform *= Matrix4.CreateTranslation(new Vector3(positionFeetDragon.X, positionFeetDragon.Y , positionFeetDragon.Z ));
            justin.duri5._transform *= Matrix4.CreateTranslation(new Vector3(positionFeetDragon.X, positionFeetDragon.Y, positionFeetDragon.Z ));



            justin.duri._transform *= Matrix4.CreateTranslation(offsetCannon);
            justin.duri1._transform *= Matrix4.CreateTranslation(offsetCannon);
            justin.duri2._transform *= Matrix4.CreateTranslation(offsetCannon);
            justin.duri3._transform *= Matrix4.CreateTranslation(offsetCannon);
            justin.duri4._transform *= Matrix4.CreateTranslation(offsetCannon);
            justin.duri5._transform *= Matrix4.CreateTranslation(offsetCannon);


            justin.duri._transform *= Matrix4.CreateTranslation(Johansen.Global.translate);
            justin.duri1._transform *= Matrix4.CreateTranslation(Johansen.Global.translate);
            justin.duri2._transform *= Matrix4.CreateTranslation(Johansen.Global.translate);
            justin.duri3._transform *= Matrix4.CreateTranslation(Johansen.Global.translate);
            justin.duri4._transform *= Matrix4.CreateTranslation(Johansen.Global.translate);
            justin.duri5._transform *= Matrix4.CreateTranslation(Johansen.Global.translate);


            #endregion



            #region follow the global angle
            justin.duri._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.X));
            justin.duri._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Y));
            justin.duri._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Z));


            justin.duri1._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.X));
            justin.duri1._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Y));
            justin.duri1._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Z));


            justin.duri2._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.X));
            justin.duri2._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Y));
            justin.duri2._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Z));


            justin.duri3._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.X));
            justin.duri3._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Y));
            justin.duri3._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Z));


            justin.duri4._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.X));
            justin.duri4._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Y));
            justin.duri4._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Z));

            justin.duri5._transform *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.X));
            justin.duri5._transform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Y));
            justin.duri5._transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(UTS_PROJECT.Johansen.Global.angle.Z));

            #endregion

            base.OnUpdateFrame(args);
        }
    }
}
