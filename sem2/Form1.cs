using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace sem2
{
    public partial class Form1 : Form
    {
        List<Figure> figureList = new List<Figure>();
        OpenGL gl;
        string selectedFigure = "cube";
        bool enableGravity = false;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            label2.Text = "CUBE";
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {

            //string key = e.KeyData.ToString();

            switch (e.KeyCode)
            {
              
                case Keys.Z:
                    selectedFigure = "cube";
                    label2.Text = "CUBE";
                    break;
                case Keys.X:
                    selectedFigure = "pyramid";
                    label2.Text = "PYRAMID";
                    break;
                case Keys.C:
                    selectedFigure = "hexagon";
                    label2.Text = "HEXAGON";
                    break;
                case Keys.R:
                    randomCubes();
                    break;
                case Keys.D1:
                    for (int i = 0; i < figureList.Count(); ++i)
                    {
                        figureList[i].displaySides[0] = !figureList[i].displaySides[0];
                    }
                     break;
                case Keys.D2:
                    for (int i = 0; i < figureList.Count(); ++i)
                    {
                        figureList[i].displaySides[1] = !figureList[i].displaySides[1];
                    }
                    break;
                case Keys.D3:
                    for (int i = 0; i < figureList.Count(); ++i)
                    {
                        figureList[i].displaySides[2] = !figureList[i].displaySides[2];
                    }
                    break;
                case Keys.D4:
                    for (int i = 0; i < figureList.Count(); ++i)
                    {
                        figureList[i].displaySides[3] = !figureList[i].displaySides[3];
                    }
                    break;
                case Keys.G:
                    
                    enableGravity = !enableGravity;
                    break;
                default:
                     break;
            }

            openGLControl1.Invalidate();
        }
        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LookAt(0,0,0,0,0,0,0,0,0);

            gl.LoadIdentity();


            gl.PushMatrix();
            gl.PopMatrix();
            if (enableGravity) {
                for (int i = 0; i < figureList.Count(); ++i)
                {
                    figureList[i].y = figureList[i].y - 0.1f * 9.8f; // ahj nemaku fiziku :(
                }

            }
            for (int i = 0; i < figureList.Count(); ++i)
            {
                figureList[i].drawFigure(gl);
            }

            openGLControl1.Invalidate();
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            gl = openGLControl1.OpenGL;
        }




        private void randomCubes()
        {
            Random rand = new Random();
            double[] color = new double[3];
            bool[] displaySides = new bool[4];

            for (int i = 0; i < 4; ++i)
                displaySides[i] = true;

            for (int i = 0; i < 3; ++i)
                color[i] = rand.NextDouble();
            float randomX = (float)(rand.Next(-6, 6));
            float randomY = (float)(rand.Next(-4, 4));
            float randomZ = (float)(rand.Next(-40, -10));

            if (selectedFigure == "cube")
            {
               
                figureList.Add(new MyCubes(randomX, randomY, randomZ, 1.0f, gl, color, displaySides));
            }
            if (selectedFigure == "pyramid") {
                figureList.Add(new Pyramid(randomX, randomY, randomZ, 1.0f, gl, color, displaySides));
            }
            if (selectedFigure == "hexagon")
            {
                /// doesnt DRAW
              ///  figureList.Add(new MyHexagon(randomX, randomY, randomZ, 1.0f, gl, color, displaySides));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
