using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using static Tao.OpenGl.Glu;

namespace Khlyzova_Valeria_PRI_117_lab_16
{ 
    public partial class Form1 : Form
    {
        unsafe GLUnurbs theNurb;

        string figure = "tor";
        string mode = "figure";
        static float[,,] ctrlpoints = {
            {{-1.5f, -1.5f, 4.0f}, {-0.5f, -1.5f, 2.0f},
            {0.5f, -1.5f, -1.0f}, {1.5f, -1.5f, 2.0f}},
            {{-1.5f, -0.5f, 1.0f}, {-0.5f, -0.5f, 3.0f},
            {0.5f, -0.5f, 0.0f}, {1.5f, -0.5f, -1.0f}},
            {{-1.5f, 0.5f, 4.0f}, {-0.5f, 0.5f, 0.0f},
            {0.5f, 0.5f, 3.0f}, {1.5f, 0.5f, 4.0f}},
            {{-1.5f, 1.5f, -2.0f}, {-0.5f, 1.5f, -2.0f},
            {0.5f, 1.5f, 0.0f}, {1.5f, 1.5f, -1.0f}}
        };

        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Gl.glClearColor(0, 0, 0, 1);

            Gl.glViewport(0, 0, simpleOpenGlControl.Width, simpleOpenGlControl.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)simpleOpenGlControl.Width / (float)simpleOpenGlControl.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            RenderTimer.Start();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);

            Gl.glLoadIdentity();

            Gl.glTranslated(0, 0, -17);
            Gl.glRotated(trackBar1.Value, 0, 1, 0);

            if (mode == "figure") Draw(); 
            else DrawSpline();

            Gl.glPopMatrix();
            Gl.glFlush();
            simpleOpenGlControl.Invalidate();
        }

        private void DrawSpline()
        {
            if (radioButton1.Checked)
            {
                // поверхности Безье
                Gl.glMap2f(Gl.GL_MAP2_VERTEX_3, 0, 1, 3, 4, 0, 1, 12, 4, ref ctrlpoints[0, 0, 0]);
                Gl.glEnable(Gl.GL_MAP2_VERTEX_3);

                int i, j;

                Gl.glPushMatrix();
                for (j = 0; j <= 20; j++)
                {
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    for (i = 0; i <= 50; i++)
                        Gl.glEvalCoord2f((float)i / 50.0f, (float)j / 20.0f);
                    Gl.glEnd();
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    for (i = 0; i <= 50; i++)
                        Gl.glEvalCoord2f((float)j / 20.0f, (float)i / 50.0f);
                    Gl.glEnd();
                }
                Gl.glPopMatrix();
                Gl.glFlush();
            }

            //  би-сплайновая поверхность (с обрезкой поверхностей)
            if (radioButton2.Checked)
            {
                float[] mat_diffuse = { 0.6f, 0.6f, 0.6f, 1.0f };
                float[] mat_specular = { 0.9f, 0.9f, 0.9f, 1.0f };
                float[] mat_shininess = { 128.0f };

                theNurb = gluNewNurbsRenderer();
          
                float[] knots = { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f };
                float[,] edgePt = { { 0.0f, 0.0f}, { 1.0f, 0.0f}, { 1.0f, 1.0f}, { 0.0f, 1.0f}, { 0.0f, 0.0f}};
                float[,] curvePt = { { 0.25f, 0.5f}, { 0.25f, 0.75f}, { 0.75f, 0.75f}, { 0.75f, 0.5f} };
                float[] curveKnots = {0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f };
                float[,] pwlPt = { { 0.75f, 0.5f }, { 0.5f, 0.25f}, { 0.25f, 0.5f } };

                gluBeginSurface(theNurb);
                gluNurbsSurface(theNurb, 8, knots, 8, knots, 12, 3, ctrlpoints, 4, 4, Gl.GL_MAP2_VERTEX_3);
                gluBeginTrim(theNurb);
                gluPwlCurve(theNurb, 5, edgePt, 2, GLU_MAP1_TRIM_2);
                gluEndTrim(theNurb);
                gluBeginTrim(theNurb);
                gluNurbsCurve(theNurb, 8, curveKnots, 2,curvePt, 4, GLU_MAP1_TRIM_2);
                gluPwlCurve(theNurb, 3, pwlPt, 2, GLU_MAP1_TRIM_2);
                gluEndTrim(theNurb);
                gluEndSurface(theNurb);
            }
        }

        private void Draw()
        {
            if (checkBox1.Checked)
            {
                // отрисовка поверхностей с использованием функций GLUT
                switch (figure)
                {
                    case "tor": Glut.glutWireTorus(0.5, 4, 20, 50); break;
                    case "superellipsoid": Glut.glutWireSphere(5, 32, 32);  break;
                }
            }
            else
            {
                int numc = 20, numt = 50;
                double Angle;

                // отрисовка поверхностей на основе их уравнений
                switch (figure)
                {
                    case "tor":
                        Angle = 2 * Math.PI;

                        Gl.glBegin(Gl.GL_LINE_STRIP);
                        for (int i = 0; i < numc; i++)
                        {
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            for (int j = 0; j <= numt; j++)
                            {
                                for (int k = 1; k >= 0; k--)
                                {

                                    double s = (i + k) % numc + 0.5;
                                    double t = j % numt;

                                    double x = (1 + 0.1 * Math.Cos(s * Angle / numc)) * Math.Cos(t * Angle / numt);
                                    double y = (1 + 0.1 * Math.Cos(s * Angle / numc)) * Math.Sin(t * Angle / numt);
                                    double z = 1 * Math.Sin(s * Angle / numc);

                                    Gl.glVertex3d(4 * x, 4 * y, 0.5 * z);
                                }
                            }
                            Gl.glEnd();
                        }
                        Gl.glEnd();

                        break;
                    case "superellipsoid":
                        double x1, y1, z1;      
                        Angle = Math.PI;

                        for (double a = 0; a < Angle; a += Angle / numc)
                        {
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            for (double b = 0; b < 2.01 * Angle; b += Angle / numc)
                            {
                                x1 = 5 * Math.Cos(b) * Math.Sin(a);
                                y1 = 5 * Math.Sin(b) * Math.Sin(a);
                                z1 = 5 * Math.Cos(a);
                                Gl.glVertex3f((float)x1, (float)y1, (float)z1);

                                x1 = 5 * Math.Cos(b) * Math.Sin(a + Angle / numc);
                                y1 = 5 * Math.Sin(b) * Math.Sin(a + Angle / numc);
                                z1 = 5 * Math.Cos(a + Angle / numc);
                                Gl.glVertex3f((float)x1, (float)y1, (float)z1);
                            }
                            Gl.glEnd();
                        }
                        break;
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mode = "figure";
            figure = "superellipsoid";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode = "figure";
            figure = "tor";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mode = "spline";
        }
    }
}
