using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;
using UTS_PROJECT.Alfons;

namespace UTS_PROJECT
{

    class AlfonsProps
    {
        //ELLIPSOID
        Mesh ellipsoidkepala = new Mesh();
        Mesh[] ellipsoidmata = new Mesh[2];
        Mesh[] ellipsoidbadan = new Mesh[7];
        Mesh[] ellipsoidtangankanan = new Mesh[7];
        Mesh[] ellipsoidtangankiri = new Mesh[7];
        Mesh ellipsoidhidung = new Mesh();
        Mesh ellipsoidbuntutbawah = new Mesh();
        //ELLIPTIC
        Mesh elliptictanduk = new Mesh();
        Mesh ellipticbuntut = new Mesh();
        //HYPERBOLOID
        Mesh hyperboloidskill = new Mesh();
        //BEZIER
        Mesh[] beziersungut = new Mesh[2];

        int counteranimasi = 0;
        float[] animasibadan = new float[8];

        int counterscale = -1;
        float scaleskill = 1.0f;
        float angle = 90f;
        //string path = "C/Users/richa/Documents/Kuliah/Semester 4/GRAFKOM/12maret(2)/asset/testing.obj";
        public AlfonsProps()
        {
            float tempanimasi = 0.0001f;
            for (int i = 0; i < 7; i++)
            {
                if (i < 2)
                {
                    ellipsoidmata[i] = new Mesh();
                    beziersungut[i] = new Mesh();
                }
                ellipsoidbadan[i] = new Mesh();
                ellipsoidtangankanan[i] = new Mesh();
                ellipsoidtangankiri[i] = new Mesh();
                animasibadan[i] = tempanimasi;
                tempanimasi += 0.0005f;
            }
            animasibadan[7] = tempanimasi;
        }
        public void load()
        {
            float posxellipsoid = 0.8f;
            float posyellipsoid = 0.4f;
            float poszellipsoid = 0.0f;
            //ELLIPSOID KEPALA
            float radiuselllipsoid = 0.2f;
            float scalekepala = 0.25f;
            ellipsoidkepala.createellipsoidvertices(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f);
            ellipsoidkepala.transforms();
            ellipsoidkepala.vbo();
            ellipsoidkepala.vao();
            ellipsoidkepala.useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shader.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shader.frag");
            ellipsoidkepala.scale(scalekepala);
            ellipsoidkepala.translate(posxellipsoid, posyellipsoid, poszellipsoid);


            //BEZIER SUNGUT
            int banyaktitik = 5;
            float counterpositionbezier = 0.0f;
            float counterpositionbezier2 = 0.0f;
            Vector3[] position = new Vector3[5];
            //SUNGUT KE 1
            for (int i = 0; i < banyaktitik; i++)
            {
                position[i].X = -counterpositionbezier;
                position[i].Z = counterpositionbezier;
                if (i > (banyaktitik / 2))
                {
                    position[i].Y = counterpositionbezier - counterpositionbezier2;
                    counterpositionbezier2 += 0.1f;
                }
                else
                {
                    position[i].Y = counterpositionbezier;
                }
                counterpositionbezier += 0.05f;
            }
            beziersungut[0].createbezier(position, banyaktitik);
            beziersungut[0].transforms();
            beziersungut[0].vbo();
            beziersungut[0].vao();
            beziersungut[0].useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadersungut.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadersungut.frag");
            beziersungut[0].translate(posxellipsoid - 0.15f, posyellipsoid + 0.17f, poszellipsoid + 0.1f);
            //SUNGUT KE 2
            for (int i = 0; i < banyaktitik; i++)
            {
                position[i].Z *= -1.0f;
            }
            beziersungut[1].createbezier(position, banyaktitik);
            beziersungut[1].transforms();
            beziersungut[1].vbo();
            beziersungut[1].vao();
            beziersungut[1].useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadersungut.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadersungut.frag");
            beziersungut[1].translate(posxellipsoid - 0.15f, posyellipsoid + 0.17f, poszellipsoid - 0.1f);


            //SKILL
            hyperboloidskill.createhyperboloidvertices(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f);
            hyperboloidskill.transforms();
            hyperboloidskill.vbo();
            hyperboloidskill.vao();
            hyperboloidskill.useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shaderskill.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shaderskill.frag");
            hyperboloidskill.rotate(90f, 'y');
            hyperboloidskill.rotate(30f, 'z');
            hyperboloidskill.scale(0.05f);
            hyperboloidskill.translate(posxellipsoid - 0.31f, posyellipsoid - 0.05f, poszellipsoid);


            //ELLIPSOID MATA
            //MATA KE 1
            float radiusmata = 0.025f;
            ellipsoidmata[0].createellipsoidvertices(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f);
            ellipsoidmata[0].transforms();
            ellipsoidmata[0].vbo();
            ellipsoidmata[0].vao();
            ellipsoidmata[0].useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadermata.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadermata.frag");
            ellipsoidmata[0].scale(radiusmata);
            ellipsoidmata[0].translate(posxellipsoid - 0.2f, posyellipsoid + 0.05f, poszellipsoid + 0.16f);
            //MATA KE 2
            ellipsoidmata[1].createellipsoidvertices(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f);
            ellipsoidmata[1].transforms();
            ellipsoidmata[1].vbo();
            ellipsoidmata[1].vao();
            ellipsoidmata[1].useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadermata.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadermata.frag");
            ellipsoidmata[1].scale(radiusmata);
            ellipsoidmata[1].translate(posxellipsoid - 0.2f, posyellipsoid + 0.05f, poszellipsoid - 0.16f);


            //ELLIPSOID BADAN DAN TANGAN
            float x = 0.05f;
            float x2 = 0.2f;
            float x3 = 0.05f;
            float y2 = 0.05f;
            float radiustangan = 0.03f;
            float tambahantangan = 0.0f;
            for (int i = 0; i < 7; i++)
            {
                float posxbaru = posxellipsoid + x * x2 - x3;
                float posybaru = posyellipsoid - x * 6.0f + y2;
                if (i == 6)
                {
                    ellipsoidbadan[i].createellipsoidvertices(posxbaru * 0.8f, posybaru, poszellipsoid, radiuselllipsoid - x / 4, radiuselllipsoid - x / 4, radiuselllipsoid - x / 4);
                    ellipsoidtangankanan[i].createellipsoidvertices(posxbaru * 0.8f, posybaru - 0.06f, poszellipsoid + 0.1f, radiustangan, radiustangan, radiustangan);
                    ellipsoidtangankiri[i].createellipsoidvertices(posxbaru * 0.8f, posybaru - 0.06f, poszellipsoid - 0.1f, radiustangan, radiustangan, radiustangan);
                }
                else
                {
                    ellipsoidbadan[i].createellipsoidvertices(posxbaru, posybaru, poszellipsoid, radiuselllipsoid - x / 4, radiuselllipsoid - x / 4, radiuselllipsoid - x / 4);
                    ellipsoidtangankanan[i].createellipsoidvertices(posxbaru - 0.15f + tambahantangan, posybaru - tambahantangan, poszellipsoid + 0.1f, radiustangan, radiustangan, radiustangan);
                    ellipsoidtangankiri[i].createellipsoidvertices(posxbaru - 0.15f + tambahantangan, posybaru - tambahantangan, poszellipsoid - 0.1f, radiustangan, radiustangan, radiustangan);
                }
                tambahantangan += 0.02f;
                x += 0.05f;
                x2 += 0.5f;
                x3 += 0.075f;
                y2 += y2 / 1.5f;
                ellipsoidbadan[i].transforms();
                ellipsoidbadan[i].vbo();
                ellipsoidbadan[i].vao();
                ellipsoidbadan[i].useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shader.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shader.frag");

                ellipsoidtangankanan[i].transforms();
                ellipsoidtangankanan[i].vbo();
                ellipsoidtangankanan[i].vao();
                ellipsoidtangankanan[i].useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shaderhidung.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shaderhidung.frag");

                ellipsoidtangankiri[i].transforms();
                ellipsoidtangankiri[i].vbo();
                ellipsoidtangankiri[i].vao();
                ellipsoidtangankiri[i].useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shaderhidung.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shaderhidung.frag");
            }


            //ELLIPSOID HIDUNG
            ellipsoidhidung.createellipsoidvertices(0.0f, 0.0f, 0.0f, 0.06f, 0.075f, 0.13f);
            ellipsoidhidung.transforms();
            ellipsoidhidung.vbo();
            ellipsoidhidung.vao();
            ellipsoidhidung.useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shaderhidung.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shaderhidung.frag");
            ellipsoidhidung.translate(posxellipsoid - 0.25f, posyellipsoid - 0.05f, poszellipsoid);


            //ELLIPTIC TANDUK
            elliptictanduk.createellipticvertices(0.0f, 0.0f, 0.0f, 0.05f, 0.05f, 0.15f);
            elliptictanduk.transforms();
            elliptictanduk.vbo();
            elliptictanduk.vao();
            elliptictanduk.useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadertanduk.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadertanduk.frag");
            elliptictanduk.rotate(270f, 'x');
            elliptictanduk.translate(posxellipsoid, posyellipsoid + 0.47f, poszellipsoid);
            //elliptictanduk.translate(0.0f, 0.87f, 0.0f);


            //ELLIPTIC BUNTUT ATAS
            ellipticbuntut.createellipticvertices(0.0f, 0.0f, 0.0f, 0.05f, 0.05f, 0.2f);
            ellipticbuntut.transforms();
            ellipticbuntut.vbo();
            ellipticbuntut.vao();
            ellipticbuntut.useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadertanduk.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadertanduk.frag");
            ellipticbuntut.rotate(270f, 'x');
            ellipticbuntut.rotate(-30f, 'z');
            ellipticbuntut.translate(posxellipsoid + 0.76f, posyellipsoid - 0.62f, poszellipsoid);


            //ELLIPSOID SETENGAH LINGKARAN BUNTUT BAWAH
            ellipsoidbuntutbawah.createellipsoidsetengahvertices(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f);
            ellipsoidbuntutbawah.transforms();
            ellipsoidbuntutbawah.vbo();
            ellipsoidbuntutbawah.vao();
            ellipsoidbuntutbawah.useshaders(@"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadertanduk.vert", @"C:\Users\c1419\source\repos\UTS_PROJECT\UTS_PROJECT\Alfons\shader\shadertanduk.frag");
            ellipsoidbuntutbawah.rotate(-30f, 'z');
            ellipsoidbuntutbawah.scale(0.08f);
            ellipsoidbuntutbawah.translate(posxellipsoid + 0.6f, posyellipsoid - 0.9f, poszellipsoid);


        }

        public void render()
        {

            counteranimasi++;
            counterscale++;

            //KEPALA
            //ellipsoidkepala.sumbux();
            ellipsoidkepala.sumbuy();
            //ellipsoidkepala.sumbuz();
            ellipsoidkepala.drawlines();
            ellipsoidkepala.translate(animasibadan[0], 0.0f, animasibadan[0]);
            //SUNGUT
            //beziersungut[0].sumbux();
            beziersungut[0].sumbuy();
            //beziersungut[0].sumbuz();
            beziersungut[0].drawlines();
            beziersungut[0].translate(animasibadan[0], 0.0f, animasibadan[0]);
            //beziersungut[1].sumbux();
            beziersungut[1].sumbuy();
            //beziersungut[1].sumbuz();
            beziersungut[1].drawlines();
            beziersungut[1].translate(animasibadan[0], 0.0f, animasibadan[0]);
            //MATA
            //ellipsoidmata[0].sumbux();
            ellipsoidmata[0].sumbuy();
            //ellipsoidmata[0].sumbuz();
            ellipsoidmata[0].drawlines();
            ellipsoidmata[0].translate(animasibadan[0], 0.0f, animasibadan[0]);
            //ellipsoidmata[1].sumbux();
            ellipsoidmata[1].sumbuy();
            //ellipsoidmata[1].sumbuz();
            ellipsoidmata[1].drawlines();
            ellipsoidmata[1].translate(animasibadan[0], 0.0f, animasibadan[0]);
            //HIDUNG
            //ellipsoidhidung.sumbux();
            ellipsoidhidung.sumbuy();
            //ellipsoidhidung.sumbuz();
            ellipsoidhidung.drawlines();
            ellipsoidhidung.translate(animasibadan[0], 0.0f, animasibadan[0]);
            //TANDUK
            //elliptictanduk.sumbux();
            elliptictanduk.sumbuy();
            //elliptictanduk.sumbuz();
            elliptictanduk.drawlines();
            elliptictanduk.translate(animasibadan[0], 0.0f, animasibadan[0]);
            //BADAN
            for (int i = 0; i < 7; i++)
            {
                //ellipsoidbadan[i].sumbux();
                ellipsoidbadan[i].sumbuy();
                //ellipsoidbadan[i].sumbuz();
                //ellipsoidtangankanan[i].sumbux();
                ellipsoidtangankanan[i].sumbuy();
                //ellipsoidtangankanan[i].sumbuz();
                //ellipsoidtangankiri[i].sumbux();
                ellipsoidtangankiri[i].sumbuy();
                //ellipsoidtangankiri[i].sumbuz();
                if (counteranimasi % 50 == 0)
                {
                    counteranimasi %= 50;
                    for (int j = 0; j < 8; j++)
                    {
                        animasibadan[j] *= -1.0f;
                    }
                }
                ellipsoidbadan[i].translate(animasibadan[i + 1], 0.0f, animasibadan[i + 1]);
                ellipsoidtangankanan[i].translate(animasibadan[i + 1], 0.0f, animasibadan[i + 1]);
                ellipsoidtangankiri[i].translate(animasibadan[i + 1], 0.0f, animasibadan[i + 1]);
                ellipsoidbadan[i].drawlinestrip();
                ellipsoidtangankanan[i].drawlines();
                ellipsoidtangankiri[i].drawlines();

            }
            //BUNTUT
            //ellipticbuntut.sumbux();
            ellipticbuntut.sumbuy();
            //ellipticbuntut.sumbuz();
            ellipticbuntut.drawlines();
            ellipticbuntut.translate(animasibadan[7], 0.0f, animasibadan[7]);
            //ellipsoidbuntutbawah.sumbux();
            ellipsoidbuntutbawah.sumbuy();
            //ellipsoidbuntutbawah.sumbuz();
            ellipsoidbuntutbawah.drawlines();
            ellipsoidbuntutbawah.translate(animasibadan[7], 0.0f, animasibadan[7]);
            //SKILL

            if (counterscale < 10)
            {
                scaleskill += 0.0005f;
            }
            else if (counterscale == 10)
            {
                scaleskill = 1.0f;
            }
            else if (counterscale < 21)
            {
                scaleskill -= 0.0005f;
            }
            else
            {
                counterscale = -1;
                scaleskill = 1.0f;
            }
            //hyperboloidskill.sumbux();
            hyperboloidskill.sumbuy();
            //hyperboloidskill.sumbuz();
            hyperboloidskill.scale(scaleskill);
            hyperboloidskill.drawlines();


        }
       
    }
}
