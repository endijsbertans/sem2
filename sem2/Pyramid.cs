using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Drawing.Imaging;

namespace sem2
{
    internal class Pyramid : Figure
    {
        public Texture texture = new Texture();

        public Pyramid(float x, float y, float z, float size, OpenGL gl, double[] color, bool[] displaySides) : base(x, y, z, size, gl,color, displaySides)
        {
            texture.Create(gl, "bmw_e46.png");
        }

        public override void drawFigure(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Bind(gl);
            gl.Color(color[0], color[1], color[2]);
            gl.PushMatrix();
            gl.Translate(x, y, z);

            float halfSize = size / 2.0f;

            float[] v1 = { -halfSize, 0.0f, -halfSize };
            float[] v2 = { halfSize, 0.0f, -halfSize };  
            float[] v3 = { halfSize, 0.0f, halfSize };   
            float[] v4 = { -halfSize, 0.0f, halfSize }; 

            float[] apex = { 0.0f, size, 0.0f };


            gl.Begin(OpenGL.GL_TRIANGLES);
            if (displaySides[0])
            {
                gl.TexCoord(0.5f, 0.0f); gl.Vertex(apex);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(v2);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(v1);
            }
            if (displaySides[1])
            {
                gl.TexCoord(0.5f, 0.0f); gl.Vertex(apex);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(v3);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(v2);
            }
            if (displaySides[2])
            {
                gl.TexCoord(0.5f, 0.0f); gl.Vertex(apex);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(v4);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(v3);
            }
            if (displaySides[3])
            {
                gl.TexCoord(0.5f, 0.0f); gl.Vertex(apex);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(v1);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(v4);
            }
            gl.End();

            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(v1);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(v2);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(v3);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(v4);
            gl.End();

            gl.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            gl.PopMatrix();
        }

       
    }
}
