using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace sem2
{
    internal class MyCubes : Figure
    { 
        public Texture texture = new Texture();

        public MyCubes(float x, float y, float z, float size, OpenGL gl, double[] color, bool[] displaySides) : base(x, y, z, size, gl, color, displaySides)
        {
            texture.Create(gl, "bmw_e46.png");

        }

        public override void drawFigure(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_TEXTURE_2D);

            texture.Bind(gl);
            
            gl.PushMatrix();
            gl.Translate(x, y, z);
            gl.Color(color[0], color[1], color[2]);



            // Front
            if (displaySides[0])
            {
                gl.Begin(OpenGL.GL_QUADS);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(-size, -size, size);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(size, -size, size);
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(size, size, size);
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(-size, size, size);
                gl.End();
            }
            if (displaySides[1])
            {
                // Back
                gl.Begin(OpenGL.GL_QUADS);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(-size, -size, -size);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(size, -size, -size);
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(size, size, -size);
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(-size, size, -size);
                gl.End();
            }
            if (displaySides[2])
            {
                // Left
                gl.Begin(OpenGL.GL_QUADS);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(-size, -size, -size);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(-size, -size, size);
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(-size, size, size);
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(-size, size, -size);
                gl.End();
            }
            // Right
            if (displaySides[3])
            {
                gl.Begin(OpenGL.GL_QUADS);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(size, -size, -size);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(size, -size, size);
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(size, size, size);
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(size, size, -size);
                gl.End();
            }
            // Top
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-size, size, size);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(size, size, size);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(size, size, -size);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-size, size, -size);
            gl.End();

            // Bottom
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-size, -size, size);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(size, -size, size);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(size, -size, -size);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-size, -size, -size);
            gl.End();

            gl.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            gl.PopMatrix();
        }

      


    }
}
