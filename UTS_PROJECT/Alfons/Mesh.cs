using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using System.IO;

namespace UTS_PROJECT.Alfons
{
    class Mesh
    {
        protected List<Vector3> vertices = new List<Vector3>();
        protected List<Vector3> texturevertices = new List<Vector3>();
        protected List<Vector3> normals = new List<Vector3>();
        protected List<uint> vertexindices = new List<uint>();
        protected int _vertexbufferobject;
        protected int _elementbufferobject;
        protected int _vertexarrayobject;
        Shader _shader;
        Matrix4 transform;

        public Mesh()
        {

        }

        public void createbezier(Vector3[] position, int banyaktitik)
        {
            for (float t = 0.0f; t <= 1.0f; t += 0.001f)
            {
                createbeziervertices(position, t, banyaktitik);
            }
        }

        public void createbeziervertices(Vector3[] position, float t, int banyaktitik)
        {
            int pangkat = banyaktitik - 1;
            float[] all = new float[banyaktitik];
            Vector3 temp_vector;
            temp_vector.X = 0.0f;
            temp_vector.Y = 0.0f;
            temp_vector.Z = 0.0f;
            for (int h = 0; h < banyaktitik; h++)
            {
                if (h == 0)
                {
                    all[h] = (float)Math.Pow((1 - t), pangkat);
                }
                else if (h == banyaktitik - 1)
                {
                    all[h] = (float)Math.Pow(t, h);
                }
                else
                {
                    int mouse_click_temp = banyaktitik - 1;
                    int h_temp = h;
                    int selisih = mouse_click_temp - h_temp;
                    int kombinasi = 1;
                    while (mouse_click_temp > 0)
                    {
                        kombinasi *= mouse_click_temp;
                        mouse_click_temp--;
                    }
                    while (h_temp > 0)
                    {
                        kombinasi /= h_temp;
                        h_temp--;
                    }
                    while (selisih > 0)
                    {
                        kombinasi /= selisih;
                        selisih--;
                    }
                    all[h] = kombinasi * (float)Math.Pow((1 - t), pangkat) * (float)Math.Pow(t, h);
                }
                pangkat--;
            }
            for (int h = 0; h < banyaktitik; h++)
            {
                float temp = all[h] * position[h].X;
                temp_vector.X += temp;
                temp = all[h] * position[h].Y;
                temp_vector.Y += temp;
                temp = all[h] * position[h].Z;
                temp_vector.Z += temp;
            }
            vertices.Add(temp_vector);
        }
        public void createboxvertices(float _positionX, float _positionY, float _positionZ, float _boxlength)
        {

            Vector3 temp_vector;

            //TITIK 1
            temp_vector.X = _positionX - _boxlength / 2.0f; //x
            temp_vector.Y = _positionY + _boxlength / 2.0f; //y
            temp_vector.Z = _positionZ - _boxlength / 2.0f; //z
            vertices.Add(temp_vector);
            //TITIK 2
            temp_vector.X = _positionX + _boxlength / 2.0f; //x
            temp_vector.Y = _positionY + _boxlength / 2.0f; //y
            temp_vector.Z = _positionZ - _boxlength / 2.0f; //z
            vertices.Add(temp_vector);

            //TITIK 3
            temp_vector.X = _positionX - _boxlength / 2.0f; //x
            temp_vector.Y = _positionY - _boxlength / 2.0f; //y
            temp_vector.Z = _positionZ - _boxlength / 2.0f; //z
            vertices.Add(temp_vector);

            //TITIK 4
            temp_vector.X = _positionX + _boxlength / 2.0f; //x
            temp_vector.Y = _positionY - _boxlength / 2.0f; //y
            temp_vector.Z = _positionZ - _boxlength / 2.0f; //z
            vertices.Add(temp_vector);

            //TITIK 5
            temp_vector.X = _positionX - _boxlength / 2.0f; //x
            temp_vector.Y = _positionY + _boxlength / 2.0f; //y
            temp_vector.Z = _positionZ + _boxlength / 2.0f; //z
            vertices.Add(temp_vector);

            //TITIK 6
            temp_vector.X = _positionX + _boxlength / 2.0f; //x
            temp_vector.Y = _positionY + _boxlength / 2.0f; //y
            temp_vector.Z = _positionZ + _boxlength / 2.0f; //z
            vertices.Add(temp_vector);

            //TITIK 7
            temp_vector.X = _positionX - _boxlength / 2.0f; //x
            temp_vector.Y = _positionY - _boxlength / 2.0f; //y
            temp_vector.Z = _positionZ + _boxlength / 2.0f; //z
            vertices.Add(temp_vector);

            //TITIK 8
            temp_vector.X = _positionX + _boxlength / 2.0f; //x
            temp_vector.Y = _positionY - _boxlength / 2.0f; //y
            temp_vector.Z = _positionZ + _boxlength / 2.0f; //z
            vertices.Add(temp_vector);

            vertexindices = new List<uint>
            {
                  //segitiga depan 1
            0,1,2,
            //segitiga depan 2
            1,2,3,
            //segitiga atas 1
            0,4,5,
            //segitiga atas 2
            0,1,5,
            //segitiga kanan 1
            1,3,5,
            //segitiga kanan 2
            3,5,7,
            //segitiga kiri 1
            0,2,4,
            //segitiga kiri 2
            2,4,6,
            //segitiga belakang 1
            4,5,6,
            //segitiga belakang 2
            5,6,7,
            //segitiga bawah 1
            2,3,6,
            //segitiga bawah 2
            3,6,7
            };
        }

        public void createellipsoidvertices(float positionX, float positionY, float positionZ, float radiusx, float radiusy, float radiusz)
        {
            float _pi = 3.14159f;

            Vector3 temp_vector;
            for (float u = -_pi; u <= _pi; u += _pi / 600)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 600)
                {
                    temp_vector.X = positionX + radiusx * (float)Math.Cos(v) * (float)Math.Cos(u); //x
                    temp_vector.Y = positionY + radiusy * (float)Math.Cos(v) * (float)Math.Sin(u); //y
                    temp_vector.Z = positionZ + radiusz * (float)Math.Sin(v); //z
                    vertices.Add(temp_vector);
                }
            }
        }

        public void createellipsoidsetengahvertices(float positionX, float positionY, float positionZ, float radiusx, float radiusy, float radiusz)
        {
            float _pi = 3.14159f;

            Vector3 temp_vector;
            for (float u = -_pi; u <= 0; u += _pi / 600)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 600)
                {
                    temp_vector.X = positionX + radiusx * (float)Math.Cos(v) * (float)Math.Cos(u); //x
                    temp_vector.Y = positionY + radiusy * (float)Math.Cos(v) * (float)Math.Sin(u); //y
                    temp_vector.Z = positionZ + radiusz * (float)Math.Sin(v); //z
                    vertices.Add(temp_vector);
                }
            }
        }


        public void createellipticvertices(float positionX, float positionY, float positionZ, float radiusX, float radiusY, float radiusZ)
        {

            float _pi = 3.14159f;
            Vector3 temp_vector;
            for (float u = -_pi; u < _pi; u += _pi / 600)
            {
                //Elliptic Cone
                //DIGANTI V < 0 BIAR 1 SISI AJA YANG KELUAR
                for (float v = -_pi / 2; v < 0; v += _pi / 600)
                {
                    temp_vector.X = v * (float)Math.Cos(u) * radiusX + positionX;
                    temp_vector.Y = v * (float)Math.Sin(u) * radiusY + positionY;
                    temp_vector.Z = v * radiusZ + positionZ;
                    vertices.Add(temp_vector);
                }
                ////Elliptic Paraboloid
                //for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                //{
                //    temp_vector.X = v * (float)Math.Cos(u) * radiusX + positionX;
                //    temp_vector.Y = v * (float)Math.Sin(u) * radiusY + positionY;
                //    temp_vector.Z = v * v + positionZ;
                //    vertices.Add(temp_vector);
                //}
            }
        }

        public void createhyperboloidvertices(float _positionX, float _positionY, float _positionZ, float _radiusX, float _radiusY, float _radiusZ)
        {
            float _pi = 3.14159f;

            Vector3 temp_vector;

            for (float u = -_pi; u <= _pi; u += _pi / 30)
            {
                //hyperboloid
                for (float v = -_pi / 2; v < 0; v += _pi / 30)
                {
                    temp_vector.X = _positionX + (1.0f / (float)Math.Cos(v)) * (float)Math.Cos(u) * _radiusX;
                    temp_vector.Y = _positionY + (1.0f / (float)Math.Cos(v)) * (float)Math.Sin(u) * _radiusY;
                    temp_vector.Z = _positionZ + (float)Math.Tan(v) * _radiusZ;
                    vertices.Add(temp_vector);
                }

                ////hyperboloid paraboloid
                //for (float v = 0; v < _pi / 2; v += _pi / 30)
                //{
                //    temp_vector.X = _positionX + v * (float)Math.Tan(u) * _radiusX;
                //    temp_vector.Y = _positionY + v * (1.0f / (float)Math.Cos(u)) * _radiusY;
                //    temp_vector.Z = _positionZ + v * v;
                //    vertices.Add(temp_vector);
                //}
            }
        }

        public void transforms()
        {
            transform = Matrix4.Identity;
        }
        public void vbo()
        {
            _vertexbufferobject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexbufferobject);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, vertices.Count * Vector3.SizeInBytes, vertices.ToArray(), BufferUsageHint.StaticDraw);
        }
        public void vao()
        {
            _vertexarrayobject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexarrayobject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }
        public void ebo()
        {
            _elementbufferobject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementbufferobject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, vertexindices.Count * sizeof(uint), vertexindices.ToArray(), BufferUsageHint.StaticDraw);
        }
        public void useshaders(string x, string y)
        {
            _shader = new Shader(x, y);
            _shader.Use();
        }


        public void rotate(float degree, char sumbu)
        {
            if (sumbu == 'x')
            {
                transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degree));
            }
            else if (sumbu == 'y')
            {
                transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degree));
            }
            if (sumbu == 'z')
            {
                transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degree));
            }
        }
        public void scale(float scale)
        {
            transform = transform * Matrix4.CreateScale(scale);
        }
        public void translate(float sumbux, float sumbuy, float sumbuz)
        {
            transform = transform * Matrix4.CreateTranslation(sumbux, sumbuy, sumbuz);
        }
        public void sumbux()
        {
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.9f));
        }
        public void sumbuy()
        {
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.9f));
        }
        public void sumbuz()
        {
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.9f));
        }



        public void render()
        {
            _shader.Use();
            //scale();
            _shader.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vertexarrayobject);

        }
        public void drawlines()
        {
            render();
            GL.DrawArrays(PrimitiveType.Lines, 0, vertices.Count);
        }
        public void drawtriangles()
        {
            render();
            GL.DrawElements(PrimitiveType.Triangles, vertexindices.Count, DrawElementsType.UnsignedInt, 0);
        }
        public void drawlinestrip()
        {
            render();
            GL.DrawArrays(PrimitiveType.LineStrip, 0, vertices.Count);
        }

    }
}
