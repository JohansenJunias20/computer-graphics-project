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

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            johansen.update();

            //Alfons.TranslateX(translateX);
            base.OnUpdateFrame(args);
        }
    }
}
