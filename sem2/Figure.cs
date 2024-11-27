using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2
{
    abstract public class Figure
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public double[] color { get; set; }
        public float size { get; set; }
        public OpenGL gl { get; set; }
        public bool[] displaySides { get; set; }
        public Figure(float x, float y, float z, float size, OpenGL gl, double[] color, bool[] displaySides)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.color = color;
            this.size = size;
            this.gl = gl;
            this.displaySides = displaySides;
        }

        abstract public void drawFigure(OpenGL gl);

    }
}
