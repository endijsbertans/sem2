using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2
{
    internal class MyHexagon : Figure
    {
        public Texture texture = new Texture();

        public MyHexagon(float x, float y, float z, float size, OpenGL gl, double[] color , bool[] displaySides) : base(x, y, z, size, gl,color, displaySides)
        {
            texture.Create(gl, "bmw_e46.png");
        }
        public override void drawFigure(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Bind(gl);
            float[] v1 = { -0.13f, -0.2f };
            float[] v2 = { 0.13f, -0.2f };
            float[] v3 = { 0.2f, 0.0f };
            float[] v4 = { 0.13f, 0.2f };
            float[] v5 = { -0.13f, 0.2f };
            float[] v6 = { -0.2f, 0.0f };
 

            gl.PushMatrix();
            gl.Translate(x, y, z);
            gl.Color(color[0], color[1], color[2]);
            gl.Begin(OpenGL.GL_POLYGON);
                gl.Vertex(v1);
                gl.Vertex(v2);
                gl.Vertex(v3);
                gl.Vertex(v4);
                gl.Vertex(v5);
                gl.Vertex(v6);

            gl.End();
            gl.Translate(0.5f, 0.4f, 0.0f);
            gl.Begin(OpenGL.GL_POLYGON);
                gl.Vertex(v1);
                gl.Vertex(v2);
                gl.Vertex(v3);
                gl.Vertex(v4);
                gl.Vertex(v5);
                gl.Vertex(v6);

            gl.End();
            gl.Translate(0.5f, -0.5f, 0.5f);
            gl.Begin(OpenGL.GL_POLYGON);
                gl.Vertex(v1);
                gl.Vertex(v2);
                gl.Vertex(v3);
                gl.Vertex(v4);
                gl.Vertex(v5);
                gl.Vertex(v6);
            gl.End();

            gl.PopMatrix();

        }


    }
}
