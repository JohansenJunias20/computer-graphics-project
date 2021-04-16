using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using System.IO;
using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System.Drawing.Imaging;
using System.Drawing;

namespace UTS_PROJECT.Justin
{
    class Mesh
    {
        public Vector3 rotation;
        protected List<Vector3> vertices = new List<Vector3>();
        protected List<Vector3> textureVertices = new List<Vector3>();
        protected List<Vector3> normals = new List<Vector3>();
        protected List<uint> vertexIndices = new List<uint>();
        protected int _vertextBufferObject;
        protected int _elementBufferObject;
        protected int _vertexArrayObject;
        public Shader _shader;
        public Matrix4 _transform = Matrix4.Identity;
        public Vector3 _position;
        protected PrimitiveType _type;
        public Vector3 sizeBox = new Vector3(0.02f, 0.2f, 0.02f);
        public Vector3 radius;

        public Mesh(string vert = "none", string frag = "none", Vector3? position = null, PrimitiveType? type = null)
        {
            rotation = new Vector3(0f, 0f, 0f);
            _type = type ?? PrimitiveType.Lines;
            setPosition(position);
            setShaderPath(vert, frag);
        }

        public void setSize(Vector3 size)
        {
            sizeBox = size;
        }
        public void setPosition(Vector3? position)
        {
            _position = position ?? new Vector3(0f, 0f, 0f);
        }
        //a percepatan
        public void move(Vector3 target, float a)
        {
            _transform = _transform * Matrix4.CreateTranslation(new Vector3(0.001f, 0f, 0f));
        }
        public void setShaderPath(string vert = "none", string frag = "none")
        {
            _shader = new Shader(vert != "none" ? vert : "C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader.vert", frag != "none" ? frag : "C:\\Users\\c1419\\source\\repos\\UTS_PROJECT\\UTS_PROJECT\\Justin\\Shaders\\shader.frag");
        }
        int texture;
        bool isInit = false;
        public void setupObject()
        {
            //inisialisasi Transformasi
            _transform = Matrix4.Identity;

            if (isInit)
            {
                GL.DeleteVertexArray(_vertexArrayObject);
                GL.DeleteBuffer(_vertextBufferObject);
                GL.DeleteBuffer(_elementBufferObject);

            }
            isInit = true;
            //inisialisasi buffer
            _vertextBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertextBufferObject);
            //parameter 2 yg kita panggil vertices.Count == array.length
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                vertices.Count * Vector3.SizeInBytes,
                vertices.ToArray(),
                BufferUsageHint.StaticDraw);
            //inisialisasi array
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            //inisialisasi index vertex
            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            //parameter 2 dan 3 perlu dirubah
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                vertexIndices.Count * sizeof(uint),
                vertexIndices.ToArray(), BufferUsageHint.StaticDraw);
            _shader.Use();
        }
        public void rotateZ()
        {
            _transform = _transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.05f)) + Matrix4.CreateTranslation(_position);

        }
        public void rotateY()
        {
            _transform = (_transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.05f))) + Matrix4.CreateTranslation(_position);

        }
        public void createBall()
        {
            float _radiusX = radius.X;
            float _radiusY = radius.Y;
            vertices.Clear();
            float _radiusZ = radius.Z;
            _transform = Matrix4.Identity;
            float _pi = 3.141519f;
            for (float u = -_pi; u <= _pi; u += _pi / 600)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 600)
                {
                    Vector3 temp;
                    temp.X = _position.X + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u);
                    temp.Y = _position.Y + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u);
                    temp.Z = _position.Z + _radiusZ * (float)Math.Sin(v);
                    vertices.Add(temp);
                }
            }

            //VBO
            _vertextBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertextBufferObject);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, vertices.Count * Vector3.SizeInBytes, vertices.ToArray(), BufferUsageHint.StaticDraw);

            //VAO
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            _shader.Use();

        }
        public void createKerucut()
        {
            float x = _position.X;
            float z = _position.Z;
            float radius = 0.1f;
            for (float i = 0; i < 360; i += 0.5f)
            {
                Vector3 temp;
                float degInRad = i * 3.1416f / 180;
                temp.X = x + (float)Math.Cos(degInRad) * radius;
                temp.Y = _position.Y;
                temp.Z = z + (float)Math.Sin(degInRad) * radius;
                vertices.Add(temp);
                temp.X = _position.X;
                temp.Y = _position.Y + sizeBox.Y;
                temp.Z = _position.Z;
                vertices.Add(temp);
            }
        }
        public void createMeshfromObjFile(string path, Vector3 position)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
            }

            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    List<string> words = new List<string>(streamReader.ReadLine().ToLower().Split(' '));
                    words.RemoveAll(s => s == string.Empty);

                    if (words.Count == 0)
                        continue;
                    string type = words[0];
                    words.RemoveAt(0);

                    switch (type)
                    {
                        // vertex
                        case "v":
                            vertices.Add(new Vector3(float.Parse(words[0]) / 10, float.Parse(words[1]) / 10, float.Parse(words[2]) / 10));
                            break;

                        case "vt":
                            textureVertices.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]),
                                                            words.Count < 3 ? 0 : float.Parse(words[2])));
                            break;

                        case "vn":
                            normals.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]), float.Parse(words[2])));
                            break;
                        // face
                        case "f":
                            foreach (string w in words)
                            {
                                if (w.Length == 0)
                                    continue;

                                string[] comps = w.Split('/');

                                vertexIndices.Add(uint.Parse(comps[0]) - 1);

                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }
        public void scale()
        {

        }
        public void move()
        {

        }
        public void updateBox()
        {
            createBoxVertices();

            _vertextBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertextBufferObject);
            //parameter 2 yg kita panggil vertices.Count == array.length
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                vertices.Count * Vector3.SizeInBytes,
                vertices.ToArray(),
                BufferUsageHint.StaticDraw);
            //inisialisasi array
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            //inisialisasi index vertex
            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            //parameter 2 dan 3 perlu dirubah
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                vertexIndices.Count * sizeof(uint),
                vertexIndices.ToArray(), BufferUsageHint.StaticDraw);
            _shader.Use();

        }
        //kalok kotak pake ini
        public void render(PrimitiveType? type = null)
        {
            _type = PrimitiveType.Lines;
            _shader.Use();
            _shader.SetMatrix4("transform", _transform);
            //_shader.SetMatrix4("transform", _transform);
            GL.BindVertexArray(_vertexArrayObject);
            //perlu diganti di parameter 2
            GL.DrawElements(PrimitiveType.Triangles,
                vertexIndices.Count,
                DrawElementsType.UnsignedInt, 0);

        }
        //kalok bukan kotak dkk pake ini
        public void renderBezier()
        {
            _type = PrimitiveType.Lines;
            _shader.Use();
            _shader.SetMatrix4("transform", _transform);

            GL.BindVertexArray(_vertexArrayObject);
            GL.Enable(EnableCap.LineSmooth);
            GL.DrawArrays(PrimitiveType.Lines, 0, vertices.Count);
        }
        public void createBoxVertices()
        {
            //biar lebih fleksibel jangan inisialiasi posisi dan 
            //panjang kotak didalam tapi ditaruh ke parameter
            float _positionX = _position.X;
            float _positionY = _position.Y;
            float _positionZ = _position.Z;
            vertices.Clear();

            Vector3 _boxLength = sizeBox;

            //Buat temporary vector
            Vector3 temp_vector;
            vertices.Clear();
            //1. Inisialisasi vertex
            // Titik 1
            temp_vector.X = _positionX - _boxLength.X / 2.0f; // x 
            temp_vector.Y = _positionY + _boxLength.Y / 2.0f; // y
            temp_vector.Z = _positionZ - _boxLength.Z / 2.0f; // z

            vertices.Add(temp_vector);

            // Titik 2
            temp_vector.X = _positionX + _boxLength.X / 2.0f; // x
            temp_vector.Y = _positionY + _boxLength.Y / 2.0f; // y
            temp_vector.Z = _positionZ - _boxLength.Z / 2.0f; // z

            vertices.Add(temp_vector);
            // Titik 3
            temp_vector.X = _positionX - _boxLength.X / 2.0f; // x
            temp_vector.Y = _positionY - _boxLength.Y / 2.0f; // y
            temp_vector.Z = _positionZ - _boxLength.Z / 2.0f; // z
            vertices.Add(temp_vector);

            // Titik 4
            temp_vector.X = _positionX + _boxLength.X / 2.0f; // x
            temp_vector.Y = _positionY - _boxLength.Y / 2.0f; // y
            temp_vector.Z = _positionZ - _boxLength.Z / 2.0f; // z

            vertices.Add(temp_vector);

            // Titik 5
            temp_vector.X = _positionX - _boxLength.X / 2.0f; // x
            temp_vector.Y = _positionY + _boxLength.Y / 2.0f; // y
            temp_vector.Z = _positionZ + _boxLength.Z / 2.0f; // z

            vertices.Add(temp_vector);

            // Titik 6
            temp_vector.X = _positionX + _boxLength.X / 2.0f; // x
            temp_vector.Y = _positionY + _boxLength.Y / 2.0f; // y
            temp_vector.Z = _positionZ + _boxLength.Z / 2.0f; // z

            vertices.Add(temp_vector);

            // Titik 7
            temp_vector.X = _positionX - _boxLength.X / 2.0f; // x
            temp_vector.Y = _positionY - _boxLength.Y / 2.0f; // y
            temp_vector.Z = _positionZ + _boxLength.Z / 2.0f; // z

            vertices.Add(temp_vector);

            // Titik 8
            temp_vector.X = _positionX + _boxLength.X / 2.0f; // x
            temp_vector.Y = _positionY - _boxLength.Y / 2.0f; // y
            temp_vector.Z = _positionZ + _boxLength.Z / 2.0f; // z

            vertices.Add(temp_vector);
            //2. Inisialisasi index vertex
            vertexIndices = new List<uint> {
                // Segitiga Depan 1
                0, 1, 2,
                // Segitiga Depan 2
                1, 2, 3,
                // Segitiga Atas 1
                0, 4, 5,
                // Segitiga Atas 2
                0, 1, 5,
                // Segitiga Kanan 1
                1, 3, 5,
                // Segitiga Kanan 2
                3, 5, 7,
                // Segitiga Kiri 1
                0, 2, 4,
                // Segitiga Kiri 2
                2, 4, 6,
                // Segitiga Belakang 1
                4, 5, 6,
                // Segitiga Belakang 2
                5, 6, 7,
                // Segitiga Bawah 1
                2, 3, 6,
                // Segitiga Bawah 2
                3, 6, 7
            };


        }

        public void createBezier(Vector3 cp1, Vector3 cp2, Vector3 pEnd, float intervalT)
        {
            Vector3 p;
            float a1;
            float a2;
            float a3;
            float a4;

            for (float t = 0; t <= 1.0f; t += intervalT)
            {
                a1 = (float)Math.Pow((1 - t), 3);
                a2 = (float)Math.Pow((1 - t), 2) * 3 * t;
                a3 = 3 * t * t * (1 - t);
                a4 = t * t * t;
                p.X = a1 * _position.X + a2 * cp1.X + a3 * cp2.X + a4 * pEnd.X;
                p.Y = a1 * _position.Y + a2 * cp1.Y + a3 * cp2.Y + a4 * pEnd.Y;
                p.Z = a1 * _position.Z + a2 * cp1.Z + a3 * cp2.Z + a4 * pEnd.Z;
                vertices.Add(p);
            }
            Console.WriteLine("antenna vertices : ");
            vertices.ForEach(item =>
            {
                Console.WriteLine(item);
            });
        }
        public void setPositionBezier(Vector3 p)
        {
            _position = new Vector3(p.X - 0.0f, p.Y, p.Z);
        }
        public void setupBezier()
        {
            _vertextBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertextBufferObject);
            //parameter 2 yg kita panggil vertices.Count == array.length
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                vertices.Count * Vector3.SizeInBytes,
                vertices.ToArray(),
                BufferUsageHint.StaticDraw);
            //inisialisasi array
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            _shader.Use();
        }
        public void setupMesh()
        {

        }
    }
}
