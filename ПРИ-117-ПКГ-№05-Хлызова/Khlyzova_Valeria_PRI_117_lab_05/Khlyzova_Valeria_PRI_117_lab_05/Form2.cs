﻿using System;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace Khlyzova_Valeria_PRI_117_lab_05
{
    public partial class Form2 : Form
    {
        double ScreenW, ScreenH;
        private float devX;
        private float devY;
        private float[,] GrapValuesArray;
        private int elements_count = 0;
        private bool not_calculate = true;
        private int pointPosition = 0;
        float lineX, lineY;
        float Mcoord_X = 0, Mcoord_Y = 0;

        public Form2()
        {
            InitializeComponent();
            AnT.InitializeContexts();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            if ((float)AnT.Width <= (float)AnT.Height)
            {
                ScreenW = 30.0;
                ScreenH = 30.0 * (float)AnT.Height / (float)AnT.Width;

                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            }
            else
            {
                ScreenW = 30.0 * (float)AnT.Width / (float)AnT.Height;
                ScreenH = 30.0;

                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);
            }

            devX = (float)ScreenW / (float)AnT.Width;
            devY = (float)ScreenH / (float)AnT.Height;

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            PointInGrap.Start();
        } 

        private void PointInGrap_Tick(object sender, EventArgs e)
        {
            if (pointPosition == elements_count - 1) pointPosition = 0;

            Draw();
            pointPosition++;
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            Mcoord_X = e.X;
            Mcoord_Y = e.Y;

            lineX = devX * e.X;
            lineY = (float)(ScreenH - devY * e.Y);
        }


        private void PrintText2D(float x, float y, string text)
        {
            Gl.glRasterPos2f(x, y);
            foreach (char char_for_draw in text)
            {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_9_BY_15, char_for_draw);
            }
        }


        private void functionCalculation()
        {

            float x = 0, y = 0;
            float a = -5, b = 5, n = 40;

            GrapValuesArray = new float[300, 2];

            elements_count = 0;
            for (x = a; x < b; x += (b - a)/n)
            {
                // 7 * x / (3 * x ^ 2 + 2 * x + 1)
                y = (float) 7 * x / (3 * (float)Math.Pow(x, 2) + 2 * x + 1);
                GrapValuesArray[elements_count, 0] = x;
                GrapValuesArray[elements_count, 1] = y;
                elements_count++;
            }
            not_calculate = false;
        }


        private void DrawDiagram()
        {
            if (not_calculate)
            {
                functionCalculation();
            }

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(GrapValuesArray[0, 0], GrapValuesArray[0, 1]);
            for (int ax = 1; ax < elements_count; ax += 2)
            {
                Gl.glVertex2d(GrapValuesArray[ax, 0], GrapValuesArray[ax, 1]);
            }


            Gl.glEnd();
            Gl.glPointSize(5);
            Gl.glColor3f(255, 0, 0);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2d(GrapValuesArray[pointPosition, 0], GrapValuesArray[pointPosition, 1]);
            Gl.glEnd();
            Gl.glPointSize(1);
        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(0, 0, 0);
            Gl.glPushMatrix();

            Gl.glTranslated(15, 15, 0);
            Gl.glBegin(Gl.GL_POINTS);

            for (int ax = -15; ax < 15; ax++)
            {
                for (int bx = -15; bx < 15; bx++)
                {
                    Gl.glVertex2d(ax, bx);
                }
            }

            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(0, -15);
            Gl.glVertex2d(0, 15);

            Gl.glVertex2d(-15, 0);
            Gl.glVertex2d(15, 0);

            Gl.glVertex2d(0, 15);
            Gl.glVertex2d(0.1, 14.5);
            Gl.glVertex2d(0, 15);
            Gl.glVertex2d(-0.1, 14.5);

            Gl.glVertex2d(15, 0);
            Gl.glVertex2d(14.5, 0.1);
            Gl.glVertex2d(15, 0);
            Gl.glVertex2d(14.5, -0.1);

            Gl.glEnd();

            PrintText2D(15.5f, 0, "x");
            PrintText2D(0.5f, 14.5f, "y");

            DrawDiagram();
            Gl.glPopMatrix();
            PrintText2D(devX * Mcoord_X + 0.2f, (float)ScreenH - devY * Mcoord_Y + 0.4f, "[ x: " + (devX * Mcoord_X - 15).ToString() + " ; y: " + ((float)ScreenH - devY * Mcoord_Y - 15).ToString() + "]");
           
            Gl.glFlush();

            AnT.Invalidate();
        }

    }
}
